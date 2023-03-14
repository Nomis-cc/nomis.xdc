// ------------------------------------------------------------------------------------------------------
// <copyright file="IWalletCyberConnectStats.cs" company="Nomis">
// Copyright (c) Nomis, 2023. All rights reserved.
// The Application under the MIT license. See LICENSE file in the solution root for full license information.
// </copyright>
// ------------------------------------------------------------------------------------------------------

using Nomis.CyberConnect.Interfaces.Models;
using Nomis.Utils.Contracts.Stats;

namespace Nomis.CyberConnect.Interfaces.Stats
{
    /// <summary>
    /// Wallet CyberConnect protocol stats.
    /// </summary>
    public interface IWalletCyberConnectStats :
        IWalletStats
    {
        /// <summary>
        /// Set wallet CyberConnect protocol stats.
        /// </summary>
        /// <typeparam name="TWalletStats">The wallet stats type.</typeparam>
        /// <param name="stats">The wallet stats.</param>
        /// <returns>Returns wallet stats with initialized properties.</returns>
        public new TWalletStats FillStatsTo<TWalletStats>(TWalletStats stats)
            where TWalletStats : class, IWalletCyberConnectStats
        {
            stats.CyberConnectProfile = CyberConnectProfile;
            stats.CyberConnectSubscribings = CyberConnectSubscribings;
            stats.CyberConnectLikes = CyberConnectLikes;
            stats.CyberConnectEssences = CyberConnectEssences;
            return stats;
        }

        /// <summary>
        /// The CyberConnect protocol profile.
        /// </summary>
        public CyberConnectProfileData? CyberConnectProfile { get; set; }

        /// <summary>
        /// The CyberConnect protocol subscribings.
        /// </summary>
        public IEnumerable<CyberConnectSubscribingProfileData>? CyberConnectSubscribings { get; set; }

        /// <summary>
        /// The CyberConnect protocol likes.
        /// </summary>
        public IEnumerable<CyberConnectLikeData>? CyberConnectLikes { get; set; }

        /// <summary>
        /// The CyberConnect protocol essences.
        /// </summary>
        public IEnumerable<CyberConnectEssenceData>? CyberConnectEssences { get; set; }

        /// <summary>
        /// Calculate wallet CyberConnect protocol stats score.
        /// </summary>
        /// <returns>Returns wallet CyberConnect protocol stats score.</returns>
        public new double CalculateScore()
        {
            // TODO - add calculation
            return 0;
        }
    }
}