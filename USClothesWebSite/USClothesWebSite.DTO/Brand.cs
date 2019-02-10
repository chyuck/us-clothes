using System;
using System.Runtime.Serialization;
using USClothesWebSite.Common.Helpers.Object;
using USClothesWebSite.Common.Services.LocalizedName;
using USClothesWebSite.Common.Services.Validate.Attributes;

namespace USClothesWebSite.DTO
{
    [DataContract(IsReference = true)]
    [LocalizedName("Бренд", "Бренды")]
    public class Brand : IEquatable<Brand>, IActivatedDto, ITrackableDto, ICloneable
    {
        [DataMember]
        [IdValidate]
        public int Id { get; set; }

        [DataMember]
        [StringValidate("Название должно иметь длину от 1 до 50 символов.",
            CanBeNull = false, CanBeEmpty = false, MinLength = 1, MaxLength = 50)]
        public string Name { get; set; }

        [DataMember]
        public bool Active { get; set; }

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
            return Equals(obj as Brand);
        }

        public override int GetHashCode()
        {
            return ObjectHelper.GetHashCode(this);
        }

        public bool Equals(Brand other)
        {
            return ObjectHelper.Equals(this, other);
        }

        public object Clone()
        {
            return ObjectHelper.Clone(this);
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
