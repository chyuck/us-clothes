using System.Data.Entity;
using USClothesWebSite.Common.Helpers;

namespace USClothesWebSite.BusinessLogic.Test.Mocks
{
    public static class OrderItemMockFactory
    {
        public static DataAccess.OrderItem OrderItem_1
        {
            get
            {
                return CacheHelper.Get(ref _orderItem_1,
                    () =>
                        new DataAccess.OrderItem
                        {
                            Id = 1,
                            Active = true,
                            Price = 3100m,
                            PurchaserPaid = 50m,
                            Quantity = 2,
                            TotalPrice = 6200m,
                            CreateDate = TimeServiceMockFactory.Date1,
                            ChangeDate = TimeServiceMockFactory.Date3
                        });
            }
        }
        private static DataAccess.OrderItem _orderItem_1;

        public static DataAccess.OrderItem OrderItem_2
        {
            get
            {
                return CacheHelper.Get(ref _orderItem_2,
                    () =>
                        new DataAccess.OrderItem
                        {
                            Id = 2,
                            Active = true,
                            Price = 2100m,
                            PurchaserPaid = 0m,
                            Quantity = 1,
                            TotalPrice = 2100m,
                            CreateDate = TimeServiceMockFactory.Date1,
                            ChangeDate = TimeServiceMockFactory.Date5
                        });
            }
        }
        private static DataAccess.OrderItem _orderItem_2;

        public static DataAccess.OrderItem OrderItem_3
        {
            get
            {
                return CacheHelper.Get(ref _orderItem_3,
                    () =>
                        new DataAccess.OrderItem
                        {
                            Id = 3,
                            Active = true,
                            Price = 3100m,
                            PurchaserPaid = 62m,
                            Quantity = 2,
                            TotalPrice = 6200m,
                            CreateDate = TimeServiceMockFactory.Date2,
                            ChangeDate = TimeServiceMockFactory.Date5
                        });
            }
        }
        private static DataAccess.OrderItem _orderItem_3;

        public static DataAccess.OrderItem OrderItem_4
        {
            get
            {
                return CacheHelper.Get(ref _orderItem_4,
                    () =>
                        new DataAccess.OrderItem
                        {
                            Id = 4,
                            Active = true,
                            Price = 2900m,
                            PurchaserPaid = 0m,
                            Quantity = 1,
                            TotalPrice = 2900m,
                            CreateDate = TimeServiceMockFactory.Date2,
                            ChangeDate = TimeServiceMockFactory.Date5
                        });
            }
        }
        private static DataAccess.OrderItem _orderItem_4;

        public static DataAccess.OrderItem OrderItem_5
        {
            get
            {
                return CacheHelper.Get(ref _orderItem_5,
                    () =>
                        new DataAccess.OrderItem
                        {
                            Id = 5,
                            Active = false,
                            Price = 3105m,
                            PurchaserPaid = 55m,
                            Quantity = 2,
                            TotalPrice = 6210m,
                            CreateDate = TimeServiceMockFactory.Date1,
                            ChangeDate = TimeServiceMockFactory.Date5
                        });
            }
        }
        private static DataAccess.OrderItem _orderItem_5;

        public static DataAccess.OrderItem OrderItem_6
        {
            get
            {
                return CacheHelper.Get(ref _orderItem_6,
                    () =>
                        new DataAccess.OrderItem
                        {
                            Id = 6,
                            Active = true,
                            Price = 2106m,
                            PurchaserPaid = 0m,
                            Quantity = 1,
                            TotalPrice = 2106m,
                            CreateDate = TimeServiceMockFactory.Date3,
                            ChangeDate = TimeServiceMockFactory.Date5
                        });
            }
        }
        private static DataAccess.OrderItem _orderItem_6;

