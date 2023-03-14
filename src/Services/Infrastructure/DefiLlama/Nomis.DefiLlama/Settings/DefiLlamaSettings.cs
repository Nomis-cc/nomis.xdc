// ------------------------------------------------------------------------------------------------------
// <copyright file="DefiLlamaSettings.cs" company="Nomis">
// Copyright (c) Nomis, 2023. All rights reserved.
// The Application under the MIT license. See LICENSE file in the solution root for full license information.
// </copyright>
// ------------------------------------------------------------------------------------------------------

using Nomis.Utils.Contracts.Common;

namespace Nomis.DefiLlama.Settings
{
    /// <summary>
    /// DefiLlama settings.
    /// </summary>
    internal class DefiLlamaSettings :
        ISettings
    {
        /// <summary>
        /// API base URL.
        /// </summary>
        /// <remarks>
        /// <see href="https://defillama.com/docs/api"/>
        /// </remarks>
        public string? ApiBaseUrl { get; set; }
    }
}