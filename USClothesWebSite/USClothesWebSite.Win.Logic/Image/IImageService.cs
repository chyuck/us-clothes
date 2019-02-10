using USClothesWebSite.DTO;

namespace USClothesWebSite.Win.Logic.Image
{
    public interface IImageService
    {
        Picture UploadPicture(string path);
        void DeletePicture(Picture picture);
    }
}
