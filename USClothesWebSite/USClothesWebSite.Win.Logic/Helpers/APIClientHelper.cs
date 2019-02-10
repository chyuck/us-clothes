using System;
using System.ServiceModel;
using DepIC;
using USClothesWebSite.Common.Helpers;

namespace USClothesWebSite.Win.Logic.Helpers
{
    public static class APIClientHelper<TAPIClient>
        where TAPIClient : class, ICommunicationObject
    {
        private static IReadOnlyContainer Container
        {
            get { return IoC.Container; }
        }

        public static TResult Call<TResult>(Func<TAPIClient, TResult> method)
        {
            CheckHelper.ArgumentNotNull(method, "method");

            var client = Container.Get<TAPIClient>();
            CheckHelper.NotNull(client, "client");

            try
            {
                var result = method(client);

                client.Close();

                return result;
            }
            catch (Exception)
            {
                client.Abort();
                throw;
            }
        }

        public static void Call(Action<TAPIClient> method)
        {
            CheckHelper.ArgumentNotNull(method, "method");

            var client = Container.Get<TAPIClient>();
            CheckHelper.NotNull(client, "client");

            try
            {
                method(client);

                client.Close();
            }
            catch (Exception)
            {
                client.Abort();
                throw;
            }
        }
    }
}
