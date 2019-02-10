using System;
using System.Runtime.Serialization;

namespace USClothesWebSite.DTO
{
    [DataContract(Namespace = "http://usclothes.ru/dto/errordata")]
    public class ErrorData
    {
        [DataMember]
        public string Message { get; set; }

        [DataMember]
        public string StackTrace { get; set; }

        [DataMember]
        public DateTime UtcTime { get; set; }

        [DataMember]
        public string ExceptionType { get; set; }
    }
}
