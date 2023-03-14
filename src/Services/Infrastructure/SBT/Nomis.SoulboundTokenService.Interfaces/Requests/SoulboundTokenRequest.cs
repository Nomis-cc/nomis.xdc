// ------------------------------------------------------------------------------------------------------
// <copyright file="SoulboundTokenRequest.cs" company="Nomis">
// Copyright (c) Nomis, 2023. All rights reserved.
// The Application under the MIT license. See LICENSE file in the solution root for full license information.
// </copyright>
// ------------------------------------------------------------------------------------------------------

using Nomis.Utils.Enums;

namespace Nomis.SoulboundTokenService.Interfaces.Requests
{
    /// <summary>
    /// Soulbound token request.
    /// </summary>
    public class SoulboundTokenRequest
    {
        /// <summary>
        /// To address.
        /// </summary>
        /// <example>0x0000000000000000000000000000000000000000</example>
        public string? To { get; set; }

        /// <summary>
        /// The score type.
        /// </summary>
        /// <example>0</example>
        public ScoreType ScoreType { get; set; }

        /// <summary>
        /// Score value.
        /// </summary>
        /// <example>14</example>
        public ushort Score { get; set; }

        /// <summary>
        /// Nonce.
        /// </summary>
        /// <example>0</example>
        public ulong Nonce { get; set; }

        /// <summary>
        /// Blockchain id.
        /// </summary>
        /// <example>5</example>
        public ulong ChainId { get; set; }

        /// <summary>
        /// Soulbound token contract address.
        /// </summary>
        /// <example>0x0000000000000000000000000000000000000000</example>
        public string? ContractAddress { get; set; }

        /// <summary>
        /// Time to the verifying deadline.
        /// </summary>
        /// <example>0</example>
        public ulong Deadline { get; set; }
    }
}