// ------------------------------------------------------------------------------------------------------
// <copyright file="RapydCreatePaymentBody.cs" company="Nomis">
// Copyright (c) Nomis, 2023. All rights reserved.
// The Application under the MIT license. See LICENSE file in the solution root for full license information.
// </copyright>
// ------------------------------------------------------------------------------------------------------

using System.Text.Json.Serialization;

namespace Nomis.Rapyd.Interfaces.Requests
{
    /// <summary>
    /// Rapyd create payment body.
    /// </summary>
    public class RapydCreatePaymentBody
    {
        /// <summary>
        /// The amount of the payment, in units of the currency defined in currency. Decimal.
        /// Note: If you are using JavaScript, you must pass this value as a string if it is not an integer amount.
        /// </summary>
        /// <example>0</example>
        [JsonPropertyName("amount")]
        public float Amount { get; set; }

        /// <summary>
        /// URL where the customer is redirected after a successful payment. Required for bank redirect payment methods.
        /// </summary>
        [JsonPropertyName("complete_payment_url")]
        public string? CompletePaymentUrl { get; set; }

        /// <summary>
        /// In transactions without FX, defines the currency received in the Rapyd wallet.
        /// In FX transactions, when fixed_side is buy, it is the currency received in the Rapyd wallet.
        /// When fixed_side is sell, it is the currency charged to the buyer.
        /// See also fixed_side and requested_currency fields. Three-letter ISO 4217 code.
        /// </summary>
        /// <example>USD</example>
        [JsonPropertyName("currency")]
        public string? Currency { get; set; }

        /// <summary>
        /// ID of the customer who is making the payment. String starting with cus_. Required if payment_method is blank.
        /// </summary>
        [JsonPropertyName("customer")]
        public string? CustomerId { get; set; }

        /// <summary>
        /// Description of the payment.
        /// </summary>
        [JsonPropertyName("description")]
        public string? Description { get; set; }

        /// <summary>
        /// URL where the customer is redirected in case of an error in the payment. Required for bank redirect payment methods.
        /// </summary>
        [JsonPropertyName("error_payment_url")]
        public string? ErrorPaymentUrl { get; set; }

        /// <summary>
        /// End of the time allowed for customer to make this payment,
        /// in <see href="https://docs.rapyd.net/build-with-rapyd/reference-link/glossary">Unix time</see>.
        /// Must be after the current time.
        /// </summary>
        [JsonPropertyName("expiration")]
        public int? Expiration { get; set; }

        /// <summary>
        /// payment_method ID or object.
        /// If not specified in this field, the payment method is the default payment method specified for the customer.
        /// Mandatory when there is no default payment method.
        /// <para>
        /// For a description of the fields in the payment_method object, <see href="https://docs.rapyd.net/build-with-rapyd/reference-link/customer-payment-method-object">Customer Payment Method Object</see>.
        /// </para>
        /// </summary>
        /// <example>other_7f991f72a4c14c5cd79627ebc21241de</example>
        [JsonPropertyName("payment_method")]
        public string? PaymentMethodId { get; set; }

        /// <summary>
        /// Email address that the receipt for this transaction is sent to.
        /// </summary>
        [JsonPropertyName("receipt_email")]
        public string? ReceiptEmail { get; set; }
    }
}