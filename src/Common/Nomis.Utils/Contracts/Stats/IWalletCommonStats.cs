// ------------------------------------------------------------------------------------------------------
// <copyright file="IWalletCommonStats.cs" company="Nomis">
// Copyright (c) Nomis, 2023. All rights reserved.
// The Application under the MIT license. See LICENSE file in the solution root for full license information.
// </copyright>
// ------------------------------------------------------------------------------------------------------

using System.Text.Json.Serialization;

namespace Nomis.Utils.Contracts.Stats
{
    /// <summary>
    /// Wallet common stats.
    /// </summary>
    public interface IWalletCommonStats<TTransactionIntervalData> :
        IWalletStats
        where TTransactionIntervalData : class, ITransactionIntervalData
    {
        private const double WalletAgePercents = 32.34 / 100;

        /// <summary>
        /// Set wallet common stats.
        /// </summary>
        /// <typeparam name="TWalletStats">The wallet stats type.</typeparam>
        /// <param name="stats">The wallet stats.</param>
        /// <returns>Returns wallet stats with initialized properties.</returns>
        public new TWalletStats FillStatsTo<TWalletStats>(TWalletStats stats)
            where TWalletStats : class, IWalletCommonStats<TTransactionIntervalData>
        {
            stats.WalletAge = WalletAge;
            stats.TurnoverIntervals = TurnoverIntervals;
            stats.NoData = NoData;
            return stats;
        }

        /// <summary>
        /// Additional wallet stats scoring calculation functions.
        /// </summary>
        [JsonIgnore]
        IEnumerable<Func<double>> AdditionalScores => new List<Func<double>>();

        /// <summary>
        /// Wallet stats adjusting score multiplier calculation functions.
        /// </summary>
        [JsonIgnore]
        public IEnumerable<Func<double>> AdjustingScoreMultipliers => new List<Func<double>>();

        /// <summary>
        /// The list of properties excluded from <see cref="StatsDescriptions"/>.
        /// </summary>
        [JsonIgnore]
        static IEnumerable<string> ExcludedStatDescriptions => new List<string>
        {
            nameof(AdditionalScores),
            nameof(AdjustingScoreMultipliers),
            nameof(NoData),
            nameof(TurnoverIntervals),
            nameof(StatsDescriptions),
            nameof(ExcludedStatDescriptions)
        };

        /// <summary>
        /// Wallet age (months).
        /// </summary>
        public int WalletAge { get; set; }

        /// <summary>
        /// The intervals of funds movements on the wallet.
        /// </summary>
        public IEnumerable<TTransactionIntervalData>? TurnoverIntervals { get; set; }

        /// <summary>
        /// Wallet stats descriptions.
        /// </summary>
        public IDictionary<string, PropertyData> StatsDescriptions { get; }

        /// <summary>
        /// Calculate wallet common stats score.
        /// </summary>
        /// <returns>Returns wallet common stats score.</returns>
        public new double CalculateScore()
        {
            double result = WalletAgeScore(WalletAge) / 100 * WalletAgePercents;

            return result;
        }

        private static double WalletAgeScore(int walletAgeMonths)
        {
            return walletAgeMonths switch
            {
                < 1 => 7.14,
                < 12 => 36,
                < 24 => 60,
                _ => 100.0
            };
        }
    }
}