        public static DataAccess.OrderItem OrderItem_7
        {
            get
            {
                return CacheHelper.Get(ref _orderItem_7,
                    () =>
                        new DataAccess.OrderItem
                        {
                            Id = 7,
                            Active = true,
                            Price = 3100m,
                            PurchaserPaid = 62m,
                            Quantity = 2,
                            TotalPrice = 6200m,
                            CreateDate = TimeServiceMockFactory.Date2,
                            ChangeDate = TimeServiceMockFactory.Date5
                        });
            }
        }
        private static DataAccess.OrderItem _orderItem_7;

        public static DataAccess.OrderItem OrderItem_8
        {
            get
            {
                return CacheHelper.Get(ref _orderItem_8,
                    () =>
                        new DataAccess.OrderItem
                        {
                            Id = 8,
                            Active = true,
                            Price = 2980m,
                            PurchaserPaid = 0m,
                            Quantity = 1,
                            TotalPrice = 2980m,
                            CreateDate = TimeServiceMockFactory.Date1,
                            ChangeDate = TimeServiceMockFactory.Date5
                        });
            }
        }
        private static DataAccess.OrderItem _orderItem_8;

        public static DataAccess.OrderItem OrderItem_9
        {
            get
            {
                return CacheHelper.Get(ref _orderItem_9,
                    () =>
                        new DataAccess.OrderItem
                        {
                            Id = 9,
                            Active = true,
                            Price = 9100m,
                            PurchaserPaid = 90m,
                            Quantity = 2,
                            TotalPrice = 18200m,
                            CreateDate = TimeServiceMockFactory.Date1,
                            ChangeDate = TimeServiceMockFactory.Date5
                        });
            }
        }
        private static DataAccess.OrderItem _orderItem_9;

        public static DataAccess.OrderItem OrderItem_10
        {
            get
            {
                return CacheHelper.Get(ref _orderItem_10,
                    () =>
                        new DataAccess.OrderItem
                        {
                            Id = 10,
                            Active = true,
                            Price = 2100m,
                            PurchaserPaid = 0m,
                            Quantity = 1,
                            TotalPrice = 2100m,
                            CreateDate = TimeServiceMockFactory.Date1,
                            ChangeDate = TimeServiceMockFactory.Date5
                        });
            }
        }
        private static DataAccess.OrderItem _orderItem_10;

        public static DataAccess.OrderItem OrderItem_11
        {
            get
            {
                return CacheHelper.Get(ref _orderItem_11,
                    () =>
                        new DataAccess.OrderItem
                        {
                            Id = 11,
                            Active = true,
                            Price = 3100m,
                            PurchaserPaid = 1111m,
                            Quantity = 2,
                            TotalPrice = 6200m,
                            CreateDate = TimeServiceMockFactory.Date2,
                            ChangeDate = TimeServiceMockFactory.Date5
                        });
            }
        }
        private static DataAccess.OrderItem _orderItem_11;

        public static DataAccess.OrderItem OrderItem_12
        {
            get
            {
                return CacheHelper.Get(ref _orderItem_12,
                    () =>
                        new DataAccess.OrderItem
                        {
                            Id = 12,
                            Active = false,
                            Price = 2905m,
                            PurchaserPaid = 0m,
                            Quantity = 1,
                            TotalPrice = 2905m,
                            CreateDate = TimeServiceMockFactory.Date2,
                            ChangeDate = TimeServiceMockFactory.Date5
                        });
            }
        }
        private static DataAccess.OrderItem _orderItem_12;

        public static DataAccess.OrderItem OrderItem_13
        {
            get
            {
                return CacheHelper.Get(ref _orderItem_13,
                    () =>
                        new DataAccess.OrderItem
                        {
                            Id = 13,
                            Active = true,
                            Price = 3100m,
                            PurchaserPaid = 62m,
                            Quantity = 2,
                            TotalPrice = 6200m,
                            CreateDate = TimeServiceMockFactory.Date2,
                            ChangeDate = TimeServiceMockFactory.Date5
                        });
            }
        }
        private static DataAccess.OrderItem _orderItem_13;

