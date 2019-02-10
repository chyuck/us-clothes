using System;
using USClothesWebSite.Common.Helpers;

namespace USClothesWebSite.Common.Services.Time
{
    internal class TimeService : ITimeService
    {
        private static DateTime ConvertToKind(DateTime dateTime, DateTimeKind kind)
        {
            CheckHelper.ArgumentWithinCondition(dateTime.Kind == DateTimeKind.Unspecified, "dateTime.Kind == DateTimeKind.Unspecified");

            return new DateTime(dateTime.Ticks, kind);
        }

        public DateTime UtcNow
        {
            get { return DateTime.UtcNow; }
        }

        public DateTime LocalNow
        {
            get { return DateTime.Now; }
        }
        
        public DateTime ToUtc(DateTime localTime)
        {
            CheckHelper.ArgumentWithinCondition(localTime.Kind != DateTimeKind.Utc, "localTime.Kind != DateTimeKind.Utc");

            if (localTime.Kind == DateTimeKind.Unspecified)
                localTime = ConvertToKind(localTime, DateTimeKind.Local);

            var dateTimeOffset = new DateTimeOffset(localTime);

            return dateTimeOffset.UtcDateTime;
        }

        public DateTime ToLocal(DateTime utcTime)
        {
            CheckHelper.ArgumentWithinCondition(utcTime.Kind != DateTimeKind.Local, "utcTime.Kind != DateTimeKind.Local");

            if (utcTime.Kind == DateTimeKind.Unspecified)
                utcTime = ConvertToKind(utcTime, DateTimeKind.Utc);

            var dateTimeOffset = new DateTimeOffset(utcTime);

            return dateTimeOffset.LocalDateTime;
        }
    }
}
