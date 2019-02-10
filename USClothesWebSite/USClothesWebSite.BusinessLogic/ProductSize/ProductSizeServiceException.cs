using System;
using System.Runtime.Serialization;

namespace USClothesWebSite.BusinessLogic.ProductSize
{
    [Serializable]
    public class ProductSizeServiceException : Exception
    {
        public ProductSizeServiceException(string message)
            : base(message)
        {
        }

        public ProductSizeServiceException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        public ProductSizeServiceException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}
