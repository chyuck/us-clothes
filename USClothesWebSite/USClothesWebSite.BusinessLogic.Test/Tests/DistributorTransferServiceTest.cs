using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using USClothesWebSite.BusinessLogic.DistributorTransfer;
using USClothesWebSite.BusinessLogic.Dto;
using USClothesWebSite.BusinessLogic.Security;
using USClothesWebSite.BusinessLogic.Test.Extensions;
using USClothesWebSite.BusinessLogic.Test.Mocks;
using USClothesWebSite.Common.Services.Time;
using USClothesWebSite.DataAccess;
using USClothesWebSite.Test.Common;
using USClothesWebSite.BusinessLogic.Extensions;

namespace USClothesWebSite.BusinessLogic.Test
{
    [TestClass]
    public class DistributorTransferServiceTest
    {
        [TestMethod]
        public void GetDistributorTransfers_Should_Return_All_Transfers_When_Current_User_Is_Purchaser_And_Distributor_Is_Null()
        {
            // Arrange
            var container = ContainerMockFactory.Create();
            var securityService = container.Get<ISecurityService>();

            UserRoleMockFactory.JenyaDistributor.Active = false;
            UserRoleMockFactory.JenyaPurchaser.Active = true;
            UserRoleMockFactory.JenyaAdministrator.Active = false;
            UserRoleMockFactory.JenyaSeller.Active = false;
            securityService.LogIn(UserMockFactory.Jenya.Login, EncryptServiceMockFactory.JenyaPasswordData.Password);

            var dtoService = container.Get<IDtoService>();
            var distributorTransferService = container.Get<IDistributorTransferService>();

            // Act
            var distributorTransfers = distributorTransferService.GetDistributorTransfers(null);

            // Assert
            var expectedDistributorTransfers =
                new[]
                {
                    dtoService.CreateDistributorTransfer(DistributorTransferMockFactory.Olesya_Transfer_1),
                    dtoService.CreateDistributorTransfer(DistributorTransferMockFactory.Olesya_Transfer_2),
                    dtoService.CreateDistributorTransfer(DistributorTransferMockFactory.Diana_Transfer_1),
                    dtoService.CreateDistributorTransfer(DistributorTransferMockFactory.Diana_Transfer_2)
                };

            CollectionAssert.AreEqual(expectedDistributorTransfers, distributorTransfers);
        }

        [TestMethod]
        public void GetDistributorTransfers_Should_Return_Only_Transfers_Of_Specified_Distributor_When_Current_User_Is_Purchaser_And_Distributor_Is_Specified()
        {
            // Arrange
            var container = ContainerMockFactory.Create();
            var securityService = container.Get<ISecurityService>();

            UserRoleMockFactory.JenyaDistributor.Active = false;
            UserRoleMockFactory.JenyaPurchaser.Active = true;
            UserRoleMockFactory.JenyaAdministrator.Active = false;
            UserRoleMockFactory.JenyaSeller.Active = false;
            securityService.LogIn(UserMockFactory.Jenya.Login, EncryptServiceMockFactory.JenyaPasswordData.Password);

            var dtoService = container.Get<IDtoService>();
            var distributorTransferService = container.Get<IDistributorTransferService>();

            var distributor = dtoService.CreateUser(UserMockFactory.Diana);

            // Act
            var distributorTransfers = distributorTransferService.GetDistributorTransfers(distributor);

            // Assert
            var expectedDistributorTransfers =
                new[]
                {
                    dtoService.CreateDistributorTransfer(DistributorTransferMockFactory.Diana_Transfer_1),
                    dtoService.CreateDistributorTransfer(DistributorTransferMockFactory.Diana_Transfer_2)
                };

            CollectionAssert.AreEqual(expectedDistributorTransfers, distributorTransfers);
        }

        [TestMethod]
        public void GetDistributorTransfers_Should_Return_Only_Transfers_Of_Current_Distributor_When_User_Is_Distributor_And_Distributor_Is_Null()
        {
            // Arrange
            var container = ContainerMockFactory.Create();
            var securityService = container.Get<ISecurityService>();

            UserRoleMockFactory.OlesyaDistributor.Active = true;
            UserRoleMockFactory.OlesyaPurchaser.Active = false;
            UserRoleMockFactory.OlesyaAdministrator.Active = false;
            UserRoleMockFactory.OlesyaSeller.Active = false;
            securityService.LogIn(UserMockFactory.Olesya.Login, EncryptServiceMockFactory.OlesyaPasswordData.Password);

            var dtoService = container.Get<IDtoService>();
            var distributorTransferService = container.Get<IDistributorTransferService>();

            // Act
            var distributorTransfers = distributorTransferService.GetDistributorTransfers(null);

            // Assert
            var expectedDistributorTransfers =
                new[]
                {
                    dtoService.CreateDistributorTransfer(DistributorTransferMockFactory.Olesya_Transfer_1),
                    dtoService.CreateDistributorTransfer(DistributorTransferMockFactory.Olesya_Transfer_2)
                };

            CollectionAssert.AreEqual(expectedDistributorTransfers, distributorTransfers);
        }

