using System;

namespace USClothesWebSite.DataAccess
{
    public interface ITrackableEntity : IEntity
    {
        DateTime CreateDate { get; set; }
        DateTime ChangeDate { get; set; }
        
        int CreateUserId { get; set; }
        int ChangeUserId { get; set; }

        User CreatedBy { get; set; }
        User ChangedBy { get; set; }
    }
}
