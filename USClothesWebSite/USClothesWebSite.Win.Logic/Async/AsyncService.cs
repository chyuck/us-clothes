using System;
using System.Threading.Tasks;
using DepIC;
using DepIC.Attributes;
using USClothesWebSite.Common.Helpers;
using USClothesWebSite.Common.Services;

namespace USClothesWebSite.Win.Logic.Async
{
    internal class AsyncService : BaseService, IAsyncService
    {
        [Inject]
        public AsyncService(IReadOnlyContainer container) 
            : base(container)
        {
        }

        public async Task<T> DoAsync<T>(Func<T> action)
        {
            CheckHelper.ArgumentNotNull(action, "action");

            var asyncStatusPresenter = Container.Get<IAsyncStatusPresenter>();

            try
            {
                asyncStatusPresenter.SetAsyncStatus(true);

                return await Task.Run(action);
            }
            finally
            {
                asyncStatusPresenter.SetAsyncStatus(false);
            }
        }


        public async Task DoAsync(Action action)
        {
            CheckHelper.ArgumentNotNull(action, "action");

            var asyncStatusPresenter = Container.Get<IAsyncStatusPresenter>();

            try
            {
                asyncStatusPresenter.SetAsyncStatus(true);

                await Task.Run(action);
            }
            finally
            {
                asyncStatusPresenter.SetAsyncStatus(false);
            }
        }
    }
}
