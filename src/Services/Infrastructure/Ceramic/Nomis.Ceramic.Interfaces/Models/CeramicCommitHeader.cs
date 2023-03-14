// ------------------------------------------------------------------------------------------------------
// <copyright file="CeramicCommitHeader.cs" company="Nomis">
// Copyright (c) Nomis, 2023. All rights reserved.
// The Application under the MIT license. See LICENSE file in the solution root for full license information.
// </copyright>
// ------------------------------------------------------------------------------------------------------

using System.Text.Json.Serialization;

namespace Nomis.Ceramic.Interfaces.Models
{
    /// <summary>
    /// Ceramic genesis commit header.
    /// </summary>
    public class CeramicCommitHeader
    {
        /// <summary>
        /// Controllers.
        /// </summary>
        [JsonPropertyName("controllers")]
        public IList<string> Controllers { get; set; } = new List<string>();

        /// <summary>
        /// StreamID encoded as byte array.
        /// </summary>
        [JsonPropertyName("model")]
        public byte[]? Model { get; set; }
    }
}