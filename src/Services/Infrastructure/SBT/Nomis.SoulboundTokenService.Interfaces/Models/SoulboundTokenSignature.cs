// ------------------------------------------------------------------------------------------------------
// <copyright file="SoulboundTokenSignature.cs" company="Nomis">
// Copyright (c) Nomis, 2023. All rights reserved.
// The Application under the MIT license. See LICENSE file in the solution root for full license information.
// </copyright>
// ------------------------------------------------------------------------------------------------------

namespace Nomis.SoulboundTokenService.Interfaces.Models
{
    /// <summary>
    /// Soulbound token signature data.
    /// </summary>
    public class SoulboundTokenSignature
    {
        /// <summary>
        /// Signature.
        /// </summary>
        public string? Signature { get; set; }
    }
}