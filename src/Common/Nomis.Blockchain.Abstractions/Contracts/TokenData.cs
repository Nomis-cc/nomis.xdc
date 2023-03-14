// ------------------------------------------------------------------------------------------------------
// <copyright file="TokenData.cs" company="Nomis">
// Copyright (c) Nomis, 2023. All rights reserved.
// The Application under the MIT license. See LICENSE file in the solution root for full license information.
// </copyright>
// ------------------------------------------------------------------------------------------------------

using System.Text.Json.Serialization;

namespace Nomis.Blockchain.Abstractions.Contracts
{
    /// <summary>
    /// Token data.
    /// </summary>
    /// <remarks>
    /// <see href="https://docs.sushi.com/docs/Developers/Subgraphs/Exchange/Entities#token"/>
    /// </remarks>
    public class TokenData
    {
        /// <summary>
        /// Token id in the blockchain.
        /// </summary>
        [JsonPropertyName("id")]
        public string? Id { get; set; }

        /// <summary>
        /// Token symbol.
        /// </summary>
        [JsonPropertyName("symbol")]
        public string? Symbol { get; set; }

        /// <summary>
        /// Token name.
        /// </summary>
        [JsonPropertyName("name")]
        public string? Name { get; set; }

        /// <summary>
        /// Token decimals.
        /// </summary>
        [JsonPropertyName("decimals")]
        public string? Decimals { get; set; }

        /// <summary>
        /// Logo URI.
        /// </summary>
        [JsonPropertyName("logoUri")]
        public string? LogoUri { get; set; }
    }
}