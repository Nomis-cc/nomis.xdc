// ------------------------------------------------------------------------------------------------------
// <copyright file="CeramicCommit.cs" company="Nomis">
// Copyright (c) Nomis, 2023. All rights reserved.
// The Application under the MIT license. See LICENSE file in the solution root for full license information.
// </copyright>
// ------------------------------------------------------------------------------------------------------

using System.Text.Json.Serialization;

namespace Nomis.Ceramic.Interfaces.Models
{
    /// <summary>
    /// Ceramic commit.
    /// </summary>
    public class CeramicCommit
    {
        /// <summary>
        /// Cid.
        /// </summary>
        [JsonPropertyName("cid")]
        public string? Cid { get; set; }

        /// <summary>
        /// Value.
        /// </summary>
        [JsonPropertyName("value")]
        public object? Value { get; set; }
    }
}