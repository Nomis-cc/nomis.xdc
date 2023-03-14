// ------------------------------------------------------------------------------------------------------
// <copyright file="XdcWalletStatsRequest.cs" company="Nomis">
// Copyright (c) Nomis, 2023. All rights reserved.
// The Application under the MIT license. See LICENSE file in the solution root for full license information.
// </copyright>
// ------------------------------------------------------------------------------------------------------

using Nomis.Blockchain.Abstractions.Requests;

namespace Nomis.Xdcscan.Interfaces.Requests
{
    /// <summary>
    /// Request for getting the wallet stats for XDC.
    /// </summary>
    public sealed class XdcWalletStatsRequest :
        BaseEvmWalletStatsRequest
    {
    }
}