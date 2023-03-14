// ------------------------------------------------------------------------------------------------------
// <copyright file="CeramicCommits.cs" company="Nomis">
// Copyright (c) Nomis, 2023. All rights reserved.
// The Application under the MIT license. See LICENSE file in the solution root for full license information.
// </copyright>
// ------------------------------------------------------------------------------------------------------

using System.Text.Json.Serialization;

namespace Nomis.Ceramic.Interfaces.Models
{
    /// <summary>
    /// Ceramic commits.
    /// </summary>
    public class CeramicCommits
    {
        /// <summary>
        /// Stream ID.
        /// </summary>
        [JsonPropertyName("streamId")]
        public string? StreamId { get; set; }

        /// <summary>
        /// Doc ID.
        /// </summary>
        [JsonPropertyName("docId")]
        public string? DocId { get; set; }

        /// <summary>
        /// Commits.
        /// </summary>
        [JsonPropertyName("commits")]
        public IList<CeramicCommit> Commits { get; set; } = new List<CeramicCommit>();
    }
}