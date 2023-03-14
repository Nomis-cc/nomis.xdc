// ------------------------------------------------------------------------------------------------------
// <copyright file="TatumApi.cs" company="Nomis">
// Copyright (c) Nomis, 2023. All rights reserved.
// The Application under the MIT license. See LICENSE file in the solution root for full license information.
// </copyright>
// ------------------------------------------------------------------------------------------------------

using Microsoft.Extensions.DependencyInjection;
using Nomis.Tatum.Extensions;
using Nomis.Tatum.Interfaces;

namespace Nomis.Tatum
{
    /// <summary>
    /// Tatum API service registrar.
    /// </summary>
    public sealed class TatumApi :
        ITatumServiceRegistrar
    {
        /// <inheritdoc/>
        public IServiceCollection RegisterService(
            IServiceCollection services)
        {
            return services
                .AddTatumService();
        }
    }
}