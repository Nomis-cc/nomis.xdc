// ------------------------------------------------------------------------------------------------------
// <copyright file="ExtensionMethods.cs" company="Nomis">
// Copyright (c) Nomis, 2023. All rights reserved.
// The Application under the MIT license. See LICENSE file in the solution root for full license information.
// </copyright>
// ------------------------------------------------------------------------------------------------------

using System.Numerics;

using Nomis.DefiLlama.Interfaces.Models;
using Nomis.DefiLlama.Interfaces.Responses;

namespace Nomis.DefiLlama.Interfaces.Extensions
{
    /// <summary>
    /// DefiLlama extension methods.
    /// </summary>
    public static class ExtensionMethods
    {
        /// <summary>
        /// Get token balance data.
        /// </summary>
        /// <param name="tokenPrices">DefiLlama token prices response.</param>
        /// <param name="tokensData">Tokens data.</param>
        public static IEnumerable<TokenBalanceData> TokenBalanceData(
            this DefiLlamaTokensPriceResponse tokenPrices,
            IList<(string TokenContractId, string? TokenContractIdWithBlockchain, BigInteger? Balance)> tokensData)
        {
            List<TokenBalanceData>? result;
            if (tokenPrices.TokensPrices.Any())
            {
                result = tokensData
                    .Where(t => t.TokenContractIdWithBlockchain != null && tokenPrices.TokensPrices.ContainsKey(t.TokenContractIdWithBlockchain))
                    .Select(t => new TokenBalanceData(tokenPrices.TokensPrices[t.TokenContractIdWithBlockchain!], t.TokenContractId, t.TokenContractIdWithBlockchain, t.Balance))
                    .ToList();
                result = result
                    .Union(tokensData.Where(t => t.TokenContractIdWithBlockchain == null || !tokenPrices.TokensPrices.ContainsKey(t.TokenContractIdWithBlockchain))
                        .Select(t => new TokenBalanceData(new TokenPriceData(), t.TokenContractId, t.TokenContractIdWithBlockchain, t.Balance)))
                    .ToList();
            }
            else
            {
                result = tokensData
                    .Select(t => new TokenBalanceData(new TokenPriceData(), t.TokenContractId, t.TokenContractIdWithBlockchain, t.Balance))
                    .ToList();
            }

            return result;
        }
    }
}