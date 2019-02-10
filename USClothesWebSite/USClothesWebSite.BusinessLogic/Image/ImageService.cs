using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using DepIC;
using DepIC.Attributes;
using USClothesWebSite.BusinessLogic.Configuration;
using USClothesWebSite.BusinessLogic.Http;
using USClothesWebSite.BusinessLogic.Security;
using USClothesWebSite.Common.Extensions;
using USClothesWebSite.Common.Helpers;
using USClothesWebSite.Common.Services;
using USClothesWebSite.Common.Services.Validate;
using USClothesWebSite.DTO;

namespace USClothesWebSite.BusinessLogic.Image
{
    internal class ImageService : BaseService, IImageService
    {
        #region Constructors

        [Inject]
        public ImageService(IReadOnlyContainer container)
            : base(container)
        {
        }

        #endregion


        #region Properties

        private ISecurityService SecurityService
        {
            get { return Container.Get<ISecurityService>(); }
        }

        #endregion


        #region Methods

        private string CreateRandomImageName()
        {
            var name = Guid.NewGuid().ToString("N");
            
            return Path.ChangeExtension(name, "jpg");
        }

        private string GetImageDirectoryPath()
        {
            var httpService = Container.Get<IHttpService>();
            var applicationPath = httpService.ApplicationPath;

            var configurationService = Container.Get<IConfigurationService>();
            var imagesDirectoryName = configurationService.ImagesDirectoryName;

            return Path.Combine(applicationPath, imagesDirectoryName);
        }

        private string GetImageDirectoryUrl()
        {
            var httpService = Container.Get<IHttpService>();
            var applicationUrl = httpService.ApplicationUrl;

            var configurationService = Container.Get<IConfigurationService>();
            var imagesDirectoryName = configurationService.ImagesDirectoryName;

            return UrlHelper.Combine(applicationUrl, imagesDirectoryName);
        }

        private string SaveResizedImage(Bitmap bitmap, string fileName, int maxWidth, int maxHeight)
        {
            CheckHelper.ArgumentNotNull(bitmap, "bitmap");
            CheckHelper.ArgumentNotNullAndNotWhiteSpace(fileName, "fileName");

            var imagesDirectoryPath = GetImageDirectoryPath();
            if (!Directory.Exists(imagesDirectoryPath))
                Directory.CreateDirectory(imagesDirectoryPath);

            var fullPicturePath = Path.Combine(imagesDirectoryPath, fileName);
            CheckHelper.WithinCondition(!File.Exists(fullPicturePath), string.Format("File {0} already exists.", fileName));
            
            var imagesDirectoryUrl = GetImageDirectoryUrl();

            using (var resizedBitmap = bitmap.ResizeBitmap(maxWidth, maxHeight))
            {
                resizedBitmap.Save(fullPicturePath, ImageFormat.Jpeg);

                return UrlHelper.Combine(imagesDirectoryUrl, fileName);
            }
        }

        private void RemovePictureByUrl(string url)
        {
            CheckHelper.ArgumentNotNullAndNotWhiteSpace(url, "url");

            var fileName = Path.GetFileName(url);
            var imagesDirectoryPath = GetImageDirectoryPath();
            var fullPicturePath = Path.Combine(imagesDirectoryPath, fileName);

            if (File.Exists(fullPicturePath))
                File.Delete(fullPicturePath);
        }

        #endregion


        #region IImageService
        
        public Picture UploadPicture(byte[] picture)
        {
            CheckHelper.ArgumentNotNull(picture, "picture");
            CheckHelper.WithinCondition(SecurityService.IsCurrentUserSeller, "Only seller can upload pictures.");

            var imageName = CreateRandomImageName();
            var fullPictureName = string.Format("full_{0}", imageName);
            var previewPictureName = string.Format("preview_{0}", imageName);

            using (var pictureMemoryStream = new MemoryStream(picture))
            {
                using (var bitmap = new Bitmap(pictureMemoryStream))
                {
                    return
                        new Picture
                        {
                            FullPictureURL = SaveResizedImage(bitmap, fullPictureName, Picture.FULL_PICTURE_MAX_WIDTH, Picture.FULL_PICTURE_MAX_HEIGHT),
                            PreviewPictureURL = SaveResizedImage(bitmap, previewPictureName, Picture.PREVIEW_PICTURE_MAX_WIDTH, Picture.PREVIEW_PICTURE_MAX_HEIGHT)
                        };
                }
            }
        }

        public void DeletePicture(Picture picture)
        {
            CheckHelper.ArgumentNotNull(picture, "picture");
            CheckHelper.WithinCondition(SecurityService.IsCurrentUserSeller, "Only seller can delete pictures.");
            Container.Get<IValidateService>().CheckIsValid(picture);

            RemovePictureByUrl(picture.FullPictureURL);
            RemovePictureByUrl(picture.PreviewPictureURL);
        }
        
        #endregion
    }
}
