using System.Data.Entity;
using USClothesWebSite.Common.Helpers;
using USClothesWebSite.DataAccess;

namespace USClothesWebSite.BusinessLogic.Test.Mocks
{
    public static class UserRoleMockFactory
    {
        public static UserRole AndreyAdministrator
        {
            get
            {
                return CacheHelper.Get(ref _andreyAdministrator,
                    () =>
                        new UserRole
                        {
                            Id = 1,
                            Active = true,
                            CreateDate = TimeServiceMockFactory.Date1,
                            ChangeDate = TimeServiceMockFactory.Date1
                        });
            }
        }
        private static UserRole _andreyAdministrator;

        public static UserRole AndreyPurchaser
        {
            get
            {
                return CacheHelper.Get(ref _andreyPurchaser,
                    () =>
                        new UserRole
                        {
                            Id = 2,
                            Active = false,
                            CreateDate = TimeServiceMockFactory.Date1,
                            ChangeDate = TimeServiceMockFactory.Date1
                        });
            }
        }
        private static UserRole _andreyPurchaser;

        public static UserRole AndreyDistributor
        {
            get
            {
                return CacheHelper.Get(ref _andreyDistributor,
                    () =>
                        new UserRole
                        {
                            Id = 3,
                            Active = false,
                            CreateDate = TimeServiceMockFactory.Date1,
                            ChangeDate = TimeServiceMockFactory.Date1
                        });
            }
        }
        private static UserRole _andreyDistributor;

        public static UserRole AndreySeller
        {
            get
            {
                return CacheHelper.Get(ref _andreySeller,
                    () =>
                        new UserRole
                        {
                            Id = 4,
                            Active = false,
                            CreateDate = TimeServiceMockFactory.Date1,
                            ChangeDate = TimeServiceMockFactory.Date1
                        });
            }
        }
        private static UserRole _andreySeller;

        public static UserRole GuestAdministrator
        {
            get
            {
                return CacheHelper.Get(ref _guestAdministrator,
                    () =>
                        new UserRole
                        {
                            Id = 5,
                            Active = false,
                            CreateDate = TimeServiceMockFactory.Date1,
                            ChangeDate = TimeServiceMockFactory.Date1
                        });
            }
        }
        private static UserRole _guestAdministrator;

        public static UserRole GuestPurchaser
        {
            get
            {
                return CacheHelper.Get(ref _guestPurchaser,
                    () =>
                        new UserRole
                        {
                            Id = 6,
                            Active = false,
                            CreateDate = TimeServiceMockFactory.Date1,
                            ChangeDate = TimeServiceMockFactory.Date1
                        });
            }
        }
        private static UserRole _guestPurchaser;

        public static UserRole GuestDistributor
        {
            get
            {
                return CacheHelper.Get(ref _guestDistributor,
                    () =>
                        new UserRole
                        {
                            Id = 7,
                            Active = false,
                            CreateDate = TimeServiceMockFactory.Date1,
                            ChangeDate = TimeServiceMockFactory.Date1
                        });
            }
        }
        private static UserRole _guestDistributor;

        public static UserRole GuestSeller
        {
            get
            {
                return CacheHelper.Get(ref _guestSeller,
                    () =>
                        new UserRole
                        {
                            Id = 8,
                            Active = false,
                            CreateDate = TimeServiceMockFactory.Date1,
                            ChangeDate = TimeServiceMockFactory.Date1
                        });
            }
        }
        private static UserRole _guestSeller;

        public static UserRole JenyaAdministrator
        {
            get
            {
                return CacheHelper.Get(ref _jenyaAdministrator,
                    () =>
                        new UserRole
                        {
                            Id = 9,
                            Active = true,
                            CreateDate = TimeServiceMockFactory.Date1,
                            ChangeDate = TimeServiceMockFactory.Date1
                        });
            }
        }
        private static UserRole _jenyaAdministrator;

        public static UserRole JenyaPurchaser
        {
            get
            {
                return CacheHelper.Get(ref _jenyaPurchaser,
                    () =>
                        new UserRole
                        {
                            Id = 10,
                            Active = true,
                            CreateDate = TimeServiceMockFactory.Date1,
                            ChangeDate = TimeServiceMockFactory.Date1
                        });
            }
        }
        private static UserRole _jenyaPurchaser;

        public static UserRole JenyaDistributor
        {
            get
            {
                return CacheHelper.Get(ref _jenyaDistributor,
                    () =>
                        new UserRole
                        {
                            Id = 11,
                            Active = true,
                            CreateDate = TimeServiceMockFactory.Date1,
                            ChangeDate = TimeServiceMockFactory.Date1
                        });
            }
        }
        private static UserRole _jenyaDistributor;

