using System;
using System.Runtime.Serialization;

namespace USClothesWebSite.BusinessLogic.Security
{
    [Serializable]
    public class SecurityServiceException : Exception
    {
        public SecurityServiceException(string message)
            : base(message)
        {
        }

        public SecurityServiceException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        public SecurityServiceException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}
