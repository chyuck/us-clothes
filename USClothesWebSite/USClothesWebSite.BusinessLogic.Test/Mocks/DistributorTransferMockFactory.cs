using System.Data.Entity;
using USClothesWebSite.Common.Helpers;

namespace USClothesWebSite.BusinessLogic.Test.Mocks
{
    public static class DistributorTransferMockFactory
    {
        public static DataAccess.DistributorTransfer Olesya_Transfer_1
        {
            get
            {
                return CacheHelper.Get(ref _olesya_Transfer_1,
                    () =>
                        new DataAccess.DistributorTransfer
                        {
                            Id = 1,
                            Date = TimeServiceMockFactory.Date1,
                            RublesPerDollar = 31m,
                            Amount = 20000m,
                            Active = true,
                            CreateDate = TimeServiceMockFactory.Date1,
                            ChangeDate = TimeServiceMockFactory.Date1
                        });
            }
        }
        private static DataAccess.DistributorTransfer _olesya_Transfer_1;

        public static DataAccess.DistributorTransfer Olesya_Transfer_2
        {
            get
            {
                return CacheHelper.Get(ref _olesya_Transfer_2,
                    () =>
                        new DataAccess.DistributorTransfer
                        {
                            Id = 2,
                            Date = TimeServiceMockFactory.Date2,
                            RublesPerDollar = 31.1m,
                            Amount = 10000m,
                            Active = true,
                            CreateDate = TimeServiceMockFactory.Date2,
                            ChangeDate = TimeServiceMockFactory.Date3
                        });
            }
        }
        private static DataAccess.DistributorTransfer _olesya_Transfer_2;

        public static DataAccess.DistributorTransfer Diana_Transfer_1
        {
            get
            {
                return CacheHelper.Get(ref _diana_Transfer_1,
                    () =>
                        new DataAccess.DistributorTransfer
                        {
                            Id = 3,
                            Date = TimeServiceMockFactory.Date2,
                            RublesPerDollar = 31.3m,
                            Amount = 15000m,
                            Active = true,
                            CreateDate = TimeServiceMockFactory.Date1,
                            ChangeDate = TimeServiceMockFactory.Date2
                        });
            }
        }
        private static DataAccess.DistributorTransfer _diana_Transfer_1;

        public static DataAccess.DistributorTransfer Diana_Transfer_2
        {
            get
            {
                return CacheHelper.Get(ref _diana_Transfer_2,
                    () =>
                        new DataAccess.DistributorTransfer
                        {
                            Id = 4,
                            Date = TimeServiceMockFactory.Date3,
                            RublesPerDollar = 32m,
                            Amount = 25000m,
                            Active = true,
                            CreateDate = TimeServiceMockFactory.Date3,
                            ChangeDate = TimeServiceMockFactory.Date3
                        });
            }
        }
        private static DataAccess.DistributorTransfer _diana_Transfer_2;

        public static IDbSet<DataAccess.DistributorTransfer> DistributorTransfers
        {
            get
            {
                return CacheHelper.Get(ref _distributorTransfers,
                    () =>
                    {
                        var distributorTransfers =
                            new[]
                            {
                                Olesya_Transfer_1, 
                                Olesya_Transfer_2, 
                                Diana_Transfer_1,
                                Diana_Transfer_2
                            };

                        return new DbSetMock<DataAccess.DistributorTransfer>(distributorTransfers);
                    });
            }
        }
        private static IDbSet<DataAccess.DistributorTransfer> _distributorTransfers;

        public static void Reset()
        {
            _olesya_Transfer_1 = null;
            _olesya_Transfer_2 = null;
            _diana_Transfer_1 = null;
            _diana_Transfer_2 = null;
            _distributorTransfers = null;
        }

        public static void InitializeRelations()
        {
            Olesya_Transfer_1.CreateUserId = UserMockFactory.Olesya.Id;
            Olesya_Transfer_1.CreatedBy = UserMockFactory.Olesya;
            Olesya_Transfer_1.ChangeUserId = UserMockFactory.Olesya.Id;
            Olesya_Transfer_1.ChangedBy = UserMockFactory.Olesya;

            Olesya_Transfer_2.CreateUserId = UserMockFactory.Olesya.Id;
            Olesya_Transfer_2.CreatedBy = UserMockFactory.Olesya;
            Olesya_Transfer_2.ChangeUserId = UserMockFactory.Olesya.Id;
            Olesya_Transfer_2.ChangedBy = UserMockFactory.Olesya;

            Diana_Transfer_1.CreateUserId = UserMockFactory.Diana.Id;
            Diana_Transfer_1.CreatedBy = UserMockFactory.Diana;
            Diana_Transfer_1.ChangeUserId = UserMockFactory.Diana.Id;
            Diana_Transfer_1.ChangedBy = UserMockFactory.Diana;

            Diana_Transfer_2.CreateUserId = UserMockFactory.Diana.Id;
            Diana_Transfer_2.CreatedBy = UserMockFactory.Diana;
            Diana_Transfer_2.ChangeUserId = UserMockFactory.Diana.Id;
            Diana_Transfer_2.ChangedBy = UserMockFactory.Diana;
        }

        public static void InitializeCollections()
        {
        }
    }
}
