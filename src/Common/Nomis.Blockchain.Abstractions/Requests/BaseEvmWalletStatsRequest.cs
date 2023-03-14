// ------------------------------------------------------------------------------------------------------
// <copyright file="BaseEvmWalletStatsRequest.cs" company="Nomis">
// Copyright (c) Nomis, 2023. All rights reserved.
// The Application under the MIT license. See LICENSE file in the solution root for full license information.
// </copyright>
// ------------------------------------------------------------------------------------------------------

using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

using Microsoft.AspNetCore.Mvc;
using Nomis.Blockchain.Abstractions.Contracts;
using Nomis.Chainanalysis.Interfaces.Contracts;
using Nomis.CyberConnect.Interfaces.Contracts;
using Nomis.Greysafe.Interfaces.Contracts;
using Nomis.Snapshot.Interfaces.Contracts;
using Nomis.Utils.Contracts.Requests;

namespace Nomis.Blockchain.Abstractions.Requests
{
    /// <summary>
    /// Base EVM wallet stats request.
    /// </summary>
    public abstract class BaseEvmWalletStatsRequest :
        WalletStatsRequest,
        IWalletTokensBalancesRequest,
        IWalletSnapshotProtocolRequest,
        IWalletGreysafeRequest,
        IWalletChainanalysisRequest,
        IWalletCyberConnectProtocolRequest
    {
        /// <inheritdoc />
        /// <example>true</example>
        [FromQuery]
        [JsonPropertyOrder(-8)]
        public virtual bool GetHoldTokensBalances { get; set; } = true;

        /// <inheritdoc />
        /// <example>6</example>
        [FromQuery]
        [Range(typeof(int), "1", "8760")]
        [JsonPropertyOrder(-7)]
        public virtual int SearchWidthInHours { get; set; } = 6;

        /// <inheritdoc />
        /// <example>false</example>
        [FromQuery]
        [JsonPropertyOrder(-6)]
        public virtual bool UseTokenLists { get; set; } = false;

        /// <inheritdoc />
        /// <example>false</example>
        [FromQuery]
        [JsonPropertyOrder(-5)]
        public virtual bool IncludeUniversalTokenLists { get; set; } = false;

        /// <inheritdoc />
        /// <example>false</example>
        [FromQuery]
        [JsonPropertyOrder(-4)]
        public virtual bool GetSnapshotProtocolData { get; set; } = false;

        /// <inheritdoc />
        /// <example>true</example>
        [FromQuery]
        [JsonPropertyOrder(-3)]
        public virtual bool GetGreysafeData { get; set; } = true;

        /// <inheritdoc />
        /// <example>true</example>
        [FromQuery]
        [JsonPropertyOrder(-2)]
        public virtual bool GetChainanalysisData { get; set; } = true;

        /// <inheritdoc />
        /// <example>true</example>
        [FromQuery]
        [JsonPropertyOrder(-1)]
        public virtual bool GetCyberConnectProtocolData { get; set; }
    }
}