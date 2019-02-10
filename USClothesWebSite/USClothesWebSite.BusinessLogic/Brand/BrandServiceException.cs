using System;
using System.Runtime.Serialization;

namespace USClothesWebSite.BusinessLogic.Brand
{
    [Serializable]
    public class BrandServiceException : Exception
    {
        public BrandServiceException(string message)
            : base(message)
        {
        }

        public BrandServiceException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        public BrandServiceException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}