        [TestMethod]
        public void GetDistributorTransfers_Should_Return_All_Transfers_When_Current_User_Is_Purchaser_And_Distributor()
        {
            // Arrange
            var container = ContainerMockFactory.Create();
            var securityService = container.Get<ISecurityService>();

            UserRoleMockFactory.JenyaDistributor.Active = true;
            UserRoleMockFactory.JenyaPurchaser.Active = true;
            UserRoleMockFactory.JenyaAdministrator.Active = false;
            UserRoleMockFactory.JenyaSeller.Active = false;
            securityService.LogIn(UserMockFactory.Jenya.Login, EncryptServiceMockFactory.JenyaPasswordData.Password);

            var dtoService = container.Get<IDtoService>();
            var distributorTransferService = container.Get<IDistributorTransferService>();

            // Act
            var distributorTransfers = distributorTransferService.GetDistributorTransfers(null);

            // Assert
            var expectedDistributorTransfers =
                new[]
                {
                    dtoService.CreateDistributorTransfer(DistributorTransferMockFactory.Olesya_Transfer_1),
                    dtoService.CreateDistributorTransfer(DistributorTransferMockFactory.Olesya_Transfer_2),
                    dtoService.CreateDistributorTransfer(DistributorTransferMockFactory.Diana_Transfer_1),
                    dtoService.CreateDistributorTransfer(DistributorTransferMockFactory.Diana_Transfer_2)
                };

            CollectionAssert.AreEqual(expectedDistributorTransfers, distributorTransfers);
        }

        [TestMethod]
        public void GetDistributorTransfers_Should_Throw_Exception_When_Current_User_Is_Distributor_And_Distributor_Is_Not_Null()
        {
            // Arrange
            var container = ContainerMockFactory.Create();
            var securityService = container.Get<ISecurityService>();

            UserRoleMockFactory.OlesyaDistributor.Active = true;
            UserRoleMockFactory.OlesyaPurchaser.Active = false;
            UserRoleMockFactory.OlesyaAdministrator.Active = false;
            UserRoleMockFactory.OlesyaSeller.Active = false;
            securityService.LogIn(UserMockFactory.Olesya.Login, EncryptServiceMockFactory.OlesyaPasswordData.Password);

            var dtoService = container.Get<IDtoService>();
            var distributorTransferService = container.Get<IDistributorTransferService>();

            var distributor = dtoService.CreateUser(UserMockFactory.Diana);

            // Act
            // Assert
            ExceptionAssert.Throw<InvalidOperationException>(
                () => distributorTransferService.GetDistributorTransfers(distributor),
                "Distributor can only get all transfers without any filter specified.");
        }

        [TestMethod]
        public void GetDistributorTransfers_Should_Throw_Exception_When_Current_User_Is_Not_Distributor_And_Purchaser()
        {
            // Arrange
            var container = ContainerMockFactory.Create();
            var securityService = container.Get<ISecurityService>();

            UserRoleMockFactory.OlesyaDistributor.Active = false;
            UserRoleMockFactory.OlesyaPurchaser.Active = false;
            UserRoleMockFactory.OlesyaAdministrator.Active = true;
            UserRoleMockFactory.OlesyaSeller.Active = true;
            securityService.LogIn(UserMockFactory.Olesya.Login, EncryptServiceMockFactory.OlesyaPasswordData.Password);

            var distributorTransferService = container.Get<IDistributorTransferService>();

            // Act
            // Assert
            ExceptionAssert.Throw<InvalidOperationException>(
                () => distributorTransferService.GetDistributorTransfers(null),
                "Only purchaser and distributor can get all distributor transfers.");
        }

