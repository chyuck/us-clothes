using System;
using System.Collections.Generic;
using System.Linq;
using USClothesWebSite.Common.Helpers;

namespace USClothesWebSite.Common.Extensions
{
    public static class EnumerableExtensions
    {
        public static void ForEach<T>(this IEnumerable<T> collection, Action<T> action)
        {
            CheckHelper.ArgumentNotNull(collection, "collection");
            CheckHelper.ArgumentNotNull(action, "action");

            foreach (var item in collection)
                action(item);
        }

        public static int IndexOfElement<T>(this IEnumerable<T> collection, Func<T, bool> selector)
        {
            CheckHelper.ArgumentNotNull(collection, "collection");
            CheckHelper.ArgumentNotNull(selector, "selector");

            return
                collection
                    .Select((value, index) => new {value, Index = index})
                    .Single(vi => selector(vi.value))
                    .Index;
        }

        public static bool IsEquivalent<T>(this IEnumerable<T> collection1, IEnumerable<T> collection2)
        {
            if (collection1 == null && collection2 == null)
                return true;

            if (collection1 == null || collection2 == null)
                return false;

            if (collection1.Count() != collection2.Count())
                return false;

            foreach (var item1 in collection1)
            {
                if (!collection2.Any(item2 => Equals(item1, item2)))
                    return false;
            }

            return true;
        }
    }
}
