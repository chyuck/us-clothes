using System;
using System.Web;
using System.Web.Hosting;
using USClothesWebSite.Common.Helpers;

namespace USClothesWebSite.BusinessLogic.Http
{
    internal class HttpService : IHttpService
    {
        public virtual string ApplicationPath
        {
            get { return HostingEnvironment.ApplicationPhysicalPath; }
        }

        public virtual string ApplicationUrl
        {
            get
            {
                var requestUrl = HttpContext.Current.Request.Url;

                var absoluteUrl = requestUrl.AbsoluteUri;
                var absolutePath = requestUrl.AbsolutePath;
                var lastIndex = absoluteUrl.LastIndexOf(absolutePath, StringComparison.OrdinalIgnoreCase);

                return absoluteUrl.Substring(0, lastIndex);
            }
        }
        
        public virtual string GetAbsoluteURLFromRelativeURL(string relativeUrl)
        {
            CheckHelper.ArgumentNotNullAndNotWhiteSpace(relativeUrl, "relativeUrl");

            return UrlHelper.Combine(ApplicationUrl, relativeUrl);
        }

        public virtual string GetRelativeURLFromAbsoluteURL(string absoluteUrl)
        {
            CheckHelper.ArgumentNotNullAndNotWhiteSpace(absoluteUrl, "absoluteUrl");

            return absoluteUrl.Replace(ApplicationUrl, string.Empty);
        }
    }
}
