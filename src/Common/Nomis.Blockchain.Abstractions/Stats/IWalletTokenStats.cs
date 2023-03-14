// ------------------------------------------------------------------------------------------------------
// <copyright file="IWalletTokenStats.cs" company="Nomis">
// Copyright (c) Nomis, 2023. All rights reserved.
// The Application under the MIT license. See LICENSE file in the solution root for full license information.
// </copyright>
// ------------------------------------------------------------------------------------------------------

using Nomis.Utils.Contracts.Stats;

namespace Nomis.Blockchain.Abstractions.Stats
{
    /// <summary>
    /// Wallet token stats.
    /// </summary>
    public interface IWalletTokenStats :
        IWalletStats
    {
        private const double TokensHoldingPercents = 3.86 / 100;

        /// <summary>
        /// Set wallet token stats.
        /// </summary>
        /// <typeparam name="TWalletStats">The wallet stats type.</typeparam>
        /// <param name="stats">The wallet stats.</param>
        /// <returns>Returns wallet stats with initialized properties.</returns>
        public new TWalletStats FillStatsTo<TWalletStats>(TWalletStats stats)
            where TWalletStats : class, IWalletTokenStats
        {
            stats.TokensHolding = TokensHolding;
            return stats;
        }

        /// <summary>
        /// Value of all holding tokens (number).
        /// </summary>
        public int TokensHolding { get; set; }

        /// <summary>
        /// Calculate wallet token stats score.
        /// </summary>
        /// <returns>Returns wallet token stats score.</returns>
        public new double CalculateScore()
        {
            return TokensHoldingScore(TokensHolding) / 100 * TokensHoldingPercents;
        }

        private static double TokensHoldingScore(int tokens)
        {
            return tokens switch
            {
                < 1 => 3.52,
                < 5 => 6.78,
                < 10 => 15.75,
                < 100 => 30.13,
                _ => 45.67
            };
        }
    }
}