// ------------------------------------------------------------------------------------------------------
// <copyright file="SnapshotHub.cs" company="Nomis">
// Copyright (c) Nomis, 2023. All rights reserved.
// The Application under the MIT license. See LICENSE file in the solution root for full license information.
// </copyright>
// ------------------------------------------------------------------------------------------------------

using Microsoft.Extensions.DependencyInjection;
using Nomis.Snapshot.Extensions;
using Nomis.Snapshot.Interfaces;

namespace Nomis.Snapshot
{
    /// <summary>
    /// SnapshotHub service registrar.
    /// </summary>
    public sealed class SnapshotHub :
        ISnapshotServiceRegistrar
    {
        /// <inheritdoc/>
        public IServiceCollection RegisterService(
            IServiceCollection services)
        {
            return services
                .AddSnapshotService();
        }
    }
}