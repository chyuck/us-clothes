using System;
using System.Linq;
using System.Runtime.Serialization;
using USClothesWebSite.Common.Extensions;
using USClothesWebSite.Common.Helpers.Object;
using USClothesWebSite.Common.Services.LocalizedName;
using USClothesWebSite.Common.Services.Validate.Attributes;

namespace USClothesWebSite.DTO
{
    [DataContract(IsReference = true)]
    [LocalizedName("Пользователь", "Пользователи")]
    public class User : IEquatable<User>, IActivatedDto, ICloneable, ITrackableDto
    {
        public const string GUEST_LOGIN = "guest";

        [DataMember]
        [IdValidate]
        public int Id { get; set; }

        [DataMember]
        [StringValidate("Имя должно иметь длину от 1 до 50 символов.", 
            CanBeNull = false, CanBeEmpty = false, MinLength = 1, MaxLength = 50)]
        public string FirstName { get; set; }

        [DataMember]
        [StringValidate("Фамилия должна иметь длину от 1 до 50 символов.", 
            CanBeNull = false, CanBeEmpty = false, MinLength = 1, MaxLength = 50)]
        public string LastName { get; set; }

        [DataMember]
        [EmailValidate("Неправильный формат электронной почты.")]
        public string Email { get; set; }

        [DataMember]
        [LoginValidate("Логин должен состоять из букв и цифр, и иметь длину от 3 до 50 символов.")]
        public string Login { get; set; }

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

        [DataMember]
        [IgnoreInEquals]
        [IgnoreInGetHashCode]
        [IgnoreInClone]
        public Role[] Roles { get; set; }

        public override bool Equals(object obj)
        {
            return Equals(obj as User);
        }

        public override int GetHashCode()
        {
            var hashCode = ObjectHelper.GetHashCode(this);

            if (Roles != null)
                Roles.ForEach(r => hashCode |= r.GetHashCode());

            return hashCode;
        }

        public bool Equals(User other)
        {
            var isEqual = ObjectHelper.Equals(this, other);

            if (!isEqual)
                return false;

            if (!Roles.IsEquivalent(other.Roles))
                return false;

            return true;
        }

        public object Clone()
        {
            var user = ObjectHelper.Clone(this);

            if (Roles != null)
                user.Roles =
                    Roles
                        .Select(r => (Role) r.Clone())
                        .ToArray();

            return user;
        }

        public override string ToString()
        {
            return GetFullName(FirstName, LastName);
        }

        public static string GetFullName(string firstName, string lastName)
        {
            return string.Format("{0} {1}", lastName ?? string.Empty, firstName ?? string.Empty);
        }
    }
}
