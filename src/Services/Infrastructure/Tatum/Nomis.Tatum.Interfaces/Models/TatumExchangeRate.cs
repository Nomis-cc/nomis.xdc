// ------------------------------------------------------------------------------------------------------
// <copyright file="TatumExchangeRate.cs" company="Nomis">
// Copyright (c) Nomis, 2023. All rights reserved.
// The Application under the MIT license. See LICENSE file in the solution root for full license information.
// </copyright>
// ------------------------------------------------------------------------------------------------------

using System.Text.Json.Serialization;

using Nomis.Tatum.Interfaces.Extensions;

namespace Nomis.Tatum.Interfaces.Models
{
    /// <summary>
    /// Tatum exchange rate.
    /// </summary>
    public class TatumExchangeRate
    {
        /// <summary>
        /// FIAT or crypto asset.
        /// </summary>
        [JsonPropertyName("id")]
        public string? Id { get; set; }

        /// <summary>
        /// FIAT value of the asset in given base pair.
        /// </summary>
        [JsonPropertyName("value")]
        public string? Value { get; set; }

        /// <summary>
        /// Base pair.
        /// </summary>
        [JsonPropertyName("basePair")]
        public string? BasePair { get; set; }

        /// <summary>
        /// Date of validity of rate in UTC.
        /// </summary>
        [JsonPropertyName("timestamp")]
        public long Timestamp { get; set; }

        /// <summary>
        /// Readable date of validity of rate in UTC.
        /// </summary>
        public DateTime HumanTimestamp => Timestamp.ToTatumDateTime();

        /// <summary>
        /// Source of base pair.
        /// </summary>
        [JsonPropertyName("source")]
        public string? Source { get; set; }
    }
}