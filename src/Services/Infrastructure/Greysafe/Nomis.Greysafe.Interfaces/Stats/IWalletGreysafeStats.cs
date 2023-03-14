// ------------------------------------------------------------------------------------------------------
// <copyright file="IWalletGreysafeStats.cs" company="Nomis">
// Copyright (c) Nomis, 2023. All rights reserved.
// The Application under the MIT license. See LICENSE file in the solution root for full license information.
// </copyright>
// ------------------------------------------------------------------------------------------------------

using Nomis.Greysafe.Interfaces.Models;
using Nomis.Utils.Contracts.Stats;

namespace Nomis.Greysafe.Interfaces.Stats
{
    /// <summary>
    /// Wallet Greysafe scam reporting service stats.
    /// </summary>
    public interface IWalletGreysafeStats :
        IWalletStats
    {
        /// <summary>
        /// Set wallet Greysafe scam reporting service stats.
        /// </summary>
        /// <typeparam name="TWalletStats">The wallet stats type.</typeparam>
        /// <param name="stats">The wallet stats.</param>
        /// <returns>Returns wallet stats with initialized properties.</returns>
        public new TWalletStats FillStatsTo<TWalletStats>(TWalletStats stats)
            where TWalletStats : class, IWalletGreysafeStats
        {
            stats.GreysafeReports = GreysafeReports;
            return stats;
        }

        /// <summary>
        /// The Greysafe scam reports.
        /// </summary>
        public IEnumerable<GreysafeReport>? GreysafeReports { get; set; }

        /// <summary>
        /// Calculate wallet Greysafe stats score.
        /// </summary>
        /// <returns>Returns wallet Greysafe protocol stats score.</returns>
        public new double CalculateScore()
        {
            return 0;
        }

        /// <summary>
        /// Calculate wallet Greysafe adjusting score multiplier.
        /// </summary>
        /// <returns>Returns wallet Greysafe adjusting score multiplier.</returns>
        public new double CalculateAdjustingScoreMultiplier()
        {
            // TODO - add
            return 1;
        }
    }
}