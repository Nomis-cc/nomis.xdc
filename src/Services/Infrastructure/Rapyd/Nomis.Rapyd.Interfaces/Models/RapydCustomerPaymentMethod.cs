// ------------------------------------------------------------------------------------------------------
// <copyright file="RapydCustomerPaymentMethod.cs" company="Nomis">
// Copyright (c) Nomis, 2023. All rights reserved.
// The Application under the MIT license. See LICENSE file in the solution root for full license information.
// </copyright>
// ------------------------------------------------------------------------------------------------------

using System.Text.Json.Serialization;

namespace Nomis.Rapyd.Interfaces.Models
{
    /// <summary>
    /// Rapyd customer payment method.
    /// </summary>
    /// <remarks>
    /// <see href="https://docs.rapyd.net/build-with-rapyd/reference/customer-payment-method#customer-payment-method-object"/>
    /// </remarks>
    public class RapydCustomerPaymentMethod
    {
        /// <summary>
        /// ID of the Payment Method object. String starting with card_ or other_.
        /// </summary>
        [JsonPropertyName("id")]
        public string? Id { get; set; }

        /// <summary>
        /// Name of the payment method type.
        /// </summary>
        /// <example>us_mastercard_card</example>
        [JsonPropertyName("type")]
        public string? Type { get; set; }

        /// <summary>
        /// Category of payment method. Possible values:
        /// <para>bank_redirect</para>
        /// <para>bank_transfer</para>
        /// <para>card</para>
        /// <para>card_to_card</para>
        /// <para>cash</para>
        /// <para>ewallet</para>
        /// <para>rapyd_ewallet</para>
        /// </summary>
        /// <example>bank_redirect</example>
        [JsonPropertyName("category")]
        public string? Category { get; set; }

        /// <summary>
        /// A JSON object defined by the client.
        /// </summary>
        [JsonPropertyName("metadata")]
        public object? Metadata { get; set; }

        /// <summary>
        /// A URL to the image of the icon for the type of payment method. Response only.
        /// </summary>
        [JsonPropertyName("image")]
        public string? Image { get; set; }

        /// <summary>
        /// Reserved. Response only.
        /// </summary>
        [JsonPropertyName("webhook_url")]
        public string? WebhookUrl { get; set; }

        /// <summary>
        /// Reserved. Response only.
        /// </summary>
        [JsonPropertyName("supporting_documentation")]
        public string? SupportingDocumentation { get; set; }

        /// <summary>
        /// Indicates the next action for completing the payment. Response only. One of the following values:
        /// <para>
        /// 3d_verification - The next action is 3DS authentication.
        /// To simulate 3DS authentication in the sandbox,
        /// <see href="https://docs.rapyd.net/build-with-rapyd/reference-link/simulating-3ds-authentication">Simulating 3DS Authentication</see>.
        /// Relevant only to card payments.
        /// </para>
        /// <para>
        /// pending_capture - The next action is pending the capture of the amount.
        /// Relevant only to card payments when the amount is not zero.
        /// </para>
        /// <para>
        /// pending_confirmation - The next action is pending the confirmation for the payment.
        /// Relevant to all payment methods excluding card payment.
        /// </para>
        /// <para>
        /// not_applicable - The payment has completed or the next action is not relevant.
        /// </para>
        /// </summary>
        /// <example>3d_verification</example>
        [JsonPropertyName("next_action")]
        public string? NextAction { get; set; }

        /// <summary>
        /// Name.
        /// </summary>
        /// <example>John Doe</example>
        [JsonPropertyName("name")]
        public string? Name { get; set; }

        /// <summary>
        /// Last four digits of the bank account or IBAN (International Bank Account Number). Response only.
        /// </summary>
        /// <example>1111</example>
        [JsonPropertyName("last4")]
        public string? Last4 { get; set; }

        /// <summary>
        /// TODO.
        /// </summary>
        /// <example>unchecked</example>
        [JsonPropertyName("acs_check")]
        public string? AcsCheck { get; set; }

        /// <summary>
        /// TODO.
        /// </summary>
        /// <example>unchecked</example>
        [JsonPropertyName("cvv_check")]
        public string? CvvCheck { get; set; }

        /// <summary>
        /// BIN details.
        /// </summary>
        [JsonPropertyName("bin_details")]
        public RapydBinDetails? BinDetails { get; set; }

        /// <summary>
        /// Expiration year.
        /// </summary>
        /// <example>25</example>
        [JsonPropertyName("expiration_year")]
        public string? ExpirationYear { get; set; }

        /// <summary>
        /// Expiration month.
        /// </summary>
        /// <example>12</example>
        [JsonPropertyName("expiration_month")]
        public string? ExpirationMonth { get; set; }

        /// <summary>
        /// TODO.
        /// </summary>
        /// <example>ocfp_e599f990674473ce6283b245e9ad2467</example>
        [JsonPropertyName("fingerprint_token")]
        public string? FingerprintToken { get; set; }
    }
}