// ------------------------------------------------------------------------------------------------------
// <copyright file="RapydAmountRangePerCurrency.cs" company="Nomis">
// Copyright (c) Nomis, 2023. All rights reserved.
// The Application under the MIT license. See LICENSE file in the solution root for full license information.
// </copyright>
// ------------------------------------------------------------------------------------------------------

using System.Text.Json.Serialization;

namespace Nomis.Rapyd.Interfaces.Models
{
    /// <summary>
    /// Rapyd amount range per currency.
    /// </summary>
    public class RapydAmountRangePerCurrency
    {
        /// <summary>
        /// Three-letter ISO 4217 format of currency.
        /// </summary>
        [JsonPropertyName("currency")]
        public string? Currency { get; set; }

        /// <summary>
        /// The maximum payment amount.
        /// </summary>
        [JsonPropertyName("maximum_amount")]
        public object? MaximumAmount { get; set; }

        /// <summary>
        /// The minimum payment amount.
        /// </summary>
        [JsonPropertyName("minimum_amount")]
        public object? MinimumAmount { get; set; }
    }
}