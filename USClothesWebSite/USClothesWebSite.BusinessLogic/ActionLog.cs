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
    
    public partial class ActionLog
    {
        public int ActionLogId { get; set; }
        public string Text { get; set; }
        public int DocumentId { get; set; }
        public int ActionLogTypeId { get; set; }
        public System.DateTime CreateDate { get; set; }
        public int CreateUserId { get; set; }
    
        public virtual ActionLogType ActionLogType { get; set; }
        public virtual User User { get; set; }
    }
}
