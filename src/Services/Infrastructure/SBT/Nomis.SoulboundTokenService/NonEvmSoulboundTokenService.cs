// ------------------------------------------------------------------------------------------------------
// <copyright file="NonEvmSoulboundTokenService.cs" company="Nomis">
// Copyright (c) Nomis, 2023. All rights reserved.
// The Application under the MIT license. See LICENSE file in the solution root for full license information.
// </copyright>
// ------------------------------------------------------------------------------------------------------

using Microsoft.Extensions.Options;
using Nomis.SoulboundTokenService.Interfaces;
using Nomis.SoulboundTokenService.Interfaces.Models;
using Nomis.SoulboundTokenService.Interfaces.Requests;
using Nomis.SoulboundTokenService.Settings;
using Nomis.Utils.Contracts.Services;
using Nomis.Utils.Wrapper;

namespace Nomis.SoulboundTokenService
{
    /// <inheritdoc cref="INonEvmSoulboundTokenService"/>
    internal sealed class NonEvmSoulboundTokenService :
        INonEvmSoulboundTokenService,
        ITransientService
    {
        private readonly SoulboundTokenSettings _settings;

        /// <summary>
        /// Initialize <see cref="NonEvmSoulboundTokenService"/>.
        /// </summary>
        /// <param name="settings"><see cref="SoulboundTokenSettings"/>.</param>
        public NonEvmSoulboundTokenService(
            IOptions<SoulboundTokenSettings> settings)
        {
            _settings = settings.Value;
        }

        /// <inheritdoc />
        public Result<SoulboundTokenSignature> GetSoulboundTokenSignature(
            SoulboundTokenRequest request)
        {
            // TODO - add implementation for all non EVM-compatible blockchains
            return Result<SoulboundTokenSignature>.Fail(new() { Signature = null }, "Get token signature: Verifying the contract signature for non EVM-compatible blockchains is not implemented yet.");
        }
    }
}