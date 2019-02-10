using System.Data.Entity;
using System.Linq;
using USClothesWebSite.Common.Helpers;

namespace USClothesWebSite.BusinessLogic.Test.Mocks
{
    public static class OrderMockFactory
    {
        public static DataAccess.Order Order_1
        {
            get
            {
                return CacheHelper.Get(ref _order_1,
                    () =>
                        new DataAccess.Order
                        {
                            Id = 1,
                            Active = true,
                            CustomerFirstName = "Вася",
                            CustomerLastName = "Пупкин",
                            CustomerAddress = "100 Middlesex Road",
                            CustomerCity = "Waltham",
                            CustomerCountry = "USA",
                            CustomerPostalCode = "02452",
                            CustomerPhoneNumber = "3475673333",
                            CustomerEmail = "cust@mail.ru",
                            RublesPerDollar = 33m,
                            TrackingNumber = "2135345656475787",
                            Comments = "Полный расчет",
                            CustomerPrepaid = 1000m,
                            CustomerPaid = 7300m,
                            DistributorSpentOnDelivery = 300m,
                            OrderDate = TimeServiceMockFactory.Date1,
                            CreateDate = TimeServiceMockFactory.Date1,
                            ChangeDate = TimeServiceMockFactory.Date3
                        });
            }
        }
        private static DataAccess.Order _order_1;

        public static DataAccess.Order Order_2
        {
            get
            {
                return CacheHelper.Get(ref _order_2,
                    () =>
                        new DataAccess.Order
                        {
                            Id = 2,
                            Active = true,
                            CustomerFirstName = "Мария",
                            CustomerLastName = "Рурина",
                            CustomerAddress = "ул. Вяцкова дом 32 кв 11",
                            CustomerCity = "Мичуринск",
                            CustomerCountry = "Россия",
                            CustomerPostalCode = "100456",
                            CustomerPhoneNumber = "3475656666",
                            CustomerEmail = "cust_2@mail.ru",
                            RublesPerDollar = 33m,
                            TrackingNumber = null,
                            Comments = null,
                            CustomerPrepaid = 0m,
                            CustomerPaid = 0m,
                            DistributorSpentOnDelivery = 0m,
                            OrderDate = TimeServiceMockFactory.Date2,
                            CreateDate = TimeServiceMockFactory.Date2,
                            ChangeDate = TimeServiceMockFactory.Date5
                        });
            }
        }
        private static DataAccess.Order _order_2;

        public static DataAccess.Order Order_3
        {
            get
            {
                return CacheHelper.Get(ref _order_3,
                    () =>
                        new DataAccess.Order
                        {
                            Id = 3,
                            Active = true,
                            CustomerFirstName = "Женя",
                            CustomerLastName = "Цыганкова",
                            CustomerAddress = "ул. Рыбакова дом 2А",
                            CustomerCity = "Алма-Ата",
                            CustomerCountry = "Казахстан",
                            CustomerPostalCode = "450043",
                            CustomerPhoneNumber = "4565554322",
                            CustomerEmail = "jencig@gmail.com",
                            RublesPerDollar = 32.5m,
                            TrackingNumber = null,
                            Comments = "Не отправлена",
                            CustomerPrepaid = 500m,
                            CustomerPaid = 0m,
                            DistributorSpentOnDelivery = 0m,
                            OrderDate = TimeServiceMockFactory.Date4,
                            CreateDate = TimeServiceMockFactory.Date4,
                            ChangeDate = TimeServiceMockFactory.Date4
                        });
            }
        }
        private static DataAccess.Order _order_3;

        public static DataAccess.Order Order_4
        {
            get
            {
                return CacheHelper.Get(ref _order_4,
                    () =>
                        new DataAccess.Order
                        {
                            Id = 4,
                            Active = false,
                            CustomerFirstName = "Саша",
                            CustomerLastName = "Дуров",
                            CustomerAddress = "ул. Караблестроителей дом 56 кв 1",
                            CustomerCity = "Москва",
                            CustomerCountry = "Россия",
                            CustomerPostalCode = "145006",
                            CustomerPhoneNumber = "4445567890",
                            CustomerEmail = "sasha@gmail.com",
                            RublesPerDollar = 33m,
                            TrackingNumber = null,
                            Comments = null,
                            CustomerPrepaid = 0m,
                            CustomerPaid = 0m,
                            DistributorSpentOnDelivery = 0m,
                            OrderDate = TimeServiceMockFactory.Date2,
                            CreateDate = TimeServiceMockFactory.Date2,
                            ChangeDate = TimeServiceMockFactory.Date5
                        });
            }
        }
        private static DataAccess.Order _order_4;

