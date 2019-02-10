using System;

namespace USClothesWebSite.BusinessLogic.Parcel
{
    public interface IParcelService
    {
        DTO.Parcel[] GetParcels(DateTime startDate, DateTime endDate, string filter);

        void CreateParcel(DTO.Parcel createdParcel);
        void UpdateParcel(DTO.Parcel updatedParcel);
    }
}
