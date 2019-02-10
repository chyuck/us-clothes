using System;

namespace USClothesWebSite.DTO
{
    public interface ITrackableDto : IDto
    {
        DateTime CreateDate { get; set; }
        string CreateUser { get; set; }
        DateTime ChangeDate { get; set; }
        string ChangeUser { get; set; }
    }
}