        public static DataAccess.OrderItem OrderItem_14
        {
            get
            {
                return CacheHelper.Get(ref _orderItem_14,
                    () =>
                        new DataAccess.OrderItem
                        {
                            Id = 14,
                            Active = true,
                            Price = 3900m,
                            PurchaserPaid = 0m,
                            Quantity = 1,
                            TotalPrice = 3900m,
                            CreateDate = TimeServiceMockFactory.Date2,
                            ChangeDate = TimeServiceMockFactory.Date5
                        });
            }
        }
        private static DataAccess.OrderItem _orderItem_14;

        public static IDbSet<DataAccess.OrderItem> OrderItems
        {
            get
            {
                return CacheHelper.Get(ref _orderItems,
                    () =>
                    {
                        var orderItems =
                            new[]
                            {
                                OrderItem_1,
                                OrderItem_2,
                                OrderItem_3,
                                OrderItem_4,
                                OrderItem_5,
                                OrderItem_6,
                                OrderItem_7,
                                OrderItem_8,
                                OrderItem_9,
                                OrderItem_10,
                                OrderItem_11,
                                OrderItem_12,
                                OrderItem_13,
                                OrderItem_14
                            };

                        return new DbSetMock<DataAccess.OrderItem>(orderItems);
                    });
            }
        }
        private static IDbSet<DataAccess.OrderItem> _orderItems;

        public static void Reset()
        {
            _orderItem_1 = null;
            _orderItem_2 = null;
            _orderItem_3 = null;
            _orderItem_4 = null;
            _orderItem_5 = null;
            _orderItem_6 = null;
            _orderItem_7 = null;
            _orderItem_8 = null;
            _orderItem_9 = null;
            _orderItem_10 = null;
            _orderItem_11 = null;
            _orderItem_12 = null;
            _orderItem_13 = null;
            _orderItem_14 = null;

            _orderItems = null;
        }

