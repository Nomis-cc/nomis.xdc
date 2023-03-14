// ------------------------------------------------------------------------------------------------------
// <copyright file="ITatumUtilsService.cs" company="Nomis">
// Copyright (c) Nomis, 2023. All rights reserved.
// The Application under the MIT license. See LICENSE file in the solution root for full license information.
// </copyright>
// ------------------------------------------------------------------------------------------------------

using Nomis.Tatum.Interfaces.Enums;
using Nomis.Tatum.Interfaces.Models;
using Nomis.Utils.Contracts.Services;

namespace Nomis.Tatum.Interfaces
{
    /// <summary>
    /// Tatum Utils service.
    /// </summary>
    public interface ITatumUtilsService :
        IInfrastructureService
    {
        /// <summary>
        /// Get the current exchange rate for exchanging fiat/crypto assets.
        /// </summary>
        /// <remarks>
        /// By default, the base pair (the target asset) is USD.
        /// When obtaining the exchange rate for an asset (for example, BTC), the value returned by
        /// the API expresses the amount of USD that can be currently exchanged into 1 BTC.
        /// </remarks>
        /// <param name="currency">The fiat or crypto asset to exchange.</param>
        /// <param name="basePair">The target fiat asset to get the exchange rate for.</param>
        /// <returns>Returns <see cref="TatumExchangeRate"/>.</returns>
        Task<TatumExchangeRate?> GetCurrentExchangeRateAsync(
            TatumExchangeCurrency currency = TatumExchangeCurrency.BTC,
            TatumExchangeCurrency basePair = TatumExchangeCurrency.USD);

        // TODO - add methods
    }
}