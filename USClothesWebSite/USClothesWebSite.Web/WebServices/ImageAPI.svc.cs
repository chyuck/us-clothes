using USClothesWebSite.BusinessLogic.Image;
using USClothesWebSite.DTO;

namespace USClothesWebSite.Web.WebServices
{
    public class ImageAPI : BaseAPI, IImageAPI
    {
        public Picture UploadPicture(byte[] picture)
        {
            return Container.Get<IImageService>().UploadPicture(picture);
        }
        
        public void DeletePicture(Picture picture)
        {
            Container.Get<IImageService>().DeletePicture(picture);
        }
    }
}
