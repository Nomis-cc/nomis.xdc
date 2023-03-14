// ------------------------------------------------------------------------------------------------------
// <copyright file="SoulboundTokenData.cs" company="Nomis">
// Copyright (c) Nomis, 2023. All rights reserved.
// The Application under the MIT license. See LICENSE file in the solution root for full license information.
// </copyright>
// ------------------------------------------------------------------------------------------------------

namespace Nomis.SoulboundTokenService.Models
{
    /// <summary>
    /// Soulbound token data.
    /// </summary>
    public sealed class SoulboundTokenData
    {
        /// <summary>
        /// Token name.
        /// </summary>
        /// <remarks>
        /// "NMSS" value by default.
        /// </remarks>
        public string? TokenName { get; set; } = "NMSS";

        /// <summary>
        /// Token version.
        /// </summary>
        /// <remarks>
        /// "0.1" value by default.
        /// </remarks>
        public string? Version { get; set; } = "0.1";
    }
}