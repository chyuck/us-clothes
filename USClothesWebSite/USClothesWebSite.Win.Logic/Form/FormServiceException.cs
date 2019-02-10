using System;

namespace USClothesWebSite.Win.Logic.Form
{
    public class FormServiceException : Exception
    {
        public FormServiceException(string formatMessage, params object[] args)
            : base(string.Format(formatMessage, args))
        {
        }
    }
}
