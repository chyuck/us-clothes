using System;
using System.Linq;
using System.Runtime.Serialization;
using USClothesWebSite.Common.Helpers.Object;
using USClothesWebSite.Common.Services.LocalizedName;
using USClothesWebSite.Common.Services.Validate;
using USClothesWebSite.Common.Services.Validate.Attributes;

namespace USClothesWebSite.DTO
{
    [DataContract(IsReference = true)]
    [LocalizedName("Товар", "Товары")]
    public class Product : IEquatable<Product>, IActivatedDto, ITrackableDto, ICloneable, IMasterDto<Product, ProductSize>
    {
        [DataMember]
        [IdValidate]
        public int Id { get; set; }

        [DataMember]
        [StringValidate("Название должно иметь длину от 1 до 50 символов.",
            CanBeNull = false, CanBeEmpty = false, MinLength = 1, MaxLength = 50)]
        public string Name { get; set; }

        [DataMember]
        [StringValidate("Описание должно иметь длину не более 1000 символов.",
            CanBeNull = true, CanBeEmpty = true, MaxLength = 1000)]
        public string Description { get; set; }

        [DataMember]
        public string PreviewPictureURL { get; set; }

        [DataMember]
        public string FullPictureURL { get; set; }

        [DataMember]
        [StringValidate("Ссылка производителя должна иметь длину не более 1000 символов.",
            CanBeNull = true, CanBeEmpty = true, MaxLength = 1000)]
        public string VendorShopURL { get; set; }

        [DataMember]
        public bool Active { get; set; }

        [DataMember]
        [NotNullValidate("Бренд должен быть задан.")]
        public Brand Brand { get; set; }

        [DataMember]
        [NotNullValidate("Подкатегория должна быть задана.")]
        public SubCategory SubCategory { get; set; }

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
        public ProductSize[] ProductSizes { get; set; }

        [ValidateMethod]
        public ValidationError ValidatePicture()
        {
            var isPreviewPictureIsValid = 
                StringValidator.ValidateString(PreviewPictureURL, minLength:1, maxLength:1000, canBeNull:false, canBeEmpty:false);
            var isFullPictureIsValid =
                StringValidator.ValidateString(FullPictureURL, minLength: 1, maxLength: 1000, canBeNull: false, canBeEmpty: false);

            if (!isPreviewPictureIsValid || !isFullPictureIsValid)
                return new ValidationError("Picture", "Фотография должна быть задана.");

            return null;
        }

        [ValidateMethod]
        public ValidationError ValidateSubCategory()
        {
            if (ProductSizes != null && ProductSizes.Any())
            {
                var subCategoryId = SubCategory != null ? SubCategory.Id : 0;

                var areThereAnyProductSizeWithDifferentSubCategory =
                    ProductSizes.Any(ps => ps.Size.SubCategory.Id != subCategoryId);

                if (areThereAnyProductSizeWithDifferentSubCategory)
                    return new ValidationError("ProductSizeSubCategory", "Все размеры товара должны быть той же подкатегории.");
            }

            return null;
        }

        [ValidateMethod]
        public ValidationError ValidateBrand()
        {
            if (ProductSizes != null && ProductSizes.Any())
            {
                var brandId = Brand != null ? Brand.Id : 0;

                var areThereAnyProductSizeWithDifferentBrand =
                    ProductSizes.Any(ps => ps.Size.Brand.Id != brandId);

                if (areThereAnyProductSizeWithDifferentBrand)
                    return new ValidationError("ProductSizeBrand", "Все размеры товара должны быть того же брэнда.");
            }

            return null;
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as Product);
        }

        public override int GetHashCode()
        {
            return ObjectHelper.GetHashCode(this);
        }

        public bool Equals(Product other)
        {
            return ObjectHelper.Equals(this, other);
        }

        public object Clone()
        {
            var product = ObjectHelper.Clone(this);

            if (ProductSizes != null)
                product.ProductSizes =
                    ProductSizes
                        .Select(ps => ps.Clone(product))
                        .ToArray();

            return product;
        }

        public override string ToString()
        {
            return Name;
        }

        public ProductSize[] DetailDtos
        {
            get { return ProductSizes; }
        }
    }
}
