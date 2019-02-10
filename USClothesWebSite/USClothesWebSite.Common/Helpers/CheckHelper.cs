using System;

namespace USClothesWebSite.Common.Helpers
{
    public static class CheckHelper
    {
        public static void ArgumentNotNull<T>(T argument, string message) 
            where T : class
        {
            if (argument == null)
                throw new ArgumentNullException(message);
        }

        public static void ArgumentNotNullAndNotEmpty(string argument, string message)
        {
            if (string.IsNullOrEmpty(argument))
                throw new ArgumentException(message);
        }

        public static void ArgumentNotNullAndNotWhiteSpace(string argument, string message)
        {
            if (string.IsNullOrWhiteSpace(argument))
                throw new ArgumentException(message);
        }

        public static void ArgumentWithinCondition(bool condition, string message)
        {
            if (!condition)
                throw new ArgumentException(message);
        }

        public static void NotNull<T>(T argument, string message)
            where T : class
        {
            if (argument == null)
                throw new InvalidOperationException(message);
        }

        public static void WithinCondition(bool condition, string message)
        {
            if (!condition)
                throw new InvalidOperationException(message);
        }
    }
}
