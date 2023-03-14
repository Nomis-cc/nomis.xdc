// ------------------------------------------------------------------------------------------------------
// <copyright file="CeramicExtensions.cs" company="Nomis">
// Copyright (c) Nomis, 2023. All rights reserved.
// The Application under the MIT license. See LICENSE file in the solution root for full license information.
// </copyright>
// ------------------------------------------------------------------------------------------------------

using Nomis.Api.Ceramic.Settings;
using Nomis.Api.Common.Extensions;
using Nomis.Ceramic.Interfaces;
using Nomis.ScoringService.Interfaces.Builder;

namespace Nomis.Api.Ceramic.Extensions
{
    /// <summary>
    /// Ceramic extension methods.
    /// </summary>
    public static class CeramicExtensions
    {
        /// <summary>
        /// Add Ceramic API.
        /// </summary>
        /// <typeparam name="TServiceRegistrar">The service registrar type.</typeparam>
        /// <param name="optionsBuilder"><see cref="IScoringOptionsBuilder"/>.</param>
        /// <returns>Returns <see cref="IScoringOptionsBuilder"/>.</returns>
        // ReSharper disable once InconsistentNaming
        public static IScoringOptionsBuilder WithCeramicAPI<TServiceRegistrar>(
            this IScoringOptionsBuilder optionsBuilder)
            where TServiceRegistrar : ICeramicServiceRegistrar, new()
        {
            return optionsBuilder
                .With<CeramicAPISettings, TServiceRegistrar>();
        }
    }
}