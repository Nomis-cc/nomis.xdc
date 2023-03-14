// ------------------------------------------------------------------------------------------------------
// <copyright file="RapydController.cs" company="Nomis">
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
using Nomis.Rapyd.Interfaces;
using Nomis.Rapyd.Interfaces.Models;
using Nomis.Rapyd.Interfaces.Requests;
using Nomis.Utils.Wrapper;
using Swashbuckle.AspNetCore.Annotations;

namespace Nomis.Api.Rapyd
{
    /// <summary>
    /// A controller to aggregate all Rapyd-related actions.
    /// </summary>
    [Route(BasePath)]
    [ApiVersion("1")]
    [SwaggerTag("Rapyd Payment API.")]
    public sealed class RapydController :
        ControllerBase
    {
        /// <summary>
        /// Base path for routing.
        /// </summary>
        internal const string BasePath = "api/v{version:apiVersion}/rapyd";

        /// <summary>
        /// Common tag for Rapyd actions.
        /// </summary>
        internal const string RapydTag = "Rapyd";

        private readonly ILogger<RapydController> _logger;
        private readonly IRapydService _rapydService;

        /// <summary>
        /// Initialize <see cref="RapydController"/>.
        /// </summary>
        /// <param name="rapydExplorerService"><see cref="IRapydService"/>.</param>
        /// <param name="logger"><see cref="ILogger{T}"/>.</param>
        public RapydController(
            IRapydService rapydExplorerService,
            ILogger<RapydController> logger)
        {
            _rapydService = rapydExplorerService ?? throw new ArgumentNullException(nameof(rapydExplorerService));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        #region Customer

        /// <summary>
        /// Retrieve a list of all customers.
        /// </summary>
        /// <returns>Returns a list of all customers.</returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET /api/v1/rapyd/customers
        /// </remarks>
        /// <response code="200">Returns a list of all customers.</response>
        /// <response code="400">Request not valid.</response>
        /// <response code="404">No data found.</response>
        /// <response code="500">Unknown internal error.</response>
        [HttpGet("customers", Name = "GetRapydCustomers")]
        [AllowAnonymous]
        [SwaggerOperation(
            OperationId = "GetRapydCustomers",
            Tags = new[] { RapydTag })]
        [ProducesResponseType(typeof(Result<List<RapydCustomer>>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResult<string>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorResult<string>), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(RateLimitResult), StatusCodes.Status429TooManyRequests)]
        [ProducesResponseType(typeof(ErrorResult<string>), StatusCodes.Status500InternalServerError)]
        [Produces(MediaTypeNames.Application.Json)]
        public async Task<IActionResult> GetRapydCustomersAsync()
        {
            var result = await _rapydService.GetCustomersAsync();
            return Ok(result);
        }

        /// <summary>
        /// Create a customer profile to save the payment methods a customer can use.
        /// </summary>
        /// <returns>Returns a created customer.</returns>
        /// <param name="body">The request body.</param>
        /// <response code="200">Returns Rapyd created customer.</response>
        /// <response code="400">Request not valid.</response>
        /// <response code="404">No data found.</response>
        /// <response code="500">Unknown internal error.</response>
        [HttpPost("customer", Name = "CreateRapydCustomer")]
        [AllowAnonymous]
        [SwaggerOperation(
            OperationId = "CreateRapydCustomer",
            Tags = new[] { RapydTag })]
        [ProducesResponseType(typeof(Result<RapydCustomer?>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResult<string>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorResult<string>), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(RateLimitResult), StatusCodes.Status429TooManyRequests)]
        [ProducesResponseType(typeof(ErrorResult<string>), StatusCodes.Status500InternalServerError)]
        [Produces(MediaTypeNames.Application.Json)]
        public async Task<IActionResult> RapydCreateCustomerAsync(
            [FromBody, Required(ErrorMessage = "The request body is required.")] RapydCreateCustomerBody body)
        {
            var result = await _rapydService.CreateCustomerAsync(body);
            return Ok(result);
        }

        #endregion Customer

        #region Payment

        /// <summary>
        /// Create a checkout page that makes a payment.
        /// </summary>
        /// <returns>Returns a created customer.</returns>
        /// <param name="body">The request body.</param>
        /// <response code="200">Returns Rapyd created checkout page data.</response>
        /// <response code="400">Request not valid.</response>
        /// <response code="404">No data found.</response>
        /// <response code="500">Unknown internal error.</response>
        [HttpPost("checkout", Name = "CreateRapydPaymentCheckout")]
        [AllowAnonymous]
        [SwaggerOperation(
            OperationId = "CreateRapydPaymentCheckout",
            Tags = new[] { RapydTag })]
        [ProducesResponseType(typeof(Result<RapydCheckout?>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResult<string>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorResult<string>), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(RateLimitResult), StatusCodes.Status429TooManyRequests)]
        [ProducesResponseType(typeof(ErrorResult<string>), StatusCodes.Status500InternalServerError)]
        [Produces(MediaTypeNames.Application.Json)]
        public async Task<IActionResult> CreateRapydPaymentCheckoutAsync(
            [FromBody, Required(ErrorMessage = "The request body is required.")] RapydCreateCheckoutBody body)
        {
            var result = await _rapydService.CreatePaymentCheckoutAsync(body);
            return Ok(result);
        }

        /// <summary>
        /// Retrieve checkout data by id.
        /// </summary>
        /// <returns>Returns checkout data.</returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET /api/v1/rapyd/checkout/checkout_xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx
        /// </remarks>
        /// <param name="checkoutId" example="checkout_xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx">ID of the checkout page object. String starting with 'checkout_'.</param>
        /// <response code="200">Returns checkout data.</response>
        /// <response code="400">Request not valid.</response>
        /// <response code="404">No data found.</response>
        /// <response code="500">Unknown internal error.</response>
        [HttpGet("checkout/{checkoutId}", Name = "GetRapydCheckoutById")]
        [AllowAnonymous]
        [SwaggerOperation(
            OperationId = "GetRapydCheckoutById",
            Tags = new[] { RapydTag })]
        [ProducesResponseType(typeof(Result<RapydCheckout?>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResult<string>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorResult<string>), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(RateLimitResult), StatusCodes.Status429TooManyRequests)]
        [ProducesResponseType(typeof(ErrorResult<string>), StatusCodes.Status500InternalServerError)]
        [Produces(MediaTypeNames.Application.Json)]
        public async Task<IActionResult> GetRapydCheckoutByIdAsync(
            [FromRoute] string checkoutId)
        {
            var result = await _rapydService.GetCheckoutAsync(checkoutId);
            return Ok(result);
        }

        /// <summary>
        /// Retrieve a list of all payment methods available for a country.
        /// </summary>
        /// <returns>Returns a list of all payment methods available for a country.</returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET /api/v1/rapyd/payment_methods/US
        /// </remarks>
        /// <param name="country" example="CR">The country code.</param>
        /// <response code="200">Returns a list of all payment methods available for a country.</response>
        /// <response code="400">Request not valid.</response>
        /// <response code="404">No data found.</response>
        /// <response code="500">Unknown internal error.</response>
        [HttpGet("payment-methods/{country}", Name = "GetRapydPaymentMethods")]
        [AllowAnonymous]
        [SwaggerOperation(
            OperationId = "GetRapydPaymentMethods",
            Tags = new[] { RapydTag })]
        [ProducesResponseType(typeof(Result<List<RapydPaymentMethod>>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResult<string>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorResult<string>), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(RateLimitResult), StatusCodes.Status429TooManyRequests)]
        [ProducesResponseType(typeof(ErrorResult<string>), StatusCodes.Status500InternalServerError)]
        [Produces(MediaTypeNames.Application.Json)]
        public async Task<IActionResult> GetRapydPaymentMethodsAsync(
            [FromRoute] string country)
        {
            var result = await _rapydService.GetPaymentMethodsAsync(country);
            return Ok(result);
        }

        #endregion Payment
    }
}