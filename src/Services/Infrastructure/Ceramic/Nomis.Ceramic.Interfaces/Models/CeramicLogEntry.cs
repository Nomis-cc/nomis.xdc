// ------------------------------------------------------------------------------------------------------
// <copyright file="CeramicLogEntry.cs" company="Nomis">
// Copyright (c) Nomis, 2023. All rights reserved.
// The Application under the MIT license. See LICENSE file in the solution root for full license information.
// </copyright>
// ------------------------------------------------------------------------------------------------------

using System.Text.Json.Serialization;

using Nomis.Ceramic.Interfaces.Enums;

namespace Nomis.Ceramic.Interfaces.Models
{
    /// <summary>
    /// Ceramic log entry.
    /// </summary>
    /// <remarks>
    /// Entry in a stream log as represented in a StreamState object.
    /// </remarks>
    public class CeramicLogEntry
    {
        /// <summary>
        /// CID of the stream commit.
        /// </summary>
        [JsonPropertyName("cid")]
        public string? Cid { get; set; }

        /// <summary>
        /// Type of the commit (e.g. genesis, signed, anchor).
        /// </summary>
        [JsonPropertyName("type")]
        public CommitType Type { get; set; }

        /// <summary>
        /// Timestamp (in seconds) of when this commit was anchored (if available).
        /// </summary>
        [JsonPropertyName("timestamp")]
        public ulong? Timestamp { get; set; }
    }
}