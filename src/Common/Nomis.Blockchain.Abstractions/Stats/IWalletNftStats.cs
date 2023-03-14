// ------------------------------------------------------------------------------------------------------
// <copyright file="IWalletNftStats.cs" company="Nomis">
// Copyright (c) Nomis, 2023. All rights reserved.
// The Application under the MIT license. See LICENSE file in the solution root for full license information.
// </copyright>
// ------------------------------------------------------------------------------------------------------

using Nomis.Utils.Contracts.Stats;

namespace Nomis.Blockchain.Abstractions.Stats
{
    /// <summary>
    /// Wallet NFT stats.
    /// </summary>
    public interface IWalletNftStats :
        IWalletStats
    {
        private const double NftPercents = 2.15 / 100;
        private const double NftHoldingPercents = 6.52 / 100;
        private const double NftTradingPercents = 16.38 / 100;
        private const double NftWorthPercents = 23.75 / 100;

        /// <summary>
        /// Set wallet NFT stats.
        /// </summary>
        /// <typeparam name="TWalletStats">The wallet stats type.</typeparam>
        /// <param name="stats">The wallet stats.</param>
        /// <returns>Returns wallet stats with initialized properties.</returns>
        public new TWalletStats FillStatsTo<TWalletStats>(TWalletStats stats)
            where TWalletStats : class, IWalletNftStats
        {
            stats.NftHolding = NftHolding;
            stats.NftTrading = NftTrading;
            stats.NftWorth = NftWorth;
            return stats;
        }

        /// <summary>
        /// Total NFTs on wallet (number).
        /// </summary>
        public int NftHolding { get; set; }

        /// <summary>
        /// NFT trading activity (Native token).
        /// </summary>
        public decimal NftTrading { get; set; }

        /// <summary>
        /// NFT worth on wallet (Native token).
        /// </summary>
        public decimal NftWorth { get; set; }

        /// <summary>
        /// Calculate wallet NFT stats score.
        /// </summary>
        /// <returns>Returns wallet NFT stats score.</returns>
        public new double CalculateScore()
        {
            double result = 0.0;
            double nft = 0.0;
            nft += NftHoldingScore(NftHolding) / 100 * NftHoldingPercents;
            nft += NftTradingScore(NftTrading) / 100 * NftTradingPercents;
            nft += NftWorthScore(NftWorth) / 100 * NftWorthPercents;
            result += nft * NftPercents;

            return result;
        }

        private static double NftHoldingScore(int value)
        {
            return value switch
            {
                < 10 => 3.93,
                < 100 => 11.13,
                < 500 => 35.18,
                _ => 49.76
            };
        }

        private static double NftTradingScore(decimal value)
        {
            return value switch
            {
                < 1 => 2.35,
                < 10 => 5.44,
                < 50 => 12.56,
                < 100 => 28.39,
                _ => 51.26
            };
        }

        private static double NftWorthScore(decimal value)
        {
            return value switch
            {
                < 1 => 2.35,
                < 10 => 5.44,
                < 50 => 12.56,
                < 100 => 28.39,
                _ => 51.26
            };
        }
    }
}