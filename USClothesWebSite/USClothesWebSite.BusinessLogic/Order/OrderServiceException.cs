using System;
using System.Runtime.Serialization;

namespace USClothesWebSite.BusinessLogic.Order
{
    [Serializable]
    public class OrderServiceException : Exception
    {
        public OrderServiceException(string message)
            : base(message)
        {
        }

        public OrderServiceException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        public OrderServiceException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}
