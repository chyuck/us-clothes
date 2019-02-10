using System;
using System.Runtime.Serialization;
using USClothesWebSite.Common.Helpers.Object;
using USClothesWebSite.Common.Services.Validate.Attributes;

namespace USClothesWebSite.DTO
{
    [DataContract]
    public class Picture : ICloneable
    {
        public const int FULL_PICTURE_MAX_WIDTH = 480;
        public const int FULL_PICTURE_MAX_HEIGHT = 480;

        public const int PREVIEW_PICTURE_MAX_WIDTH = 128;
        public const int PREVIEW_PICTURE_MAX_HEIGHT = 128;

        [DataMember]
        [StringValidate("Адрес маленькой фотографии должен иметь длину от 1 до 1000 символов.",
            CanBeNull = false, CanBeEmpty = false, MinLength = 1, MaxLength = 1000)]
        public string PreviewPictureURL { get; set; }
        
        [DataMember]
        [StringValidate("Адрес большой фотографии должен иметь длину от 1 до 1000 символов.",
           CanBeNull = false, CanBeEmpty = false, MinLength = 1, MaxLength = 1000)]
        public string FullPictureURL { get; set; }

        public object Clone()
        {
            return ObjectHelper.Clone(this);
        }
    }
}
