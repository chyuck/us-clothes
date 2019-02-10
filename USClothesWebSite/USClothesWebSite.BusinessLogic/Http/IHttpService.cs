namespace USClothesWebSite.BusinessLogic.Http
{
    internal interface IHttpService
    {
        string ApplicationPath { get; }
        string ApplicationUrl { get; }

        string GetAbsoluteURLFromRelativeURL(string relativeUrl);
        string GetRelativeURLFromAbsoluteURL(string absoluteUrl);
    }
}
