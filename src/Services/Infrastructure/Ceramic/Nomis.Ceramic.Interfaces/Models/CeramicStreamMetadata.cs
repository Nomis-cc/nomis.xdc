// ------------------------------------------------------------------------------------------------------
// <copyright file="CeramicStreamMetadata.cs" company="Nomis">
// Copyright (c) Nomis, 2023. All rights reserved.
// The Application under the MIT license. See LICENSE file in the solution root for full license information.
// </copyright>
// ------------------------------------------------------------------------------------------------------

using System.Text.Json.Serialization;

namespace Nomis.Ceramic.Interfaces.Models
{
    /// <summary>
    /// Ceramic stream metadata.
    /// </summary>
    public class CeramicStreamMetadata
    {
        /// <summary>
        /// Tags.
        /// </summary>
        [JsonPropertyName("tags")]
        public IList<string> Tags { get; set; } = new List<string>();

        /// <summary>
        /// Family.
        /// </summary>
        [JsonPropertyName("family")]
        public string? Family { get; set; }

        /// <summary>
        /// Schema.
        /// </summary>
        [JsonPropertyName("schema")]
        public string? Schema { get; set; }

        /// <summary>
        /// Unique.
        /// </summary>
        [JsonPropertyName("unique")]
        public string? Unique { get; set; }

        /// <summary>
        /// Controllers.
        /// </summary>
        [JsonPropertyName("controllers")]
        public IList<string> Controllers { get; set; } = new List<string>();
    }
}