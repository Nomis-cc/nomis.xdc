// ------------------------------------------------------------------------------------------------------
// <copyright file="BlockchainDescriptor.cs" company="Nomis">
// Copyright (c) Nomis, 2023. All rights reserved.
// The Application under the MIT license. See LICENSE file in the solution root for full license information.
// </copyright>
// ------------------------------------------------------------------------------------------------------

using System.Text.Json.Serialization;

using Nomis.Blockchain.Abstractions.Enums;
using Nomis.Utils.Enums;

// ReSharper disable InconsistentNaming
namespace Nomis.Blockchain.Abstractions.Contracts
{
    /// <inheritdoc cref="IBlockchainDescriptor"/>
    public class BlockchainDescriptor :
        IBlockchainDescriptor
    {
        /// <summary>
        /// Initialize <see cref="BlockchainDescriptor"/>.
        /// </summary>
        public BlockchainDescriptor()
        {
            // for serializers
        }

        /// <summary>
        /// Initialize <see cref="BlockchainDescriptor"/>.
        /// </summary>
        /// <param name="blockchainDescriptor"><see cref="IBlockchainDescriptor"/>.</param>
        public BlockchainDescriptor(
            IBlockchainDescriptor? blockchainDescriptor)
        {
            ChainId = blockchainDescriptor?.ChainId ?? 0;
            ChainName = blockchainDescriptor?.ChainName;
            BlockchainName = blockchainDescriptor?.BlockchainName;
            BlockchainSlug = blockchainDescriptor?.BlockchainSlug;
            BlockExplorerUrls = blockchainDescriptor?.BlockExplorerUrls;
            RPCUrls = blockchainDescriptor?.RPCUrls;
            IsEVMCompatible = blockchainDescriptor?.IsEVMCompatible ?? false;
            SBTContractAddresses = blockchainDescriptor?.SBTContractAddresses;
            NativeCurrency = blockchainDescriptor?.NativeCurrency;
            Order = blockchainDescriptor?.Order ?? 1;
            Icon = blockchainDescriptor?.Icon;
            LabelIcon = blockchainDescriptor?.LabelIcon;
            Enabled = blockchainDescriptor?.Enabled ?? false;
            Type = blockchainDescriptor?.Type ?? BlockchainType.None;
            PlatformIds = blockchainDescriptor?.PlatformIds;
            BalancesCheckerAddress = blockchainDescriptor?.BalancesCheckerAddress;
        }

        /// <inheritdoc cref="IBlockchainDescriptor.ChainId"/>
        [JsonInclude]
        public ulong ChainId { get; set; }

        /// <inheritdoc cref="IBlockchainDescriptor.ChainName"/>
        [JsonInclude]
        public string? ChainName { get; set; }

        /// <inheritdoc cref="IBlockchainDescriptor.BlockchainName"/>
        [JsonInclude]
        public string? BlockchainName { get; set; }

        /// <inheritdoc cref="IBlockchainDescriptor.BlockExplorerUrls"/>
        [JsonInclude]
        public IList<string>? BlockExplorerUrls { get; set; } = new List<string>();

        /// <inheritdoc cref="IBlockchainDescriptor.RPCUrls"/>
        [JsonInclude]
        public IList<string>? RPCUrls { get; set; } = new List<string>();

        /// <inheritdoc cref="IBlockchainDescriptor.BlockchainSlug"/>
        [JsonInclude]
        public string? BlockchainSlug { get; set; }

        /// <inheritdoc cref="IBlockchainDescriptor.IsEVMCompatible"/>
        [JsonInclude]
        public bool IsEVMCompatible { get; set; }

        /// <inheritdoc cref="IBlockchainDescriptor.SBTContractAddresses"/>
        [JsonInclude]
        public IDictionary<ScoreType, string>? SBTContractAddresses { get; set; } = new Dictionary<ScoreType, string>();

        /// <inheritdoc cref="IBlockchainDescriptor.NativeCurrency"/>
        [JsonInclude]
        public TokenData? NativeCurrency { get; set; }

        /// <inheritdoc cref="IBlockchainDescriptor.Order"/>
        [JsonInclude]
        public int Order { get; set; }

        /// <inheritdoc cref="IBlockchainDescriptor.Icon"/>
        [JsonInclude]
        public string? Icon { get; set; }

        /// <inheritdoc cref="IBlockchainDescriptor.LabelIcon"/>
        [JsonInclude]
        public string? LabelIcon { get; set; }

        /// <inheritdoc cref="IBlockchainDescriptor.Enabled"/>
        [JsonInclude]
        public bool Enabled { get; set; }

        /// <inheritdoc cref="IBlockchainDescriptor.Type"/>
        [JsonInclude]
        public BlockchainType Type { get; set; }

        /// <inheritdoc cref="IBlockchainDescriptor.PlatformIds"/>
        [JsonInclude]
        public IDictionary<BlockchainPlatform, string>? PlatformIds { get; set; } = new Dictionary<BlockchainPlatform, string>();

        /// <inheritdoc cref="IBlockchainDescriptor.BalancesCheckerAddress"/>
        [JsonInclude]
        public string? BalancesCheckerAddress { get; set; }
    }
}