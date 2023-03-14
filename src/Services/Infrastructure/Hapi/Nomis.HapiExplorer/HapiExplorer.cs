// ------------------------------------------------------------------------------------------------------
// <copyright file="HapiExplorer.cs" company="Nomis">
// Copyright (c) Nomis, 2023. All rights reserved.
// The Application under the MIT license. See LICENSE file in the solution root for full license information.
// </copyright>
// ------------------------------------------------------------------------------------------------------

using Microsoft.Extensions.DependencyInjection;
using Nomis.HapiExplorer.Extensions;
using Nomis.HapiExplorer.Interfaces;

namespace Nomis.HapiExplorer
{
    /// <summary>
    /// HapiExplorer service registrar.
    /// </summary>
    public sealed class HapiExplorer :
        IHapiServiceRegistrar
    {
        /// <inheritdoc/>
        public IServiceCollection RegisterService(
            IServiceCollection services)
        {
            return services
                .AddHapiExplorerService();
        }
    }
}