using System;

namespace USClothesWebSite.Common.Helpers
{
    public static class UrlHelper
    {
        public static string Combine(string baseUrl, string relativeUrl)
        {
            CheckHelper.ArgumentNotNullAndNotWhiteSpace(baseUrl, "baseUrl");
            CheckHelper.ArgumentNotNullAndNotWhiteSpace(relativeUrl, "relativeUrl");

            if (baseUrl[baseUrl.Length - 1] != '/')
                baseUrl += "/";

            var baseUri = new Uri(baseUrl);
            var uri = new Uri(baseUri, relativeUrl);

            return uri.ToString();
        }
    }
}
