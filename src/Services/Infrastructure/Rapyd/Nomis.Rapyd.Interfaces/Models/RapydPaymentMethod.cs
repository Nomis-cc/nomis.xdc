// ------------------------------------------------------------------------------------------------------
// <copyright file="RapydPaymentMethod.cs" company="Nomis">
// Copyright (c) Nomis, 2023. All rights reserved.
// The Application under the MIT license. See LICENSE file in the solution root for full license information.
// </copyright>
// ------------------------------------------------------------------------------------------------------

using System.Text.Json.Serialization;

namespace Nomis.Rapyd.Interfaces.Models
{
    /// <summary>
    /// Rapyd payment method.
    /// </summary>
    public class RapydPaymentMethod
    {
        /// <summary>
        /// Type of the payment method.
        /// </summary>
        /// <example>it_visa_card</example>
        [JsonPropertyName("type")]
        public string? Type { get; set; }

        /// <summary>
        /// The name of the payment method, in user-friendly terms. Response only.
        /// </summary>
        /// <example>Ireland Visa card</example>
        [JsonPropertyName("name")]
        public string? Name { get; set; }

        /// <summary>
        /// Category of payment method. Possible values:
        /// <para>bank_redirect</para>
        /// <para>bank_transfer</para>
        /// <para>card</para>
        /// <para>cash</para>
        /// <para>ewallet</para>
        /// <para>rapyd_ewallet</para>
        /// </summary>
        [JsonPropertyName("category")]
        public string? Category { get; set; }

        /// <summary>
        /// A URL to the image of the icon for the type of payment method. Response only.
        /// </summary>
        [JsonPropertyName("image")]
        public string? Image { get; set; }

        /// <summary>
        /// Name of the country where this payment method is in use. Two-letter ISO 3166-1 alpha-2 code.
        /// </summary>
        /// <remarks>
        /// <see href="https://docs.rapyd.net/build-with-rapyd/reference-link/list-countries"/>.
        /// </remarks>
        [JsonPropertyName("country")]
        public string? Country { get; set; }

        /// <summary>
        /// Indicates how the customer completes the payment transaction. Possible values:
        /// <para>bank redirect - The customer is directed to another URL to complete the bank payment.</para>
        /// <para>bank transfer - Customer makes a transfer directly from the customer's bank to a bank account.</para>
        /// <para>card - Rapyd charges the customer's card.</para>
        /// <para>otc - The customer pays in cash at a Rapyd point-of-sale location. To find nearby locations, <see href="https://docs.rapyd.net/build-with-rapyd/reference-link/location-object">Location Object</see>.</para>
        /// <para>ewallet - The customer pays from a local eWallet.</para>
        /// </summary>
        [JsonPropertyName("payment_flow_type")]
        public string? PaymentFlowType { get; set; }

        /// <summary>
        /// A list of currencies in use in the country for this type of payment method. Three-letter ISO 4217 format. Response only.
        /// </summary>
        [JsonPropertyName("currencies")]
        public IList<string> Currencies { get; set; } = new List<string>();

        /// <summary>
        /// Indicates the status of the payment method. One of the following values:
        /// <para>1 - Valid.</para>
        /// </summary>
        [JsonPropertyName("status")]
        public int Status { get; set; }

        /// <summary>
        /// Indicates whether a payment made with this payment method can be canceled. Response only.
        /// </summary>
        [JsonPropertyName("is_cancelable")]
        public bool IsCancelable { get; set; }

        /// <summary>
        /// Additional fields of the Payment object which are required for the payment.
        /// In the request to create payment, these fields appear in the root of the body of the request.
        /// </summary>
        /// <remarks>
        /// To determine the fields required, run <see href="https://docs.rapyd.net/build-with-rapyd/reference-link/get-payment-method-required-fields">Get Payment Method Required Fields</see>.
        /// </remarks>
        [JsonPropertyName("payment_options")]
        public IList<RapydPaymentOption> PaymentOptions { get; set; } = new List<RapydPaymentOption>();

        /// <summary>
        /// Indicates whether the merchant can set an expiration time for the customer to complete the payment. Response only.
        /// </summary>
        [JsonPropertyName("is_expirable")]
        public bool IsExpirable { get; set; }

        /// <summary>
        /// Indicates whether the payment is completed immediately online. Response only.
        /// </summary>
        [JsonPropertyName("is_online")]
        public bool IsOnline { get; set; }

        /// <summary>
        /// Indicates whether the payment method type supports refunds.
        /// </summary>
        [JsonPropertyName("is_refundable")]
        public bool IsRefundable { get; set; }

        /// <summary>
        /// The minimum time (in seconds) that the merchant can set for completing the payment. Relevant when is_expirable is true. Response only.
        /// </summary>
        [JsonPropertyName("minimum_expiration_seconds")]
        public int MinimumExpirationSeconds { get; set; }

        /// <summary>
        /// The maximum time (in seconds) that the merchant can set for completing the payment. Relevant when is_expirable is true. Response only.
        /// </summary>
        [JsonPropertyName("maximum_expiration_seconds")]
        public int MaximumExpirationSeconds { get; set; }

        /// <summary>
        /// Indicates the name of the Web-based version of this payment method type.
        /// </summary>
        [JsonPropertyName("virtual_payment_method_type")]
        public string? VirtualPaymentMethodType { get; set; }

        /// <summary>
        /// Indicates whether a Web-based version of the payment method type exists.
        /// </summary>
        [JsonPropertyName("is_virtual")]
        public bool IsVirtual { get; set; }

        /// <summary>
        /// Indicates whether multiple overage charges are allowed for this payment method type.
        /// </summary>
        [JsonPropertyName("multiple_overage_allowed")]
        public bool MultipleOverageAllowed { get; set; }

        /// <summary>
        /// Indicates the amount range for the payment method's currencies. Each object contains the following fields:
        /// <para>currency - Three-letter ISO 4217 format of currency.</para>
        /// <para>maximum_amount - The maximum payment amount.</para>
        /// <para>minimum_amount - The minimum payment amount.</para>
        /// </summary>
        [JsonPropertyName("amount_range_per_currency")]
        public IList<RapydAmountRangePerCurrency> AmountRangePerCurrency { get; set; } = new List<RapydAmountRangePerCurrency>();

        /// <summary>
        /// Indicates whether the token of the payment method can be used in a collect operation.
        /// </summary>
        [JsonPropertyName("is_tokenizable")]
        public bool IsTokenizable { get; set; }

        /// <summary>
        /// Describes the digital wallet providers that support the payment method.
        /// These providers may include apple_pay and google_pay.
        /// </summary>
        [JsonPropertyName("supported_digital_wallet_providers")]
        public IList<object> SupportedDigitalWalletProviders { get; set; } = new List<object>();
    }
}