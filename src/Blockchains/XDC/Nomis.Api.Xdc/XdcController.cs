// ------------------------------------------------------------------------------------------------------
// <copyright file="XdcController.cs" company="Nomis">
// Copyright (c) Nomis, 2023. All rights reserved.
// The Application under the MIT license. See LICENSE file in the solution root for full license information.
// </copyright>
// ------------------------------------------------------------------------------------------------------

using System.ComponentModel.DataAnnotations;
using System.Net.Mime;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Nomis.Api.Common.Swagger.Examples;
using Nomis.Utils.Enums;
using Nomis.Utils.Wrapper;
using Nomis.Xdcscan.Interfaces;
using Nomis.Xdcscan.Interfaces.Models;
using Nomis.Xdcscan.Interfaces.Requests;
using Swashbuckle.AspNetCore.Annotations;

namespace Nomis.Api.Xdc
{
    /// <summary>
    /// A controller to aggregate all XDC-related actions.
    /// </summary>
    [Route(BasePath)]
    [ApiVersion("1")]
    [SwaggerTag("XDC Network blockchain.")]
    public sealed class XdcController :
        ControllerBase
    {
        /// <summary>
        /// Base path for routing.
        /// </summary>
        internal const string BasePath = "api/v{version:apiVersion}/xdc";

        /// <summary>
        /// Common tag for XDC actions.
        /// </summary>
        internal const string XdcTag = "Xdc";

        private readonly ILogger<XdcController> _logger;
        private readonly IXdcScoringService _scoringService;

        /// <summary>
        /// Initialize <see cref="XdcController"/>.
        /// </summary>
        /// <param name="scoringService"><see cref="IXdcScoringService"/>.</param>
        /// <param name="logger"><see cref="ILogger{T}"/>.</param>
        public XdcController(
            IXdcScoringService scoringService,
            ILogger<XdcController> logger)
        {
            _scoringService = scoringService ?? throw new ArgumentNullException(nameof(scoringService));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        /// <summary>
        /// Get Nomis Score for given wallet address.
        /// </summary>
        /// <param name="request">Request for getting the wallet stats.</param>
        /// <param name="cancellationToken"><see cref="CancellationToken"/>.</param>
        /// <returns>An Nomis Score value and corresponding statistical data.</returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET /api/v1/xdc/wallet/xdc86871225DFD426A132DaAbDA85a9E13A0164bB4d/score?scoreType=0&amp;nonce=0&amp;deadline=133160867380732039
        /// </remarks>
        /// <response code="200">Returns Nomis Score and stats.</response>
        /// <response code="400">Address not valid.</response>
        /// <response code="404">No data found.</response>
        /// <response code="500">Unknown internal error.</response>
        [HttpGet("wallet/{address}/score", Name = "GetXdcWalletScore")]
        [AllowAnonymous]
        [SwaggerOperation(
            OperationId = "GetXdcWalletScore",
            Tags = new[] { XdcTag })]
        [ProducesResponseType(typeof(Result<XdcWalletScore>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResult<string>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorResult<string>), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(RateLimitResult), StatusCodes.Status429TooManyRequests)]
        [ProducesResponseType(typeof(ErrorResult<string>), StatusCodes.Status500InternalServerError)]
        [Produces(MediaTypeNames.Application.Json)]
        public async Task<IActionResult> GetXdcWalletScoreAsync(
            [Required(ErrorMessage = "Request should be set")] XdcWalletStatsRequest request,
            CancellationToken cancellationToken = default)
        {
            switch (request.ScoreType)
            {
                case ScoreType.Finance:
                    return Ok(await _scoringService.GetWalletStatsAsync<XdcWalletStatsRequest, XdcWalletScore, XdcWalletStats, XdcTransactionIntervalData>(request, cancellationToken));
                default:
                    throw new NotImplementedException();
            }
        }
    }
}