        public static UserRole JenyaSeller
        {
            get
            {
                return CacheHelper.Get(ref _jenyaSeller,
                    () =>
                        new UserRole
                        {
                            Id = 12,
                            Active = true,
                            CreateDate = TimeServiceMockFactory.Date1,
                            ChangeDate = TimeServiceMockFactory.Date1
                        });
            }
        }
        private static UserRole _jenyaSeller;

        public static UserRole OlesyaAdministrator
        {
            get
            {
                return CacheHelper.Get(ref _olesyaAdministrator,
                    () =>
                        new UserRole
                        {
                            Id = 13,
                            Active = false,
                            CreateDate = TimeServiceMockFactory.Date2,
                            ChangeDate = TimeServiceMockFactory.Date2
                        });
            }
        }
        private static UserRole _olesyaAdministrator;

        public static UserRole OlesyaPurchaser
        {
            get
            {
                return CacheHelper.Get(ref _olesyaPurchaser,
                    () =>
                        new UserRole
                        {
                            Id = 14,
                            Active = false,
                            CreateDate = TimeServiceMockFactory.Date2,
                            ChangeDate = TimeServiceMockFactory.Date2
                        });
            }
        }
        private static UserRole _olesyaPurchaser;

        public static UserRole OlesyaDistributor
        {
            get
            {
                return CacheHelper.Get(ref _olesyaDistributor,
                    () =>
                        new UserRole
                        {
                            Id = 15,
                            Active = true,
                            CreateDate = TimeServiceMockFactory.Date2,
                            ChangeDate = TimeServiceMockFactory.Date2
                        });
            }
        }
        private static UserRole _olesyaDistributor;

        public static UserRole OlesyaSeller
        {
            get
            {
                return CacheHelper.Get(ref _olesyaSeller,
                    () =>
                        new UserRole
                        {
                            Id = 16,
                            Active = false,
                            CreateDate = TimeServiceMockFactory.Date2,
                            ChangeDate = TimeServiceMockFactory.Date2
                        });
            }
        }
        private static UserRole _olesyaSeller;

        public static UserRole DianaAdministrator
        {
            get
            {
                return CacheHelper.Get(ref _dianaAdministrator,
                    () =>
                        new UserRole
                        {
                            Id = 17,
                            Active = false,
                            CreateDate = TimeServiceMockFactory.Date4,
                            ChangeDate = TimeServiceMockFactory.Date4
                        });
            }
        }
        private static UserRole _dianaAdministrator;

        public static UserRole DianaPurchaser
        {
            get
            {
                return CacheHelper.Get(ref _dianaPurchaser,
                    () =>
                        new UserRole
                        {
                            Id = 18,
                            Active = false,
                            CreateDate = TimeServiceMockFactory.Date4,
                            ChangeDate = TimeServiceMockFactory.Date4
                        });
            }
        }
        private static UserRole _dianaPurchaser;

        public static UserRole DianaDistributor
        {
            get
            {
                return CacheHelper.Get(ref _dianaDistributor,
                    () =>
                        new UserRole
                        {
                            Id = 19,
                            Active = true,
                            CreateDate = TimeServiceMockFactory.Date4,
                            ChangeDate = TimeServiceMockFactory.Date4
                        });
            }
        }
        private static UserRole _dianaDistributor;

        public static UserRole DianaSeller
        {
            get
            {
                return CacheHelper.Get(ref _dianaSeller,
                    () =>
                        new UserRole
                        {
                            Id = 20,
                            Active = true,
                            CreateDate = TimeServiceMockFactory.Date4,
                            ChangeDate = TimeServiceMockFactory.Date4
                        });
            }
        }
        private static UserRole _dianaSeller;

        public static IDbSet<UserRole> UserRoles
        {
            get
            {
                return CacheHelper.Get(ref _userRoles,
                    () =>
                    {
                        var userRoles =
                            new[]
                            {
                                AndreyAdministrator,
                                AndreyPurchaser,
                                AndreyDistributor,
                                AndreySeller,
                                GuestAdministrator,
                                GuestPurchaser,
                                GuestDistributor,
                                GuestSeller,
                                JenyaAdministrator,
                                JenyaPurchaser,
                                JenyaDistributor,
                                JenyaSeller,
                                OlesyaAdministrator,
                                OlesyaPurchaser,
                                OlesyaDistributor,
                                OlesyaSeller,
                                DianaAdministrator,
                                DianaPurchaser,
                                DianaDistributor,
                                DianaSeller
                            };

                        return new DbSetMock<UserRole>(userRoles);
                    });
            }
        }
        private static IDbSet<UserRole> _userRoles;

