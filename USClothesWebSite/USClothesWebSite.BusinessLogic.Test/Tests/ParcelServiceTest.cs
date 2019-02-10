using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using USClothesWebSite.BusinessLogic.Dto;
using USClothesWebSite.BusinessLogic.Parcel;
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
    public class ParcelServiceTest
    {
        [TestMethod]
        public void GetParcels_Should_Return_Parcels_By_Filter()
        {
            // Arrange
            var container = ContainerMockFactory.Create();
            var securityService = container.Get<ISecurityService>();

            securityService.LogIn(UserMockFactory.Jenya.Login, EncryptServiceMockFactory.JenyaPasswordData.Password);

            var dtoService = container.Get<IDtoService>();
            var parcelService = container.Get<IParcelService>();

            // Act
            var parcels =
                parcelService.GetParcels(
                    TimeServiceMockFactory.Date1, TimeServiceMockFactory.Date5, "7654");

            // Assert
            var expectedParcels =
                new[]
                {
                    dtoService.CreateParcel(ParcelMockFactory.Parcel_1)
                };
            CollectionAssert.AreEqual(expectedParcels, parcels);
        }

        [TestMethod]
        public void GetParcels_Should_Return_Parcels_By_Dates()
        {
            // Arrange
            var container = ContainerMockFactory.Create();
            var securityService = container.Get<ISecurityService>();

            securityService.LogIn(UserMockFactory.Jenya.Login, EncryptServiceMockFactory.JenyaPasswordData.Password);

            var dtoService = container.Get<IDtoService>();
            var parcelService = container.Get<IParcelService>();

            // Act
            var parcels =
                parcelService.GetParcels(
                    TimeServiceMockFactory.Date2, TimeServiceMockFactory.Date3, null);

            // Assert
            var expectedParcels =
                new[]
                {
                    dtoService.CreateParcel(ParcelMockFactory.Parcel_1),
                    dtoService.CreateParcel(ParcelMockFactory.Parcel_3)
                };
            CollectionAssert.AreEqual(expectedParcels, parcels);
        }

        [TestMethod]
        public void GetParcels_Should_Return_Parcels_With_Orders_Created_By_Current_User_When_Current_User_Is_Seller()
        {
            // Arrange
            var container = ContainerMockFactory.Create();
            var securityService = container.Get<ISecurityService>();

            UserRoleMockFactory.DianaDistributor.Active = false;
            UserRoleMockFactory.DianaPurchaser.Active = false;
            UserRoleMockFactory.DianaAdministrator.Active = false;
            UserRoleMockFactory.DianaSeller.Active = true;
            securityService.LogIn(UserMockFactory.Diana.Login, EncryptServiceMockFactory.DianaPasswordData.Password);

            var dtoService = container.Get<IDtoService>();
            var parcelService = container.Get<IParcelService>();

            // Act
            var parcels =
                parcelService.GetParcels(
                    TimeServiceMockFactory.Date1, TimeServiceMockFactory.Date5, null);

            // Assert
            var expectedParcels =
                new[]
                {
                    dtoService.CreateParcel(ParcelMockFactory.Parcel_2),
                    dtoService.CreateParcel(ParcelMockFactory.Parcel_3)
                };
            CollectionAssert.AreEqual(expectedParcels, parcels);
        }
        
        [TestMethod]
        public void GetParcels_Should_Return_Parcels_With_Current_User_As_Distributor_When_Current_User_Is_Distributor()
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
            var parcelService = container.Get<IParcelService>();

            // Act
            var parcels =
                parcelService.GetParcels(
                    TimeServiceMockFactory.Date1, TimeServiceMockFactory.Date5, null);

            // Assert
            var expectedParcels =
                new[]
                {
                    dtoService.CreateParcel(ParcelMockFactory.Parcel_1)
                };
            CollectionAssert.AreEqual(expectedParcels, parcels);
        }

        [TestMethod]
        public void GetParcels_Should_Return_Parcels_When_Current_User_Is_Purchaser()
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
            var parcelService = container.Get<IParcelService>();

            // Act
            var parcels =
                parcelService.GetParcels(
                    TimeServiceMockFactory.Date1, TimeServiceMockFactory.Date5, null);

            // Assert
            var expectedParcels =
                new[]
                {
                    dtoService.CreateParcel(ParcelMockFactory.Parcel_1),
                    dtoService.CreateParcel(ParcelMockFactory.Parcel_2),
                    dtoService.CreateParcel(ParcelMockFactory.Parcel_3)
                };
            CollectionAssert.AreEqual(expectedParcels, parcels);
        }

        [TestMethod]
        public void GetParcels_Should_Return_Parcels_When_Current_User_Is_Purchaser_Distributor_Seller()
        {
            // Arrange
            var container = ContainerMockFactory.Create();
            var securityService = container.Get<ISecurityService>();

            UserRoleMockFactory.JenyaDistributor.Active = true;
            UserRoleMockFactory.JenyaPurchaser.Active = true;
            UserRoleMockFactory.JenyaAdministrator.Active = false;
            UserRoleMockFactory.JenyaSeller.Active = true;
            securityService.LogIn(UserMockFactory.Jenya.Login, EncryptServiceMockFactory.JenyaPasswordData.Password);

            var dtoService = container.Get<IDtoService>();
            var parcelService = container.Get<IParcelService>();

            // Act
            var parcels =
                parcelService.GetParcels(
                    TimeServiceMockFactory.Date1, TimeServiceMockFactory.Date5, null);

            // Assert
            var expectedParcels =
                new[]
                {
                    dtoService.CreateParcel(ParcelMockFactory.Parcel_1),
                    dtoService.CreateParcel(ParcelMockFactory.Parcel_2),
                    dtoService.CreateParcel(ParcelMockFactory.Parcel_3)
                };
            CollectionAssert.AreEqual(expectedParcels, parcels);
        }

        [TestMethod]
        public void GetParcels_Should_Return_Parcels_When_Current_User_Is_Seller_Distributor()
        {
            // Arrange
            var container = ContainerMockFactory.Create();
            var securityService = container.Get<ISecurityService>();

            UserRoleMockFactory.DianaDistributor.Active = true;
            UserRoleMockFactory.DianaPurchaser.Active = false;
            UserRoleMockFactory.DianaAdministrator.Active = false;
            UserRoleMockFactory.DianaSeller.Active = true;
            securityService.LogIn(UserMockFactory.Diana.Login, EncryptServiceMockFactory.DianaPasswordData.Password);

            var dtoService = container.Get<IDtoService>();
            var parcelService = container.Get<IParcelService>();

            // Act
            var parcels =
                parcelService.GetParcels(
                    TimeServiceMockFactory.Date1, TimeServiceMockFactory.Date5, null);

            // Assert
            var expectedParcels =
                new[]
                {
                    dtoService.CreateParcel(ParcelMockFactory.Parcel_2),
                    dtoService.CreateParcel(ParcelMockFactory.Parcel_3)
                };
            CollectionAssert.AreEqual(expectedParcels, parcels);
        }
        
        [TestMethod]
        public void GetParcels_Should_Throw_Exception_When_Current_User_Is_Not_Seller_Purchaser_Distributor()
        {
            // Arrange
            var container = ContainerMockFactory.Create();
            var securityService = container.Get<ISecurityService>();

            UserMockFactory.Andrey.Active = true;
            securityService.LogIn(UserMockFactory.Andrey.Login, EncryptServiceMockFactory.AndreyPasswordData.Password);

            var parcelService = container.Get<IParcelService>();

            // Act
            // Assert
            ExceptionAssert.Throw<InvalidOperationException>(
                () => parcelService.GetParcels(TimeServiceMockFactory.Date1, TimeServiceMockFactory.Date5, null),
                "Only seller, purchaser and distributor can get all parcels.");
        }

        [TestMethod]
        public void CreateParcel_Should_Create_Parcel()
        {
            // Arrange
            var container = ContainerMockFactory.Create();
            var securityService = container.Get<ISecurityService>();

            UserRoleMockFactory.JenyaDistributor.Active = false;
            UserRoleMockFactory.JenyaPurchaser.Active = true;
            UserRoleMockFactory.JenyaAdministrator.Active = false;
            UserRoleMockFactory.JenyaSeller.Active = false;
            securityService.LogIn(UserMockFactory.Jenya.Login, EncryptServiceMockFactory.JenyaPasswordData.Password);
            
            const decimal RUBLES_PER_DOLLAR = 31.5m;
            const decimal PURCHASER_SPENT_ON_DELIVERY = 149m;
            const string TRACK_NUMBER = "US867958674896Z";
            var sentDate = new DateTime(2013, 5, 31);
            var distributor = container.Get<IDtoService>().CreateUser(UserMockFactory.Olesya);
            const string COMMENTS = "Some comments";

            var createdParcel =
                new DTO.Parcel
                {
                    RublesPerDollar = RUBLES_PER_DOLLAR,
                    PurchaserSpentOnDelivery = PURCHASER_SPENT_ON_DELIVERY,
                    TrackingNumber = TRACK_NUMBER,
                    SentDate = sentDate,
                    Distributor = distributor,
                    Comments = COMMENTS,
                    
                    // Filled by Distributor
                    ReceivedDate = new DateTime(2013, 6, 30)
                };
  
            var parcelService = container.Get<IParcelService>();
            var persistentService = container.Get<IPersistentService>();
            var timeService = container.Get<ITimeService>();
 
            // Act
            parcelService.CreateParcel(createdParcel);

            // Assert
            Assert.IsTrue(createdParcel.Id > 0);

            var actualParcel = persistentService.GetEntityById<DataAccess.Parcel>(createdParcel.Id);
            
            Assert.AreEqual(createdParcel.Id, actualParcel.Id);
            Assert.AreEqual(RUBLES_PER_DOLLAR, actualParcel.RublesPerDollar);
            Assert.AreEqual(PURCHASER_SPENT_ON_DELIVERY, actualParcel.PurchaserSpentOnDelivery);
            Assert.AreEqual(TRACK_NUMBER, actualParcel.TrackingNumber);
            Assert.AreEqual(sentDate, actualParcel.SentDate);
            Assert.AreEqual(distributor.Id, actualParcel.DistributorId);
            Assert.AreEqual(COMMENTS, actualParcel.Comments);
            Assert.IsNull(actualParcel.ReceivedDate);
            Assert.AreEqual(timeService.UtcNow, actualParcel.CreateDate);
            Assert.AreEqual(timeService.UtcNow, actualParcel.ChangeDate);
            Assert.AreEqual(UserMockFactory.Jenya, actualParcel.CreatedBy);
            Assert.AreEqual(UserMockFactory.Jenya, actualParcel.ChangedBy);

            Assert.AreEqual(createdParcel, container.Get<IDtoService>().CreateParcel(actualParcel));
        }

        [TestMethod]
        public void CreateParcel_Should_Throw_Exception_When_Current_User_Is_Not_Purchaser()
        {
            // Arrange
            var container = ContainerMockFactory.Create();
            var securityService = container.Get<ISecurityService>();

            securityService.LogIn(UserMockFactory.Diana.Login, EncryptServiceMockFactory.DianaPasswordData.Password);

            var createdParcel =
                new DTO.Parcel
                {
                    RublesPerDollar = 31.5m,
                    PurchaserSpentOnDelivery = 149m,
                    TrackingNumber = "US867958674896Z",
                    SentDate = new DateTime(2013, 5, 31),
                    Distributor = container.Get<IDtoService>().CreateUser(UserMockFactory.Olesya),
                    Comments = "Some comments"
                };

            var parcelService = container.Get<IParcelService>();

            // Act
            // Assert
            ExceptionAssert.Throw<InvalidOperationException>(
                () => parcelService.CreateParcel(createdParcel),
                "Only purchaser can create parcel.");
        }

        [TestMethod]
        public void UpdateParcel_Should_Update_Parcel_When_Current_User_Is_Purchaser()
        {
            // Arrange
            var container = ContainerMockFactory.Create();
            var securityService = container.Get<ISecurityService>();

            UserRoleMockFactory.JenyaDistributor.Active = false;
            UserRoleMockFactory.JenyaPurchaser.Active = true;
            UserRoleMockFactory.JenyaAdministrator.Active = false;
            UserRoleMockFactory.JenyaSeller.Active = false;
            securityService.LogIn(UserMockFactory.Jenya.Login, EncryptServiceMockFactory.JenyaPasswordData.Password);

            const decimal RUBLES_PER_DOLLAR = 31.5m;
            const decimal PURCHASER_SPENT_ON_DELIVERY = 149m;
            const string TRACK_NUMBER = "US867958674896Z";
            var sentDate = new DateTime(2013, 5, 31);
            var distributor = container.Get<IDtoService>().CreateUser(UserMockFactory.Diana);
            const string COMMENTS = "Some comments";
            var receivedDate = ParcelMockFactory.Parcel_1.ReceivedDate;
            var createDate = ParcelMockFactory.Parcel_1.CreateDate;
            var createdBy = ParcelMockFactory.Parcel_1.CreatedBy;

            var updatedParcel =
                new DTO.Parcel
                {
                    Id = ParcelMockFactory.Parcel_1.Id,
                    RublesPerDollar = RUBLES_PER_DOLLAR,
                    PurchaserSpentOnDelivery = PURCHASER_SPENT_ON_DELIVERY,
                    TrackingNumber = TRACK_NUMBER,
                    SentDate = sentDate,
                    Distributor = distributor,
                    Comments = COMMENTS,

                    // Filled by Distributor
                    ReceivedDate = new DateTime(2013, 6, 30)
                };

            var parcelService = container.Get<IParcelService>();
            var persistentService = container.Get<IPersistentService>();
            var timeService = container.Get<ITimeService>();

            // Act
            parcelService.UpdateParcel(updatedParcel);

            // Assert
            var actualParcel = persistentService.GetEntityById<DataAccess.Parcel>(ParcelMockFactory.Parcel_1.Id);

            Assert.AreEqual(RUBLES_PER_DOLLAR, actualParcel.RublesPerDollar);
            Assert.AreEqual(PURCHASER_SPENT_ON_DELIVERY, actualParcel.PurchaserSpentOnDelivery);
            Assert.AreEqual(TRACK_NUMBER, actualParcel.TrackingNumber);
            Assert.AreEqual(sentDate, actualParcel.SentDate);
            Assert.AreEqual(distributor.Id, actualParcel.DistributorId);
            Assert.AreEqual(COMMENTS, actualParcel.Comments);
            Assert.AreEqual(receivedDate, actualParcel.ReceivedDate);
            Assert.AreEqual(createDate, actualParcel.CreateDate);
            Assert.AreEqual(timeService.UtcNow, actualParcel.ChangeDate);
            Assert.AreEqual(createdBy, actualParcel.CreatedBy);
            Assert.AreEqual(UserMockFactory.Jenya, actualParcel.ChangedBy);

            Assert.AreEqual(updatedParcel, container.Get<IDtoService>().CreateParcel(actualParcel));
        }

        [TestMethod]
        public void UpdateParcel_Should_Update_Parcel_When_Current_User_Is_Distributor()
        {
            // Arrange
            var container = ContainerMockFactory.Create();
            var securityService = container.Get<ISecurityService>();

            UserRoleMockFactory.OlesyaDistributor.Active = true;
            UserRoleMockFactory.OlesyaPurchaser.Active = false;
            UserRoleMockFactory.OlesyaAdministrator.Active = false;
            UserRoleMockFactory.OlesyaSeller.Active = false;
            securityService.LogIn(UserMockFactory.Olesya.Login, EncryptServiceMockFactory.OlesyaPasswordData.Password);

            var rublesPerDollar = ParcelMockFactory.Parcel_1.RublesPerDollar;
            var purchaserSpentOnDelivery = ParcelMockFactory.Parcel_1.PurchaserSpentOnDelivery;
            var trackingNumber = ParcelMockFactory.Parcel_1.TrackingNumber;
            var sentDate = ParcelMockFactory.Parcel_1.SentDate;
            var distributorId = ParcelMockFactory.Parcel_1.DistributorId;
            var comments = ParcelMockFactory.Parcel_1.Comments;
            var createDate = ParcelMockFactory.Parcel_1.CreateDate;
            var createdBy = ParcelMockFactory.Parcel_1.CreatedBy;

            var receivedDate = new DateTime(2013, 6, 30);

            var updatedParcel =
                new DTO.Parcel
                {
                    Id = ParcelMockFactory.Parcel_1.Id,
                    ReceivedDate = receivedDate,

                    // Filled by Purchaser
                    RublesPerDollar = 31.5m,
                    PurchaserSpentOnDelivery = 149m,
                    TrackingNumber = "US867958674896Z",
                    SentDate = new DateTime(2013, 5, 31),
                    Distributor = container.Get<IDtoService>().CreateUser(UserMockFactory.Diana),
                    Comments = "Some comments"
                };

            var parcelService = container.Get<IParcelService>();
            var persistentService = container.Get<IPersistentService>();
            var timeService = container.Get<ITimeService>();

            // Act
            parcelService.UpdateParcel(updatedParcel);

            // Assert
            var actualParcel = persistentService.GetEntityById<DataAccess.Parcel>(ParcelMockFactory.Parcel_1.Id);

            Assert.AreEqual(rublesPerDollar, actualParcel.RublesPerDollar);
            Assert.AreEqual(purchaserSpentOnDelivery, actualParcel.PurchaserSpentOnDelivery);
            Assert.AreEqual(trackingNumber, actualParcel.TrackingNumber);
            Assert.AreEqual(sentDate, actualParcel.SentDate);
            Assert.AreEqual(distributorId, actualParcel.DistributorId);
            Assert.AreEqual(comments, actualParcel.Comments);
            Assert.AreEqual(receivedDate, actualParcel.ReceivedDate);
            Assert.AreEqual(createDate, actualParcel.CreateDate);
            Assert.AreEqual(timeService.UtcNow, actualParcel.ChangeDate);
            Assert.AreEqual(createdBy, actualParcel.CreatedBy);
            Assert.AreEqual(UserMockFactory.Olesya, actualParcel.ChangedBy);

            Assert.AreEqual(updatedParcel, container.Get<IDtoService>().CreateParcel(actualParcel));
        }

        [TestMethod]
        public void UpdateParcel_Should_Update_Parcel_When_Current_User_Is_Purchaser_And_Distributor()
        {
            // Arrange
            var container = ContainerMockFactory.Create();
            var securityService = container.Get<ISecurityService>();

            UserRoleMockFactory.JenyaDistributor.Active = true;
            UserRoleMockFactory.JenyaPurchaser.Active = true;
            UserRoleMockFactory.JenyaAdministrator.Active = false;
            UserRoleMockFactory.JenyaSeller.Active = false;
            securityService.LogIn(UserMockFactory.Jenya.Login, EncryptServiceMockFactory.JenyaPasswordData.Password);

            ParcelMockFactory.Parcel_1.DistributorId = UserMockFactory.Jenya.Id;
            ParcelMockFactory.Parcel_1.Distributor = UserMockFactory.Jenya;

            const decimal RUBLES_PER_DOLLAR = 31.5m;
            const decimal PURCHASER_SPENT_ON_DELIVERY = 149m;
            const string TRACK_NUMBER = "US867958674896Z";
            var sentDate = new DateTime(2013, 5, 31);
            var distributor = container.Get<IDtoService>().CreateUser(UserMockFactory.Diana);
            const string COMMENTS = "Some comments";
            var receivedDate = new DateTime(2013, 6, 30);
            var createDate = ParcelMockFactory.Parcel_1.CreateDate;
            var createdBy = ParcelMockFactory.Parcel_1.CreatedBy;

            var updatedParcel =
                new DTO.Parcel
                {
                    Id = ParcelMockFactory.Parcel_1.Id,
                    RublesPerDollar = RUBLES_PER_DOLLAR,
                    PurchaserSpentOnDelivery = PURCHASER_SPENT_ON_DELIVERY,
                    TrackingNumber = TRACK_NUMBER,
                    SentDate = sentDate,
                    Distributor = distributor,
                    Comments = COMMENTS,
                    ReceivedDate = receivedDate
                };

            var parcelService = container.Get<IParcelService>();
            var persistentService = container.Get<IPersistentService>();
            var timeService = container.Get<ITimeService>();

            // Act
            parcelService.UpdateParcel(updatedParcel);

            // Assert
            var actualParcel = persistentService.GetEntityById<DataAccess.Parcel>(ParcelMockFactory.Parcel_1.Id);

            Assert.AreEqual(RUBLES_PER_DOLLAR, actualParcel.RublesPerDollar);
            Assert.AreEqual(PURCHASER_SPENT_ON_DELIVERY, actualParcel.PurchaserSpentOnDelivery);
            Assert.AreEqual(TRACK_NUMBER, actualParcel.TrackingNumber);
            Assert.AreEqual(sentDate, actualParcel.SentDate);
            Assert.AreEqual(distributor.Id, actualParcel.DistributorId);
            Assert.AreEqual(COMMENTS, actualParcel.Comments);
            Assert.AreEqual(receivedDate, actualParcel.ReceivedDate);
            Assert.AreEqual(createDate, actualParcel.CreateDate);
            Assert.AreEqual(timeService.UtcNow, actualParcel.ChangeDate);
            Assert.AreEqual(createdBy, actualParcel.CreatedBy);
            Assert.AreEqual(UserMockFactory.Jenya, actualParcel.ChangedBy);

            Assert.AreEqual(updatedParcel, container.Get<IDtoService>().CreateParcel(actualParcel));
        }

        [TestMethod]
        public void UpdateParcel_Should_Update_Parcel_When_Current_User_Is_Purchaser_And_Distributor_And_Parcel_Is_Assigned_To_Another_Distributor()
        {
            // Arrange
            var container = ContainerMockFactory.Create();
            var securityService = container.Get<ISecurityService>();

            UserRoleMockFactory.JenyaDistributor.Active = true;
            UserRoleMockFactory.JenyaPurchaser.Active = true;
            UserRoleMockFactory.JenyaAdministrator.Active = false;
            UserRoleMockFactory.JenyaSeller.Active = false;
            securityService.LogIn(UserMockFactory.Jenya.Login, EncryptServiceMockFactory.JenyaPasswordData.Password);

            const decimal RUBLES_PER_DOLLAR = 31.5m;
            const decimal PURCHASER_SPENT_ON_DELIVERY = 149m;
            const string TRACK_NUMBER = "US867958674896Z";
            var sentDate = new DateTime(2013, 5, 31);
            var distributor = container.Get<IDtoService>().CreateUser(UserMockFactory.Diana);
            const string COMMENTS = "Some comments";
            var receivedDate = ParcelMockFactory.Parcel_1.ReceivedDate;
            var createDate = ParcelMockFactory.Parcel_1.CreateDate;
            var createdBy = ParcelMockFactory.Parcel_1.CreatedBy;


            var updatedParcel =
                new DTO.Parcel
                {
                    Id = ParcelMockFactory.Parcel_1.Id,
                    RublesPerDollar = RUBLES_PER_DOLLAR,
                    PurchaserSpentOnDelivery = PURCHASER_SPENT_ON_DELIVERY,
                    TrackingNumber = TRACK_NUMBER,
                    SentDate = sentDate,
                    Distributor = distributor,
                    Comments = COMMENTS,
                    ReceivedDate = new DateTime(2013, 6, 30)
                };

            var parcelService = container.Get<IParcelService>();
            var persistentService = container.Get<IPersistentService>();
            var timeService = container.Get<ITimeService>();

            // Act
            parcelService.UpdateParcel(updatedParcel);

            // Assert
            var actualParcel = persistentService.GetEntityById<DataAccess.Parcel>(ParcelMockFactory.Parcel_1.Id);

            Assert.AreEqual(RUBLES_PER_DOLLAR, actualParcel.RublesPerDollar);
            Assert.AreEqual(PURCHASER_SPENT_ON_DELIVERY, actualParcel.PurchaserSpentOnDelivery);
            Assert.AreEqual(TRACK_NUMBER, actualParcel.TrackingNumber);
            Assert.AreEqual(sentDate, actualParcel.SentDate);
            Assert.AreEqual(distributor.Id, actualParcel.DistributorId);
            Assert.AreEqual(COMMENTS, actualParcel.Comments);
            Assert.AreEqual(receivedDate, actualParcel.ReceivedDate);
            Assert.AreEqual(createDate, actualParcel.CreateDate);
            Assert.AreEqual(timeService.UtcNow, actualParcel.ChangeDate);
            Assert.AreEqual(createdBy, actualParcel.CreatedBy);
            Assert.AreEqual(UserMockFactory.Jenya, actualParcel.ChangedBy);

            Assert.AreEqual(updatedParcel, container.Get<IDtoService>().CreateParcel(actualParcel));
        }

        [TestMethod]
        public void UpdateParcel_Should_Throw_Exception_When_Current_User_Is_Not_Purchaser_Distributor()
        {
            // Arrange
            var container = ContainerMockFactory.Create();
            var securityService = container.Get<ISecurityService>();

            UserRoleMockFactory.JenyaDistributor.Active = false;
            UserRoleMockFactory.JenyaPurchaser.Active = false;
            UserRoleMockFactory.JenyaAdministrator.Active = false;
            UserRoleMockFactory.JenyaSeller.Active = true;
            securityService.LogIn(UserMockFactory.Jenya.Login, EncryptServiceMockFactory.JenyaPasswordData.Password);

            var updatedParcel =
                new DTO.Parcel
                {
                    Id = ParcelMockFactory.Parcel_1.Id,
                    RublesPerDollar = 31.5m,
                    PurchaserSpentOnDelivery = 149m,
                    TrackingNumber = "US867958674896Z",
                    SentDate = new DateTime(2013, 5, 31),
                    Distributor = container.Get<IDtoService>().CreateUser(UserMockFactory.Diana),
                    Comments = "Some comments",
                    ReceivedDate = new DateTime(2013, 6, 30)
                };

            var parcelService = container.Get<IParcelService>();

            // Act
            // Assert
            ExceptionAssert.Throw<InvalidOperationException>(
                () => parcelService.UpdateParcel(updatedParcel),
                "Only purchaser and distributor can change parcel.");
        }

        [TestMethod]
        public void UpdateParcel_Should_Throw_Exception_When_Current_User_Is_Distributor_And_Parcel_Is_Assigned_To_Another_Distributor()
        {
            // Arrange
            var container = ContainerMockFactory.Create();
            var securityService = container.Get<ISecurityService>();

            UserRoleMockFactory.OlesyaDistributor.Active = true;
            UserRoleMockFactory.OlesyaPurchaser.Active = false;
            UserRoleMockFactory.OlesyaAdministrator.Active = false;
            UserRoleMockFactory.OlesyaSeller.Active = false;
            securityService.LogIn(UserMockFactory.Olesya.Login, EncryptServiceMockFactory.OlesyaPasswordData.Password);

            var updatedParcel =
                new DTO.Parcel
                {
                    Id = ParcelMockFactory.Parcel_2.Id,
                    RublesPerDollar = 31.5m,
                    PurchaserSpentOnDelivery = 149m,
                    TrackingNumber = "US867958674896Z",
                    SentDate = new DateTime(2013, 5, 31),
                    Distributor = container.Get<IDtoService>().CreateUser(UserMockFactory.Diana),
                    Comments = "Some comments",
                    ReceivedDate = new DateTime(2013, 6, 30)
                };

            var parcelService = container.Get<IParcelService>();

            // Act
            // Assert
            ExceptionAssert.Throw<InvalidOperationException>(
                () => parcelService.UpdateParcel(updatedParcel),
                "Only purchaser and distributor can change parcel.");
        }
    }
}
