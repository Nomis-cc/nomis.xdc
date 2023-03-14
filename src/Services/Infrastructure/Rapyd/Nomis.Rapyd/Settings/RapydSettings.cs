// ------------------------------------------------------------------------------------------------------
// <copyright file="RapydSettings.cs" company="Nomis">
// Copyright (c) Nomis, 2023. All rights reserved.
// The Application under the MIT license. See LICENSE file in the solution root for full license information.
// </copyright>
// ------------------------------------------------------------------------------------------------------

using Nomis.Utils.Contracts.Common;

namespace Nomis.Rapyd.Settings
{
    /// <summary>
    /// Rapyd settings.
    /// </summary>
    internal class RapydSettings :
        ISettings
    {
        /// <summary>
        /// API base URL.
        /// </summary>
        /// <remarks>
        /// <see href="https://docs.rapyd.net/build-with-rapyd/docs"/>
        /// </remarks>
        public string? ApiBaseUrl { get; set; }

        /// <summary>
        /// API access key.
        /// </summary>
        public string? AccessKey { get; set; }

        /// <summary>
        /// API secret key.
        /// </summary>
        public string? SecretKey { get; set; }
    }
}