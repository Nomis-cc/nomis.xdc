// ------------------------------------------------------------------------------------------------------
// <copyright file="CeramicAnchorProof.cs" company="Nomis">
// Copyright (c) Nomis, 2023. All rights reserved.
// The Application under the MIT license. See LICENSE file in the solution root for full license information.
// </copyright>
// ------------------------------------------------------------------------------------------------------

using System.Text.Json.Serialization;

namespace Nomis.Ceramic.Interfaces.Models
{
    /// <summary>
    /// Ceramic anchor proof.
    /// </summary>
    public class CeramicAnchorProof
    {
        /// <summary>
        /// Chain id.
        /// </summary>
        [JsonPropertyName("chainId")]
        public string? ChainId { get; set; }

        /// <summary>
        /// Tx hash.
        /// </summary>
        [JsonPropertyName("txHash")]
        public string? TxHash { get; set; }

        /// <summary>
        /// Root.
        /// </summary>
        [JsonPropertyName("root")]
        public string? Root { get; set; }

        /// <summary>
        /// Tx type.
        /// </summary>
        [JsonPropertyName("txType")]
        public string? TxType { get; set; }
    }
}