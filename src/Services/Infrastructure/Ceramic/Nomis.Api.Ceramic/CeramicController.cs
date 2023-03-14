// ------------------------------------------------------------------------------------------------------
// <copyright file="CeramicController.cs" company="Nomis">
// Copyright (c) Nomis, 2023. All rights reserved.
// The Application under the MIT license. See LICENSE file in the solution root for full license information.
// </copyright>
// ------------------------------------------------------------------------------------------------------

using System.Net.Mime;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Nomis.Api.Common.Swagger.Examples;
using Nomis.Ceramic.Interfaces;
using Nomis.Ceramic.Interfaces.Models;
using Nomis.Ceramic.Interfaces.Requests;
using Nomis.Utils.Wrapper;
using Swashbuckle.AspNetCore.Annotations;

namespace Nomis.Api.Ceramic
{
    /// <summary>
    /// A controller to aggregate all Ceramic-related actions.
    /// </summary>
    [Route(BasePath)]
    [ApiVersion("1")]
    [SwaggerTag("Ceramic API.")]
    public sealed class CeramicController :
        ControllerBase
    {
        /// <summary>
        /// Base path for routing.
        /// </summary>
        internal const string BasePath = "api/v{version:apiVersion}/ceramic";

        /// <summary>
        /// Common tag for Ceramic actions.
        /// </summary>
        internal const string CeramicTag = "Ceramic";

        private readonly ILogger<CeramicController> _logger;
        private readonly ICeramicService _ceramicService;

        /// <summary>
        /// Initialize <see cref="CeramicController"/>.
        /// </summary>
        /// <param name="ceramicExplorerService"><see cref="ICeramicService"/>.</param>
        /// <param name="logger"><see cref="ILogger{T}"/>.</param>
        public CeramicController(
            ICeramicService ceramicExplorerService,
            ILogger<CeramicController> logger)
        {
            _ceramicService = ceramicExplorerService ?? throw new ArgumentNullException(nameof(ceramicExplorerService));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        /// <summary>
        /// Get the state of a stream given its StreamID.
        /// </summary>
        /// <param name="streamId">The StreamID of the requested stream as string.</param>
        /// <returns>Returns the state of a stream.</returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET /api/v1/ceramic/streams/kjzl6cwe1jw145gkad3p7i1cawlbm1wbtzldx79ac95szmcpap69xbbqb3rpzsu
        /// </remarks>
        /// <response code="200">Returns the state of a stream.</response>
        /// <response code="400">Request data not valid.</response>
        /// <response code="404">No data found.</response>
        /// <response code="500">Unknown internal error.</response>
        [HttpGet("streams/{streamId}", Name = "GetCeramicStreamState")]
        [AllowAnonymous]
        [SwaggerOperation(
            OperationId = "GetCeramicStreamState",
            Tags = new[] { CeramicTag })]
        [ProducesResponseType(typeof(Result<CeramicStream?>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResult<string>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorResult<string>), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(RateLimitResult), StatusCodes.Status429TooManyRequests)]
        [ProducesResponseType(typeof(ErrorResult<string>), StatusCodes.Status500InternalServerError)]
        [Produces(MediaTypeNames.Application.Json)]
        public async Task<IActionResult> StreamStateAsync(
            string streamId)
        {
            var result = await _ceramicService.StreamAsync(streamId);
            return Ok(result);
        }

        /// <summary>
        /// Get all commits in a stream.
        /// </summary>
        /// <param name="streamId">The StreamID of the requested stream as string.</param>
        /// <returns>Returns the commits of a stream.</returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET /api/v1/ceramic/commits/kjzl6cwe1jw145gkad3p7i1cawlbm1wbtzldx79ac95szmcpap69xbbqb3rpzsu
        /// </remarks>
        /// <response code="200">Returns the commits of a stream.</response>
        /// <response code="400">Request data not valid.</response>
        /// <response code="404">No data found.</response>
        /// <response code="500">Unknown internal error.</response>
        [HttpGet("commits/{streamId}", Name = "GetCeramicStreamCommits")]
        [AllowAnonymous]
        [SwaggerOperation(
            OperationId = "GetCeramicStreamCommits",
            Tags = new[] { CeramicTag })]
        [ProducesResponseType(typeof(Result<CeramicCommits?>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResult<string>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorResult<string>), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(RateLimitResult), StatusCodes.Status429TooManyRequests)]
        [ProducesResponseType(typeof(ErrorResult<string>), StatusCodes.Status500InternalServerError)]
        [Produces(MediaTypeNames.Application.Json)]
        public async Task<IActionResult> StreamCommitsAsync(
            string streamId)
        {
            var result = await _ceramicService.CommitsAsync(streamId);
            return Ok(result);
        }

        /// <summary>
        /// Create the stream given its StreamID.
        /// </summary>
        /// <param name="request">The create stream request.</param>
        /// <returns>Returns the state of a created stream.</returns>
        /// <response code="200">Returns the state of a created stream.</response>
        /// <response code="400">Request data not valid.</response>
        /// <response code="404">No data found.</response>
        /// <response code="500">Unknown internal error.</response>
        [HttpPost("streams", Name = "CreateCeramicStream")]
        [AllowAnonymous]
        [SwaggerOperation(
            OperationId = "CreateCeramicStream",
            Tags = new[] { CeramicTag })]
        [ProducesResponseType(typeof(Result<CeramicStream?>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResult<string>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorResult<string>), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(RateLimitResult), StatusCodes.Status429TooManyRequests)]
        [ProducesResponseType(typeof(ErrorResult<string>), StatusCodes.Status500InternalServerError)]
        [Produces(MediaTypeNames.Application.Json)]
        public async Task<IActionResult> CreateStreamAsync(
            [FromBody] CreateStreamRequest request)
        {
            var result = await _ceramicService.CreateStreamAsync(request);
            return Ok(result);
        }

        /// <summary>
        /// Update the stream given its StreamID.
        /// </summary>
        /// <param name="request">The update stream request.</param>
        /// <returns>Returns the state of an updated stream.</returns>
        /// <response code="200">Returns the state of an updated stream.</response>
        /// <response code="400">Request data not valid.</response>
        /// <response code="404">No data found.</response>
        /// <response code="500">Unknown internal error.</response>
        [HttpPost("commits", Name = "UpdateCeramicStream")]
        [AllowAnonymous]
        [SwaggerOperation(
            OperationId = "UpdateCeramicStream",
            Tags = new[] { CeramicTag })]
        [ProducesResponseType(typeof(Result<CeramicStream?>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResult<string>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorResult<string>), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(RateLimitResult), StatusCodes.Status429TooManyRequests)]
        [ProducesResponseType(typeof(ErrorResult<string>), StatusCodes.Status500InternalServerError)]
        [Produces(MediaTypeNames.Application.Json)]
        public async Task<IActionResult> UpdateStreamAsync(
            [FromBody] UpdateStreamRequest request)
        {
            var result = await _ceramicService.UpdateStreamAsync(request);
            return Ok(result);
        }
    }
}