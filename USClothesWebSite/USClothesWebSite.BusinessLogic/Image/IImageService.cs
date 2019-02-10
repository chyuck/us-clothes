using USClothesWebSite.DTO;

namespace USClothesWebSite.BusinessLogic.Image
{
    public interface IImageService
    {
        /// <remarks>
        /// Maximum size of preview picture - 128 x 128 px
        /// Maximum size of full picture - 480 x 480 px
        /// </remarks>
        Picture UploadPicture(byte[] picture);

        void DeletePicture(Picture picture);
    }
}
