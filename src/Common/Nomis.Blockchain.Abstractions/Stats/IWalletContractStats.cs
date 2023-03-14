// ------------------------------------------------------------------------------------------------------
// <copyright file="IWalletContractStats.cs" company="Nomis">
// Copyright (c) Nomis, 2023. All rights reserved.
// The Application under the MIT license. See LICENSE file in the solution root for full license information.
// </copyright>
// ------------------------------------------------------------------------------------------------------

using Nomis.Utils.Contracts.Stats;

namespace Nomis.Blockchain.Abstractions.Stats
{
    /// <summary>
    /// Wallet contract stats.
    /// </summary>
    public interface IWalletContractStats :
        IWalletStats
    {
        /// <summary>
        /// Set wallet contract stats.
        /// </summary>
        /// <typeparam name="TWalletStats">The wallet stats type.</typeparam>
        /// <param name="stats">The wallet stats.</param>
        /// <returns>Returns wallet stats with initialized properties.</returns>
        public new TWalletStats FillStatsTo<TWalletStats>(TWalletStats stats)
            where TWalletStats : class, IWalletContractStats
        {
            stats.DeployedContracts = DeployedContracts;
            return stats;
        }

        /// <summary>
        /// Amount of deployed smart-contracts.
        /// </summary>
        public int DeployedContracts { get; set; }

        /// <summary>
        /// Calculate wallet contract stats score.
        /// </summary>
        /// <returns>Returns wallet contract stats score.</returns>
        public new double CalculateScore()
        {
            // TODO - add calculation
            return 0;
        }
    }
}