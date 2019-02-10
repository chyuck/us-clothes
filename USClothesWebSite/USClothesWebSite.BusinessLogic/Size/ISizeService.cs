using USClothesWebSite.DTO;

namespace USClothesWebSite.BusinessLogic.Size
{
    public interface ISizeService
    {
        DTO.Size[] GetActiveSizes(SubCategory subCategory, DTO.Brand brand);

        DTO.Size[] GetSizes(SubCategory subCategory, DTO.Brand brand, string filter);
        DTO.Size[] GetSizes(string filter);

        void CreateSize(DTO.Size createdSize);
        void UpdateSize(DTO.Size updatedSize);
    }
}
