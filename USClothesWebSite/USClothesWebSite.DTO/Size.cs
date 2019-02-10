using System;
using System.Runtime.Serialization;
using USClothesWebSite.Common.Helpers.Object;
using USClothesWebSite.Common.Services.LocalizedName;
using USClothesWebSite.Common.Services.Validate.Attributes;

namespace USClothesWebSite.DTO
{
    [DataContract(IsReference = true)]
    [LocalizedName("Размер", "Размеры")]
    public class Size : IEquatable<Size>, IActivatedDto, ITrackableDto, ICloneable
    {
        [DataMember]
        [IdValidate]
        public int Id { get; set; }

        [DataMember]
        [StringValidate("Название должно иметь длину от 1 до 50 символов.",
            CanBeNull = false, CanBeEmpty = false, MinLength = 1, MaxLength = 50)]
        public string Name { get; set; }

        [DataMember]
        [StringValidate("Вес должен иметь длину от 0 до 30 символов.",
            CanBeNull = true, CanBeEmpty = true, MinLength = 0, MaxLength = 30)]
        public string Weight { get; set; }

        [DataMember]
        [StringValidate("Рост должен иметь длину от 0 до 30 символов.",
            CanBeNull = true, CanBeEmpty = true, MinLength = 0, MaxLength = 30)]
        public string Height { get; set; }

        [DataMember]
        public bool Active { get; set; }

        [DataMember]
        [NotNullValidate("Подкатегория должна быть задана.")]
        public SubCategory SubCategory { get; set; }

        [DataMember]
        [NotNullValidate("Бренд должен быть задан.")]
        public Brand Brand { get; set; }

        [DataMember]
        [IgnoreInEquals]
        [IgnoreInGetHashCode]
        public DateTime CreateDate { get; set; }

        [DataMember]
        [IgnoreInEquals]
        [IgnoreInGetHashCode]
        public string CreateUser { get; set; }

        [DataMember]
        [IgnoreInEquals]
        [IgnoreInGetHashCode]
        public DateTime ChangeDate { get; set; }

        [DataMember]
        [IgnoreInEquals]
        [IgnoreInGetHashCode]
        public string ChangeUser { get; set; }

        public override bool Equals(object obj)
        {
            return Equals(obj as Size);
        }

        public override int GetHashCode()
        {
            return ObjectHelper.GetHashCode(this);
        }

        public bool Equals(Size other)
        {
            return ObjectHelper.Equals(this, other);
        }

        public object Clone()
        {
            return ObjectHelper.Clone(this);
        }

        public override string ToString()
        {
            return string.Format("{0} (Вес:{1}, Высота:{2})", Name, Weight, Height);
        }
    }
}
