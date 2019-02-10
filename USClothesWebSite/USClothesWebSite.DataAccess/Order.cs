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
    
    public partial class Order
    {
        public Order()
        {
            this.OrderItems = new HashSet<OrderItem>();
        }
    
        public int Id { get; set; }
        public System.DateTime OrderDate { get; set; }
        public string CustomerFirstName { get; set; }
        public string CustomerLastName { get; set; }
        public string CustomerAddress { get; set; }
        public string CustomerCity { get; set; }
        public string CustomerCountry { get; set; }
        public string CustomerPostalCode { get; set; }
        public string CustomerPhoneNumber { get; set; }
        public string CustomerEmail { get; set; }
        public bool Active { get; set; }
        public string Comments { get; set; }
        public decimal RublesPerDollar { get; set; }
        public decimal CustomerPrepaid { get; set; }
        public Nullable<int> ParcelId { get; set; }
        public decimal DistributorSpentOnDelivery { get; set; }
        public decimal CustomerPaid { get; set; }
        public string TrackingNumber { get; set; }
        public System.DateTime CreateDate { get; set; }
        public System.DateTime ChangeDate { get; set; }
        public int CreateUserId { get; set; }
        public int ChangeUserId { get; set; }
    
        public virtual User ChangedBy { get; set; }
        public virtual User CreatedBy { get; set; }
        public virtual Parcel Parcel { get; set; }
        public virtual ICollection<OrderItem> OrderItems { get; set; }
    }
}
