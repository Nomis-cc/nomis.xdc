// ------------------------------------------------------------------------------------------------------
// <copyright file="RapydService.cs" company="Nomis">
// Copyright (c) Nomis, 2023. All rights reserved.
// The Application under the MIT license. See LICENSE file in the solution root for full license information.
// </copyright>
// ------------------------------------------------------------------------------------------------------

using System.Security.Cryptography;
using System.Text;
using System.Text.Json;

using Microsoft.Extensions.Options;
using Nomis.Rapyd.Interfaces;
using Nomis.Rapyd.Interfaces.Models;
using Nomis.Rapyd.Interfaces.Requests;
using Nomis.Rapyd.Interfaces.Responses;
using Nomis.Rapyd.Settings;
using Nomis.Utils.Contracts.Services;
using Nomis.Utils.Exceptions;
using Nomis.Utils.Wrapper;
using RestSharp;

namespace Nomis.Rapyd
{
    /// <inheritdoc cref="IRapydService"/>
    internal sealed class RapydService :
        IRapydService,
        ISingletonService
    {
        private readonly RestClient _client;
        private readonly string _accessKey;
        private readonly string _secretKey;

        /// <summary>
        /// Initialize <see cref="RapydService"/>.
        /// </summary>
        /// <param name="rapydOptions"><see cref="RapydSettings"/>.</param>
        public RapydService(
            IOptions<RapydSettings> rapydOptions)
        {
            _client = new(rapydOptions.Value.ApiBaseUrl ?? throw new ArgumentNullException(nameof(rapydOptions.Value.ApiBaseUrl)));
            _accessKey = rapydOptions.Value.AccessKey ?? throw new ArgumentNullException(nameof(rapydOptions.Value.AccessKey));
            _secretKey = rapydOptions.Value.SecretKey ?? throw new ArgumentNullException(nameof(rapydOptions.Value.SecretKey));
        }

        #region Customer

        /// <inheritdoc />
        public async Task<Result<List<RapydCustomer>>> GetCustomersAsync()
        {
            var apiResponse = await MakeRequest<RapydResponse<List<RapydCustomer>>>(Method.Get, "/v1/customers").ConfigureAwait(false);
            var result = apiResponse;
            return await Result<List<RapydCustomer>>.SuccessAsync(result?.Data ?? new List<RapydCustomer>(), "Got a list of all customers.").ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<Result<RapydCustomer?>> CreateCustomerAsync(RapydCreateCustomerBody body)
        {
            var apiResponse = await MakeRequest<RapydResponse<RapydCustomer>>(Method.Post, "/v1/customers", body).ConfigureAwait(false);
            var result = apiResponse;
            return await Result<RapydCustomer?>.SuccessAsync(result?.Data, "Customer created successfully.").ConfigureAwait(false);
        }

        #endregion Customer

        #region Payment

        /// <inheritdoc />
        public async Task<Result<RapydCheckout?>> CreatePaymentCheckoutAsync(RapydCreateCheckoutBody body)
        {
            var apiResponse = await MakeRequest<RapydResponse<RapydCheckout>>(Method.Post, "/v1/checkout", body).ConfigureAwait(false);
            var result = apiResponse?.Data;
            return await Result<RapydCheckout?>.SuccessAsync(result, "Payment checkout created successfully.").ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<Result<RapydCheckout?>> GetCheckoutAsync(string checkoutId)
        {
            var apiResponse = await MakeRequest<RapydResponse<RapydCheckout>>(Method.Get, $"/v1/checkout/{checkoutId}").ConfigureAwait(false);
            var result = apiResponse?.Data;
            return await Result<RapydCheckout?>.SuccessAsync(result, "Got checkout data.").ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<Result<List<RapydPaymentMethod>>> GetPaymentMethodsAsync(string country)
        {
            var apiResponse = await MakeRequest<RapydResponse<List<RapydPaymentMethod>>>(Method.Get, $"/v1/payment_methods/country?country={country}").ConfigureAwait(false);
            var result = apiResponse?.Data ?? new List<RapydPaymentMethod>();
            return await Result<List<RapydPaymentMethod>>.SuccessAsync(result, "Got payment methods.").ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<Result<RapydPaymentMethodRequiredFields?>> GetPaymentMethodRequiredFieldsAsync(string type)
        {
            var apiResponse = await MakeRequest<RapydResponse<RapydPaymentMethodRequiredFields>>(Method.Get, $"/v1/payment_methods/required_fields/{type}").ConfigureAwait(false);
            var result = apiResponse?.Data;
            return await Result<RapydPaymentMethodRequiredFields?>.SuccessAsync(result, "Got payment method required fields.").ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<Result<RapydPayment?>> CreatePaymentAsync(RapydCreatePaymentBody body)
        {
            var apiResponse = await MakeRequest<RapydResponse<RapydPayment>>(Method.Post, "/v1/payments", body).ConfigureAwait(false);
            var result = apiResponse?.Data;
            return await Result<RapydPayment?>.SuccessAsync(result, "Payment created successfully.").ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<Result<RapydPayment?>> CancelPaymentAsync(string paymentId)
        {
            var apiResponse = await MakeRequest<RapydResponse<RapydPayment>>(Method.Delete, $"/v1/payments/{paymentId}").ConfigureAwait(false);
            var result = apiResponse?.Data;
            return await Result<RapydPayment?>.SuccessAsync(result, "Payment cancelled successfully.").ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<Result<List<RapydCustomerPaymentMethod>>> GetCustomerPaymentMethodsAsync(string customerId)
        {
            var apiResponse = await MakeRequest<RapydResponse<List<RapydCustomerPaymentMethod>>>(Method.Get, $"/v1/customers/{customerId}/payment_methods").ConfigureAwait(false);
            var result = apiResponse?.Data ?? new();
            return await Result<List<RapydCustomerPaymentMethod>>.SuccessAsync(result, "Got customer payment methods.").ConfigureAwait(false);
        }

        #endregion Payment

        #region Private methods

        private async Task<T?> MakeRequest<T>(Method method, string urlPath, object? body = null)
        {
            var request = PrepareRequest(method, urlPath, body);
            var response = await _client.ExecuteAsync<T>(request).ConfigureAwait(false);
            if (response.ResponseStatus != ResponseStatus.Completed)
            {
                throw new CustomException(response.Data != null ? JsonSerializer.Serialize(response.Data) : response.Content ?? string.Empty);
            }

            return response.Data;
        }

        private RestRequest PrepareRequest(Method method, string httpUrlPath, object? body = null)
        {
            var request = new RestRequest(httpUrlPath);
            string httpBody = body is null ? string.Empty : JsonSerializer.Serialize(body);
            string salt = GenerateRandomString(8);
            long timestamp = DateTimeOffset.Now.ToUnixTimeSeconds();
            string signature = GenerateSign(method.ToString(), httpUrlPath, salt, timestamp, httpBody);

            request.Method = method;
            request.AddHeader("salt", salt);
            request.AddHeader("timestamp", timestamp.ToString());
            request.AddHeader("signature", signature);
            request.AddHeader("access_key", _accessKey);

            if (body != null)
            {
                request.AddJsonBody(body);
            }

            return request;
        }

        private string GenerateSign(string method, string urlPath, string salt, long timestamp, string body)
        {
            string bodyString = string.Empty;
            if (!string.IsNullOrWhiteSpace(body))
            {
                bodyString = string.Equals(body, "{}", StringComparison.OrdinalIgnoreCase) ? string.Empty : body;
            }

            string toSign = method.ToLower() + urlPath + salt + timestamp + _accessKey + _secretKey + bodyString;

            var encoding = new UTF8Encoding();
            byte[] secretKeyBytes = encoding.GetBytes(_secretKey);
            byte[] signatureBytes = encoding.GetBytes(toSign);
            using var hmac = new HMACSHA256(secretKeyBytes);
            byte[] signatureHash = hmac.ComputeHash(signatureBytes);
            string signatureHex = string.Concat(Array.ConvertAll(signatureHash, x => x.ToString("x2")));

            return Convert.ToBase64String(encoding.GetBytes(signatureHex));
        }

        private string GenerateSignForWebhookAuth(string urlPath, string salt, long timestamp, string body)
        {
            string bodyString = string.Empty;
            if (!string.IsNullOrWhiteSpace(body))
            {
                bodyString = string.Equals(body, "{}", StringComparison.OrdinalIgnoreCase) ? string.Empty : body;
            }

            string toSign = urlPath + salt + timestamp + _accessKey + _secretKey + bodyString;

            var encoding = new UTF8Encoding();
            byte[] secretKeyBytes = encoding.GetBytes(_secretKey);
            byte[] signatureBytes = encoding.GetBytes(toSign);
            using var hmac = new HMACSHA256(secretKeyBytes);
            byte[] signatureHash = hmac.ComputeHash(signatureBytes);
            string signatureHex = string.Concat(Array.ConvertAll(signatureHash, x => x.ToString("x2")));

            return Convert.ToBase64String(encoding.GetBytes(signatureHex));
        }

        private string GenerateRandomString(int size)
        {
            using var rng = RandomNumberGenerator.Create();
            byte[] randomBytes = new byte[size];
            rng.GetBytes(randomBytes);
            return string.Concat(Array.ConvertAll(randomBytes, x => x.ToString("x2")));
        }

        #endregion Private methods
    }
}