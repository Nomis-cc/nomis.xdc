// ------------------------------------------------------------------------------------------------------
// <copyright file="TatumController.cs" company="Nomis">
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
using Nomis.Tatum.Interfaces;
using Nomis.Tatum.Interfaces.Enums;
using Nomis.Tatum.Interfaces.Models;
using Nomis.Utils.Wrapper;
using Swashbuckle.AspNetCore.Annotations;

namespace Nomis.Api.Tatum
{
    /// <summary>
    /// A controller to aggregate all Tatum-related actions.
    /// </summary>
    [Route(BasePath)]
    [ApiVersion("1")]
    [SwaggerTag("Tatum Payment API.")]
    public sealed class TatumController :
        ControllerBase
    {
        /// <summary>
        /// Base path for routing.
        /// </summary>
        internal const string BasePath = "api/v{version:apiVersion}/tatum";

        /// <summary>
        /// Common tag for Tatum actions.
        /// </summary>
        internal const string TatumTag = "Tatum";

        private readonly ILogger<TatumController> _logger;
        private readonly ITatumUtilsService _tatumService;

        /// <summary>
        /// Initialize <see cref="TatumController"/>.
        /// </summary>
        /// <param name="tatumExplorerService"><see cref="ITatumUtilsService"/>.</param>
        /// <param name="logger"><see cref="ILogger{T}"/>.</param>
        public TatumController(
            ITatumUtilsService tatumExplorerService,
            ILogger<TatumController> logger)
        {
            _tatumService = tatumExplorerService ?? throw new ArgumentNullException(nameof(tatumExplorerService));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        /// <summary>
        /// Get the current exchange rate for exchanging fiat/crypto assets.
        /// </summary>
        /// <returns>Returns exchange rate data.</returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET /api/v1/tatum/rate/5?basePair=6
        /// </remarks>
        /// <param name="currency" example="BTC">The fiat or crypto asset to exchange.</param>
        /// <param name="basePair" example="EUR">The target fiat asset to get the exchange rate for.</param>
        /// <response code="200">Returns exchange rate data.</response>
        /// <response code="400">Request not valid.</response>
        /// <response code="404">No data found.</response>
        /// <response code="500">Unknown internal error.</response>
        [HttpGet("rate/{currency}", Name = "GetTatumCurrentExchangeRate")]
        [AllowAnonymous]
        [SwaggerOperation(
            OperationId = "GetTatumCurrentExchangeRate",
            Tags = new[] { TatumTag })]
        [ProducesResponseType(typeof(Result<TatumExchangeRate?>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResult<string>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorResult<string>), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(RateLimitResult), StatusCodes.Status429TooManyRequests)]
        [ProducesResponseType(typeof(ErrorResult<string>), StatusCodes.Status500InternalServerError)]
        [Produces(MediaTypeNames.Application.Json)]
        public async Task<IActionResult> GetTatumCurrentExchangeRateAsync(
            [FromRoute] TatumExchangeCurrency currency = TatumExchangeCurrency.BTC,
            [FromQuery] TatumExchangeCurrency basePair = TatumExchangeCurrency.USD)
        {
            var result = await _tatumService.GetCurrentExchangeRateAsync(currency, basePair);
            return Ok(result);
        }
    }
}