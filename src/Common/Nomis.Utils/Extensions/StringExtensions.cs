// ------------------------------------------------------------------------------------------------------
// <copyright file="StringExtensions.cs" company="Nomis">
// Copyright (c) Nomis, 2023. All rights reserved.
// The Application under the MIT license. See LICENSE file in the solution root for full license information.
// </copyright>
// ------------------------------------------------------------------------------------------------------

using System.Globalization;
using System.Numerics;

namespace Nomis.Utils.Extensions
{
    /// <summary>
    /// Extension methods for converting string.
    /// </summary>
    public static class StringExtensions
    {
        /// <summary>
        /// Convert string value to BigInteger value.
        /// </summary>
        /// <param name="stringValue">String value.</param>
        /// <returns>Returns total BigInteger value.</returns>
        public static BigInteger ToBigInteger(this string? stringValue)
        {
            return !BigInteger.TryParse(stringValue, NumberStyles.AllowDecimalPoint, new NumberFormatInfo { CurrencyDecimalSeparator = "." }, out var value) ? 0 : value;
        }
    }
}