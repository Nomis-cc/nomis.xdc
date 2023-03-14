// ------------------------------------------------------------------------------------------------------
// <copyright file="CeramicStreamId.cs" company="Nomis">
// Copyright (c) Nomis, 2023. All rights reserved.
// The Application under the MIT license. See LICENSE file in the solution root for full license information.
// </copyright>
// ------------------------------------------------------------------------------------------------------

using System.Text.Json.Serialization;

namespace Nomis.Ceramic.Interfaces.Models
{
    /// <summary>
    /// Ceramic stream id.
    /// </summary>
    public class CeramicStreamId
    {
        /// <summary>
        /// Stream ID.
        /// </summary>
        [JsonPropertyName("streamId")]
        public string? StreamId { get; set; }
    }
}