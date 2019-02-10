using System;
using System.Linq;
using System.Runtime.Serialization;
using USClothesWebSite.Common.Helpers.Object;
using USClothesWebSite.Common.Services.LocalizedName;
using USClothesWebSite.Common.Services.Validate.Attributes;

namespace USClothesWebSite.DTO
{
    [DataContract(IsReference = true)]
    [LocalizedName("Категория", "Категории")]
    public class Category : IEquatable<Category>, IActivatedDto, ITrackableDto, ICloneable, IMasterDto<Category, SubCategory>
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

        [DataMember]
        [IgnoreInEquals]
        [IgnoreInGetHashCode]
        [IgnoreInClone]
        public SubCategory[] SubCategories { get; set; }

        public override bool Equals(object obj)
        {
            return Equals(obj as Category);
        }

        public override int GetHashCode()
        {
            return ObjectHelper.GetHashCode(this);
        }

        public bool Equals(Category other)
        {
            return ObjectHelper.Equals(this, other);
        }

        public object Clone()
        {
            var category = ObjectHelper.Clone(this);

            if (SubCategories != null)
                category.SubCategories =
                    SubCategories
                        .Select(sc => sc.Clone(category))
                        .ToArray();
            
            return category;
        }
        
        public SubCategory[] DetailDtos
        {
            get { return SubCategories; }
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
