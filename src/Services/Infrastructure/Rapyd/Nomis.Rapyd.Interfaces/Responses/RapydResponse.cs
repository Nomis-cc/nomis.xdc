// ------------------------------------------------------------------------------------------------------
// <copyright file="RapydResponse.cs" company="Nomis">
// Copyright (c) Nomis, 2023. All rights reserved.
// The Application under the MIT license. See LICENSE file in the solution root for full license information.
// </copyright>
// ------------------------------------------------------------------------------------------------------

using System.Text.Json.Serialization;

namespace Nomis.Rapyd.Interfaces.Responses
{
    /// <summary>
    /// Rapyd response.
    /// </summary>
    /// <typeparam name="T">The type of response data.</typeparam>
    public class RapydResponse<T> :
        RapydBaseApiResponse
    {
        /// <summary>
        /// Data.
        /// </summary>
        [JsonPropertyName("data")]
        public T? Data { get; set; }
    }
}