        [TestMethod]
        public void CreateDistributorTransfer_Should_Create_Transfer_When_Current_User_Is_Distributor()
        {
            // Arrange
            var container = ContainerMockFactory.Create();
            var securityService = container.Get<ISecurityService>();

            UserRoleMockFactory.OlesyaDistributor.Active = true;
            UserRoleMockFactory.OlesyaPurchaser.Active = false;
            UserRoleMockFactory.OlesyaAdministrator.Active = false;
            UserRoleMockFactory.OlesyaSeller.Active = false;
            securityService.LogIn(UserMockFactory.Olesya.Login, EncryptServiceMockFactory.OlesyaPasswordData.Password);

            var date = new DateTime(2013, 7, 23);
            const decimal AMOUNT = 10200m;
            const bool ACTIVE = true;
            const decimal RUBLES_PER_DOLLAR = 33.1m;

            var createdDistributorTransfer =
                new DTO.DistributorTransfer
                {
                    Date = date,
                    Amount = AMOUNT,
                    Active = ACTIVE,
                    RublesPerDollar = RUBLES_PER_DOLLAR
                };

            var distributorTransferService = container.Get<IDistributorTransferService>();
            var persistentService = container.Get<IPersistentService>();
            var timeService = container.Get<ITimeService>();

            // Act
            distributorTransferService.CreateDistributorTransfer(createdDistributorTransfer);

            // Assert
            var actualDistributorTransfer =
                persistentService
                    .GetEntitySet<DataAccess.DistributorTransfer>()
                    .Single(dt => dt.Date == date);

            Assert.IsTrue(actualDistributorTransfer.Id > 0);
            Assert.AreEqual(date, actualDistributorTransfer.Date);
            Assert.AreEqual(AMOUNT, actualDistributorTransfer.Amount);
            Assert.IsTrue(actualDistributorTransfer.Active);
            Assert.AreEqual(RUBLES_PER_DOLLAR, actualDistributorTransfer.RublesPerDollar);
            Assert.AreEqual(timeService.UtcNow, actualDistributorTransfer.CreateDate);
            Assert.AreEqual(timeService.UtcNow, actualDistributorTransfer.ChangeDate);
            Assert.AreEqual(UserMockFactory.Olesya, actualDistributorTransfer.CreatedBy);
            Assert.AreEqual(UserMockFactory.Olesya, actualDistributorTransfer.ChangedBy);

            Assert.AreEqual(createdDistributorTransfer, container.Get<IDtoService>().CreateDistributorTransfer(actualDistributorTransfer));
        }

        [TestMethod]
        public void CreateDistributorTransfer_Should_Throw_Exception_When_Current_User_Is_Not_Distributor()
        {
            // Arrange
            var container = ContainerMockFactory.Create();
            var securityService = container.Get<ISecurityService>();

            UserRoleMockFactory.OlesyaDistributor.Active = false;
            UserRoleMockFactory.OlesyaPurchaser.Active = true;
            UserRoleMockFactory.OlesyaAdministrator.Active = true;
            UserRoleMockFactory.OlesyaSeller.Active = true;
            securityService.LogIn(UserMockFactory.Olesya.Login, EncryptServiceMockFactory.OlesyaPasswordData.Password);

            var createdDistributorTransfer =
                new DTO.DistributorTransfer
                {
                    Date = new DateTime(2013, 7, 23),
                    Amount = 10200m,
                    Active = true,
                    RublesPerDollar = 33.1m
                };

            var distributorTransferService = container.Get<IDistributorTransferService>();

            // Act
            // Assert
            ExceptionAssert.Throw<InvalidOperationException>(
                () => distributorTransferService.CreateDistributorTransfer(createdDistributorTransfer),
                "Only distributor can create distributor transfer.");
        }

