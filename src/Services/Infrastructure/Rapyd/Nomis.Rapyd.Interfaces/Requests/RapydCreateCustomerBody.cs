// ------------------------------------------------------------------------------------------------------
// <copyright file="RapydCreateCustomerBody.cs" company="Nomis">
// Copyright (c) Nomis, 2023. All rights reserved.
// The Application under the MIT license. See LICENSE file in the solution root for full license information.
// </copyright>
// ------------------------------------------------------------------------------------------------------

using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Nomis.Rapyd.Interfaces.Requests
{
    /// <summary>
    /// Rapyd create customer body.
    /// </summary>
    public class RapydCreateCustomerBody
    {
        /// <summary>
        /// Customer name.
        /// </summary>
        /// <example>0x0000000000000000000000000000000000000000</example>
        [Required]
        [JsonPropertyName("name")]
        public string? Name { get; set; }
    }
}