// ------------------------------------------------------------------------------------------------------
// <copyright file="RapydCreateCheckoutBody.cs" company="Nomis">
// Copyright (c) Nomis, 2023. All rights reserved.
// The Application under the MIT license. See LICENSE file in the solution root for full license information.
// </copyright>
// ------------------------------------------------------------------------------------------------------

using System.Text.Json.Serialization;

namespace Nomis.Rapyd.Interfaces.Requests
{
    /// <summary>
    /// Rapyd create checkout body.
    /// </summary>
    public class RapydCreateCheckoutBody
    {
        /// <summary>
        /// The amount of the payment, in units of the currency defined in currency.
        /// Required if cart_items is not used. Decimal.
        /// </summary>
        /// <example>123.45</example>
        [JsonPropertyName("amount")]
        public decimal Amount { get; set; }

        /// <summary>
        /// The two-letter ISO 3166-1 ALPHA-2 code for the country.
        /// </summary>
        /// <example>SG</example>
        [JsonPropertyName("country")]
        public string? Country { get; set; }

        /// <summary>
        /// Defines the currency for the amount. Three-letter ISO 4217 code.
        /// </summary>
        /// <example>SGD</example>
        [JsonPropertyName("currency")]
        public string? Currency { get; set; }

        /// <summary>
        /// ID of the 'customer' object. String starting with cus_.
        /// When used, the customer has the option to save card details for future purchases.
        /// This field is required for certain production mode payment methods.
        /// </summary>
        /// <example>cus_xxxxxxxxxxxxxxxxxxxxxxxx</example>
        [JsonPropertyName("customer")]
        public string? CustomerId { get; set; }

        /// <summary>
        /// URL where the customer is redirected when payment is successful.
        /// Relevant to bank redirect payment methods.
        /// </summary>
        /// <example>http://example.com/complete</example>
        [JsonPropertyName("complete_payment_url")]
        public string? CompletePaymentUrl { get; set; }

        /// <summary>
        /// URL where the customer is redirected when payment is not successful.
        /// Relevant to bank redirect payment methods.
        /// </summary>
        /// <example>http://example.com/error</example>
        [JsonPropertyName("error_payment_url")]
        public string? ErrorPaymentUrl { get; set; }

        /// <summary>
        /// URL where the customer is redirected when payment is successful. Relevant to bank redirect payment methods.
        /// </summary>
        /// <example>http://example.com/checkout</example>
        [JsonPropertyName("complete_checkout_url")]
        public string? CompleteCheckoutUrl { get; set; }

        /// <summary>
        /// URL where the customer is redirected after pressing Back to Website to exit the hosted page.
        /// This URL overrides the merchant_website URL.
        /// Does not support localhost URLs.
        /// </summary>
        /// <example>http://example.com/checkout-cancel</example>
        [JsonPropertyName("cancel_checkout_url")]
        public string? CancelCheckoutUrl { get; set; }
    }
}