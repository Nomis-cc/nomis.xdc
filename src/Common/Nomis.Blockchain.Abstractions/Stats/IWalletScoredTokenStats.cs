// ------------------------------------------------------------------------------------------------------
// <copyright file="IWalletScoredTokenStats.cs" company="Nomis">
// Copyright (c) Nomis, 2023. All rights reserved.
// The Application under the MIT license. See LICENSE file in the solution root for full license information.
// </copyright>
// ------------------------------------------------------------------------------------------------------

using Nomis.Utils.Contracts.Stats;

// ReSharper disable InconsistentNaming
namespace Nomis.Blockchain.Abstractions.Stats
{
    /// <summary>
    /// Wallet scored token stats.
    /// </summary>
    public interface IWalletScoredTokenStats :
        IWalletStats
    {
        /// <summary>
        /// Set wallet scored token stats.
        /// </summary>
        /// <typeparam name="TWalletStats">The wallet stats type.</typeparam>
        /// <param name="stats">The wallet stats.</param>
        /// <returns>Returns wallet stats with initialized properties.</returns>
        public new TWalletStats FillStatsTo<TWalletStats>(TWalletStats stats)
            where TWalletStats : class, IWalletScoredTokenStats
        {
            stats.Token = Token;
            stats.TokenBalance = TokenBalance;
            stats.TokenBalanceUSD = TokenBalanceUSD;
            return stats;
        }

        /// <summary>
        /// Token.
        /// </summary>
        public string? Token { get; set; }

        /// <summary>
        /// Token balance.
        /// </summary>
        public decimal TokenBalance { get; set; }

        /// <summary>
        /// Wallet token balance (in USD).
        /// </summary>
        public decimal TokenBalanceUSD { get; set; }

        /// <summary>
        /// Calculate wallet scored token stats score.
        /// </summary>
        /// <returns>Returns wallet scored token stats score.</returns>
        public new double CalculateScore()
        {
            return 0;
        }
    }
}