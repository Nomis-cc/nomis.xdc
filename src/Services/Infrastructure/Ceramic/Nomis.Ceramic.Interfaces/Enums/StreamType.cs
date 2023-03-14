// ------------------------------------------------------------------------------------------------------
// <copyright file="StreamType.cs" company="Nomis">
// Copyright (c) Nomis, 2023. All rights reserved.
// The Application under the MIT license. See LICENSE file in the solution root for full license information.
// </copyright>
// ------------------------------------------------------------------------------------------------------

// ReSharper disable InconsistentNaming
// ReSharper disable IdentifierTypo
namespace Nomis.Ceramic.Interfaces.Enums
{
    /// <summary>
    /// Stream type.
    /// </summary>
    public enum StreamType :
        byte
    {
        /// <summary>
        /// A stream type representing a json document.
        /// </summary>
        Tile = 0,

        /// <summary>
        /// Link blockchain accounts to DIDs.
        /// </summary>
        CAIP_10_Link = 1,

        /// <summary>
        /// Defines a group of documents in ComposeDB that share a schema.
        /// </summary>
        Model = 2,

        /// <summary>
        /// Represents a json document in ComposeDB.
        /// </summary>
        ModelInstanceDocument = 3,

        /// <summary>
        /// A stream that is not meant to be loaded.
        /// </summary>
        UNLOADABLE = 4
    }
}