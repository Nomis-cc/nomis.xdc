// ------------------------------------------------------------------------------------------------------
// <copyright file="ExtensionMethods.cs" company="Nomis">
// Copyright (c) Nomis, 2023. All rights reserved.
// The Application under the MIT license. See LICENSE file in the solution root for full license information.
// </copyright>
// ------------------------------------------------------------------------------------------------------

using Nomis.SoulboundTokenService.Interfaces.Models;
using Nomis.Utils.Contracts.Requests;
using Nomis.Utils.Enums;
using Nomis.Utils.Wrapper;

namespace Nomis.SoulboundTokenService.Interfaces.Extensions
{
    /// <summary>
    /// Extension methods.
    /// </summary>
    public static class ExtensionMethods
    {
        /// <summary>
        /// Get the signed data signature.
        /// </summary>
        /// <typeparam name="TWalletRequest">The wallet request type.</typeparam>
        /// <param name="service"><see cref="IEvmSoulboundTokenService"/>.</param>
        /// <param name="request"><see cref="WalletStatsRequest"/>.</param>
        /// <param name="mintedScore">The wallet minted score.</param>
        /// <param name="chainId">Blockchain id.</param>
        /// <param name="contractAddresses">The contract addresses.</param>
        /// <param name="criteria">Criteria to get signature.</param>
        /// <returns>Returns the signed data signature.</returns>
        public static async Task<Result<SoulboundTokenSignature>> SignatureAsync<TWalletRequest>(
            this IEvmSoulboundTokenService service,
            TWalletRequest request,
            ushort mintedScore,
            ulong chainId,
            IDictionary<ScoreType, string>? contractAddresses,
            params bool?[] criteria)
            where TWalletRequest : WalletStatsRequest
        {
            var signatureResult = await Result<SoulboundTokenSignature>.FailAsync(
                new SoulboundTokenSignature
                {
                    Signature = null
                }, "Get token signature: Can't get signature without Risk adjusting score.").ConfigureAwait(false);
            if (!criteria.Any() || criteria.All(c => c == true))
            {
                signatureResult = service.GetSoulboundTokenSignature(new()
                {
                    Score = mintedScore,
                    ScoreType = request.ScoreType,
                    To = request.Address,
                    Nonce = request.Nonce,
                    ChainId = chainId,
                    ContractAddress = contractAddresses?.ContainsKey(request.ScoreType) == true ? contractAddresses[request.ScoreType] : null,
                    Deadline = request.Deadline
                });
            }

            return signatureResult;
        }
    }
}