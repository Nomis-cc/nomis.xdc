// ------------------------------------------------------------------------------------------------------
// <copyright file="CeramicCommitData.cs" company="Nomis">
// Copyright (c) Nomis, 2023. All rights reserved.
// The Application under the MIT license. See LICENSE file in the solution root for full license information.
// </copyright>
// ------------------------------------------------------------------------------------------------------

using System.Text.Json.Serialization;

namespace Nomis.Ceramic.Interfaces.Models
{
    /// <summary>
    /// Ceramic commit data.
    /// </summary>
    public class CeramicCommitData
    {
        /// <summary>
        /// Commit value.
        /// </summary>
        [JsonPropertyName("value")]
        public CeramicGenesisCommit? Value { get; set; }
    }
}