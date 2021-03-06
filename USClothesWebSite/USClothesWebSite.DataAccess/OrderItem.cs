//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace USClothesWebSite.DataAccess
{
    using System;
    using System.Collections.Generic;
    
    public partial class OrderItem
    {
        public int Id { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public decimal TotalPrice { get; set; }
        public decimal PurchaserPaid { get; set; }
        public int OrderId { get; set; }
        public int ProductSizeId { get; set; }
        public bool Active { get; set; }
        public System.DateTime CreateDate { get; set; }
        public System.DateTime ChangeDate { get; set; }
        public int CreateUserId { get; set; }
        public int ChangeUserId { get; set; }
    
        public virtual User ChangedBy { get; set; }
        public virtual User CreatedBy { get; set; }
        public virtual ProductSize ProductSize { get; set; }
        public virtual Order Order { get; set; }
    }
}
