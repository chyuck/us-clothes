using System;

namespace USClothesWebSite.Common.Services.Time
{
    public interface ITimeService
    {
        DateTime UtcNow { get; }

        DateTime LocalNow { get; }

        DateTime ToUtc(DateTime localTime);

        DateTime ToLocal(DateTime utcTime);
    }
}
