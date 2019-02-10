using System;

namespace USClothesWebSite.Common.Extensions
{
    public static class DecimalExtensions
    {
        public static decimal ToMoney(this decimal d)
        {
            return Math.Round(d, 2, MidpointRounding.AwayFromZero);
        }
    }
}
