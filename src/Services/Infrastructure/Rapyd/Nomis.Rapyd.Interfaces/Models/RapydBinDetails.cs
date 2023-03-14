// ------------------------------------------------------------------------------------------------------
// <copyright file="RapydBinDetails.cs" company="Nomis">
// Copyright (c) Nomis, 2023. All rights reserved.
// The Application under the MIT license. See LICENSE file in the solution root for full license information.
// </copyright>
// ------------------------------------------------------------------------------------------------------

using System.Text.Json.Serialization;

namespace Nomis.Rapyd.Interfaces.Models
{
    /// <summary>
    /// Rapyd BIN details.
    /// </summary>
    public class RapydBinDetails
    {
        /// <summary>
        /// Type.
        /// </summary>
        /// <example>CREDIT</example>
        [JsonPropertyName("type")]
        public string? Type { get; set; }

        /// <summary>
        /// Brand.
        /// </summary>
        /// <example>MASTERCARD</example>
        [JsonPropertyName("brand")]
        public string? Brand { get; set; }

        /// <summary>
        /// Country.
        /// </summary>
        /// <example>US</example>
        [JsonPropertyName("country")]
        public string? Country { get; set; }

        /// <summary>
        /// BIN number.
        /// </summary>
        /// <example>523929</example>
        [JsonPropertyName("bin_number")]
        public string? BinNumber { get; set; }
    }
}