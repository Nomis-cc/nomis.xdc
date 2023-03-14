// ------------------------------------------------------------------------------------------------------
// <copyright file="WalletStatsExtensions.cs" company="Nomis">
// Copyright (c) Nomis, 2023. All rights reserved.
// The Application under the MIT license. See LICENSE file in the solution root for full license information.
// </copyright>
// ------------------------------------------------------------------------------------------------------

using Nomis.Blockchain.Abstractions.Stats;
using Nomis.Utils.Contracts;
using Nomis.Utils.Contracts.Stats;

namespace Nomis.Blockchain.Abstractions.Extensions
{
    /// <summary>
    /// <see cref="IWalletStats"/> extension methods.
    /// </summary>
    public static class WalletStatsExtensions
    {
        /// <summary>
        /// Initialize properties for stats.
        /// </summary>
        /// <typeparam name="TWalletConcreteStats">Concrete wallet stats type.</typeparam>
        /// <typeparam name="TWalletStats">The wallet stats type.</typeparam>
        /// <param name="stats">The wallet stats.</param>
        /// <param name="concreteStats">Concrete wallet stats.</param>
        /// <returns>Returns wallet stats with initialized properties.</returns>
        public static TWalletStats WithStats<TWalletConcreteStats, TWalletStats>(
            this TWalletStats stats,
            TWalletConcreteStats? concreteStats)
            where TWalletConcreteStats : class, IWalletStats
            where TWalletStats : class, TWalletConcreteStats
        {
            if (concreteStats == null)
            {
                return stats;
            }

            return concreteStats.FillStatsTo(stats);
        }

        /// <summary>
        /// Calculate wallet score.
        /// </summary>
        /// <param name="stats"><see cref="IWalletStats"/>.</param>
        /// <returns>Returns wallet score.</returns>
        public static double CalculateScore<TWalletStats, TTransactionIntervalData>(
            this TWalletStats stats)
            where TWalletStats : IWalletCommonStats<TTransactionIntervalData>
            where TTransactionIntervalData : class, ITransactionIntervalData
        {
            double result = 0;
            if (stats is IWalletStats walletStats)
            {
                result += walletStats.CalculateScore();
            }

            if (stats is IWalletCommonStats<TTransactionIntervalData> commonStats)
            {
                if (commonStats.NoData)
                {
                    return result;
                }

                result += commonStats.CalculateScore();
            }

            if (stats is IWalletNativeBalanceStats balanceStats)
            {
                result += balanceStats.CalculateScore();
            }

            if (stats is IWalletTransactionStats transactionStats)
            {
                result += transactionStats.CalculateScore();
            }

            if (stats is IWalletNftStats nftStats)
            {
                result += nftStats.CalculateScore();
            }

            if (stats is IWalletTokenStats tokenStats)
            {
                result += tokenStats.CalculateScore();
            }

            // add additional scores stored in wallet stats implementation class
            foreach (var additionalScore in stats.AdditionalScores)
            {
                result += additionalScore.Invoke();
            }

            // add adjusting score multipliers stored in wallet stats implementation class
            foreach (var adjustingScoreMultiplier in stats.AdjustingScoreMultipliers)
            {
                result *= adjustingScoreMultiplier.Invoke();
            }

            return result;
        }
    }
}