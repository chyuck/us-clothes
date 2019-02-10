using System.Data.Entity;
using System.Linq;
using USClothesWebSite.Common.Helpers;

namespace USClothesWebSite.BusinessLogic.Test.Mocks
{
    public static class ParcelMockFactory
    {
        public static DataAccess.Parcel Parcel_1
        {
            get
            {
                return CacheHelper.Get(ref _parcel_1,
                    () =>
                        new DataAccess.Parcel
                        {
                            Id = 1,
                            Comments = "Полный расчет по посылке",
                            RublesPerDollar = 33,
                            PurchaserSpentOnDelivery = 124,
                            TrackingNumber = "US345678907654",
                            SentDate = TimeServiceMockFactory.Date3,
                            ReceivedDate = TimeServiceMockFactory.Date5,
                            CreateDate = TimeServiceMockFactory.Date4,
                            ChangeDate = TimeServiceMockFactory.Date5
                        });
            }
        }
        private static DataAccess.Parcel _parcel_1;

        public static DataAccess.Parcel Parcel_2
        {
            get
            {
                return CacheHelper.Get(ref _parcel_2,
                    () =>
                        new DataAccess.Parcel
                        {
                            Id = 2,
                            Comments = null,
                            RublesPerDollar = 33,
                            PurchaserSpentOnDelivery = 0,
                            TrackingNumber = null,
                            SentDate = null,
                            ReceivedDate = null,
                            CreateDate = TimeServiceMockFactory.Date1,
                            ChangeDate = TimeServiceMockFactory.Date1
                        });
            }
        }
        private static DataAccess.Parcel _parcel_2;

        public static DataAccess.Parcel Parcel_3
        {
            get
            {
                return CacheHelper.Get(ref _parcel_3,
                    () =>
                        new DataAccess.Parcel
                        {
                            Id = 3,
                            Comments = "Отменен",
                            RublesPerDollar = 33,
                            PurchaserSpentOnDelivery = 0,
                            TrackingNumber = null,
                            SentDate = null,
                            ReceivedDate = null,
                            CreateDate = TimeServiceMockFactory.Date2,
                            ChangeDate = TimeServiceMockFactory.Date2
                        });
            }
        }
        private static DataAccess.Parcel _parcel_3;
        
        public static IDbSet<DataAccess.Parcel> Parcels
        {
            get
            {
                return CacheHelper.Get(ref _parcels,
                    () =>
                    {
                        var parcels =
                            new[]
                            {
                                Parcel_1,
                                Parcel_2,
                                Parcel_3
                            };

                        return new DbSetMock<DataAccess.Parcel>(parcels);
                    });
            }
        }
        private static IDbSet<DataAccess.Parcel> _parcels;

        public static void Reset()
        {
            _parcel_1 = null;
            _parcel_2 = null;
            _parcel_3 = null;

            _parcels = null;
        }

        public static void InitializeRelations()
        {
            Parcel_1.CreateUserId = UserMockFactory.Jenya.Id;
            Parcel_1.CreatedBy = UserMockFactory.Jenya;
            Parcel_1.ChangeUserId = UserMockFactory.Jenya.Id;
            Parcel_1.ChangedBy = UserMockFactory.Jenya;
            Parcel_1.DistributorId = UserMockFactory.Olesya.Id;
            Parcel_1.Distributor = UserMockFactory.Olesya;

            Parcel_2.CreateUserId = UserMockFactory.Jenya.Id;
            Parcel_2.CreatedBy = UserMockFactory.Jenya;
            Parcel_2.ChangeUserId = UserMockFactory.Jenya.Id;
            Parcel_2.ChangedBy = UserMockFactory.Jenya;
            Parcel_2.DistributorId = UserMockFactory.Diana.Id;
            Parcel_2.Distributor = UserMockFactory.Diana;

            Parcel_3.CreateUserId = UserMockFactory.Jenya.Id;
            Parcel_3.CreatedBy = UserMockFactory.Jenya;
            Parcel_3.ChangeUserId = UserMockFactory.Jenya.Id;
            Parcel_3.ChangedBy = UserMockFactory.Jenya;
            Parcel_3.DistributorId = null;
            Parcel_3.Distributor = null;
        }

        public static void InitializeCollections()
        {
            foreach (var parcel in Parcels)
            {
                parcel.Orders =
                    OrderMockFactory.Orders
                        .Where(o => o.Parcel == parcel)
                        .ToArray();
            }
        }
    }
}
