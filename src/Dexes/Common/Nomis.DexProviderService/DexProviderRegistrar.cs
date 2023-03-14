// ------------------------------------------------------------------------------------------------------
// <copyright file="DexProviderRegistrar.cs" company="Nomis">
// Copyright (c) Nomis, 2023. All rights reserved.
// The Application under the MIT license. See LICENSE file in the solution root for full license information.
// </copyright>
// ------------------------------------------------------------------------------------------------------

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Nomis.DexProviderService.Extensions;
using Nomis.DexProviderService.Interfaces;

namespace Nomis.DexProviderService
{
    /// <summary>
    /// DEX provider service registrar.
    /// </summary>
    public sealed class DexProviderRegistrar :
        IDexProviderServiceRegistrar
    {
        /// <inheritdoc/>
        public IServiceCollection RegisterService(
            IServiceCollection services)
        {
            var serviceProvider = services.BuildServiceProvider();
            var configuration = serviceProvider.GetRequiredService<IConfiguration>();
            return services
                .AddDexProviderService(configuration);
        }
    }
}