// ------------------------------------------------------------------------------------------------------
// <copyright file="TokenBalanceData.cs" company="Nomis">
// Copyright (c) Nomis, 2023. All rights reserved.
// The Application under the MIT license. See LICENSE file in the solution root for full license information.
// </copyright>
// ------------------------------------------------------------------------------------------------------

using System.Numerics;

namespace Nomis.DefiLlama.Interfaces.Models
{
    /// <summary>
    /// Token balance data.
    /// </summary>
    public class TokenBalanceData
        : TokenPriceData
    {
        /// <summary>
        /// Initialize <see cref="TokenBalanceData"/>.
        /// </summary>
        /// <param name="tokenPriceData"><see cref="TokenPriceData"/>.</param>
        /// <param name="tokenId">Token id.</param>
        /// <param name="defiLlamaTokenId">DefiLlama token id.</param>
        /// <param name="amount">Token balance amount.</param>
        public TokenBalanceData(
            TokenPriceData tokenPriceData,
            string tokenId,
            string? defiLlamaTokenId,
            BigInteger? amount)
            : base(tokenPriceData)
        {
            if (amount > new BigInteger(decimal.MaxValue))
            {
                var realAmount = amount ?? 0;
                for (int i = 0; i < Decimals; i++)
                {
                    realAmount /= 10;
                }

                if (realAmount <= new BigInteger(decimal.MaxValue))
                {
                    Amount = (decimal)realAmount;
                }
            }
            else
            {
                Amount = (decimal)(amount ?? 0);
                for (int i = 0; i < Decimals; i++)
                {
                    Amount /= 10;
                }
            }

            TokenId = tokenId;
            DefiLlamaTokenId = defiLlamaTokenId;
        }

        /// <summary>
        /// Token balance amount.
        /// </summary>
        public decimal Amount { get; }

        /// <summary>
        /// Token id.
        /// </summary>
        public string TokenId { get; }

        /// <summary>
        /// DefiLlama token id.
        /// </summary>
        public string? DefiLlamaTokenId { get; }

        /// <summary>
        /// Total token balance amount price.
        /// </summary>
        public decimal TotalAmountPrice => Price * Amount;
    }
}