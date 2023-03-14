// ------------------------------------------------------------------------------------------------------
// <copyright file="CeramicSettings.cs" company="Nomis">
// Copyright (c) Nomis, 2023. All rights reserved.
// The Application under the MIT license. See LICENSE file in the solution root for full license information.
// </copyright>
// ------------------------------------------------------------------------------------------------------

using Nomis.Utils.Contracts.Common;

namespace Nomis.Ceramic.Settings
{
    /// <summary>
    /// Ceramic settings.
    /// </summary>
    internal class CeramicSettings :
        ISettings
    {
        /// <summary>
        /// API base URL.
        /// </summary>
        /// <remarks>
        /// <see href="https://developers.ceramic.network/run/nodes/available/#ceramic-nodes"/>
        /// </remarks>
        public string? ApiBaseUrl { get; set; }
    }
}