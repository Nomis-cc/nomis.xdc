// ------------------------------------------------------------------------------------------------------
// <copyright file="RapydCheckout.cs" company="Nomis">
// Copyright (c) Nomis, 2023. All rights reserved.
// The Application under the MIT license. See LICENSE file in the solution root for full license information.
// </copyright>
// ------------------------------------------------------------------------------------------------------

using System.Text.Json.Serialization;

namespace Nomis.Rapyd.Interfaces.Models
{
    /// <summary>
    /// Rapyd checkout.
    /// </summary>
    public class RapydCheckout
    {
        /// <summary>
        /// ID of the Rapyd checkout page. String starting with checkout_.
        /// </summary>
        /// <example>checkout_xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx</example>
        [JsonPropertyName("id")]
        public string? Id { get; set; }

        /// <summary>
        /// The amount of the payment, in units of the currency defined in currency.
        /// Decimal, including the correct number of decimal places for the currency exponent, as defined in ISO 2417:2015.
        /// If the amount is a whole number, use an integer and not a decimal.
        /// </summary>
        /// <example>123.45</example>
        [JsonPropertyName("amount")]
        public decimal Amount { get; set; }

        /// <summary>
        /// URL where the customer is redirected after pressing Back to Website to exit the hosted page.
        /// This URL overrides the merchant_website URL.
        /// Does not support localhost URLs.
        /// </summary>
        /// <example>http://example.com/checkout-cancel</example>
        [JsonPropertyName("cancel_checkout_url")]
        public string? CancelCheckoutUrl { get; set; }

        /// <summary>
        /// URL where the customer is redirected after pressing Finish to exit the hosted page.
        /// This URL overrides the merchant_website URL.
        /// Does not support localhost URLs.
        /// </summary>
        /// <example>http://example.com/checkout</example>
        [JsonPropertyName("complete_checkout_url")]
        public string? CompleteCheckoutUrl { get; set; }

        /// <summary>
        /// The two-letter ISO 3166-1 ALPHA-2 code for the country.
        /// </summary>
        /// <example>SG</example>
        [JsonPropertyName("country")]
        public string? Country { get; set; }

        /// <summary>
        /// Defines the currency for the amount received by the seller (merchant). Three-letter ISO 4217 code.
        /// </summary>
        /// <example>SGD</example>
        [JsonPropertyName("currency")]
        public string? Currency { get; set; }

        /// <summary>
        /// ID of the customer. String starting with cus_.
        /// When used, the customer has the option to save card details for future purchases.
        /// This field is required for certain production mode payment methods.
        /// </summary>
        /// <example>cus_xxxxxxxxxxxxxxxxxxxxxxxx</example>
        [JsonPropertyName("customer")]
        public string? CustomerId { get; set; }

        /// <summary>
        /// Describes the payment that will result from the hosted page.
        /// The id and status values are null until the customer successfully submits the information on the hosted page.
        /// Response only.
        /// </summary>
        [JsonPropertyName("payment")]
        public RapydPayment? Payment { get; set; }

        /// <summary>
        /// End of the time when the customer can use the hosted page, in <see href="https://docs.rapyd.net/build-with-rapyd/reference-link/glossary">Unix time</see>.
        /// If page_expiration is not set, the checkout page expires 14 days after creation. Range: 1 minute to 30 days.
        /// </summary>
        /// <example>1671655867</example>
        [JsonPropertyName("page_expiration")]
        public int PageExpiration { get; set; }

        /// <summary>
        /// URL of the checkout page that is shown to the customer.
        /// </summary>
        /// <example>https://sandboxcheckout.rapyd.net?token=checkout_xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx</example>
        [JsonPropertyName("redirect_url")]
        public string? RedirectUrl { get; set; }

        /// <summary>
        /// Status of the hosted page. One of the following:
        /// <para>NEW - The hosted page was created.</para>
        /// <para>DON - Done. The payment was completed.</para>
        /// <para>EXP - The hosted page expired.</para>
        /// <para>INP - Creation of the payment is still in progress.</para>
        /// <para>DEC - Rapyd Protect blocked the payment.</para>
        /// </summary>
        /// <example>DON</example>
        [JsonPropertyName("status")]
        public string? Status { get; set; }

        /// <summary>
        /// Time of creation of the checkout page, in <see href="https://docs.rapyd.net/build-with-rapyd/reference-link/glossary">Unix time</see>. Response only.
        /// </summary>
        /// <example>1670446207</example>
        [JsonPropertyName("timestamp")]
        public int Timestamp { get; set; }
    }
}