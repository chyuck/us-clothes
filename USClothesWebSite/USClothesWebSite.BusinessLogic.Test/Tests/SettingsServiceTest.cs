using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using USClothesWebSite.BusinessLogic.Dto;
using USClothesWebSite.BusinessLogic.Security;
using USClothesWebSite.BusinessLogic.Settings;
using USClothesWebSite.BusinessLogic.Test.Extensions;
using USClothesWebSite.BusinessLogic.Test.Mocks;
using USClothesWebSite.Common.Services.Time;
using USClothesWebSite.DataAccess;
using USClothesWebSite.Test.Common;

namespace USClothesWebSite.BusinessLogic.Test
{
    [TestClass]
    public class SettingsServiceTest
    {
        [TestMethod]
        public void Settings_Should_Return_Settings()
        {
            // Arrange
            var container = ContainerMockFactory.Create();

            container.Get<ISecurityService>().LogInGuest();

            var dtoService = container.Get<IDtoService>();
            var settingsService = container.Get<ISettingsService>();

            // Act
            var settings = settingsService.Settings;

            // Assert
            var expectedSettings = dtoService.CreateSettings(SettingsMockFactory.SingleSettings);

            Assert.AreEqual(expectedSettings, settings);
        }

        [TestMethod]
        public void Settings_Should_Throw_Exception_When_Current_User_Is_Not_Logged_In()
        {
            // Arrange
            var container = ContainerMockFactory.Create();
            var settingsService = container.Get<ISettingsService>();

            // Act
            // Assert
            ExceptionAssert.Throw<InvalidOperationException>(
                () => { var settings = settingsService.Settings; },
                "User is not logged in.");
        }

        [TestMethod]
        public void UpdateSettings_Should_Update_Settings()
        {
            // Arrange
            var container = ContainerMockFactory.Create();

            container.Get<ISecurityService>().LogIn(UserMockFactory.Jenya.Login, EncryptServiceMockFactory.JenyaPasswordData.Password);
            
            const decimal NEW_SETTINGS_RUBLES_PER_DOLLAR = 34;
            var createDate = SettingsMockFactory.SingleSettings.CreateDate;
            var createdBy = SettingsMockFactory.SingleSettings.CreatedBy;

            var updatedSettings =
                new DTO.Settings
                {
                    Id = SettingsMockFactory.SingleSettings.Id,
                    RublesPerDollar = NEW_SETTINGS_RUBLES_PER_DOLLAR
                };

            var settingsService = container.Get<ISettingsService>();
            var persistentService = container.Get<IPersistentService>();
            var timeService = container.Get<ITimeService>();

            // Act
            settingsService.UpdateSettings(updatedSettings);

            // Assert
            var actualSettings = persistentService.GetEntitySet<DataAccess.Settings>().Single();

            Assert.AreEqual(SettingsMockFactory.SingleSettings.Id, actualSettings.Id);
            Assert.AreEqual(NEW_SETTINGS_RUBLES_PER_DOLLAR, actualSettings.RublesPerDollar);
            Assert.AreEqual(createDate, actualSettings.CreateDate);
            Assert.AreEqual(timeService.UtcNow, actualSettings.ChangeDate);
            Assert.AreEqual(createdBy, actualSettings.CreatedBy);
            Assert.AreEqual(UserMockFactory.Jenya, actualSettings.ChangedBy);

            Assert.AreEqual(updatedSettings, container.Get<IDtoService>().CreateSettings(actualSettings));
        }

        [TestMethod]
        public void UpdateSettings_Should_Throw_Exception_When_Current_User_Is_Not_Administrator()
        {
            // Arrange
            var container = ContainerMockFactory.Create();

            container.Get<ISecurityService>().LogIn(UserMockFactory.Olesya.Login, EncryptServiceMockFactory.OlesyaPasswordData.Password);

            var updatedSettings =
                new DTO.Settings
                {
                    Id = SettingsMockFactory.SingleSettings.Id,
                    RublesPerDollar = 34
                };

            var settingsService = container.Get<ISettingsService>();

            // Act
            // Assert
            ExceptionAssert.Throw<InvalidOperationException>(
                () => settingsService.UpdateSettings(updatedSettings),
                "Only administrator can update settings.");
        }
    }
}
