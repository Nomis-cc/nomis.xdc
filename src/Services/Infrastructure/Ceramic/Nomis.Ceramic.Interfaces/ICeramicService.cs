// ------------------------------------------------------------------------------------------------------
// <copyright file="ICeramicService.cs" company="Nomis">
// Copyright (c) Nomis, 2023. All rights reserved.
// The Application under the MIT license. See LICENSE file in the solution root for full license information.
// </copyright>
// ------------------------------------------------------------------------------------------------------

using Nomis.Ceramic.Interfaces.Models;
using Nomis.Ceramic.Interfaces.Requests;
using Nomis.Utils.Contracts.Services;
using Nomis.Utils.Wrapper;

namespace Nomis.Ceramic.Interfaces
{
    /// <summary>
    /// Ceramic API service.
    /// </summary>
    public interface ICeramicService :
        IInfrastructureService
    {
        /// <summary>
        /// Get the state of a stream given its StreamID.
        /// </summary>
        /// <param name="streamId">The StreamID of the requested stream as string.</param>
        /// <returns>Returns <see cref="CeramicStream"/></returns>
        Task<Result<CeramicStream?>> StreamAsync(
            string streamId);

        /// <summary>
        /// Get all commits in a stream.
        /// </summary>
        /// <param name="streamId">The StreamID of the requested stream as string.</param>
        /// <returns>Returns <see cref="CeramicCommits"/></returns>
        Task<Result<CeramicCommits?>> CommitsAsync(
            string streamId);

        /// <summary>
        /// Create the stream.
        /// </summary>
        /// <param name="request">The create stream request.</param>
        /// <returns>Returns <see cref="CeramicStream"/></returns>
        Task<Result<CeramicStream?>> CreateStreamAsync(
            CreateStreamRequest request);

        /// <summary>
        /// Update the stream.
        /// </summary>
        /// <param name="request">The create stream request.</param>
        /// <returns>Returns <see cref="CeramicStream"/></returns>
        Task<Result<CeramicStream?>> UpdateStreamAsync(
            UpdateStreamRequest request);
    }
}