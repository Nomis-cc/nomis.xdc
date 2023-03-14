// ------------------------------------------------------------------------------------------------------
// <copyright file="AnchorStatus.cs" company="Nomis">
// Copyright (c) Nomis, 2023. All rights reserved.
// The Application under the MIT license. See LICENSE file in the solution root for full license information.
// </copyright>
// ------------------------------------------------------------------------------------------------------

// ReSharper disable InconsistentNaming
namespace Nomis.Ceramic.Interfaces.Enums
{
    /// <summary>
    /// Anchor status.
    /// </summary>
    public enum AnchorStatus :
        byte
    {
        /// <summary>
        /// Not requested.
        /// </summary>
        NOT_REQUESTED = 0,

        /// <summary>
        /// Pending.
        /// </summary>
        PENDING = 1,

        /// <summary>
        /// Processing.
        /// </summary>
        PROCESSING = 2,

        /// <summary>
        /// Anchored.
        /// </summary>
        ANCHORED = 3,

        /// <summary>
        /// Failed.
        /// </summary>
        FAILED = 4,

        /// <summary>
        /// Replaced.
        /// </summary>
        REPLACED = 5
    }
}