// ------------------------------------------------------------------------------------------------------
// <copyright file="ApiCommonSettings.cs" company="Nomis">
// Copyright (c) Nomis, 2023. All rights reserved.
// The Application under the MIT license. See LICENSE file in the solution root for full license information.
// </copyright>
// ------------------------------------------------------------------------------------------------------

using Nomis.Utils.Contracts.Common;

namespace Nomis.Api.Common.Settings
{
    /// <summary>
    /// API common settings.
    /// </summary>
    /// <remarks>
    /// <see href="https://github.com/stefanprodan/AspNetCoreRateLimit/wiki/IpRateLimitMiddleware#setup"/>.
    /// </remarks>
    public class ApiCommonSettings :
        ISettings
    {
        /// <summary>
        /// Use rate limiting.
        /// </summary>
        public bool UseRateLimiting { get; set; }

        /// <summary>
        /// Use Redis caching.
        /// </summary>
        public bool UseRedisCaching { get; set; }

        /// <summary>
        /// Use Swagger caching.
        /// </summary>
        public bool UseSwaggerCaching { get; set; }
    }
}