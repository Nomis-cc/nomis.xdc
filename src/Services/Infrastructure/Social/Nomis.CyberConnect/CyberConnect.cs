// ------------------------------------------------------------------------------------------------------
// <copyright file="CyberConnect.cs" company="Nomis">
// Copyright (c) Nomis, 2023. All rights reserved.
// The Application under the MIT license. See LICENSE file in the solution root for full license information.
// </copyright>
// ------------------------------------------------------------------------------------------------------

using Microsoft.Extensions.DependencyInjection;
using Nomis.CyberConnect.Extensions;
using Nomis.CyberConnect.Interfaces;

namespace Nomis.CyberConnect
{
    /// <summary>
    /// CyberConnect service registrar.
    /// </summary>
    public sealed class CyberConnect :
        ICyberConnectServiceRegistrar
    {
        /// <inheritdoc/>
        public IServiceCollection RegisterService(
            IServiceCollection services)
        {
            return services
                .AddCyberConnectService();
        }
    }
}