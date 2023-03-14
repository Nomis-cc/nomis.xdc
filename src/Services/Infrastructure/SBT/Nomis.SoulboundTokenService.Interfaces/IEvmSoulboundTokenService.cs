// ------------------------------------------------------------------------------------------------------
// <copyright file="IEvmSoulboundTokenService.cs" company="Nomis">
// Copyright (c) Nomis, 2023. All rights reserved.
// The Application under the MIT license. See LICENSE file in the solution root for full license information.
// </copyright>
// ------------------------------------------------------------------------------------------------------

using Nomis.SoulboundTokenService.Interfaces.Models;
using Nomis.SoulboundTokenService.Interfaces.Requests;
using Nomis.Utils.Contracts.Services;
using Nomis.Utils.Wrapper;

namespace Nomis.SoulboundTokenService.Interfaces
{
    /// <summary>
    /// EVM Soulbound token service.
    /// </summary>
    public interface IEvmSoulboundTokenService :
        IInfrastructureService
    {
        /// <summary>
        /// Get the soulbound token signature.
        /// </summary>
        /// <remarks>
        /// Is EVM-compatible.
        /// </remarks>
        /// <param name="request">The soulbound token request.</param>
        /// <returns>Return the soulbound token signature.</returns>
        public Result<SoulboundTokenSignature> GetSoulboundTokenSignature(
            SoulboundTokenRequest request);
    }
}