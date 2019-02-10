using System;
using System.Runtime.Serialization;

namespace USClothesWebSite.BusinessLogic.Product
{
    [Serializable]
    public class ProductServiceException : Exception
    {
        public ProductServiceException(string message)
            : base(message)
        {
        }

        public ProductServiceException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        public ProductServiceException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}
