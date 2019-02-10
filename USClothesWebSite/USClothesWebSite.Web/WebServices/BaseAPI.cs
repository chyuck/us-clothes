using System;
using DepIC;
using USClothesWebSite.Common.Helpers;
using USClothesWebSite.Web.Behaviors.IoC;

namespace USClothesWebSite.Web.WebServices
{
    public abstract class BaseAPI
    {
        protected IReadOnlyContainer Container
        {
            get
            {
                var operationContext = IoCOperationContext.Current;
                CheckHelper.NotNull(operationContext, "operationContext");

                var container = operationContext.Container;
                CheckHelper.NotNull(container, "container");

                return container;
            }
        }

        protected string RunAndCatchException<TException>(Action action)
            where TException : Exception
        {
            CheckHelper.ArgumentNotNull(action, "action");

            try
            {
                action();
            }
            catch (TException ex)
            {
                return ex.Message;
            }

            return null;
        }
    }
}