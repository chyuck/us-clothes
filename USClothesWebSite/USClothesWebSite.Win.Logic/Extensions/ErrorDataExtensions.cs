using System;
using USClothesWebSite.Common.Helpers;
using USClothesWebSite.DTO;

namespace USClothesWebSite.Win.Logic.Extensions
{
    public static class ErrorDataExtensions
    {
        public static string ToErrorString(this ErrorData errorData)
        {
            CheckHelper.ArgumentNotNull(errorData, "errorData");

            return
                string.Format(
                    "ExceptionType: {1}{0}Message: {2}{0}UtcTime: {3}{0}Stack Trace:{0}{4}",
                    Environment.NewLine, errorData.ExceptionType, errorData.Message, errorData.UtcTime, errorData.StackTrace);
        }
    }
}
