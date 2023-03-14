// ------------------------------------------------------------------------------------------------------
// <copyright file="RapydPayment.cs" company="Nomis">
// Copyright (c) Nomis, 2023. All rights reserved.
// The Application under the MIT license. See LICENSE file in the solution root for full license information.
// </copyright>
// ------------------------------------------------------------------------------------------------------

using System.Text.Json.Serialization;

namespace Nomis.Rapyd.Interfaces.Models
{
    /// <summary>
    /// Rapyd payment.
    /// </summary>
    public class RapydPayment
    {
        /// <summary>
        /// Id.
        /// </summary>
        [JsonPropertyName("id")]
        public string? Id { get; set; }

        /// <summary>
        /// URL where the customer is redirected after completing the payment instructions on the third party site.
        /// Relevant to bank redirect payment methods.
        /// </summary>
        /// <example>http://example.com/complete</example>
        [JsonPropertyName("complete_payment_url")]
        public string? CompletePaymentUrl { get; set; }

        /// <summary>
        /// URL where the customer is redirected after an error occurs on the third-party site.
        /// Relevant to bank redirect payment methods.
        /// Does not support localhost URLs.
        /// </summary>
        /// <example>http://example.com/error</example>
        [JsonPropertyName("error_payment_url")]
        public string? ErrorPaymentUrl { get; set; }

        /// <summary>
        /// Time when the payment expires if it is not completed, in <see href="https://docs.rapyd.net/build-with-rapyd/reference-link/glossary">Unix time</see>.
        /// When both expiration and payment_expiration are set, the payment expires at the earlier time.
        /// Default is 14 days after creation of the checkout page.
        /// </summary>
        /// <example>1671655867</example>
        [JsonPropertyName("expiration")]
        public int Expiration { get; set; }

        /// <summary>
        /// Indicates the status of the payment. Response only.
        /// <para>Responses - One of the following:</para>
        /// <para>ACT - Active and awaiting completion of 3DS or capture. Can be updated.</para>
        /// <para>CAN - Canceled by the client or the customer's bank.</para>
        /// <para>CLO - Closed and paid.</para>
        /// <para>ERR - Error. An attempt was made to create or complete a payment, but it failed.</para>
        /// <para>EXP - The payment has expired.</para>
        /// <para>NEW - Not closed.</para>
        /// <para>REV - Reversed by Rapyd. See cancel_reason, above.</para>
        /// </summary>
        /// <example>CLO</example>
        [JsonPropertyName("status")]
        public string? Status { get; set; }
    }
}