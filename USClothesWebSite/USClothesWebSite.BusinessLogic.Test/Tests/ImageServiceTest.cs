using System;
using System.IO;
using DepIC;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using USClothesWebSite.BusinessLogic.Configuration;
using USClothesWebSite.BusinessLogic.Http;
using USClothesWebSite.BusinessLogic.Image;
using USClothesWebSite.BusinessLogic.Security;
using USClothesWebSite.BusinessLogic.Test.Extensions;
using USClothesWebSite.BusinessLogic.Test.Mocks;
using USClothesWebSite.Common.Helpers;
using USClothesWebSite.Test.Common;

namespace USClothesWebSite.BusinessLogic.Test
{
    [TestClass]
    public class ImageServiceTest
    {
        public TestContext TestContext { get; set; }

        private const string IMAGES_DIRECTORY_PATH = "Images";

        private const string TEST_DATA_DIRECTORY_PATH = @"TestData";
        private const string TEST_IMAGE_PATH = TEST_DATA_DIRECTORY_PATH + @"\testimage.jpg";

        private IContainer CreateContainer(string applicationPath)
        {
            CheckHelper.ArgumentNotNull(applicationPath, "applicationPath");

            var container = ContainerMockFactory.Create();

            container.Remove<IConfigurationService>();
            var configurationServiceMock = new Mock<IConfigurationService>(MockBehavior.Strict);
            configurationServiceMock.Setup(m => m.ImagesDirectoryName).Returns(IMAGES_DIRECTORY_PATH);
            container.SetConstant<IConfigurationService, IConfigurationService>(configurationServiceMock.Object);

            var httpServiceMock = Mock.Get((HttpService)container.Get<IHttpService>());
            httpServiceMock.Setup(m => m.ApplicationPath).Returns(applicationPath);

            return container;
        }

        private ImageService CreateImageService(IContainer container)
        {
            CheckHelper.ArgumentNotNull(container, "container");

            if (container.Contains<IImageService>())
                container.Remove<IImageService>();

            return new ImageService(container);
        }
        
        private byte[] GetTestImage()
        {
            using (var fileStream = new FileStream(TEST_IMAGE_PATH, FileMode.Open, FileAccess.Read))
            {
                using (var memoryStream = new MemoryStream())
                {
                    fileStream.CopyTo(memoryStream);

                    return memoryStream.ToArray();
                }
            }
        }

        private static string GetNameFromURL(string url)
        {
            var underscoreIndex = url.IndexOf("_", StringComparison.Ordinal);
            var lastDotIndex = url.LastIndexOf(".", StringComparison.Ordinal);

            return url.Substring(underscoreIndex + 1, lastDotIndex - underscoreIndex - 1);
        }

        private static void AssertImage(string path, int width, int height)
        {
            using (var image = System.Drawing.Image.FromFile(path))
            {
                Assert.AreEqual(width, image.Width);
                Assert.AreEqual(height, image.Height);
            }
        }

        [TestMethod]
        [DeploymentItem(TEST_IMAGE_PATH, TEST_DATA_DIRECTORY_PATH)]
        public void UploadPicture_Should_Upload_Picture()
        {
            // Arrange
            var container = CreateContainer(TestContext.TestDeploymentDir);
            var imageService = CreateImageService(container);

            var securityService = container.Get<ISecurityService>();
            securityService.LogIn(UserMockFactory.Diana.Login, EncryptServiceMockFactory.DianaPasswordData.Password);

            var testImage = GetTestImage();
            
            // Act
            var picture = imageService.UploadPicture(testImage);

            // Assert
            Assert.IsNotNull(picture);
            Assert.IsNotNull(picture.FullPictureURL);
            Assert.IsNotNull(picture.PreviewPictureURL);

            var fileName = GetNameFromURL(picture.FullPictureURL);

            Assert.AreEqual(HttpServiceMockFactory.APPLICATION_URL + IMAGES_DIRECTORY_PATH + "/full_" + fileName + ".jpg", picture.FullPictureURL);
            Assert.AreEqual(HttpServiceMockFactory.APPLICATION_URL + IMAGES_DIRECTORY_PATH + "/preview_" + fileName + ".jpg", picture.PreviewPictureURL);

            AssertImage(Path.Combine(TestContext.TestDeploymentDir, IMAGES_DIRECTORY_PATH, "full_" + fileName + ".jpg"), 342, 480);
            AssertImage(Path.Combine(TestContext.TestDeploymentDir, IMAGES_DIRECTORY_PATH, "preview_" + fileName + ".jpg"), 91, 128);
        }

        [TestMethod]
        [DeploymentItem(TEST_IMAGE_PATH, TEST_DATA_DIRECTORY_PATH)]
        public void UploadPicture_Should_Throw_Exception_When_Current_User_Is_Not_Seller()
        {
            // Arrange
            var container = CreateContainer(TestContext.TestDeploymentDir);
            var imageService = CreateImageService(container);

            var securityService = container.Get<ISecurityService>();
            securityService.LogIn(UserMockFactory.Olesya.Login, EncryptServiceMockFactory.OlesyaPasswordData.Password);

            var testImage = GetTestImage();

            // Act
            // Assert
            ExceptionAssert.Throw<InvalidOperationException>(
                () => imageService.UploadPicture(testImage),
                "Only seller can upload pictures.");
        }

        [TestMethod]
        [DeploymentItem(TEST_IMAGE_PATH, TEST_DATA_DIRECTORY_PATH)]
        public void DeletePicture_Should_Delete_Picture()
        {
            // Arrange
            var container = CreateContainer(TestContext.TestDeploymentDir);
            var imageService = CreateImageService(container);

            var securityService = container.Get<ISecurityService>();
            securityService.LogIn(UserMockFactory.Diana.Login, EncryptServiceMockFactory.DianaPasswordData.Password);

            var testImage = GetTestImage();
            
            var picture = imageService.UploadPicture(testImage);
            
            // Act
            imageService.DeletePicture(picture);

            // Assert
            var fileName = GetNameFromURL(picture.FullPictureURL);
            Assert.IsFalse(File.Exists(Path.Combine(TestContext.TestDeploymentDir, IMAGES_DIRECTORY_PATH, "full_" + fileName + ".jpg")));
            Assert.IsFalse(File.Exists(Path.Combine(TestContext.TestDeploymentDir, IMAGES_DIRECTORY_PATH, "preview_" + fileName + ".jpg")));
        }

        [TestMethod]
        [DeploymentItem(TEST_IMAGE_PATH, TEST_DATA_DIRECTORY_PATH)]
        public void DeletePicture_Should_Throw_Exception_When_Current_User_Is_Not_Seller()
        {
            // Arrange
            var container = CreateContainer(TestContext.TestDeploymentDir);
            var imageService = CreateImageService(container);

            var securityService = container.Get<ISecurityService>();
            securityService.LogIn(UserMockFactory.Diana.Login, EncryptServiceMockFactory.DianaPasswordData.Password);

            var testImage = GetTestImage();
            var picture = imageService.UploadPicture(testImage);

            securityService.LogOut();
            securityService.LogIn(UserMockFactory.Olesya.Login, EncryptServiceMockFactory.OlesyaPasswordData.Password);

            // Act
            // Assert
            ExceptionAssert.Throw<InvalidOperationException>(
                () => imageService.DeletePicture(picture),
                "Only seller can delete pictures.");
        }
    }
}
