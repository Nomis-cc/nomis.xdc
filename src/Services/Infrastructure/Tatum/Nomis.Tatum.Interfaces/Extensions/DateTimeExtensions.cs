// ------------------------------------------------------------------------------------------------------
// <copyright file="DateTimeExtensions.cs" company="Nomis">
// Copyright (c) Nomis, 2023. All rights reserved.
// The Application under the MIT license. See LICENSE file in the solution root for full license information.
// </copyright>
// ------------------------------------------------------------------------------------------------------

namespace Nomis.Tatum.Interfaces.Extensions
{
    /// <summary>
    /// Extension methods for converting DateTime.
    /// </summary>
    public static class DateTimeExtensions
    {
        /// <summary>
        /// Convert Unix TimeStamp to DateTime.
        /// </summary>
        /// <param name="unixTimeStamp">Unix TimeStamp.</param>
        /// <returns><see cref="DateTime"/>.</returns>
        public static DateTime ToTatumDateTime(this long unixTimeStamp)
        {
            long beginTicks = DateTime.UnixEpoch.Ticks;
            var time = new DateTime(beginTicks + (unixTimeStamp * 10000), DateTimeKind.Utc).ToLocalTime();
            return time;
        }
    }
}