        public static void InitializeRelations()
        {
            OrderItem_1.CreateUserId = UserMockFactory.Jenya.Id;
            OrderItem_1.CreatedBy = UserMockFactory.Jenya;
            OrderItem_1.ChangeUserId = UserMockFactory.Diana.Id;
            OrderItem_1.ChangedBy = UserMockFactory.Diana;
            OrderItem_1.OrderId = OrderMockFactory.Order_3.Id;
            OrderItem_1.Order = OrderMockFactory.Order_3;
            OrderItem_1.ProductSizeId = ProductSizeMockFactory.Boys_Sweater_0_3_Months.Id;
            OrderItem_1.ProductSize = ProductSizeMockFactory.Boys_Sweater_0_3_Months;

            OrderItem_2.CreateUserId = UserMockFactory.Jenya.Id;
            OrderItem_2.CreatedBy = UserMockFactory.Jenya;
            OrderItem_2.ChangeUserId = UserMockFactory.Jenya.Id;
            OrderItem_2.ChangedBy = UserMockFactory.Jenya;
            OrderItem_2.OrderId = OrderMockFactory.Order_1.Id;
            OrderItem_2.Order = OrderMockFactory.Order_1;
            OrderItem_2.ProductSizeId = ProductSizeMockFactory.Girls_Sweater_0_3_Months.Id;
            OrderItem_2.ProductSize = ProductSizeMockFactory.Girls_Sweater_0_3_Months;

            OrderItem_3.CreateUserId = UserMockFactory.Diana.Id;
            OrderItem_3.CreatedBy = UserMockFactory.Diana;
            OrderItem_3.ChangeUserId = UserMockFactory.Diana.Id;
            OrderItem_3.ChangedBy = UserMockFactory.Diana;
            OrderItem_3.OrderId = OrderMockFactory.Order_2.Id;
            OrderItem_3.Order = OrderMockFactory.Order_2;
            OrderItem_3.ProductSizeId = ProductSizeMockFactory.Boys_Sweater_0_3_Months.Id;
            OrderItem_3.ProductSize = ProductSizeMockFactory.Boys_Sweater_0_3_Months;

            OrderItem_4.CreateUserId = UserMockFactory.Jenya.Id;
            OrderItem_4.CreatedBy = UserMockFactory.Jenya;
            OrderItem_4.ChangeUserId = UserMockFactory.Olesya.Id;
            OrderItem_4.ChangedBy = UserMockFactory.Olesya;
            OrderItem_4.OrderId = OrderMockFactory.Order_2.Id;
            OrderItem_4.Order = OrderMockFactory.Order_2;
            OrderItem_4.ProductSizeId = ProductSizeMockFactory.Girls_Sweater_3_6_Months.Id;
            OrderItem_4.ProductSize = ProductSizeMockFactory.Girls_Sweater_3_6_Months;

            OrderItem_5.CreateUserId = UserMockFactory.Jenya.Id;
            OrderItem_5.CreatedBy = UserMockFactory.Jenya;
            OrderItem_5.ChangeUserId = UserMockFactory.Diana.Id;
            OrderItem_5.ChangedBy = UserMockFactory.Diana;
            OrderItem_5.OrderId = OrderMockFactory.Order_1.Id;
            OrderItem_5.Order = OrderMockFactory.Order_1;
            OrderItem_5.ProductSizeId = ProductSizeMockFactory.Boys_Sweater_3_6_Months.Id;
            OrderItem_5.ProductSize = ProductSizeMockFactory.Boys_Sweater_3_6_Months;

            OrderItem_6.CreateUserId = UserMockFactory.Jenya.Id;
            OrderItem_6.CreatedBy = UserMockFactory.Jenya;
            OrderItem_6.ChangeUserId = UserMockFactory.Jenya.Id;
            OrderItem_6.ChangedBy = UserMockFactory.Jenya;
            OrderItem_6.OrderId = OrderMockFactory.Order_1.Id;
            OrderItem_6.Order = OrderMockFactory.Order_1;
            OrderItem_6.ProductSizeId = ProductSizeMockFactory.Girls_Sweater_3_6_Months.Id;
            OrderItem_6.ProductSize = ProductSizeMockFactory.Girls_Sweater_3_6_Months;

            OrderItem_7.CreateUserId = UserMockFactory.Diana.Id;
            OrderItem_7.CreatedBy = UserMockFactory.Diana;
            OrderItem_7.ChangeUserId = UserMockFactory.Diana.Id;
            OrderItem_7.ChangedBy = UserMockFactory.Diana;
            OrderItem_7.OrderId = OrderMockFactory.Order_4.Id;
            OrderItem_7.Order = OrderMockFactory.Order_4;
            OrderItem_7.ProductSizeId = ProductSizeMockFactory.Boys_Sweater_3_6_Months.Id;
            OrderItem_7.ProductSize = ProductSizeMockFactory.Boys_Sweater_3_6_Months;

            OrderItem_8.CreateUserId = UserMockFactory.Jenya.Id;
            OrderItem_8.CreatedBy = UserMockFactory.Jenya;
            OrderItem_8.ChangeUserId = UserMockFactory.Olesya.Id;
            OrderItem_8.ChangedBy = UserMockFactory.Olesya;
            OrderItem_8.OrderId = OrderMockFactory.Order_5.Id;
            OrderItem_8.Order = OrderMockFactory.Order_5;
            OrderItem_8.ProductSizeId = ProductSizeMockFactory.Boys_Sweater_0_3_Months.Id;
            OrderItem_8.ProductSize = ProductSizeMockFactory.Boys_Sweater_0_3_Months;

            OrderItem_9.CreateUserId = UserMockFactory.Jenya.Id;
            OrderItem_9.CreatedBy = UserMockFactory.Jenya;
            OrderItem_9.ChangeUserId = UserMockFactory.Diana.Id;
            OrderItem_9.ChangedBy = UserMockFactory.Diana;
            OrderItem_9.OrderId = OrderMockFactory.Order_6.Id;
            OrderItem_9.Order = OrderMockFactory.Order_6;
            OrderItem_9.ProductSizeId = ProductSizeMockFactory.Girls_Sweater_0_3_Months.Id;
            OrderItem_9.ProductSize = ProductSizeMockFactory.Girls_Sweater_0_3_Months;

            OrderItem_10.CreateUserId = UserMockFactory.Jenya.Id;
            OrderItem_10.CreatedBy = UserMockFactory.Jenya;
            OrderItem_10.ChangeUserId = UserMockFactory.Jenya.Id;
            OrderItem_10.ChangedBy = UserMockFactory.Jenya;
            OrderItem_10.OrderId = OrderMockFactory.Order_7.Id;
            OrderItem_10.Order = OrderMockFactory.Order_7;
            OrderItem_10.ProductSizeId = ProductSizeMockFactory.Boys_Sweater_0_3_Months.Id;
            OrderItem_10.ProductSize = ProductSizeMockFactory.Boys_Sweater_0_3_Months;

            OrderItem_11.CreateUserId = UserMockFactory.Diana.Id;
            OrderItem_11.CreatedBy = UserMockFactory.Diana;
            OrderItem_11.ChangeUserId = UserMockFactory.Diana.Id;
            OrderItem_11.ChangedBy = UserMockFactory.Diana;
            OrderItem_11.OrderId = OrderMockFactory.Order_8.Id;
            OrderItem_11.Order = OrderMockFactory.Order_8;
            OrderItem_11.ProductSizeId = ProductSizeMockFactory.Girls_Sweater_3_6_Months.Id;
            OrderItem_11.ProductSize = ProductSizeMockFactory.Girls_Sweater_3_6_Months;

            OrderItem_12.CreateUserId = UserMockFactory.Jenya.Id;
            OrderItem_12.CreatedBy = UserMockFactory.Jenya;
            OrderItem_12.ChangeUserId = UserMockFactory.Olesya.Id;
            OrderItem_12.ChangedBy = UserMockFactory.Olesya;
            OrderItem_12.OrderId = OrderMockFactory.Order_7.Id;
            OrderItem_12.Order = OrderMockFactory.Order_7;
            OrderItem_12.ProductSizeId = ProductSizeMockFactory.Boys_Sweater_3_6_Months.Id;
            OrderItem_12.ProductSize = ProductSizeMockFactory.Boys_Sweater_3_6_Months;

            OrderItem_13.CreateUserId = UserMockFactory.Jenya.Id;
            OrderItem_13.CreatedBy = UserMockFactory.Jenya;
            OrderItem_13.ChangeUserId = UserMockFactory.Olesya.Id;
            OrderItem_13.ChangedBy = UserMockFactory.Olesya;
            OrderItem_13.OrderId = OrderMockFactory.Order_6.Id;
            OrderItem_13.Order = OrderMockFactory.Order_6;
            OrderItem_13.ProductSizeId = ProductSizeMockFactory.Girls_Sweater_3_6_Months.Id;
            OrderItem_13.ProductSize = ProductSizeMockFactory.Girls_Sweater_3_6_Months;

            OrderItem_14.CreateUserId = UserMockFactory.Jenya.Id;
            OrderItem_14.CreatedBy = UserMockFactory.Jenya;
            OrderItem_14.ChangeUserId = UserMockFactory.Olesya.Id;
            OrderItem_14.ChangedBy = UserMockFactory.Olesya;
            OrderItem_14.OrderId = OrderMockFactory.Order_4.Id;
            OrderItem_14.Order = OrderMockFactory.Order_4;
            OrderItem_14.ProductSizeId = ProductSizeMockFactory.Boys_Sweater_0_3_Months.Id;
            OrderItem_14.ProductSize = ProductSizeMockFactory.Boys_Sweater_0_3_Months;
        }

        public static void InitializeCollections()
        {
        }
    }
}
