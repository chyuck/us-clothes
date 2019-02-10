using System;
using System.Runtime.Serialization;
using USClothesWebSite.Common.Helpers.Object;
using USClothesWebSite.Common.Services.LocalizedName;
using USClothesWebSite.Common.Services.Validate.Attributes;

namespace USClothesWebSite.DTO
{
    [DataContract(IsReference = true)]
    [LocalizedName("Подкатегория", "Подкатегории")]
    public class SubCategory : IEquatable<SubCategory>, IActivatedDto, ITrackableDto, ICloneable, IDetailDto<Category, SubCategory>
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
        [NotNullValidate("Категория должна быть задана.")]
        [IgnoreInClone]
        public Category Category { get; set; }

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
            return Equals(obj as SubCategory);
        }

        public override int GetHashCode()
        {
            return ObjectHelper.GetHashCode(this);
        }

        public bool Equals(SubCategory other)
        {
            return ObjectHelper.Equals(this, other);
        }

        internal SubCategory Clone(Category category)
        {
            var subCategory = ObjectHelper.Clone(this);
            subCategory.Category = category;

            return subCategory;
        }

        public object Clone()
        {
            var category = Category != null ? (Category) Category.Clone() : null;

            return Clone(category);
        }

        public Category MasterDto
        {
            get { return Category; }
        }

        public override string ToString()
        {
            return string.Format("{0} ({1})", Name, Category);
        }
    }
}
