using System;

namespace USClothesWebSite.Common.Extensions
{
    public static class DateTimeExtensions
    {
        public static DateTime ToEndOfDay(this DateTime dateTime)
        {
            return dateTime.Date.AddDays(1).AddSeconds(-1);
        }
    }
}
