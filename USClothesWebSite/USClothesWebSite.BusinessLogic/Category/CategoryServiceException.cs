using System;
using System.Runtime.Serialization;

namespace USClothesWebSite.BusinessLogic.Category
{
    [Serializable]
    public class CategoryServiceException : Exception
    {
        public CategoryServiceException(string message)
            : base(message)
        {
        }

        public CategoryServiceException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        public CategoryServiceException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}
