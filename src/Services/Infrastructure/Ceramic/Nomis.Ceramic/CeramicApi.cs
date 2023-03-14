// ------------------------------------------------------------------------------------------------------
// <copyright file="CeramicApi.cs" company="Nomis">
// Copyright (c) Nomis, 2023. All rights reserved.
// The Application under the MIT license. See LICENSE file in the solution root for full license information.
// </copyright>
// ------------------------------------------------------------------------------------------------------

using Microsoft.Extensions.DependencyInjection;
using Nomis.Ceramic.Extensions;
using Nomis.Ceramic.Interfaces;

namespace Nomis.Ceramic
{
    /// <summary>
    /// Ceramic API service registrar.
    /// </summary>
    public sealed class CeramicApi :
        ICeramicServiceRegistrar
    {
        /// <inheritdoc/>
        public IServiceCollection RegisterService(
            IServiceCollection services)
        {
            return services
                .AddCeramicService();
        }
    }
}