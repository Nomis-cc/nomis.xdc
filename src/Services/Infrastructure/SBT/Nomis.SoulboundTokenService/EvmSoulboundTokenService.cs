// ------------------------------------------------------------------------------------------------------
// <copyright file="EvmSoulboundTokenService.cs" company="Nomis">
// Copyright (c) Nomis, 2023. All rights reserved.
// The Application under the MIT license. See LICENSE file in the solution root for full license information.
// </copyright>
// ------------------------------------------------------------------------------------------------------

using System.Numerics;

using Microsoft.Extensions.Options;
using Nethereum.ABI.EIP712;
using Nethereum.Signer;
using Nethereum.Signer.EIP712;
using Nomis.SoulboundTokenService.Interfaces;
using Nomis.SoulboundTokenService.Interfaces.Models;
using Nomis.SoulboundTokenService.Interfaces.Requests;
using Nomis.SoulboundTokenService.Models;
using Nomis.SoulboundTokenService.Settings;
using Nomis.Utils.Contracts.Services;
using Nomis.Utils.Enums;
using Nomis.Utils.Wrapper;

namespace Nomis.SoulboundTokenService
{
    /// <inheritdoc cref="IEvmSoulboundTokenService"/>
    internal sealed class EvmSoulboundTokenService :
        IEvmSoulboundTokenService,
        ITransientService
    {
        private readonly SoulboundTokenSettings _settings;

        /// <summary>
        /// Initialize <see cref="EvmSoulboundTokenService"/>.
        /// </summary>
        /// <param name="settings"><see cref="SoulboundTokenSettings"/>.</param>
        public EvmSoulboundTokenService(
            IOptions<SoulboundTokenSettings> settings)
        {
            _settings = settings.Value;
        }

        /// <inheritdoc />
        public Result<SoulboundTokenSignature> GetSoulboundTokenSignature(
            SoulboundTokenRequest request)
        {
            if (string.IsNullOrWhiteSpace(request.ContractAddress))
            {
                return Result<SoulboundTokenSignature>.Fail(new() { Signature = null }, "Get token signature: Contract address should be set.");
            }

            if (string.IsNullOrWhiteSpace(request.To))
            {
                return Result<SoulboundTokenSignature>.Fail(new() { Signature = null }, "Get token signature: Wallet address should be set.");
            }

            if (string.IsNullOrWhiteSpace(_settings.EvmWalletPrivateKey))
            {
                return Result<SoulboundTokenSignature>.Fail(new() { Signature = null }, "Get token signature: Signer-wallet private key is not set.");
            }

            var signer = new Eip712TypedDataSigner();
            var typedData = GetScoreTypedDefinition(request.ScoreType, request.ChainId, request.ContractAddress);
            var key = new EthECKey(_settings.EvmWalletPrivateKey);

            var score = new SetScoreMessage
            {
                Deadline = request.Deadline,
                Nonce = request.Nonce,
                Score = request.Score,
                To = request.To
            };

            string? signature = signer.SignTypedDataV4(score, typedData, key);

            return Result<SoulboundTokenSignature>.Success(new() { Signature = signature }, "Got soulbound token signature.");
        }

        private TypedData<Domain> GetScoreTypedDefinition(
            ScoreType scoreType,
            ulong chainId,
            string? contractAddress)
        {
            return new()
            {
                Domain = new()
                {
                    Name = _settings.TokenData[scoreType].TokenName,
                    Version = _settings.TokenData[scoreType].Version,
                    ChainId = new BigInteger(chainId),
                    VerifyingContract = contractAddress
                },
                Types = MemberDescriptionFactory.GetTypesMemberDescription(typeof(Domain), typeof(SetScoreMessage)),
                PrimaryType = nameof(SetScoreMessage)
            };
        }
    }
}