        public static void Reset()
        {
            _andreyAdministrator = null;
            _andreyPurchaser = null;
            _andreyDistributor = null;
            _andreySeller = null;
            _guestAdministrator = null;
            _guestPurchaser = null;
            _guestDistributor = null;
            _guestSeller = null;
            _jenyaAdministrator = null;
            _jenyaPurchaser = null;
            _jenyaDistributor = null;
            _jenyaSeller = null;
            _olesyaAdministrator = null;
            _olesyaPurchaser = null;
            _olesyaDistributor = null;
            _olesyaSeller = null;
            _dianaAdministrator = null;
            _dianaPurchaser = null;
            _dianaDistributor = null;
            _dianaSeller = null;
            _userRoles = null;
        }

        public static void InitializeRelations()
        {
            // Andrey
            AndreyAdministrator.CreateUserId = UserMockFactory.Andrey.Id;
            AndreyAdministrator.CreatedBy = UserMockFactory.Andrey;
            AndreyAdministrator.ChangeUserId = UserMockFactory.Andrey.Id;
            AndreyAdministrator.ChangedBy = UserMockFactory.Andrey;
            AndreyAdministrator.UserId = UserMockFactory.Andrey.Id;
            AndreyAdministrator.User = UserMockFactory.Andrey;
            AndreyAdministrator.RoleId = RoleMockFactory.Administrator.Id;
            AndreyAdministrator.Role = RoleMockFactory.Administrator;

            AndreyPurchaser.CreateUserId = UserMockFactory.Andrey.Id;
            AndreyPurchaser.CreatedBy = UserMockFactory.Andrey;
            AndreyPurchaser.ChangeUserId = UserMockFactory.Andrey.Id;
            AndreyPurchaser.ChangedBy = UserMockFactory.Andrey;
            AndreyPurchaser.UserId = UserMockFactory.Andrey.Id;
            AndreyPurchaser.User = UserMockFactory.Andrey;
            AndreyPurchaser.RoleId = RoleMockFactory.Purchaser.Id;
            AndreyPurchaser.Role = RoleMockFactory.Purchaser;

            AndreyDistributor.CreateUserId = UserMockFactory.Andrey.Id;
            AndreyDistributor.CreatedBy = UserMockFactory.Andrey;
            AndreyDistributor.ChangeUserId = UserMockFactory.Andrey.Id;
            AndreyDistributor.ChangedBy = UserMockFactory.Andrey;
            AndreyDistributor.UserId = UserMockFactory.Andrey.Id;
            AndreyDistributor.User = UserMockFactory.Andrey;
            AndreyDistributor.RoleId = RoleMockFactory.Distributor.Id;
            AndreyDistributor.Role = RoleMockFactory.Distributor;

            AndreySeller.CreateUserId = UserMockFactory.Andrey.Id;
            AndreySeller.CreatedBy = UserMockFactory.Andrey;
            AndreySeller.ChangeUserId = UserMockFactory.Andrey.Id;
            AndreySeller.ChangedBy = UserMockFactory.Andrey;
            AndreySeller.UserId = UserMockFactory.Andrey.Id;
            AndreySeller.User = UserMockFactory.Andrey;
            AndreySeller.RoleId = RoleMockFactory.Seller.Id;
            AndreySeller.Role = RoleMockFactory.Seller;

            // Guest
            GuestAdministrator.CreateUserId = UserMockFactory.Andrey.Id;
            GuestAdministrator.CreatedBy = UserMockFactory.Andrey;
            GuestAdministrator.ChangeUserId = UserMockFactory.Andrey.Id;
            GuestAdministrator.ChangedBy = UserMockFactory.Andrey;
            GuestAdministrator.UserId = UserMockFactory.Andrey.Id;
            GuestAdministrator.User = UserMockFactory.Andrey;
            GuestAdministrator.RoleId = RoleMockFactory.Administrator.Id;
            GuestAdministrator.Role = RoleMockFactory.Administrator;

            GuestPurchaser.CreateUserId = UserMockFactory.Andrey.Id;
            GuestPurchaser.CreatedBy = UserMockFactory.Andrey;
            GuestPurchaser.ChangeUserId = UserMockFactory.Andrey.Id;
            GuestPurchaser.ChangedBy = UserMockFactory.Andrey;
            GuestPurchaser.UserId = UserMockFactory.Andrey.Id;
            GuestPurchaser.User = UserMockFactory.Andrey;
            GuestPurchaser.RoleId = RoleMockFactory.Purchaser.Id;
            GuestPurchaser.Role = RoleMockFactory.Purchaser;

            GuestDistributor.CreateUserId = UserMockFactory.Andrey.Id;
            GuestDistributor.CreatedBy = UserMockFactory.Andrey;
            GuestDistributor.ChangeUserId = UserMockFactory.Andrey.Id;
            GuestDistributor.ChangedBy = UserMockFactory.Andrey;
            GuestDistributor.UserId = UserMockFactory.Andrey.Id;
            GuestDistributor.User = UserMockFactory.Andrey;
            GuestDistributor.RoleId = RoleMockFactory.Distributor.Id;
            GuestDistributor.Role = RoleMockFactory.Distributor;

            GuestSeller.CreateUserId = UserMockFactory.Andrey.Id;
            GuestSeller.CreatedBy = UserMockFactory.Andrey;
            GuestSeller.ChangeUserId = UserMockFactory.Andrey.Id;
            GuestSeller.ChangedBy = UserMockFactory.Andrey;
            GuestSeller.UserId = UserMockFactory.Andrey.Id;
            GuestSeller.User = UserMockFactory.Andrey;
            GuestSeller.RoleId = RoleMockFactory.Seller.Id;
            GuestSeller.Role = RoleMockFactory.Seller;

            // Jenya
            JenyaAdministrator.CreateUserId = UserMockFactory.Andrey.Id;
            JenyaAdministrator.CreatedBy = UserMockFactory.Andrey;
            JenyaAdministrator.ChangeUserId = UserMockFactory.Andrey.Id;
            JenyaAdministrator.ChangedBy = UserMockFactory.Andrey;
            JenyaAdministrator.UserId = UserMockFactory.Jenya.Id;
            JenyaAdministrator.User = UserMockFactory.Jenya;
            JenyaAdministrator.RoleId = RoleMockFactory.Administrator.Id;
            JenyaAdministrator.Role = RoleMockFactory.Administrator;

            JenyaPurchaser.CreateUserId = UserMockFactory.Andrey.Id;
            JenyaPurchaser.CreatedBy = UserMockFactory.Andrey;
            JenyaPurchaser.ChangeUserId = UserMockFactory.Andrey.Id;
            JenyaPurchaser.ChangedBy = UserMockFactory.Andrey;
            JenyaPurchaser.UserId = UserMockFactory.Jenya.Id;
            JenyaPurchaser.User = UserMockFactory.Jenya;
            JenyaPurchaser.RoleId = RoleMockFactory.Purchaser.Id;
            JenyaPurchaser.Role = RoleMockFactory.Purchaser;

            JenyaDistributor.CreateUserId = UserMockFactory.Andrey.Id;
            JenyaDistributor.CreatedBy = UserMockFactory.Andrey;
            JenyaDistributor.ChangeUserId = UserMockFactory.Andrey.Id;
            JenyaDistributor.ChangedBy = UserMockFactory.Andrey;
            JenyaDistributor.UserId = UserMockFactory.Jenya.Id;
            JenyaDistributor.User = UserMockFactory.Jenya;
            JenyaDistributor.RoleId = RoleMockFactory.Distributor.Id;
            JenyaDistributor.Role = RoleMockFactory.Distributor;

            JenyaSeller.CreateUserId = UserMockFactory.Andrey.Id;
            JenyaSeller.CreatedBy = UserMockFactory.Andrey;
            JenyaSeller.ChangeUserId = UserMockFactory.Andrey.Id;
            JenyaSeller.ChangedBy = UserMockFactory.Andrey;
            JenyaSeller.UserId = UserMockFactory.Jenya.Id;
            JenyaSeller.User = UserMockFactory.Jenya;
            JenyaSeller.RoleId = RoleMockFactory.Seller.Id;
            JenyaSeller.Role = RoleMockFactory.Seller;

            // Olesya
            OlesyaAdministrator.CreateUserId = UserMockFactory.Jenya.Id;
            OlesyaAdministrator.CreatedBy = UserMockFactory.Jenya;
            OlesyaAdministrator.ChangeUserId = UserMockFactory.Jenya.Id;
            OlesyaAdministrator.ChangedBy = UserMockFactory.Jenya;
            OlesyaAdministrator.UserId = UserMockFactory.Olesya.Id;
            OlesyaAdministrator.User = UserMockFactory.Olesya;
            OlesyaAdministrator.RoleId = RoleMockFactory.Administrator.Id;
            OlesyaAdministrator.Role = RoleMockFactory.Administrator;

            OlesyaPurchaser.CreateUserId = UserMockFactory.Jenya.Id;
            OlesyaPurchaser.CreatedBy = UserMockFactory.Jenya;
            OlesyaPurchaser.ChangeUserId = UserMockFactory.Jenya.Id;
            OlesyaPurchaser.ChangedBy = UserMockFactory.Jenya;
            OlesyaPurchaser.UserId = UserMockFactory.Olesya.Id;
            OlesyaPurchaser.User = UserMockFactory.Olesya;
            OlesyaPurchaser.RoleId = RoleMockFactory.Purchaser.Id;
            OlesyaPurchaser.Role = RoleMockFactory.Purchaser;

            OlesyaDistributor.CreateUserId = UserMockFactory.Jenya.Id;
            OlesyaDistributor.CreatedBy = UserMockFactory.Jenya;
            OlesyaDistributor.ChangeUserId = UserMockFactory.Jenya.Id;
            OlesyaDistributor.ChangedBy = UserMockFactory.Jenya;
            OlesyaDistributor.UserId = UserMockFactory.Olesya.Id;
            OlesyaDistributor.User = UserMockFactory.Olesya;
            OlesyaDistributor.RoleId = RoleMockFactory.Distributor.Id;
            OlesyaDistributor.Role = RoleMockFactory.Distributor;

            OlesyaSeller.CreateUserId = UserMockFactory.Jenya.Id;
            OlesyaSeller.CreatedBy = UserMockFactory.Jenya;
            OlesyaSeller.ChangeUserId = UserMockFactory.Jenya.Id;
            OlesyaSeller.ChangedBy = UserMockFactory.Jenya;
            OlesyaSeller.UserId = UserMockFactory.Olesya.Id;
            OlesyaSeller.User = UserMockFactory.Olesya;
            OlesyaSeller.RoleId = RoleMockFactory.Seller.Id;
            OlesyaSeller.Role = RoleMockFactory.Seller;

            // Diana
            DianaAdministrator.CreateUserId = UserMockFactory.Jenya.Id;
            DianaAdministrator.CreatedBy = UserMockFactory.Jenya;
            DianaAdministrator.ChangeUserId = UserMockFactory.Jenya.Id;
            DianaAdministrator.ChangedBy = UserMockFactory.Jenya;
            DianaAdministrator.UserId = UserMockFactory.Diana.Id;
            DianaAdministrator.User = UserMockFactory.Diana;
            DianaAdministrator.RoleId = RoleMockFactory.Administrator.Id;
            DianaAdministrator.Role = RoleMockFactory.Administrator;

            DianaPurchaser.CreateUserId = UserMockFactory.Jenya.Id;
            DianaPurchaser.CreatedBy = UserMockFactory.Jenya;
            DianaPurchaser.ChangeUserId = UserMockFactory.Jenya.Id;
            DianaPurchaser.ChangedBy = UserMockFactory.Jenya;
            DianaPurchaser.UserId = UserMockFactory.Diana.Id;
            DianaPurchaser.User = UserMockFactory.Diana;
            DianaPurchaser.RoleId = RoleMockFactory.Purchaser.Id;
            DianaPurchaser.Role = RoleMockFactory.Purchaser;

            DianaDistributor.CreateUserId = UserMockFactory.Jenya.Id;
            DianaDistributor.CreatedBy = UserMockFactory.Jenya;
            DianaDistributor.ChangeUserId = UserMockFactory.Jenya.Id;
            DianaDistributor.ChangedBy = UserMockFactory.Jenya;
            DianaDistributor.UserId = UserMockFactory.Diana.Id;
            DianaDistributor.User = UserMockFactory.Diana;
            DianaDistributor.RoleId = RoleMockFactory.Distributor.Id;
            DianaDistributor.Role = RoleMockFactory.Distributor;

            DianaSeller.CreateUserId = UserMockFactory.Jenya.Id;
            DianaSeller.CreatedBy = UserMockFactory.Jenya;
            DianaSeller.ChangeUserId = UserMockFactory.Jenya.Id;
            DianaSeller.ChangedBy = UserMockFactory.Jenya;
            DianaSeller.UserId = UserMockFactory.Diana.Id;
            DianaSeller.User = UserMockFactory.Diana;
            DianaSeller.RoleId = RoleMockFactory.Seller.Id;
            DianaSeller.Role = RoleMockFactory.Seller;
        }

        public static void InitializeCollections()
        {
        }
    }
}
