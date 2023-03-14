// ------------------------------------------------------------------------------------------------------
// <copyright file="XdcStatCalculator.cs" company="Nomis">
// Copyright (c) Nomis, 2023. All rights reserved.
// The Application under the MIT license. See LICENSE file in the solution root for full license information.
// </copyright>
// ------------------------------------------------------------------------------------------------------

using System.Numerics;

using Nomis.Blockchain.Abstractions.Calculators;
using Nomis.Blockchain.Abstractions.Stats;
using Nomis.Chainanalysis.Interfaces.Calculators;
using Nomis.Chainanalysis.Interfaces.Models;
using Nomis.CyberConnect.Interfaces.Calculators;
using Nomis.CyberConnect.Interfaces.Models;
using Nomis.CyberConnect.Interfaces.Responses;
using Nomis.DefiLlama.Interfaces.Models;
using Nomis.Greysafe.Interfaces.Calculators;
using Nomis.Greysafe.Interfaces.Models;
using Nomis.Snapshot.Interfaces.Calculators;
using Nomis.Snapshot.Interfaces.Models;
using Nomis.Snapshot.Interfaces.Responses;
using Nomis.Utils.Contracts;
using Nomis.Utils.Contracts.Calculators;
using Nomis.Xdcscan.Interfaces.Extensions;
using Nomis.Xdcscan.Interfaces.Models;

