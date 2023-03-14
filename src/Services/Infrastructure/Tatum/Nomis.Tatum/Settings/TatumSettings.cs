// ------------------------------------------------------------------------------------------------------
// <copyright file="TatumSettings.cs" company="Nomis">
// Copyright (c) Nomis, 2023. All rights reserved.
// The Application under the MIT license. See LICENSE file in the solution root for full license information.
// </copyright>
// ------------------------------------------------------------------------------------------------------

using Nomis.Utils.Contracts.Common;

namespace Nomis.Tatum.Settings
{
    /// <summary>
    /// Tatum settings.
    /// </summary>
    internal class TatumSettings :
        ISettings
    {
        /// <summary>
        /// API base URL.
        /// </summary>
        /// <remarks>
        /// <see href="https://docs.tatum.io/introduction/your-first-app"/>
        /// </remarks>
        public string? ApiBaseUrl { get; set; }

        /// <summary>
        /// API key.
        /// </summary>
        public string? ApiKey { get; set; }
    }
}