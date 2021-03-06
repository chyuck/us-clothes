//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace USClothesWebSite.BusinessLogic
{
    using System;
    using System.Collections.Generic;
    
    public partial class ProductSize
    {
        public ProductSize()
        {
            this.OrderItem = new HashSet<OrderItem>();
            this.ShoppingCart = new HashSet<ShoppingCart>();
        }
    
        public int ProductSizeId { get; set; }
        public decimal Price { get; set; }
        public int ProductId { get; set; }
        public int SizeId { get; set; }
        public bool Active { get; set; }
        public System.DateTime CreateDate { get; set; }
        public System.DateTime ChangeDate { get; set; }
        public int CreateUserId { get; set; }
        public int ChangeUserId { get; set; }
    
        public virtual ICollection<OrderItem> OrderItem { get; set; }
        public virtual Product Product { get; set; }
        public virtual User User { get; set; }
        public virtual User User1 { get; set; }
        public virtual Size Size { get; set; }
        public virtual ICollection<ShoppingCart> ShoppingCart { get; set; }
    }
}