        [TestMethod]
        public void UpdateDistributorTransfer_Should_Create_Transfer_When_Current_User_Is_Distributor()
        {
            // Arrange
            var container = ContainerMockFactory.Create();
            var securityService = container.Get<ISecurityService>();

            UserRoleMockFactory.OlesyaDistributor.Active = true;
            UserRoleMockFactory.OlesyaPurchaser.Active = false;
            UserRoleMockFactory.OlesyaAdministrator.Active = false;
            UserRoleMockFactory.OlesyaSeller.Active = false;
            securityService.LogIn(UserMockFactory.Olesya.Login, EncryptServiceMockFactory.OlesyaPasswordData.Password);

            var date = new DateTime(2013, 7, 23);
            const decimal AMOUNT = 10200m;
            const bool ACTIVE = false;
            const decimal RUBLES_PER_DOLLAR = 33.1m;
            var createDate = DistributorTransferMockFactory.Olesya_Transfer_1.CreateDate;
            var createdBy = DistributorTransferMockFactory.Olesya_Transfer_1.CreatedBy;

            var updatedDistributorTransfer =
                new DTO.DistributorTransfer
                {
                    Id = DistributorTransferMockFactory.Olesya_Transfer_1.Id,
                    Date = date,
                    Amount = AMOUNT,
                    Active = ACTIVE,
                    RublesPerDollar = RUBLES_PER_DOLLAR
                };

            var distributorTransferService = container.Get<IDistributorTransferService>();
            var persistentService = container.Get<IPersistentService>();
            var timeService = container.Get<ITimeService>();

            // Act
            distributorTransferService.UpdateDistributorTransfer(updatedDistributorTransfer);

            // Assert
            var actualDistributorTransfer =
                persistentService.GetEntityById<DataAccess.DistributorTransfer>(
                    DistributorTransferMockFactory.Olesya_Transfer_1.Id);

            Assert.AreEqual(date, actualDistributorTransfer.Date);
            Assert.AreEqual(AMOUNT, actualDistributorTransfer.Amount);
            Assert.AreEqual(ACTIVE, actualDistributorTransfer.Active);
            Assert.AreEqual(RUBLES_PER_DOLLAR, actualDistributorTransfer.RublesPerDollar);
            Assert.AreEqual(createDate, actualDistributorTransfer.CreateDate);
            Assert.AreEqual(timeService.UtcNow, actualDistributorTransfer.ChangeDate);
            Assert.AreEqual(createdBy, actualDistributorTransfer.CreatedBy);
            Assert.AreEqual(UserMockFactory.Olesya, actualDistributorTransfer.ChangedBy);

            Assert.AreEqual(updatedDistributorTransfer, container.Get<IDtoService>().CreateDistributorTransfer(actualDistributorTransfer));
        }

        [TestMethod]
        public void UpdateDistributorTransfer_Should_Throw_Exception_When_Current_User_Is_Not_Distributor()
        {
            // Arrange
            var container = ContainerMockFactory.Create();
            var securityService = container.Get<ISecurityService>();

            UserRoleMockFactory.OlesyaDistributor.Active = false;
            UserRoleMockFactory.OlesyaPurchaser.Active = true;
            UserRoleMockFactory.OlesyaAdministrator.Active = true;
            UserRoleMockFactory.OlesyaSeller.Active = true;
            securityService.LogIn(UserMockFactory.Olesya.Login, EncryptServiceMockFactory.OlesyaPasswordData.Password);

            var updatedDistributorTransfer =
                new DTO.DistributorTransfer
                {
                    Id = DistributorTransferMockFactory.Olesya_Transfer_1.Id,
                    Date = new DateTime(2013, 7, 23),
                    Amount = 10200m,
                    Active = false,
                    RublesPerDollar = 33.1m
                };

            var distributorTransferService = container.Get<IDistributorTransferService>();

            // Act
            // Assert
            ExceptionAssert.Throw<InvalidOperationException>(
                () => distributorTransferService.UpdateDistributorTransfer(updatedDistributorTransfer),
                "Only distributor can change distributor transfer.");
        }

        [TestMethod]
        public void UpdateDistributorTransfer_Should_Throw_Exception_When_Transfer_Is_Created_By_Another_Distributor()
        {
            // Arrange
            var container = ContainerMockFactory.Create();
            var securityService = container.Get<ISecurityService>();

            UserRoleMockFactory.OlesyaDistributor.Active = true;
            UserRoleMockFactory.OlesyaPurchaser.Active = false;
            UserRoleMockFactory.OlesyaAdministrator.Active = false;
            UserRoleMockFactory.OlesyaSeller.Active = false;
            securityService.LogIn(UserMockFactory.Olesya.Login, EncryptServiceMockFactory.OlesyaPasswordData.Password);

            var updatedDistributorTransfer =
                new DTO.DistributorTransfer
                {
                    Id = DistributorTransferMockFactory.Diana_Transfer_1.Id,
                    Date = new DateTime(2013, 7, 23),
                    Amount = 10200m,
                    Active = false,
                    RublesPerDollar = 33.1m
                };

            var distributorTransferService = container.Get<IDistributorTransferService>();

            // Act
            // Assert
            ExceptionAssert.Throw<InvalidOperationException>(
                () => distributorTransferService.UpdateDistributorTransfer(updatedDistributorTransfer),
                "Distributor can only change distributor transfer created by him.");
        }
    }
}
