// ------------------------------------------------------------------------------------------------------
// <copyright file="TatumUtilsService.cs" company="Nomis">
// Copyright (c) Nomis, 2023. All rights reserved.
// The Application under the MIT license. See LICENSE file in the solution root for full license information.
// </copyright>
// ------------------------------------------------------------------------------------------------------

using System.Net.Http.Json;

using Microsoft.Extensions.Options;
using Nomis.Tatum.Interfaces;
using Nomis.Tatum.Interfaces.Enums;
using Nomis.Tatum.Interfaces.Models;
using Nomis.Tatum.Settings;
using Nomis.Utils.Contracts.Services;

namespace Nomis.Tatum
{
    /// <inheritdoc cref="ITatumUtilsService"/>
    internal sealed class TatumUtilsService :
        ITatumUtilsService,
        ISingletonService
    {
        private readonly HttpClient _client;

        /// <summary>
        /// Initialize <see cref="TatumUtilsService"/>.
        /// </summary>
        /// <param name="tatumOptions"><see cref="TatumSettings"/>.</param>
        public TatumUtilsService(
            IOptions<TatumSettings> tatumOptions)
        {
            _client = new()
            {
                BaseAddress = new(tatumOptions.Value.ApiBaseUrl ?? throw new ArgumentNullException(nameof(tatumOptions.Value.ApiBaseUrl)))
            };
            _client.DefaultRequestHeaders.Add("x-api-key", tatumOptions.Value.ApiKey);
        }

        /// <inheritdoc />
        public async Task<TatumExchangeRate?> GetCurrentExchangeRateAsync(
            TatumExchangeCurrency currency = TatumExchangeCurrency.BTC,
            TatumExchangeCurrency basePair = TatumExchangeCurrency.USD)
        {
            var response = await _client.GetAsync($"/v3/tatum/rate/{currency.ToString()}?basePair={basePair.ToString()}").ConfigureAwait(false);
            response.EnsureSuccessStatusCode();

            var data = await response.Content.ReadFromJsonAsync<TatumExchangeRate>().ConfigureAwait(false);
            return data;
        }

        // TODO - add methods
    }
}