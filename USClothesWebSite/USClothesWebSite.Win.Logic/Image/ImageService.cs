using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using DepIC;
using DepIC.Attributes;
using USClothesWebSite.Common.Extensions;
using USClothesWebSite.Common.Helpers;
using USClothesWebSite.Common.Services;
using USClothesWebSite.Common.Services.Validate;
using USClothesWebSite.DTO;
using USClothesWebSite.Win.Logic.Helpers;
using USClothesWebSite.Win.Logic.ImageAPI;
using USClothesWebSite.Win.Logic.Security;

namespace USClothesWebSite.Win.Logic.Image
{
    internal class ImageService : BaseService, IImageService
    {
        [Inject]
        public ImageService(IReadOnlyContainer container) 
            : base(container)
        {
        }

        private ISecurityService SecurityService
        {
            get { return Container.Get<ISecurityService>(); }
        }

        private static byte[] ResizePicture(byte[] picture)
        {
            using (var pictureMemoryStream = new MemoryStream(picture))
            {
                using (var bitmap = new Bitmap(pictureMemoryStream))
                {
                    using (var resizedBitmap = bitmap.ResizeBitmap(Picture.FULL_PICTURE_MAX_WIDTH, Picture.FULL_PICTURE_MAX_HEIGHT))
                    {
                        using (var resizedPictureMemoryStream = new MemoryStream())
                        {
                            resizedBitmap.Save(resizedPictureMemoryStream, ImageFormat.Jpeg);

                            return resizedPictureMemoryStream.ToArray();
                        }
                    }
                }
            }
        }

        public Picture UploadPicture(string path)
        {
            CheckHelper.ArgumentNotNullAndNotWhiteSpace(path, "path");
            CheckHelper.WithinCondition(SecurityService.IsLoggedIn, "SecurityService.IsLoggedIn");

            CheckHelper.WithinCondition(File.Exists(path), string.Format("File {0} does not exist.", path));
            
            var fileExtension = Path.GetExtension(path);
            CheckHelper.WithinCondition(fileExtension != null && fileExtension.ToUpper() == ".JPG", 
                string.Format("File {0} is not jpg file.", path));

            var picture = File.ReadAllBytes(path);

            var resizedPicture = ResizePicture(picture);

            return APIClientHelper<ImageAPIClient>.Call(c => c.UploadPicture(resizedPicture));
        }

        public void DeletePicture(Picture picture)
        {
            CheckHelper.ArgumentNotNull(picture, "picture");
            CheckHelper.WithinCondition(SecurityService.IsLoggedIn, "SecurityService.IsLoggedIn");

            IoC.Container.Get<IValidateService>().CheckIsValid(picture);

            APIClientHelper<ImageAPIClient>.Call(c => c.DeletePicture(picture));
        }
    }
}
