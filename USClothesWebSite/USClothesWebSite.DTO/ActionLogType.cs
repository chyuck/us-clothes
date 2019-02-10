using System;
using System.Runtime.Serialization;
using USClothesWebSite.Common.Helpers.Object;
using USClothesWebSite.Common.Services.LocalizedName;
using USClothesWebSite.Common.Services.Validate.Attributes;

namespace USClothesWebSite.DTO
{
    [DataContract(IsReference = true)]
    [LocalizedName("Тип лога", "Типы логов")]
    public class ActionLogType : IDto, IEquatable<ActionLogType>, ICloneable
    {
        [DataMember]
        [IdValidate]
        public int Id { get; set; }

        [DataMember]
        [StringValidate("Название должно иметь длину от 1 до 50 символов.",
            CanBeNull = false, CanBeEmpty = false, MinLength = 1, MaxLength = 50)]
        public string Name { get; set; }

        public override bool Equals(object obj)
        {
            return Equals(obj as ActionLogType);
        }

        public override int GetHashCode()
        {
            return ObjectHelper.GetHashCode(this);
        }

        public bool Equals(ActionLogType other)
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
