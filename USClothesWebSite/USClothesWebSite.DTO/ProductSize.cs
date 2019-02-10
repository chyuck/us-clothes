using System;
using System.Runtime.Serialization;
using USClothesWebSite.Common.Helpers.Object;
using USClothesWebSite.Common.Services.LocalizedName;
using USClothesWebSite.Common.Services.Validate;
using USClothesWebSite.Common.Services.Validate.Attributes;

namespace USClothesWebSite.DTO
{
    [DataContract(IsReference = true)]
    [LocalizedName("Размер товара", "Размеры товара")]
    public class ProductSize : IEquatable<ProductSize>, IActivatedDto, ITrackableDto, ICloneable, IDetailDto<Product, ProductSize>
    {
        [DataMember]
        [IdValidate]
        public int Id { get; set; }

        /// <summary>Цена, руб</summary>
        [DataMember]
        [DecimalValidate("Цена должна быть в диапазоне от 0,01 до 1 000 000.",
            MinValueString = "0.01", MaxValueString = "1000000")]
        public decimal Price { get; set; }

        [DataMember]
        public bool Active { get; set; }

        [DataMember]
        [NotNullValidate("Товар должен быть задан.")]
        [IgnoreInClone]
        public virtual Product Product { get; set; }

        [DataMember]
        [NotNullValidate("Размер должен быть задан.")]
        public virtual Size Size { get; set; }

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
            return Equals(obj as ProductSize);
        }

        [ValidateMethod]
        public ValidationError Validate()
        {
            if (Product == null)
                return null;
            if (Size == null)
                return null;

            if (!Product.SubCategory.Equals(Size.SubCategory))
                return new ValidationError("SubCategory", "Товар и размер должны принадлежать одной подкатегории.");

            return null;
        }

        public override int GetHashCode()
        {
            return ObjectHelper.GetHashCode(this);
        }

        public override string ToString()
        {
            if (Product != null && Size != null)
                return string.Format("{0} Размер:{1}", Product.Name, Size.Name);

            return string.Empty;
        }

        public bool Equals(ProductSize other)
        {
            return ObjectHelper.Equals(this, other);
        }

        internal ProductSize Clone(Product product)
        {
            var productSize = ObjectHelper.Clone(this);
            productSize.Product = product;

            return productSize;
        }

        public object Clone()
        {
            var product = Product != null ? (Product)Product.Clone() : null;

            return Clone(product);
        }

        public Product MasterDto
        {
            get { return Product; }
        }
    }
}
