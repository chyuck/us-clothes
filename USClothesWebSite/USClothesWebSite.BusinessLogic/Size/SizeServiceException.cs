using System;
using System.Runtime.Serialization;

namespace USClothesWebSite.BusinessLogic.Size
{
    [Serializable]
    public class SizeServiceException : Exception
    {
        public SizeServiceException(string message)
            : base(message)
        {
        }

        public SizeServiceException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        public SizeServiceException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}
