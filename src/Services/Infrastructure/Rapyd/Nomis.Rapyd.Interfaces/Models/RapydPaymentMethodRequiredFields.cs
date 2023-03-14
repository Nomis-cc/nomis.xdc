// ------------------------------------------------------------------------------------------------------
// <copyright file="RapydPaymentMethodRequiredFields.cs" company="Nomis">
// Copyright (c) Nomis, 2023. All rights reserved.
// The Application under the MIT license. See LICENSE file in the solution root for full license information.
// </copyright>
// ------------------------------------------------------------------------------------------------------

using System.Text.Json.Serialization;

namespace Nomis.Rapyd.Interfaces.Models
{
    /// <summary>
    /// Rapyd payment method required fields.
    /// </summary>
    public class RapydPaymentMethodRequiredFields
    {
        /// <summary>
        /// Type of the payment method.
        /// </summary>
        /// <example>it_visa_card</example>
        [JsonPropertyName("type")]
        public string? Type { get; set; }

        /// <summary>
        /// Contains several fields that are used in creating the specific payment method.
        /// These fields always contain the same value for a payment method, so they are included in the payment method object.
        /// </summary>
        [JsonPropertyName("fields")]
        public IList<RapydField> Fields { get; set; } = new List<RapydField>();

        /// <summary>
        /// Additional fields required for the payment method. These values might vary from one use to the next, so they are not saved as part of the payment method object.
        /// In the request to create payment, these fields appear in the 'payment_method_options' object.
        /// </summary>
        [JsonPropertyName("payment_method_options")]
        public IList<RapydPaymentMethodOption> PaymentMethodOptions { get; set; } = new List<RapydPaymentMethodOption>();

        /// <summary>
        /// Additional fields of the Payment object which are required for the payment.
        /// In the request to create payment, these fields appear in the root of the body of the request.
        /// </summary>
        [JsonPropertyName("payment_options")]
        public IList<RapydPaymentOption> PaymentOptions { get; set; } = new List<RapydPaymentOption>();

        /// <summary>
        /// The minimum time (in seconds) that the merchant can set for completing the payment. Relevant when is_expirable is true. Response only.
        /// </summary>
        [JsonPropertyName("minimum_expiration_seconds")]
        public object? MinimumExpirationSeconds { get; set; }

        /// <summary>
        /// The maximum time (in seconds) that the merchant can set for completing the payment. Relevant when is_expirable is true. Response only.
        /// </summary>
        [JsonPropertyName("maximum_expiration_seconds")]
        public object? MaximumExpirationSeconds { get; set; }
    }
}