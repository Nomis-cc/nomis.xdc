// ------------------------------------------------------------------------------------------------------
// <copyright file="CeramicStreamState.cs" company="Nomis">
// Copyright (c) Nomis, 2023. All rights reserved.
// The Application under the MIT license. See LICENSE file in the solution root for full license information.
// </copyright>
// ------------------------------------------------------------------------------------------------------

using System.Text.Json.Serialization;

using Nomis.Ceramic.Interfaces.Enums;

namespace Nomis.Ceramic.Interfaces.Models
{
    /// <summary>
    /// Ceramic stream state data.
    /// </summary>
    public class CeramicStreamState
    {
        /// <summary>
        /// Type.
        /// </summary>
        [JsonPropertyName("type")]
        public StreamType Type { get; set; }

        /// <summary>
        /// Content.
        /// </summary>
        [JsonPropertyName("content")]
        public object? Content { get; set; }

        /// <summary>
        /// Metadata.
        /// </summary>
        [JsonPropertyName("metadata")]
        public CeramicStreamMetadata? Metadata { get; set; }

        /// <summary>
        /// Signature.
        /// </summary>
        [JsonPropertyName("signature")]
        public SignatureStatus Signature { get; set; }

        /// <summary>
        /// Anchor status.
        /// </summary>
        [JsonPropertyName("anchorStatus")]
        public AnchorStatus? AnchorStatus { get; set; }

        /// <summary>
        /// Anchor proof.
        /// </summary>
        /// <remarks>
        /// The anchor proof of the latest anchor, only present when anchor status is anchored.
        /// </remarks>
        [JsonPropertyName("anchorProof")]
        public CeramicAnchorProof? AnchorProof { get; set; }

        /// <summary>
        /// List of log entries.
        /// </summary>
        [JsonPropertyName("log")]
        public IList<CeramicLogEntry> Log { get; set; } = new List<CeramicLogEntry>();

        /// <summary>
        /// Doctype.
        /// </summary>
        [JsonPropertyName("doctype")]
        public string? Doctype { get; set; }
    }
}