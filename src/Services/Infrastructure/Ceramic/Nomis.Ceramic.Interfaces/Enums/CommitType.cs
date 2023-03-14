// ------------------------------------------------------------------------------------------------------
// <copyright file="CommitType.cs" company="Nomis">
// Copyright (c) Nomis, 2023. All rights reserved.
// The Application under the MIT license. See LICENSE file in the solution root for full license information.
// </copyright>
// ------------------------------------------------------------------------------------------------------

// ReSharper disable InconsistentNaming
namespace Nomis.Ceramic.Interfaces.Enums
{
    /// <summary>
    /// Commit type.
    /// </summary>
    public enum CommitType
    {
        /// <summary>
        /// Genesis.
        /// </summary>
        GENESIS = 0,

        /// <summary>
        /// Signed.
        /// </summary>
        SIGNED = 1,

        /// <summary>
        /// Anchor.
        /// </summary>
        ANCHOR = 2
    }
}