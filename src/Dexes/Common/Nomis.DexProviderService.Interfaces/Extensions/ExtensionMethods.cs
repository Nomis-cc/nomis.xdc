// ------------------------------------------------------------------------------------------------------
// <copyright file="ExtensionMethods.cs" company="Nomis">
// Copyright (c) Nomis, 2023. All rights reserved.
// The Application under the MIT license. See LICENSE file in the solution root for full license information.
// </copyright>
// ------------------------------------------------------------------------------------------------------

using System.Numerics;

using Nomis.Blockchain.Abstractions.Contracts;
using Nomis.DefiLlama.Interfaces;
using Nomis.DefiLlama.Interfaces.Extensions;
using Nomis.DefiLlama.Interfaces.Models;
using Nomis.DefiLlama.Interfaces.Responses;
using Nomis.Dex.Abstractions.Enums;
using Nomis.DexProviderService.Interfaces.Contracts;
using Nomis.DexProviderService.Interfaces.Requests;

namespace Nomis.DexProviderService.Interfaces.Extensions
{
    /// <summary>
    /// Extension methods.
    /// </summary>
    public static class ExtensionMethods
    {
        /// <summary>
        /// Get the token balances data.
        /// </summary>
        /// <param name="dexProviderService"><see cref="IDexProviderService"/>.</param>
        /// <param name="defiLlamaService"><see cref="IDefiLlamaService"/>.</param>
        /// <param name="request"><see cref="IWalletTokensBalancesRequest"/>.</param>
        /// <param name="tokensData">Tokens data.</param>
        /// <param name="blockchain">Blockchain.</param>
        /// <returns>Returns the token balances data and DEX token data.</returns>
        public static async Task<(IList<TokenBalanceData>? TokenBalances, IList<DexTokenData> DexTokensData)> TokenBalancesAsync<TWalletRequest>(
            this IDexProviderService dexProviderService,
            IDefiLlamaService defiLlamaService,
            TWalletRequest? request,
            IList<(string TokenContractId, string? TokenContractIdWithBlockchain, BigInteger? Balance)> tokensData,
            Chain blockchain)
            where TWalletRequest : IWalletTokensBalancesRequest
        {
            IList<TokenBalanceData>? tokenBalances = null;
            IList<DexTokenData> tokenData = new List<DexTokenData>();
            if (request?.UseTokenLists == true)
            {
                var dexTokensData = await dexProviderService.TokensDataAsync(new TokensDataRequest
                {
                    Blockchain = blockchain,
                    IncludeUniversalTokenLists = request.IncludeUniversalTokenLists,
                    FromCache = true
                }).ConfigureAwait(false);
                tokenData = dexTokensData.Data;
                tokenBalances = await defiLlamaService
                    .TokensBalancesAsync(request, tokensData, dexTokensData.Data).ConfigureAwait(false);
            }

            return (tokenBalances, tokenData);
        }

        /// <summary>
        /// Get tokens balances.
        /// </summary>
        /// <param name="service"><see cref="IDefiLlamaService"/>.</param>
        /// <param name="request">Wallet tokens balance request.</param>
        /// <param name="tokensData">Tokens data.</param>
        /// <param name="dexTokensData">DEX tokens data.</param>
        /// <returns>Returns tokens balances.</returns>
        public static async Task<IList<TokenBalanceData>> TokensBalancesAsync(
            this IDefiLlamaService service,
            IWalletTokensBalancesRequest? request,
            IList<(string TokenContractId, string? TokenContractIdWithBlockchain, BigInteger? Balance)> tokensData,
            IReadOnlyList<DexTokenData> dexTokensData)
        {
            var tokenBalances = new List<TokenBalanceData>();
            if (request?.GetHoldTokensBalances == true)
            {
                var tokenPrices = await service.TokensPriceAsync(
                    tokensData.Select(t => t.TokenContractIdWithBlockchain).ToList(),
                    request.SearchWidthInHours).ConfigureAwait(false);
                var tokenBalancesData = tokenPrices != null
                    ? tokenPrices.TokenBalanceData(tokensData).ToList()
                    : new DefiLlamaTokensPriceResponse().TokenBalanceData(tokensData).ToList();

                foreach (var tokenBalanceData in tokenBalancesData)
                {
                    var dexTokenData = dexTokensData
                        .FirstOrDefault(t => t.Id?.Equals(tokenBalanceData.TokenId, StringComparison.OrdinalIgnoreCase) == true);

                    if (dexTokenData != null)
                    {
                        tokenBalanceData.Decimals ??= int.TryParse(dexTokenData.Decimals, out int decimals) ? decimals : null;
                        tokenBalanceData.Symbol ??= dexTokenData.Symbol;
                    }
                }

                tokenBalances.AddRange(tokenBalancesData);
            }

            return tokenBalances;
        }
    }
}