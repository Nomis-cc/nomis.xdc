// ------------------------------------------------------------------------------------------------------
// <copyright file="ServiceCollectionExtensions.cs" company="Nomis">
// Copyright (c) Nomis, 2023. All rights reserved.
// The Application under the MIT license. See LICENSE file in the solution root for full license information.
// </copyright>
// ------------------------------------------------------------------------------------------------------

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Nomis.SoulboundTokenService.Interfaces;
using Nomis.SoulboundTokenService.Settings;
using Nomis.Utils.Extensions;

namespace Nomis.SoulboundTokenService.Extensions
{
    /// <summary>
    /// <see cref="IServiceCollection"/> extension methods.
    /// </summary>
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Add soulbound token service.
        /// </summary>
        /// <remarks>
        /// Is EVM-compatible.
        /// </remarks>
        /// <param name="services"><see cref="IServiceCollection"/>.</param>
        /// <returns>Returns <see cref="IServiceCollection"/>.</returns>
        internal static IServiceCollection AddEvmSoulboundTokenService(
            this IServiceCollection services)
        {
            var serviceProvider = services.BuildServiceProvider();
            var configuration = serviceProvider.GetRequiredService<IConfiguration>();
            services.AddSettings<SoulboundTokenSettings>(configuration);
            return services
                .AddTransientInfrastructureService<IEvmSoulboundTokenService, EvmSoulboundTokenService>();
        }

        /// <summary>
        /// Add soulbound token service.
        /// </summary>
        /// <remarks>
        /// Is not EVM-compatible.
        /// </remarks>
        /// <param name="services"><see cref="IServiceCollection"/>.</param>
        /// <returns>Returns <see cref="IServiceCollection"/>.</returns>
        internal static IServiceCollection AddNonEvmSoulboundTokenService(
            this IServiceCollection services)
        {
            var serviceProvider = services.BuildServiceProvider();
            var configuration = serviceProvider.GetRequiredService<IConfiguration>();
            services.AddSettings<SoulboundTokenSettings>(configuration);
            return services
                .AddTransientInfrastructureService<INonEvmSoulboundTokenService, NonEvmSoulboundTokenService>();
        }
    }
}