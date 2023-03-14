// ------------------------------------------------------------------------------------------------------
// <copyright file="SignatureStatus.cs" company="Nomis">
// Copyright (c) Nomis, 2023. All rights reserved.
// The Application under the MIT license. See LICENSE file in the solution root for full license information.
// </copyright>
// ------------------------------------------------------------------------------------------------------

// ReSharper disable InconsistentNaming
namespace Nomis.Ceramic.Interfaces.Enums
{
    /// <summary>
    /// Signature status.
    /// </summary>
    public enum SignatureStatus :
        byte
    {
        /// <summary>
        /// Genesis.
        /// </summary>
        GENESIS = 0,

        /// <summary>
        /// Partial.
        /// </summary>
        PARTIAL = 1,

        /// <summary>
        /// Signed.
        /// </summary>
        SIGNED = 2
    }
}