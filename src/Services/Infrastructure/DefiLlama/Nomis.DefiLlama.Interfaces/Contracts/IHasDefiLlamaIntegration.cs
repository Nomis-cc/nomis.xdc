// ------------------------------------------------------------------------------------------------------
// <copyright file="IHasDefiLlamaIntegration.cs" company="Nomis">
// Copyright (c) Nomis, 2023. All rights reserved.
// The Application under the MIT license. See LICENSE file in the solution root for full license information.
// </copyright>
// ------------------------------------------------------------------------------------------------------

namespace Nomis.DefiLlama.Interfaces.Contracts
{
    /// <summary>
    /// Has DefiLlama integration.
    /// </summary>
    public interface IHasDefiLlamaIntegration
    {
        /// <summary>
        /// DefiLlama chain id for getting token prices.
        /// </summary>
        public string DefiLLamaChainId { get; }

        /// <summary>
        /// Coingecko native token id.
        /// </summary>
        public string CoingeckoNativeTokenId { get; }
    }
}