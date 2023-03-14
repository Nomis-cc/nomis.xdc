// ------------------------------------------------------------------------------------------------------
// <copyright file="CeramicService.cs" company="Nomis">
// Copyright (c) Nomis, 2023. All rights reserved.
// The Application under the MIT license. See LICENSE file in the solution root for full license information.
// </copyright>
// ------------------------------------------------------------------------------------------------------

using System.Net.Http.Json;
using System.Text.Json;

using Microsoft.Extensions.Options;
using Nomis.Ceramic.Converters;
using Nomis.Ceramic.Interfaces;
using Nomis.Ceramic.Interfaces.Models;
using Nomis.Ceramic.Interfaces.Requests;
using Nomis.Ceramic.Settings;
using Nomis.Utils.Contracts.Services;
using Nomis.Utils.Wrapper;

namespace Nomis.Ceramic
{
    /// <inheritdoc cref="ICeramicService"/>
    internal sealed class CeramicService :
        ICeramicService,
        ISingletonService
    {
        private readonly HttpClient _client;

        public CeramicService(
            IOptions<CeramicSettings> ceramicOptions)
        {
            _client = new()
            {
                BaseAddress = new(ceramicOptions.Value.ApiBaseUrl ?? throw new ArgumentNullException(nameof(ceramicOptions.Value.ApiBaseUrl)))
            };
        }

        /// <inheritdoc />
        public async Task<Result<CeramicStream?>> StreamAsync(
            string streamId)
        {
            var response = await _client.GetAsync($"/api/v0/streams/{streamId}").ConfigureAwait(false);
            if (!response.IsSuccessStatusCode)
            {
                return await Result<CeramicStream?>.FailAsync(null, new List<string> { response.ReasonPhrase ?? "There is an error when getting the state of a stream." }).ConfigureAwait(false);
            }

            var result = await response.Content.ReadFromJsonAsync<CeramicStream?>(new JsonSerializerOptions
            {
                Converters = { new AnchorStatusConverter() }
            }).ConfigureAwait(false);

            return await Result<CeramicStream?>.SuccessAsync(result, "Successfully got the state of a stream.").ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<Result<CeramicCommits?>> CommitsAsync(
            string streamId)
        {
            var response = await _client.GetAsync($"/api/v0/commits/{streamId}").ConfigureAwait(false);
            if (!response.IsSuccessStatusCode)
            {
                return await Result<CeramicCommits?>.FailAsync(null, new List<string> { response.ReasonPhrase ?? "There is an error when getting the commits of a stream." }).ConfigureAwait(false);
            }

            var result = await response.Content.ReadFromJsonAsync<CeramicCommits?>().ConfigureAwait(false);

            return await Result<CeramicCommits?>.SuccessAsync(result, "Successfully got the commits of a stream.").ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<Result<CeramicStream?>> CreateStreamAsync(
            CreateStreamRequest request)
        {
            var response = await _client.PostAsJsonAsync("/api/v0/streams", request).ConfigureAwait(false);
            if (!response.IsSuccessStatusCode)
            {
                return await Result<CeramicStream?>.FailAsync(null, new List<string> { response.ReasonPhrase ?? "There is an error when creating the stream." }).ConfigureAwait(false);
            }

            var result = await response.Content.ReadFromJsonAsync<CeramicStream?>(new JsonSerializerOptions
            {
                Converters = { new AnchorStatusConverter() }
            }).ConfigureAwait(false);

            return await Result<CeramicStream?>.SuccessAsync(result, "Successfully create the stream.").ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<Result<CeramicStream?>> UpdateStreamAsync(
            UpdateStreamRequest request)
        {
            var response = await _client.PostAsJsonAsync("/api/v0/commits", request).ConfigureAwait(false);
            if (!response.IsSuccessStatusCode)
            {
                return await Result<CeramicStream?>.FailAsync(null, new List<string> { response.ReasonPhrase ?? "There is an error when updating the stream." }).ConfigureAwait(false);
            }

            var result = await response.Content.ReadFromJsonAsync<CeramicStream?>(new JsonSerializerOptions
            {
                Converters = { new AnchorStatusConverter() }
            }).ConfigureAwait(false);

            return await Result<CeramicStream?>.SuccessAsync(result, "Successfully update the stream.").ConfigureAwait(false);
        }
    }
}