// ------------------------------------------------------------------------------------------------------
// <copyright file="RapydCustomer.cs" company="Nomis">
// Copyright (c) Nomis, 2023. All rights reserved.
// The Application under the MIT license. See LICENSE file in the solution root for full license information.
// </copyright>
// ------------------------------------------------------------------------------------------------------

using System.Text.Json.Serialization;

namespace Nomis.Rapyd.Interfaces.Models
{
    /// <summary>
    /// Rapyd customer.
    /// </summary>
    public class RapydCustomer
    {
        /// <summary>
        /// Id.
        /// </summary>
        [JsonPropertyName("id")]
        public string? Id { get; set; }

        /// <summary>
        /// Delinquent.
        /// </summary>
        [JsonPropertyName("delinquent")]
        public bool Delinquent { get; set; }

        /// <summary>
        /// Discount.
        /// </summary>
        [JsonPropertyName("discount")]
        public object? Discount { get; set; }

        /// <summary>
        /// Name.
        /// </summary>
        [JsonPropertyName("name")]
        public string? Name { get; set; }

        /// <summary>
        /// Default payment method.
        /// </summary>
        [JsonPropertyName("default_payment_method")]
        public string? DefaultPaymentMethod { get; set; }

        /// <summary>
        /// Description.
        /// </summary>
        [JsonPropertyName("description")]
        public string? Description { get; set; }

        /// <summary>
        /// Email.
        /// </summary>
        [JsonPropertyName("email")]
        public string? Email { get; set; }

        /// <summary>
        /// Phone number.
        /// </summary>
        [JsonPropertyName("phone_number")]
        public string? PhoneNumber { get; set; }

        /// <summary>
        /// Invoice prefix.
        /// </summary>
        [JsonPropertyName("invoice_prefix")]
        public string? InvoicePrefix { get; set; }

        /// <summary>
        /// Addresses.
        /// </summary>
        [JsonPropertyName("addresses")]
        public IList<object> Addresses { get; set; } = new List<object>();

        /// <summary>
        /// Payment methods.
        /// </summary>
        [JsonPropertyName("payment_methods")]
        public object? PaymentMethods { get; set; }

        /// <summary>
        /// Subscriptions.
        /// </summary>
        [JsonPropertyName("subscriptions")]
        public object? Subscriptions { get; set; }

        /// <summary>
        /// Created at.
        /// </summary>
        [JsonPropertyName("created_at")]
        public int CreatedAt { get; set; }

        /// <summary>
        /// Business vat id.
        /// </summary>
        [JsonPropertyName("business_vat_id")]
        public string? BusinessVatId { get; set; }

        /// <summary>
        /// Ewallet.
        /// </summary>
        [JsonPropertyName("ewallet")]
        public string? Ewallet { get; set; }
    }
}