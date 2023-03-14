// ------------------------------------------------------------------------------------------------------
// <copyright file="IWalletScore.cs" company="Nomis">
// Copyright (c) Nomis, 2023. All rights reserved.
// The Application under the MIT license. See LICENSE file in the solution root for full license information.
// </copyright>
// ------------------------------------------------------------------------------------------------------

using Nomis.Utils.Contracts;
using Nomis.Utils.Contracts.Stats;
using Nomis.Utils.Enums;

namespace Nomis.Blockchain.Abstractions
{
    /// <inheritdoc cref="IWalletScore"/>
    /// <typeparam name="TWalletStats"><see cref="IWalletCommonStats{TTransactionIntervalData}"/>.</typeparam>
    /// <typeparam name="TTransactionIntervalData"><see cref="ITransactionIntervalData"/>.</typeparam>
    public interface IWalletScore<TWalletStats, TTransactionIntervalData> :
        IWalletScore
        where TWalletStats : IWalletCommonStats<TTransactionIntervalData>
        where TTransactionIntervalData : class, ITransactionIntervalData
    {
        /// <summary>
        /// Wallet address.
        /// </summary>
        public string? Address { get; set; }

        /// <summary>
        /// Nomis Score in range of [0; 1].
        /// </summary>
        public double Score { get; set; }

        /// <summary>
        /// Nomis minted Score in range of [0; 10000].
        /// </summary>
        public ushort MintedScore { get; set; }

        /// <inheritdoc cref="Utils.Enums.ScoreType"/>
        public ScoreType ScoreType { get; }

        /// <summary>
        /// Soulbound token signature.
        /// </summary>
        public string? Signature { get; set; }

        /// <summary>
        /// Additional stat data used in score calculations.
        /// </summary>
        public TWalletStats? Stats { get; set; }
    }

    /// <summary>
    /// Wallet score.
    /// </summary>
    public interface IWalletScore
    {
    }
}