// ------------------------------------------------------------------------------------------------------
// <copyright file="DefiLlamaApi.cs" company="Nomis">
// Copyright (c) Nomis, 2023. All rights reserved.
// The Application under the MIT license. See LICENSE file in the solution root for full license information.
// </copyright>
// ------------------------------------------------------------------------------------------------------

using Microsoft.Extensions.DependencyInjection;
using Nomis.DefiLlama.Extensions;
using Nomis.DefiLlama.Interfaces;

namespace Nomis.DefiLlama
{
    /// <summary>
    /// DefiLlama API service registrar.
    /// </summary>
    public sealed class DefiLlamaApi :
        IDefiLlamaServiceRegistrar
    {
        /// <inheritdoc/>
        public IServiceCollection RegisterService(
            IServiceCollection services)
        {
            return services
                .AddDefiLlamaService();
        }
    }
}