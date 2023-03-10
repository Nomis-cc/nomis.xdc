// ------------------------------------------------------------------------------------------------------
// <copyright file="XdcscanAccountXRC20TokenEvents.cs" company="Nomis">
// Copyright (c) Nomis, 2023. All rights reserved.
// The Application under the MIT license. See LICENSE file in the solution root for full license information.
// </copyright>
// ------------------------------------------------------------------------------------------------------

using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Nomis.Xdcscan.Interfaces.Models
{
    /// <summary>
    /// Xdcscan account XRC-20 token transfer events.
    /// </summary>
    // ReSharper disable once InconsistentNaming
    public class XdcscanAccountXRC20TokenEvents :
        IXdcscanTransferList<XdcscanAccountXRC20TokenEvent>
    {
        /// <summary>
        /// Total.
        /// </summary>
        [JsonPropertyName("total")]
        public long Total { get; set; }

        /// <summary>
        /// Per page.
        /// </summary>
        [JsonPropertyName("perPage")]
        public long PerPage { get; set; }

        /// <summary>
        /// Current page.
        /// </summary>
        [JsonPropertyName("currentPage")]
        public long CurrentPage { get; set; }

        /// <summary>
        /// Pages.
        /// </summary>
        [JsonPropertyName("pages")]
        public long Pages { get; set; }

        /// <summary>
        /// Account XRC-20 token event list.
        /// </summary>
        [JsonPropertyName("items")]
        [DataMember(EmitDefaultValue = true)]
        public IList<XdcscanAccountXRC20TokenEvent> Items { get; set; } = new List<XdcscanAccountXRC20TokenEvent>();
    }
}