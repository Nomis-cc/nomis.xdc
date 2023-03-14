// ------------------------------------------------------------------------------------------------------
// <copyright file="UpdateStreamRequest.cs" company="Nomis">
// Copyright (c) Nomis, 2023. All rights reserved.
// The Application under the MIT license. See LICENSE file in the solution root for full license information.
// </copyright>
// ------------------------------------------------------------------------------------------------------

using System.Text.Json.Serialization;

using Nomis.Ceramic.Interfaces.Models;

namespace Nomis.Ceramic.Interfaces.Requests
{
    /// <summary>
    /// Update stream request.
    /// </summary>
    public class UpdateStreamRequest
    {
        /// <summary>
        /// Stream ID.
        /// </summary>
        [JsonPropertyName("streamId")]
        public string? StreamId { get; set; }

        /// <summary>
        /// Commit.
        /// </summary>
        [JsonPropertyName("commit")]
        public CeramicCommitData? Commit { get; set; }
    }
}