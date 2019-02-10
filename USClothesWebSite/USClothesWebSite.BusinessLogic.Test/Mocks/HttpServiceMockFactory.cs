using Moq;
using USClothesWebSite.BusinessLogic.Http;

namespace USClothesWebSite.BusinessLogic.Test.Mocks
{
    public static class HttpServiceMockFactory
    {
        public const string APPLICATION_URL = @"http://usclothes.ru/";

        internal static Mock<HttpService> Create()
        {
            var httpService = new Mock<HttpService> { CallBase = true };
            httpService.Setup(m => m.ApplicationUrl).Returns(APPLICATION_URL);

            return httpService;
        }
    }
}
