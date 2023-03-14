// ------------------------------------------------------------------------------------------------------
// <copyright file="IBlockchainSettings.cs" company="Nomis">
// Copyright (c) Nomis, 2023. All rights reserved.
// The Application under the MIT license. See LICENSE file in the solution root for full license information.
// </copyright>
// ------------------------------------------------------------------------------------------------------

using Nomis.Utils.Contracts.Common;

namespace Nomis.Blockchain.Abstractions.Contracts
{
    /// <summary>
    /// Blockchain settings.
    /// </summary>
    public interface IBlockchainSettings :
        ISettings
    {
        /// <inheritdoc cref="IBlockchainDescriptor"/>
        public BlockchainDescriptor? BlockchainDescriptor { get; set; }
    }
}