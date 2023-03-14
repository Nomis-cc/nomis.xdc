// ------------------------------------------------------------------------------------------------------
// <copyright file="RapydExtensions.cs" company="Nomis">
// Copyright (c) Nomis, 2023. All rights reserved.
// The Application under the MIT license. See LICENSE file in the solution root for full license information.
// </copyright>
// ------------------------------------------------------------------------------------------------------

using Nomis.Api.Common.Extensions;
using Nomis.Api.Rapyd.Settings;
using Nomis.Rapyd.Interfaces;
using Nomis.ScoringService.Interfaces.Builder;

namespace Nomis.Api.Rapyd.Extensions
{
    /// <summary>
    /// Rapyd extension methods.
    /// </summary>
    public static class RapydExtensions
    {
        /// <summary>
        /// Add Rapyd payment API.
        /// </summary>
        /// <typeparam name="TServiceRegistrar">The service registrar type.</typeparam>
        /// <param name="optionsBuilder"><see cref="IScoringOptionsBuilder"/>.</param>
        /// <returns>Returns <see cref="IScoringOptionsBuilder"/>.</returns>
        // ReSharper disable once InconsistentNaming
        public static IScoringOptionsBuilder WithRapydPaymentAPI<TServiceRegistrar>(
            this IScoringOptionsBuilder optionsBuilder)
            where TServiceRegistrar : IRapydServiceRegistrar, new()
        {
            return optionsBuilder
                .With<RapydAPISettings, TServiceRegistrar>();
        }
    }
}