        public static DataAccess.Order Order_5
        {
            get
            {
                return CacheHelper.Get(ref _order_5,
                    () =>
                        new DataAccess.Order
                        {
                            Id = 5,
                            Active = true,
                            CustomerFirstName = "Саша1",
                            CustomerLastName = "Дуров1",
                            CustomerAddress = "ул. Караблестроителей дом 56 кв 11",
                            CustomerCity = "Москва1",
                            CustomerCountry = "Казахстан",
                            CustomerPostalCode = "145001",
                            CustomerPhoneNumber = "4445567891",
                            CustomerEmail = "sasha1@gmail.com",
                            RublesPerDollar = 33.1m,
                            TrackingNumber = null,
                            Comments = null,
                            CustomerPrepaid = 0m,
                            CustomerPaid = 0m,
                            DistributorSpentOnDelivery = 0m,
                            OrderDate = TimeServiceMockFactory.Date5,
                            CreateDate = TimeServiceMockFactory.Date5,
                            ChangeDate = TimeServiceMockFactory.Date5
                        });
            }
        }
        private static DataAccess.Order _order_5;

        public static DataAccess.Order Order_6
        {
            get
            {
                return CacheHelper.Get(ref _order_6,
                    () =>
                        new DataAccess.Order
                        {
                            Id = 6,
                            Active = false,
                            CustomerFirstName = "Саша2",
                            CustomerLastName = "Дуров2",
                            CustomerAddress = "ул. Караблестроителей дом 56 кв 122",
                            CustomerCity = "Москва22",
                            CustomerCountry = "Казахстан22",
                            CustomerPostalCode = "1450222",
                            CustomerPhoneNumber = "4445567222",
                            CustomerEmail = "sasha222@gmail.com",
                            RublesPerDollar = 33.2m,
                            TrackingNumber = null,
                            Comments = null,
                            CustomerPrepaid = 0m,
                            CustomerPaid = 0m,
                            DistributorSpentOnDelivery = 0m,
                            OrderDate = TimeServiceMockFactory.Date3,
                            CreateDate = TimeServiceMockFactory.Date3,
                            ChangeDate = TimeServiceMockFactory.Date5
                        });
            }
        }
        private static DataAccess.Order _order_6;

        public static DataAccess.Order Order_7
        {
            get
            {
                return CacheHelper.Get(ref _order_7,
                    () =>
                        new DataAccess.Order
                        {
                            Id = 7,
                            Active = true,
                            CustomerFirstName = "Мария7",
                            CustomerLastName = "Рурина7",
                            CustomerAddress = "ул. Вяцкова дом 32 кв 177",
                            CustomerCity = "Мичуринск7",
                            CustomerCountry = "Россия7",
                            CustomerPostalCode = "100457",
                            CustomerPhoneNumber = "3475656777",
                            CustomerEmail = "cust_777@mail.ru",
                            RublesPerDollar = 37m,
                            TrackingNumber = null,
                            Comments = null,
                            CustomerPrepaid = 0m,
                            CustomerPaid = 0m,
                            DistributorSpentOnDelivery = 0m,
                            OrderDate = TimeServiceMockFactory.Date2,
                            CreateDate = TimeServiceMockFactory.Date2,
                            ChangeDate = TimeServiceMockFactory.Date5
                        });
            }
        }
        private static DataAccess.Order _order_7;

        public static DataAccess.Order Order_8
        {
            get
            {
                return CacheHelper.Get(ref _order_8,
                    () =>
                        new DataAccess.Order
                        {
                            Id = 8,
                            Active = true,
                            CustomerFirstName = "Вася8",
                            CustomerLastName = "Пупкин8",
                            CustomerAddress = "100 Middlesex Road8",
                            CustomerCity = "Waltham8",
                            CustomerCountry = "USA8",
                            CustomerPostalCode = "02458",
                            CustomerPhoneNumber = "3475678888",
                            CustomerEmail = "cust8888@mail.ru",
                            RublesPerDollar = 38m,
                            TrackingNumber = "21353456564757888",
                            Comments = "Полный расчет8",
                            CustomerPrepaid = 1008m,
                            CustomerPaid = 7308m,
                            DistributorSpentOnDelivery = 308m,
                            OrderDate = TimeServiceMockFactory.Date1,
                            CreateDate = TimeServiceMockFactory.Date1,
                            ChangeDate = TimeServiceMockFactory.Date5
                        });
            }
        }
        private static DataAccess.Order _order_8;
        
