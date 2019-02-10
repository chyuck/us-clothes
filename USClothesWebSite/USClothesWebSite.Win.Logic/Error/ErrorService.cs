using System;
using System.ServiceModel;
using USClothesWebSite.Common.Helpers;
using USClothesWebSite.DTO;
using USClothesWebSite.Win.Logic.Extensions;

namespace USClothesWebSite.Win.Logic.Error
{
    internal class ErrorService : IErrorService
    {
        private const string DEFAULT_HEADER = "Произошла ошибка программы. Пожалуйста скопируйте и отошлите сообщение об ошибке поставщику программы.";
        private const string SERVER_UNAVAILABLE_HEADER = "Сервер временно недоступен. Подождите 15 секунд и повторите попытку.";

        public string GetHeader(Exception exception)
        {
            CheckHelper.ArgumentNotNull(exception, "exception");

            var communicationException = exception as CommunicationException;
            if (communicationException != null)
                return SERVER_UNAVAILABLE_HEADER;

            return DEFAULT_HEADER;
        }

        public string GetMessage(Exception exception)
        {
            CheckHelper.ArgumentNotNull(exception, "exception");

            var faultException = exception as FaultException<ErrorData>;
            if (faultException != null)
            {
                return
                    string.Format(
                        "{1}{0}{0}Details:{0}{2}{0}{0}{3}",
                        Environment.NewLine,
                        faultException.Message,
                        faultException.Detail.ToErrorString(),
                        faultException.StackTrace);
            }

            return exception.ToString();
        }
    }
}
