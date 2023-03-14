// ------------------------------------------------------------------------------------------------------
// <copyright file="CeramicAPISettings.cs" company="Nomis">
// Copyright (c) Nomis, 2023. All rights reserved.
// The Application under the MIT license. See LICENSE file in the solution root for full license information.
// </copyright>
// ------------------------------------------------------------------------------------------------------

using Nomis.Utils.Contracts.Common;

namespace Nomis.Api.Ceramic.Settings
{
    /// <summary>
    /// Ceramic API settings.
    /// </summary>
    // ReSharper disable once InconsistentNaming
    internal class CeramicAPISettings :
        IApiSettings
    {
        /// <inheritdoc/>
        public bool APIEnabled { get; set; }

        /// <inheritdoc/>
        public string APIName => CeramicController.CeramicTag;

        /// <inheritdoc/>
        public string ControllerName => nameof(CeramicController);
    }
}