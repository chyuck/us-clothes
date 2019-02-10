namespace USClothesWebSite.BusinessLogic.Brand
{
    public interface IBrandService
    {
        DTO.Brand[] ActiveBrands { get; }

        DTO.Brand[] GetBrands(string filter);

        void CreateBrand(DTO.Brand createdBrand);
        void UpdateBrand(DTO.Brand updatedBrand);
    }
}
