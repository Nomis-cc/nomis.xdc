// ------------------------------------------------------------------------------------------------------
// <copyright file="CreateStreamRequest.cs" company="Nomis">
// Copyright (c) Nomis, 2023. All rights reserved.
// The Application under the MIT license. See LICENSE file in the solution root for full license information.
// </copyright>
// ------------------------------------------------------------------------------------------------------

using System.Text.Json.Serialization;

using Nomis.Ceramic.Interfaces.Enums;
using Nomis.Ceramic.Interfaces.Models;

namespace Nomis.Ceramic.Interfaces.Requests
{
    /// <summary>
    /// Create stream request.
    /// </summary>
    public class CreateStreamRequest
    {
        /// <summary>
        /// The type of the stream to use.
        /// </summary>
        [JsonPropertyName("type")]
        public StreamType Type { get; set; }

        /// <summary>
        /// The genesis content of the stream (will differ per type).
        /// </summary>
        [JsonPropertyName("genesis")]
        public CeramicGenesisCommit? Genesis { get; set; }
    }
}