        public static IDbSet<DataAccess.Order> Orders
        {
            get
            {
                return CacheHelper.Get(ref _orders,
                    () =>
                    {
                        var orders =
                            new[]
                            {
                                Order_1,
                                Order_2,
                                Order_3,
                                Order_4,
                                Order_5,
                                Order_6,
                                Order_7,
                                Order_8
                            };

                        return new DbSetMock<DataAccess.Order>(orders);
                    });
            }
        }
        private static IDbSet<DataAccess.Order> _orders;

        public static void Reset()
        {
            _order_1 = null;
            _order_2 = null;
            _order_3 = null;
            _order_4 = null;
            _order_5 = null;
            _order_6 = null;
            _order_7 = null;
            _order_8 = null;

            _orders = null;
        }

        public static void InitializeRelations()
        {
            Order_1.CreateUserId = UserMockFactory.Jenya.Id;
            Order_1.CreatedBy = UserMockFactory.Jenya;
            Order_1.ChangeUserId = UserMockFactory.Diana.Id;
            Order_1.ChangedBy = UserMockFactory.Diana;
            Order_1.ParcelId = ParcelMockFactory.Parcel_1.Id;
            Order_1.Parcel = ParcelMockFactory.Parcel_1;

            Order_2.CreateUserId = UserMockFactory.Jenya.Id;
            Order_2.CreatedBy = UserMockFactory.Jenya;
            Order_2.ChangeUserId = UserMockFactory.Olesya.Id;
            Order_2.ChangedBy = UserMockFactory.Olesya;
            Order_2.ParcelId = ParcelMockFactory.Parcel_1.Id;
            Order_2.Parcel = ParcelMockFactory.Parcel_1;

            Order_3.CreateUserId = UserMockFactory.Jenya.Id;
            Order_3.CreatedBy = UserMockFactory.Jenya;
            Order_3.ChangeUserId = UserMockFactory.Jenya.Id;
            Order_3.ChangedBy = UserMockFactory.Jenya;
            Order_3.ParcelId = null;
            Order_3.Parcel = null;

            Order_4.CreateUserId = UserMockFactory.Diana.Id;
            Order_4.CreatedBy = UserMockFactory.Diana;
            Order_4.ChangeUserId = UserMockFactory.Diana.Id;
            Order_4.ChangedBy = UserMockFactory.Diana;
            Order_4.ParcelId = ParcelMockFactory.Parcel_3.Id;
            Order_4.Parcel = ParcelMockFactory.Parcel_3;

            Order_5.CreateUserId = UserMockFactory.Jenya.Id;
            Order_5.CreatedBy = UserMockFactory.Jenya;
            Order_5.ChangeUserId = UserMockFactory.Jenya.Id;
            Order_5.ChangedBy = UserMockFactory.Jenya;
            Order_5.ParcelId = ParcelMockFactory.Parcel_3.Id;
            Order_5.Parcel = ParcelMockFactory.Parcel_3;

            Order_6.CreateUserId = UserMockFactory.Diana.Id;
            Order_6.CreatedBy = UserMockFactory.Diana;
            Order_6.ChangeUserId = UserMockFactory.Diana.Id;
            Order_6.ChangedBy = UserMockFactory.Diana;
            Order_6.ParcelId = ParcelMockFactory.Parcel_2.Id;
            Order_6.Parcel = ParcelMockFactory.Parcel_2;

            Order_7.CreateUserId = UserMockFactory.Diana.Id;
            Order_7.CreatedBy = UserMockFactory.Diana;
            Order_7.ChangeUserId = UserMockFactory.Jenya.Id;
            Order_7.ChangedBy = UserMockFactory.Jenya;
            Order_7.ParcelId = ParcelMockFactory.Parcel_2.Id;
            Order_7.Parcel = ParcelMockFactory.Parcel_2;

            Order_8.CreateUserId = UserMockFactory.Jenya.Id;
            Order_8.CreatedBy = UserMockFactory.Jenya;
            Order_8.ChangeUserId = UserMockFactory.Olesya.Id;
            Order_8.ChangedBy = UserMockFactory.Olesya;
            Order_8.ParcelId = ParcelMockFactory.Parcel_2.Id;
            Order_8.Parcel = ParcelMockFactory.Parcel_2;
        }

        public static void InitializeCollections()
        {
            foreach (var order in Orders)
            {
                order.OrderItems =
                    OrderItemMockFactory.OrderItems
                        .Where(oi => oi.Order == order)
                        .ToArray();
            }
        }
    }
}
