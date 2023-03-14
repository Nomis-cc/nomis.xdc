// ------------------------------------------------------------------------------------------------------
// <copyright file="CeramicGenesisCommit.cs" company="Nomis">
// Copyright (c) Nomis, 2023. All rights reserved.
// The Application under the MIT license. See LICENSE file in the solution root for full license information.
// </copyright>
// ------------------------------------------------------------------------------------------------------

using System.Text.Json.Serialization;

namespace Nomis.Ceramic.Interfaces.Models
{
    /// <summary>
    /// Ceramic genesis commit.
    /// </summary>
    public class CeramicGenesisCommit
    {
        /// <summary>
        /// Header.
        /// </summary>
        [JsonPropertyName("header")]
        public CeramicCommitHeader? Header { get; set; }

        /// <summary>
        /// Content.
        /// </summary>
        [JsonPropertyName("content")]
        public object? Content { get; set; }
    }
}