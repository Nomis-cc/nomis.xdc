// ------------------------------------------------------------------------------------------------------
// <copyright file="IDefiLlamaService.cs" company="Nomis">
// Copyright (c) Nomis, 2023. All rights reserved.
// The Application under the MIT license. See LICENSE file in the solution root for full license information.
// </copyright>
// ------------------------------------------------------------------------------------------------------

using Nomis.DefiLlama.Interfaces.Responses;
using Nomis.Utils.Contracts.Services;

namespace Nomis.DefiLlama.Interfaces
{
    /// <summary>
    /// DefiLlama service.
    /// </summary>
    public interface IDefiLlamaService :
        IInfrastructureService
    {
        /// <summary>
        /// Get tokens price.
        /// </summary>
        /// <param name="tokensId">The list of tokens id.</param>
        /// <param name="searchWidthInHours">Time range in hours on either side to find price data for token balances.</param>
        /// <returns>Returns tokens price.</returns>
        public Task<DefiLlamaTokensPriceResponse?> TokensPriceAsync(
            IList<string?> tokensId,
            int searchWidthInHours = 6);
    }
}