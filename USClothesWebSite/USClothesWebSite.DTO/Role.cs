using System;
using System.Runtime.Serialization;
using USClothesWebSite.Common.Helpers.Object;
using USClothesWebSite.Common.Services.LocalizedName;
using USClothesWebSite.Common.Services.Validate.Attributes;

namespace USClothesWebSite.DTO
{
    [DataContract(IsReference = true)]
    [LocalizedName("Роль", "Роли")]
    public class Role : IEquatable<Role>, IDto, ICloneable
    {
        public const string ADMINISTRATOR_ROLE_NAME = "Администратор";
        public const string PURCHASER_ROLE_NAME = "Закупщик";
        public const string DISTRIBUTOR_ROLE_NAME = "Распространитель";
        public const string SELLER_ROLE_NAME = "Продавец";

        [DataMember]
        [IdValidate]
        public int Id { get; set; }

        [DataMember]
        [StringValidate("Название должно иметь длину от 1 до 50 символов.",
            CanBeNull = false, CanBeEmpty = false, MinLength = 1, MaxLength = 50)]
        public string Name { get; set; }

        public override bool Equals(object obj)
        {
            return Equals(obj as Role);
        }

        public override int GetHashCode()
        {
            return ObjectHelper.GetHashCode(this);
        }

        public bool Equals(Role other)
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
