// ------------------------------------------------------------------------------------------------------
// <copyright file="BaseEvmWalletStats.cs" company="Nomis">
// Copyright (c) Nomis, 2023. All rights reserved.
// The Application under the MIT license. See LICENSE file in the solution root for full license information.
// </copyright>
// ------------------------------------------------------------------------------------------------------

using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

using Nomis.Chainanalysis.Interfaces.Models;
using Nomis.Chainanalysis.Interfaces.Stats;
using Nomis.CyberConnect.Interfaces.Models;
using Nomis.CyberConnect.Interfaces.Stats;
using Nomis.DefiLlama.Interfaces.Models;
using Nomis.DefiLlama.Interfaces.Stats;
using Nomis.Greysafe.Interfaces.Models;
using Nomis.Greysafe.Interfaces.Stats;
using Nomis.Snapshot.Interfaces.Models;
using Nomis.Snapshot.Interfaces.Stats;
using Nomis.Utils.Contracts;
using Nomis.Utils.Contracts.Stats;

namespace Nomis.Blockchain.Abstractions.Stats
{
    /// <summary>
    /// Base EVM wallet stats.
    /// </summary>
    public class BaseEvmWalletStats<TTransactionIntervalData> :
        IWalletCommonStats<TTransactionIntervalData>,
        IWalletNativeBalanceStats,
        IWalletTokenBalancesStats,
        IWalletTransactionStats,
        IWalletTokenStats,
        IWalletContractStats,
        IWalletSnapshotStats,
        IWalletGreysafeStats,
        IWalletChainanalysisStats,
        IWalletCyberConnectStats
        where TTransactionIntervalData : class, ITransactionIntervalData
    {
        /// <inheritdoc/>
        [JsonPropertyOrder(-20)]
        public bool NoData { get; set; }

        /// <inheritdoc/>
        [JsonPropertyOrder(-19)]
        public virtual string NativeToken => "Native token";

        /// <inheritdoc/>
        [Display(Description = "Amount of deployed smart-contracts", GroupName = "number")]
        public virtual int DeployedContracts { get; set; }

        /// <inheritdoc/>
        [Display(Description = "Wallet native token balance", GroupName = "Native token")]
        [JsonPropertyOrder(-18)]
        public virtual decimal NativeBalance { get; set; }

        /// <inheritdoc/>
        [Display(Description = "Wallet native token balance", GroupName = "USD")]
        [JsonPropertyOrder(-17)]
        public virtual decimal NativeBalanceUSD { get; set; }

        /// <inheritdoc/>
        [Display(Description = "Wallet hold tokens total balance", GroupName = "USD")]
        [JsonPropertyOrder(-16)]
        public virtual decimal HoldTokensBalanceUSD => TokenBalances?.Sum(b => b.TotalAmountPrice) ?? 0;

        /// <inheritdoc/>
        [Display(Description = "The movement of funds on the wallet", GroupName = "Native token")]
        [JsonPropertyOrder(-15)]
        public virtual decimal WalletTurnover { get; set; }

        /// <inheritdoc/>
        [Display(Description = "The balance change value in the last month", GroupName = "Native token")]
        [JsonPropertyOrder(-14)]
        public virtual decimal BalanceChangeInLastMonth { get; set; }

        /// <inheritdoc/>
        [Display(Description = "The balance change value in the last year", GroupName = "Native token")]
        [JsonPropertyOrder(-13)]
        public virtual decimal BalanceChangeInLastYear { get; set; }

        /// <inheritdoc/>
        [Display(Description = "Wallet age", GroupName = "months")]
        [JsonPropertyOrder(-12)]
        public virtual int WalletAge { get; set; }

        /// <inheritdoc/>
        [Display(Description = "Total transactions on wallet", GroupName = "number")]
        [JsonPropertyOrder(-11)]
        public virtual int TotalTransactions { get; set; }

        /// <inheritdoc/>
        [Display(Description = "Total rejected transactions on wallet", GroupName = "number")]
        [JsonPropertyOrder(-10)]
        public virtual int TotalRejectedTransactions { get; set; }

        /// <inheritdoc/>
        [Display(Description = "Average time interval between transactions", GroupName = "hours")]
        [JsonPropertyOrder(-9)]
        public virtual double AverageTransactionTime { get; set; }

        /// <inheritdoc/>
        [Display(Description = "Maximum time interval between transactions", GroupName = "hours")]
        [JsonPropertyOrder(-8)]
        public virtual double MaxTransactionTime { get; set; }

        /// <inheritdoc/>
        [Display(Description = "Minimal time interval between transactions", GroupName = "hours")]
        [JsonPropertyOrder(-7)]
        public virtual double MinTransactionTime { get; set; }

        /// <inheritdoc/>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public virtual IEnumerable<TTransactionIntervalData>? TurnoverIntervals { get; set; }

        /// <inheritdoc/>
        [Display(Description = "Time since last transaction", GroupName = "months")]
        [JsonPropertyOrder(-6)]
        public virtual int TimeFromLastTransaction { get; set; }

        /// <inheritdoc/>
        [Display(Description = "Last month transactions", GroupName = "number")]
        [JsonPropertyOrder(-5)]
        public virtual int LastMonthTransactions { get; set; }

        /// <inheritdoc/>
        [Display(Description = "Last year transactions on wallet", GroupName = "number")]
        [JsonPropertyOrder(-4)]
        public virtual int LastYearTransactions { get; set; }

        /// <inheritdoc/>
        [Display(Description = "Average transaction per months", GroupName = "number")]
        [JsonPropertyOrder(-3)]
        public virtual double TransactionsPerMonth => WalletAge != 0 ? (double)TotalTransactions / WalletAge : 0;

        /// <inheritdoc/>
        [Display(Description = "Value of all holding tokens", GroupName = "number")]
        [JsonPropertyOrder(-2)]
        public virtual int TokensHolding { get; set; }

        /// <inheritdoc/>
        [Display(Description = "The Snapshot protocol votes", GroupName = "collection")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public virtual IEnumerable<SnapshotProtocolVoteData>? SnapshotVotes { get; set; }

        /// <inheritdoc/>
        [Display(Description = "The Snapshot protocol proposals", GroupName = "collection")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public virtual IEnumerable<SnapshotProtocolProposalData>? SnapshotProposals { get; set; }

        /// <inheritdoc/>
        [Display(Description = "The Greysafe scam reports data", GroupName = "collection")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public virtual IEnumerable<GreysafeReport>? GreysafeReports { get; set; }

        /// <inheritdoc/>
        [Display(Description = "The Greysafe sanctions reports data", GroupName = "collection")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public virtual IEnumerable<ChainanalysisReport>? ChainanalysisReports { get; set; }

        /// <inheritdoc/>
        [Display(Description = "The CyberConnect protocol profile", GroupName = "value")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public virtual CyberConnectProfileData? CyberConnectProfile { get; set; }

        /// <inheritdoc/>
        [Display(Description = "The CyberConnect protocol subscribings", GroupName = "collection")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public virtual IEnumerable<CyberConnectSubscribingProfileData>? CyberConnectSubscribings { get; set; }

        /// <inheritdoc/>
        [Display(Description = "The CyberConnect protocol likes", GroupName = "collection")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public virtual IEnumerable<CyberConnectLikeData>? CyberConnectLikes { get; set; }

        /// <inheritdoc/>
        [Display(Description = "The CyberConnect protocol essences", GroupName = "collection")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public virtual IEnumerable<CyberConnectEssenceData>? CyberConnectEssences { get; set; }

        /// <inheritdoc/>
        [Display(Description = "Hold tokens balances", GroupName = "collection")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        [JsonPropertyOrder(-1)]
        public virtual IEnumerable<TokenBalanceData>? TokenBalances { get; set; }

        /// <inheritdoc/>
        [JsonPropertyOrder(int.MaxValue)]
        public virtual IDictionary<string, PropertyData> StatsDescriptions => GetType()
            .GetProperties()
            .Where(prop => !ExcludedStatDescriptions.Contains(prop.Name) && Attribute.IsDefined(prop, typeof(DisplayAttribute)) && !Attribute.IsDefined(prop, typeof(JsonIgnoreAttribute)))
            .ToDictionary(p => p.Name, p => new PropertyData(p, NativeToken));

        /// <inheritdoc/>
        [JsonIgnore]
        public virtual IEnumerable<Func<double>> AdditionalScores => new List<Func<double>>
        {
            () => (this as IWalletSnapshotStats).CalculateScore()
        };

        /// <inheritdoc/>
        [JsonIgnore]
        public virtual IEnumerable<Func<double>> AdjustingScoreMultipliers => new List<Func<double>>
        {
            () => (this as IWalletGreysafeStats).CalculateAdjustingScoreMultiplier(),
            () => (this as IWalletChainanalysisStats).CalculateAdjustingScoreMultiplier()
        };

        /// <inheritdoc cref="IWalletCommonStats{ITransactionIntervalData}.ExcludedStatDescriptions"/>
        [JsonIgnore]
        public virtual IEnumerable<string> ExcludedStatDescriptions =>
            IWalletCommonStats<TTransactionIntervalData>.ExcludedStatDescriptions.Union(new List<string>
            {
                nameof(NativeToken),
                nameof(SnapshotProposals),
                nameof(SnapshotVotes),
                nameof(TokenBalances),
                nameof(GreysafeReports),
                nameof(ChainanalysisReports),
                nameof(CyberConnectProfile),
                nameof(CyberConnectSubscribings),
                nameof(CyberConnectLikes),
                nameof(CyberConnectEssences)
            });
    }
}