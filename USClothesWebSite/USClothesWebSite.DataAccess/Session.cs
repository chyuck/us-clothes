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
    
    public partial class Session
    {
        public Session()
        {
            this.ShoppingCarts = new HashSet<ShoppingCart>();
        }
    
        public int Id { get; set; }
        public string Key { get; set; }
        public System.DateTime CreateDate { get; set; }
    
        public virtual ICollection<ShoppingCart> ShoppingCarts { get; set; }
    }
}
