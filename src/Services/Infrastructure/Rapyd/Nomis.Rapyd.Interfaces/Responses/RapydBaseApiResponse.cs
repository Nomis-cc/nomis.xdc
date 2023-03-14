// ------------------------------------------------------------------------------------------------------
// <copyright file="RapydBaseApiResponse.cs" company="Nomis">
// Copyright (c) Nomis, 2023. All rights reserved.
// The Application under the MIT license. See LICENSE file in the solution root for full license information.
// </copyright>
// ------------------------------------------------------------------------------------------------------

using System.Text.Json.Serialization;

namespace Nomis.Rapyd.Interfaces.Responses
{
    /// <summary>
    /// Rapyd base API response.
    /// </summary>
    public class RapydBaseApiResponse
    {
        /// <summary>
        /// Status.
        /// </summary>
        [JsonPropertyName("status")]
        public RapydStatus? Status { get; set; }
    }
}