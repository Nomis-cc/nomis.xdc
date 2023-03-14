// ------------------------------------------------------------------------------------------------------
// <copyright file="Aave.cs" company="Nomis">
// Copyright (c) Nomis, 2023. All rights reserved.
// The Application under the MIT license. See LICENSE file in the solution root for full license information.
// </copyright>
// ------------------------------------------------------------------------------------------------------

using Microsoft.Extensions.DependencyInjection;
using Nomis.Aave.Extensions;
using Nomis.Aave.Interfaces;

namespace Nomis.Aave
{
    /// <summary>
    /// Aave service registrar.
    /// </summary>
    public sealed class Aave :
        IAaveServiceRegistrar
    {
        /// <inheritdoc/>
        public IServiceCollection RegisterService(
            IServiceCollection services)
        {
            return services
                .AddAaveService();
        }
    }
}