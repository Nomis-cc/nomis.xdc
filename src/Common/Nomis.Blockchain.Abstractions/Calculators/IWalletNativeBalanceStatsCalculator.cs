// ------------------------------------------------------------------------------------------------------
// <copyright file="IWalletNativeBalanceStatsCalculator.cs" company="Nomis">
// Copyright (c) Nomis, 2023. All rights reserved.
// The Application under the MIT license. See LICENSE file in the solution root for full license information.
// </copyright>
// ------------------------------------------------------------------------------------------------------

using Nomis.Blockchain.Abstractions.Stats;
using Nomis.Utils.Contracts;
using Nomis.Utils.Contracts.Calculators;

namespace Nomis.Blockchain.Abstractions.Calculators
{
    /// <summary>
    /// Blockchain wallet native balance stats calculator.
    /// </summary>
    /// <typeparam name="TWalletStats">The wallet stats type.</typeparam>
    /// <typeparam name="TTransactionIntervalData">The transaction interval data type.</typeparam>
    public interface IWalletNativeBalanceStatsCalculator<TWalletStats, TTransactionIntervalData> :
        IWalletStatsCalculator<TWalletStats, TTransactionIntervalData>
        where TWalletStats : class, IWalletNativeBalanceStats, new()
        where TTransactionIntervalData : class, ITransactionIntervalData, new()
    {
        /// <inheritdoc cref="IWalletNativeBalanceStats.NativeBalance"/>
        public decimal NativeBalance { get; }

        /// <inheritdoc cref="IWalletNativeBalanceStats.NativeBalanceUSD"/>
        // ReSharper disable once InconsistentNaming
        public decimal NativeBalanceUSD { get; }

        /// <inheritdoc cref="IWalletNativeBalanceStats.BalanceChangeInLastMonth"/>
        public decimal BalanceChangeInLastMonth { get; }

        /// <inheritdoc cref="IWalletNativeBalanceStats.BalanceChangeInLastYear"/>
        public decimal BalanceChangeInLastYear { get; }

        /// <inheritdoc cref="IWalletNativeBalanceStats.WalletTurnover"/>
        public decimal WalletTurnover { get; }

        /// <summary>
        /// Get blockchain wallet native balance stats.
        /// </summary>
        public new IWalletNativeBalanceStats Stats()
        {
            return new TWalletStats
            {
                NativeBalance = NativeBalance,
                NativeBalanceUSD = NativeBalanceUSD,
                BalanceChangeInLastMonth = BalanceChangeInLastMonth,
                BalanceChangeInLastYear = BalanceChangeInLastYear,
                WalletTurnover = WalletTurnover
            };
        }

        /// <summary>
        /// Blockchain wallet native balance stats filler.
        /// </summary>
        // ReSharper disable once UnusedMember.Global
        internal new Func<TWalletStats, TWalletStats> StatsFiller()
        {
            return stats => Stats().FillStatsTo(stats);
        }
    }
}