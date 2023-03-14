// ------------------------------------------------------------------------------------------------------
// <copyright file="CeramicStream.cs" company="Nomis">
// Copyright (c) Nomis, 2023. All rights reserved.
// The Application under the MIT license. See LICENSE file in the solution root for full license information.
// </copyright>
// ------------------------------------------------------------------------------------------------------

using System.Text.Json.Serialization;

namespace Nomis.Ceramic.Interfaces.Models
{
    /// <summary>
    /// Ceramic stream.
    /// </summary>
    public class CeramicStream :
        CeramicStreamId
    {
        /// <summary>
        /// State.
        /// </summary>
        [JsonPropertyName("state")]
        public CeramicStreamState? State { get; set; }
    }
}