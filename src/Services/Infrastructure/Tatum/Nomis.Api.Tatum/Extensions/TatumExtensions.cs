// ------------------------------------------------------------------------------------------------------
// <copyright file="TatumExtensions.cs" company="Nomis">
// Copyright (c) Nomis, 2023. All rights reserved.
// The Application under the MIT license. See LICENSE file in the solution root for full license information.
// </copyright>
// ------------------------------------------------------------------------------------------------------

using Nomis.Api.Common.Extensions;
using Nomis.Api.Tatum.Settings;
using Nomis.ScoringService.Interfaces.Builder;
using Nomis.Tatum.Interfaces;

namespace Nomis.Api.Tatum.Extensions
{
    /// <summary>
    /// Tatum extension methods.
    /// </summary>
    public static class TatumExtensions
    {
        /// <summary>
        /// Add Tatum API.
        /// </summary>
        /// <typeparam name="TServiceRegistrar">The service registrar type.</typeparam>
        /// <param name="optionsBuilder"><see cref="IScoringOptionsBuilder"/>.</param>
        /// <returns>Returns <see cref="IScoringOptionsBuilder"/>.</returns>
        // ReSharper disable once InconsistentNaming
        public static IScoringOptionsBuilder WithTatumAPI<TServiceRegistrar>(
            this IScoringOptionsBuilder optionsBuilder)
            where TServiceRegistrar : ITatumServiceRegistrar, new()
        {
            return optionsBuilder
                .With<TatumAPISettings, TServiceRegistrar>();
        }
    }
}