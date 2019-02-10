using USClothesWebSite.DTO;

namespace USClothesWebSite.BusinessLogic.DistributorTransfer
{
    public interface IDistributorTransferService
    {
        DTO.DistributorTransfer[] GetDistributorTransfers(User distributor);

        void CreateDistributorTransfer(DTO.DistributorTransfer createdDistributorTransfer);
        void UpdateDistributorTransfer(DTO.DistributorTransfer updatedDistributorTransfer);
    }
}