namespace Nomis.Xdcscan.Calculators
{
    /// <summary>
    /// Xdc wallet stats calculator.
    /// </summary>
    internal sealed class XdcStatCalculator :
        IWalletCommonStatsCalculator<XdcWalletStats, XdcTransactionIntervalData>,
        IWalletNativeBalanceStatsCalculator<XdcWalletStats, XdcTransactionIntervalData>,
        IWalletTokenBalancesStatsCalculator<XdcWalletStats, XdcTransactionIntervalData>,
        IWalletTransactionStatsCalculator<XdcWalletStats, XdcTransactionIntervalData>,
        IWalletTokenStatsCalculator<XdcWalletStats, XdcTransactionIntervalData>,
        IWalletContractStatsCalculator<XdcWalletStats, XdcTransactionIntervalData>,
        IWalletSnapshotStatsCalculator<XdcWalletStats, XdcTransactionIntervalData>,
        IWalletGreysafeStatsCalculator<XdcWalletStats, XdcTransactionIntervalData>,
        IWalletChainanalysisStatsCalculator<XdcWalletStats, XdcTransactionIntervalData>,
        IWalletCyberConnectStatsCalculator<XdcWalletStats, XdcTransactionIntervalData>,
        IWalletNftStatsCalculator<XdcWalletStats, XdcTransactionIntervalData>
    {
        private readonly string _address;
        private readonly XdcscanAccount _accountData;
        private readonly IEnumerable<XdcscanAccountNormalTransaction> _transactions;
        private readonly IEnumerable<XdcscanAccountInternalTransaction> _internalTransactions;
        private readonly IEnumerable<IXdcscanAccountNftTokenEvent> _nftTokenTransactions;
        private readonly IEnumerable<XdcscanAccountXRC20TokenEvent> _xrc20TokenTransactions;
        private readonly long _holderNftCount;
        private readonly IEnumerable<TokenBalanceData>? _tokenBalances;
        private readonly IEnumerable<GreysafeReport>? _greysafeReports;
        private readonly IEnumerable<ChainanalysisReport>? _chainanalysisReports;
        private readonly IEnumerable<CyberConnectLikeData>? _cyberConnectLikes;
        private readonly IEnumerable<CyberConnectEssenceData>? _cyberConnectEssences;
        private readonly IEnumerable<CyberConnectSubscribingProfileData>? _cyberConnectSubscribings;

        /// <inheritdoc />
        public int WalletAge => IWalletStatsCalculator
            .GetWalletAge(new List<DateTime> { _accountData.CreatedAt });

        /// <inheritdoc />
        public IList<XdcTransactionIntervalData> TurnoverIntervals
        {
            get
            {
                var turnoverIntervalsDataList =
                    _transactions.Select(x => new TurnoverIntervalsData(
                        x.Timestamp,
                        BigInteger.TryParse(x.Value, out var value) ? value : 0,
                        x.From?.Equals(_address, StringComparison.InvariantCultureIgnoreCase) == true));
                return IWalletStatsCalculator<XdcTransactionIntervalData>
                    .GetTurnoverIntervals(turnoverIntervalsDataList, _transactions.Any() ? _transactions.Min(x => x.Timestamp) : DateTime.MinValue).ToList();
            }
        }

        /// <inheritdoc />
        public decimal NativeBalance { get; }

        /// <inheritdoc />
        public decimal NativeBalanceUSD { get; }

        /// <inheritdoc />
        public decimal BalanceChangeInLastMonth =>
            IWalletStatsCalculator<XdcTransactionIntervalData>.GetBalanceChangeInLastMonth(TurnoverIntervals);

        /// <inheritdoc />
        public decimal BalanceChangeInLastYear =>
            IWalletStatsCalculator<XdcTransactionIntervalData>.GetBalanceChangeInLastYear(TurnoverIntervals);

        /// <inheritdoc />
        public decimal WalletTurnover =>
            _transactions.Sum(x => decimal.TryParse(x.Value, out decimal value) ? value.ToXdc() : 0);

        /// <inheritdoc />
        public IEnumerable<TokenBalanceData>? TokenBalances => _tokenBalances?.Any() == true ? _tokenBalances : null;

        /// <inheritdoc />
        public int DeployedContracts => _transactions.Count(x => !string.IsNullOrWhiteSpace(x.ContractAddress));

        /// <inheritdoc />
        public int TokensHolding => _xrc20TokenTransactions.Select(x => x.Symbol).Distinct().Count();

        /// <inheritdoc />
        public IEnumerable<SnapshotProposal>? SnapshotProposals { get; }

        /// <inheritdoc />
        public IEnumerable<SnapshotVote>? SnapshotVotes { get; }

        /// <inheritdoc />
        public IEnumerable<GreysafeReport>? GreysafeReports => _greysafeReports?.Any() == true ? _greysafeReports : null;

        /// <inheritdoc />
        public IEnumerable<ChainanalysisReport>? ChainanalysisReports =>
            _chainanalysisReports?.Any() == true ? _chainanalysisReports : null;

        /// <inheritdoc />
        public CyberConnectProfileData? CyberConnectProfile { get; }

        /// <inheritdoc />
        public IEnumerable<CyberConnectLikeData>? CyberConnectLikes => _cyberConnectLikes?.Any() == true ? _cyberConnectLikes : null;

        /// <inheritdoc />
        public IEnumerable<CyberConnectEssenceData>? CyberConnectEssences => _cyberConnectEssences?.Any() == true ? _cyberConnectEssences : null;

        /// <inheritdoc />
        public IEnumerable<CyberConnectSubscribingProfileData>? CyberConnectSubscribings => _cyberConnectSubscribings?.Any() == true ? _cyberConnectSubscribings : null;

        public XdcStatCalculator(
            string address,
            XdcscanAccount accountData,
            decimal usdBalance,
            IEnumerable<XdcscanAccountNormalTransaction> transactions,
            IEnumerable<XdcscanAccountInternalTransaction> internalTransactions,
            IEnumerable<IXdcscanAccountNftTokenEvent> nftTokenTransactions,
            IEnumerable<XdcscanAccountXRC20TokenEvent> xrc20TokenTransactions,
            long holderNftCount,
            SnapshotData? snapshotData,
            IEnumerable<TokenBalanceData>? tokenBalances,
            IEnumerable<GreysafeReport>? greysafeReports,
            IEnumerable<ChainanalysisReport>? chainanalysisReports,
            CyberConnectData? cyberConnectData)
        {
            _address = address;
            _accountData = accountData;
            NativeBalance = accountData.BalanceNumber;
            NativeBalanceUSD = usdBalance;
            _transactions = transactions;
            _internalTransactions = internalTransactions;
            _nftTokenTransactions = nftTokenTransactions;
            _xrc20TokenTransactions = xrc20TokenTransactions;
            _holderNftCount = holderNftCount;
            _tokenBalances = tokenBalances;
            SnapshotVotes = snapshotData?.Votes;
            SnapshotProposals = snapshotData?.Proposals;
            _greysafeReports = greysafeReports;
            _chainanalysisReports = chainanalysisReports;
            _cyberConnectLikes = cyberConnectData?.Likes;
            _cyberConnectEssences = cyberConnectData?.Essences;
            _cyberConnectSubscribings = cyberConnectData?.Subscribings;
            CyberConnectProfile = cyberConnectData?.Profile;
        }

        /// <inheritdoc />
        public XdcWalletStats Stats()
        {
            return (this as IWalletStatsCalculator<XdcWalletStats, XdcTransactionIntervalData>).ApplyCalculators();
        }

        /// <inheritdoc />
        IWalletTransactionStats IWalletTransactionStatsCalculator<XdcWalletStats, XdcTransactionIntervalData>.Stats()
        {
            if (!_transactions.Any())
            {
                return new XdcWalletStats
                {
                    NoData = true
                };
            }

            var intervals = IWalletStatsCalculator
                .GetTransactionsIntervals(_transactions.Select(x => x.Timestamp)).ToList();
            if (intervals.Count == 0)
            {
                return new XdcWalletStats
                {
                    NoData = true
                };
            }

            var monthAgo = DateTime.Now.AddMonths(-1);
            var yearAgo = DateTime.Now.AddYears(-1);

            return new XdcWalletStats
            {
                TotalTransactions = (int)_accountData.TransactionCount,
                TotalRejectedTransactions = _transactions.Count(t => !t.Status),
                MinTransactionTime = intervals.Min(),
                MaxTransactionTime = intervals.Max(),
                AverageTransactionTime = intervals.Average(),
                LastMonthTransactions = _transactions.Count(x => x.Timestamp > monthAgo),
                LastYearTransactions = _transactions.Count(x => x.Timestamp > yearAgo),
                TimeFromLastTransaction = (int)((DateTime.UtcNow - _transactions.OrderBy(x => x.Timestamp).Last().Timestamp).TotalDays / 30)
            };
        }

        /// <inheritdoc />
        IWalletNftStats IWalletNftStatsCalculator<XdcWalletStats, XdcTransactionIntervalData>.Stats()
        {
            var soldTokens = _nftTokenTransactions.Where(x => x.From?.Equals(_address, StringComparison.InvariantCultureIgnoreCase) == true).ToList();
            var soldSum = IWalletStatsCalculator
                .TokensSum(soldTokens.Select(x => x.TransactionHash!), _internalTransactions.Select(x => (x.Hash!, BigInteger.TryParse(x.Value, out var amount) ? amount : 0)));

            var soldTokensIds = soldTokens.Select(x => x.GetTokenUid());
            var buyTokens = _nftTokenTransactions.Where(x => x.To?.Equals(_address, StringComparison.InvariantCultureIgnoreCase) == true && soldTokensIds.Contains(x.GetTokenUid()));
            var buySum = IWalletStatsCalculator
                .TokensSum(buyTokens.Select(x => x.TransactionHash!), _internalTransactions.Select(x => (x.Hash!, BigInteger.TryParse(x.Value, out var amount) ? amount : 0)));

            var buyNotSoldTokens = _nftTokenTransactions.Where(x => x.To?.Equals(_address, StringComparison.InvariantCultureIgnoreCase) == true && !soldTokensIds.Contains(x.GetTokenUid()));
            var buyNotSoldSum = IWalletStatsCalculator
                .TokensSum(buyNotSoldTokens.Select(x => x.TransactionHash!), _internalTransactions.Select(x => (x.Hash!, BigInteger.TryParse(x.Value, out var amount) ? amount : 0)));

            int holdingTokens = _holderNftCount == 0 ? _nftTokenTransactions.Count() - soldTokens.Count : (int)_holderNftCount;
            decimal nftWorth = buySum == 0 ? 0 : (decimal)soldSum / (decimal)buySum * (decimal)buyNotSoldSum;

            return new XdcWalletStats
            {
                NftHolding = holdingTokens,
                NftTrading = (soldSum - buySum).ToXdc(),
                NftWorth = nftWorth.ToXdc()
            };
        }
    }
}