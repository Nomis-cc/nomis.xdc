// ------------------------------------------------------------------------------------------------------
// <copyright file="DefiLlamaService.cs" company="Nomis">
// Copyright (c) Nomis, 2023. All rights reserved.
// The Application under the MIT license. See LICENSE file in the solution root for full license information.
// </copyright>
// ------------------------------------------------------------------------------------------------------

using System.Net.Http.Json;

using Microsoft.Extensions.Options;
using Nomis.DefiLlama.Interfaces;
using Nomis.DefiLlama.Interfaces.Responses;
using Nomis.DefiLlama.Settings;
using Nomis.Utils.Contracts.Services;

namespace Nomis.DefiLlama
{
    /// <inheritdoc cref="IDefiLlamaService"/>
    internal sealed class DefiLlamaService :
        IDefiLlamaService,
        ISingletonService
    {
        private readonly HttpClient _client;

        public DefiLlamaService(
            IOptions<DefiLlamaSettings> defillamaOptions)
        {
            _client = new()
            {
                BaseAddress = new(defillamaOptions.Value.ApiBaseUrl ?? throw new ArgumentNullException(nameof(defillamaOptions.Value.ApiBaseUrl)))
            };
        }

        /// <inheritdoc />
        public async Task<DefiLlamaTokensPriceResponse?> TokensPriceAsync(
            IList<string?> tokensId,
            int searchWidthInHours = 6)
        {
            string tokensIds = string.Join(',', tokensId.Where(t => !string.IsNullOrWhiteSpace(t)));

            var response = await _client.GetAsync($"/prices/current/{tokensIds}?searchWidth={searchWidthInHours}h").ConfigureAwait(false);
            if (!response.IsSuccessStatusCode)
            {
                return default;
            }

            var result = await response.Content.ReadFromJsonAsync<DefiLlamaTokensPriceResponse>().ConfigureAwait(false);
            return result;
        }
    }
}