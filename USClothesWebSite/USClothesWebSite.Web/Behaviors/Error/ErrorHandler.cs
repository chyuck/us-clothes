using System;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Dispatcher;
using USClothesWebSite.BusinessLogic.Log;
using USClothesWebSite.BusinessLogic.Security;
using USClothesWebSite.Common.Helpers;
using USClothesWebSite.DTO;
using USClothesWebSite.Web.Behaviors.IoC;

namespace USClothesWebSite.Web.Behaviors.Error
{
    public class ErrorHandler : IErrorHandler
    {
        private static bool IsUserLoggedIn()
        {
            var operationContext = IoCOperationContext.Current;

            if (operationContext != null)
            {
                var container = operationContext.Container;

                if (container != null)
                {
                    var securityService = container.Get<ISecurityService>();

                    return securityService.IsLoggedIn && !securityService.IsCurrentUserGuest;
                }
            }

            return false;
        }

        private static void LogException(Exception error)
        {
            var operationContext = IoCOperationContext.Current;

            if (operationContext != null)
            {
                var container = operationContext.Container;

                if (container != null)
                {
                    var logService = container.Get<ILogService>();

                    logService.LogException(error);
                }
            }
        }

        private FaultException GetFaultException(Exception error)
        {
            CheckHelper.ArgumentNotNull(error, "error");

            var faultException = error as FaultException;
            if (faultException != null)
                return faultException;

            const string REASON = "Server error.";
            
            if (IsUserLoggedIn())
            {
                var exceptionData =
                    new ErrorData
                    {
                        Message = error.Message,
                        UtcTime = DateTime.UtcNow,
                        StackTrace = error.StackTrace,
                        ExceptionType = error.GetType().ToString()
                    };

                return new FaultException<ErrorData>(exceptionData, REASON);
            }

            return new FaultException(REASON);
        }

        public void ProvideFault(Exception error, MessageVersion version, ref Message fault)
        {
            LogException(error);

            var faultException = GetFaultException(error);

            var messageFault = faultException.CreateMessageFault();

            fault = Message.CreateMessage(version, messageFault, OperationContext.Current.RequestContext.RequestMessage.Headers.Action);
        }

        public bool HandleError(Exception error)
        {
            return true;
        }
    }
}