using System;
using System.Threading.Tasks;

namespace USClothesWebSite.Win.Logic.Async
{
    public interface IAsyncService
    {
        Task<T> DoAsync<T>(Func<T> action);

        Task DoAsync(Action action);
    }
}
