using System;
using USClothesWebSite.Common.Services.Time;

namespace USClothesWebSite.Win.Logic.Extensions
{
    public static class DateTimeExtensions
    {
        public static DateTime ToLocalTime(this DateTime utcTime)
        {
            return IoC.Container.Get<ITimeService>().ToLocal(utcTime);
        }
    }
}
