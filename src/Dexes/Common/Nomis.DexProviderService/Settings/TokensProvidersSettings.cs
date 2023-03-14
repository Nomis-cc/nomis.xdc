// ------------------------------------------------------------------------------------------------------
// <copyright file="TokensProvidersSettings.cs" company="Nomis">
// Copyright (c) Nomis, 2023. All rights reserved.
// The Application under the MIT license. See LICENSE file in the solution root for full license information.
// </copyright>
// ------------------------------------------------------------------------------------------------------

using Nomis.DexProviderService.Contracts;
using Nomis.Utils.Contracts.Common;

namespace Nomis.DexProviderService.Settings
{
    /// <summary>
    /// Tokens providers settings.
    /// </summary>
    public class TokensProvidersSettings :
        ISettings
    {
        /// <summary>
        /// Use caching.
        /// </summary>
        public bool UseCaching { get; set; }

        /// <summary>
        /// Cache sliding expiration time.
        /// </summary>
        public TimeSpan CacheSlidingExpiration { get; set; }

        /// <summary>
        /// List of tokens providers.
        /// </summary>
        public IList<TokensProviderData> TokensProviders { get; set; } = new List<TokensProviderData>();
    }
}