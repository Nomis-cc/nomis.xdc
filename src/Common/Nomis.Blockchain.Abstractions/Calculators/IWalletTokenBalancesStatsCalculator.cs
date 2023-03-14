// ------------------------------------------------------------------------------------------------------
// <copyright file="IWalletTokenBalancesStatsCalculator.cs" company="Nomis">
// Copyright (c) Nomis, 2023. All rights reserved.
// The Application under the MIT license. See LICENSE file in the solution root for full license information.
// </copyright>
// ------------------------------------------------------------------------------------------------------

using Nomis.DefiLlama.Interfaces.Models;
using Nomis.DefiLlama.Interfaces.Stats;
using Nomis.Utils.Contracts;
using Nomis.Utils.Contracts.Calculators;

namespace Nomis.Blockchain.Abstractions.Calculators
{
    /// <summary>
    /// Blockchain wallet hold token balances stats calculator.
    /// </summary>
    public interface IWalletTokenBalancesStatsCalculator<TWalletStats, TTransactionIntervalData> :
        IWalletStatsCalculator<TWalletStats, TTransactionIntervalData>
        where TWalletStats : class, IWalletTokenBalancesStats, new()
        where TTransactionIntervalData : class, ITransactionIntervalData, new()
    {
        /// <inheritdoc cref="IWalletTokenBalancesStats.TokenBalances"/>
        public IEnumerable<TokenBalanceData>? TokenBalances { get; }

        /// <summary>
        /// Get blockchain wallet hold token balances stats.
        /// </summary>
        public new IWalletTokenBalancesStats Stats()
        {
            return new TWalletStats
            {
                TokenBalances = TokenBalances
            };
        }

        /// <summary>
        /// Blockchain wallet hold token balances stats filler.
        /// </summary>
        // ReSharper disable once UnusedMember.Global
        internal new Func<TWalletStats, TWalletStats> StatsFiller()
        {
            return stats => Stats().FillStatsTo(stats);
        }
    }
}