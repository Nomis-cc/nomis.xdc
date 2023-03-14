// ------------------------------------------------------------------------------------------------------
// <copyright file="RapydStatus.cs" company="Nomis">
// Copyright (c) Nomis, 2023. All rights reserved.
// The Application under the MIT license. See LICENSE file in the solution root for full license information.
// </copyright>
// ------------------------------------------------------------------------------------------------------

using System.Text.Json.Serialization;

namespace Nomis.Rapyd.Interfaces.Responses
{
    /// <summary>
    /// Rapyd status.
    /// </summary>
    public class RapydStatus
    {
        /// <summary>
        /// Error code.
        /// </summary>
        [JsonPropertyName("error_code")]
        public string? ErrorCode { get; set; }

        /// <summary>
        /// Operation status.
        /// </summary>
        [JsonPropertyName("status")]
        public string? OperationStatus { get; set; }

        /// <summary>
        /// Message.
        /// </summary>
        [JsonPropertyName("message")]
        public string? Message { get; set; }

        /// <summary>
        /// Response code.
        /// </summary>
        [JsonPropertyName("response_code")]
        public string? ResponseCode { get; set; }

        /// <summary>
        /// Operation id.
        /// </summary>
        [JsonPropertyName("operation_id")]
        public string? OperationId { get; set; }
    }
}