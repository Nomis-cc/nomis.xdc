// ------------------------------------------------------------------------------------------------------
// <copyright file="IRapydService.cs" company="Nomis">
// Copyright (c) Nomis, 2023. All rights reserved.
// The Application under the MIT license. See LICENSE file in the solution root for full license information.
// </copyright>
// ------------------------------------------------------------------------------------------------------

using Nomis.Rapyd.Interfaces.Models;
using Nomis.Rapyd.Interfaces.Requests;
using Nomis.Utils.Contracts.Services;
using Nomis.Utils.Wrapper;

namespace Nomis.Rapyd.Interfaces
{
    /// <summary>
    /// Rapyd service.
    /// </summary>
    public interface IRapydService :
        IInfrastructureService
    {
        /// <summary>
        /// Retrieve a list of all customers.
        /// </summary>
        /// <remarks>
        /// <see href="https://docs.rapyd.net/build-with-rapyd/reference/customer#list-customers"/>.
        /// </remarks>
        /// <returns>Returns a list of all customers.</returns>
        Task<Result<List<RapydCustomer>>> GetCustomersAsync();

        /// <summary>
        /// Create a customer profile to save the payment methods a customer can use.
        /// </summary>
        /// <remarks>
        /// <see href="https://docs.rapyd.net/build-with-rapyd/reference/customer#create-customer"/>.
        /// </remarks>
        /// <param name="body">The request body.</param>
        /// <returns>Returns a created customer.</returns>
        Task<Result<RapydCustomer?>> CreateCustomerAsync(RapydCreateCustomerBody body);

        /// <summary>
        /// Retrieve checkout data by id.
        /// </summary>
        /// <remarks>
        /// <see href="https://docs.rapyd.net/build-with-rapyd/reference/checkout-page#retrieve-checkout-page"/>.
        /// </remarks>
        /// <param name="checkoutId">ID of the checkout page object. String starting with 'checkout_'.</param>
        /// <returns>Returns checkout data.</returns>
        Task<Result<RapydCheckout?>> GetCheckoutAsync(string checkoutId);

        /// <summary>
        /// Create a checkout page that makes a payment.
        /// </summary>
        /// <remarks>
        /// <see href="https://docs.rapyd.net/build-with-rapyd/reference/checkout-page#create-checkout-page"/>.
        /// </remarks>
        /// <param name="body">The request body.</param>
        /// <returns>Returns a checkout page data.</returns>
        Task<Result<RapydCheckout?>> CreatePaymentCheckoutAsync(RapydCreateCheckoutBody body);

        /// <summary>
        /// Retrieve a list of all payment methods available for a country.
        /// </summary>
        /// <remarks>
        /// <see href="https://docs.rapyd.net/build-with-rapyd/reference/payment-method-type#list-payment-methods-by-country"/>.
        /// </remarks>
        /// <param name="country">The country code.</param>
        /// <returns>Returns a list of all payment methods available for a country.</returns>
        Task<Result<List<RapydPaymentMethod>>> GetPaymentMethodsAsync(string country);

        /// <summary>
        /// Retrieve the required fields for a payment method.
        /// </summary>
        /// <remarks>
        /// The fields are returned as a list of objects. The name of each field appears in the name field of the response.
        /// <para>
        /// <see href="https://docs.rapyd.net/build-with-rapyd/reference/payment-method-type#get-payment-method-required-fields"/>.
        /// </para>
        /// </remarks>
        /// <param name="type">The type of the payment method.</param>
        /// <returns>Returns the required fields for a payment method.</returns>
        Task<Result<RapydPaymentMethodRequiredFields?>> GetPaymentMethodRequiredFieldsAsync(string type);

        /// <summary>
        /// Create a payment to collect money into a Rapyd Wallet.
        /// </summary>
        /// <remarks>
        /// <see href="https://docs.rapyd.net/build-with-rapyd/reference/payment#create-payment"/>.
        /// </remarks>
        /// <param name="body">The request body.</param>
        /// <returns>Returns a created payment data.</returns>
        Task<Result<RapydPayment?>> CreatePaymentAsync(RapydCreatePaymentBody body);

        /// <summary>
        /// Cancel a payment where the status of the payment is ACT.
        /// </summary>
        /// <remarks>
        /// <see href="https://docs.rapyd.net/build-with-rapyd/reference/payment#cancel-payment"/>.
        /// </remarks>
        /// <param name="paymentId">ID of the payment. String starting with payment_.</param>
        /// <returns>Returns a cancelled payment data.</returns>
        Task<Result<RapydPayment?>> CancelPaymentAsync(string paymentId);

        /// <summary>
        /// List all the payment methods of a customer.
        /// </summary>
        /// <remarks>
        /// <see href="https://docs.rapyd.net/build-with-rapyd/reference/customer-payment-method#list-payment-methods-of-customer"/>.
        /// </remarks>
        /// <param name="customerId">D of the 'customer' object. String starting with cus_.</param>
        /// <returns>Returns a list of customer payment methods.</returns>
        Task<Result<List<RapydCustomerPaymentMethod>>> GetCustomerPaymentMethodsAsync(string customerId);
    }
}