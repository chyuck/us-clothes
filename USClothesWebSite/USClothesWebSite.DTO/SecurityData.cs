using System;
using System.Runtime.Serialization;
using USClothesWebSite.Common.Helpers.Object;
using USClothesWebSite.Common.Services.Validate.Attributes;

namespace USClothesWebSite.DTO
{
    [DataContract]
    public class SecurityData : ICloneable
    {
        public const string HEADER_NAME = "Security";
        public const string HEADER_NAMESPACE = "us-clothes-security";

        [DataMember]
        [LoginValidate("Логин должен состоять из букв и цифр, и иметь длину от 3 до 50 символов.")]
        public string Login { get; set; }

        [DataMember]
        [PasswordValidate("Пароль должен иметь длину от 5 до 50 символов.")]
        public string Password { get; set; }

        public object Clone()
        {
            return ObjectHelper.Clone(this);
        }
    }
}
