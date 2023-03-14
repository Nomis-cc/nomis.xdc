// ------------------------------------------------------------------------------------------------------
// <copyright file="IWalletChainanalysisStats.cs" company="Nomis">
// Copyright (c) Nomis, 2023. All rights reserved.
// The Application under the MIT license. See LICENSE file in the solution root for full license information.
// </copyright>
// ------------------------------------------------------------------------------------------------------

using Nomis.Chainanalysis.Interfaces.Models;
using Nomis.Utils.Contracts.Stats;

namespace Nomis.Chainanalysis.Interfaces.Stats
{
    /// <summary>
    /// Wallet Chainanalysis sanctions reporting service stats.
    /// </summary>
    public interface IWalletChainanalysisStats :
        IWalletStats
    {
        /// <summary>
        /// Set wallet Chainanalysis sanctions reporting service stats.
        /// </summary>
        /// <typeparam name="TWalletStats">The wallet stats type.</typeparam>
        /// <param name="stats">The wallet stats.</param>
        /// <returns>Returns wallet stats with initialized properties.</returns>
        public new TWalletStats FillStatsTo<TWalletStats>(TWalletStats stats)
            where TWalletStats : class, IWalletChainanalysisStats
        {
            stats.ChainanalysisReports = ChainanalysisReports;
            return stats;
        }

        /// <summary>
        /// The Chainanalysis sanctions reports.
        /// </summary>
        public IEnumerable<ChainanalysisReport>? ChainanalysisReports { get; set; }

        /// <summary>
        /// Calculate wallet Chainanalysis stats score.
        /// </summary>
        /// <returns>Returns wallet Chainanalysis protocol stats score.</returns>
        public new double CalculateScore()
        {
            return 0;
        }

        /// <summary>
        /// Calculate wallet Chainanalysis adjusting score multiplier.
        /// </summary>
        /// <returns>Returns wallet Chainanalysis adjusting score multiplier.</returns>
        public new double CalculateAdjustingScoreMultiplier()
        {
            // TODO - add
            return 1;
        }
    }
}