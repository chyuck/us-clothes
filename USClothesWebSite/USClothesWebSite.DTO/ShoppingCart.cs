using System;
using USClothesWebSite.Common.Helpers.Object;

namespace USClothesWebSite.DTO
{
    public class ShoppingCart : IEquatable<ShoppingCart>, IDto
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public decimal TotalPrice { get; set; }

        public virtual ProductSize ProductSize { get; set; }
        public virtual Session Session { get; set; }

        public override bool Equals(object obj)
        {
            return Equals(obj as ShoppingCart);
        }

        public override int GetHashCode()
        {
            return ObjectHelper.GetHashCode(this);
        }

        public bool Equals(ShoppingCart other)
        {
            return ObjectHelper.Equals(this, other);
        }
    }
}
