using System.Data.Entity;
using System.Linq;
using USClothesWebSite.Common.Helpers;
using USClothesWebSite.DataAccess;

namespace USClothesWebSite.BusinessLogic.Test.Mocks
{
    public static class RoleMockFactory
    {
        public static Role Administrator
        {
            get
            {
                return CacheHelper.Get(ref _administrator,
                    () =>
                        new Role
                        {
                            Id = 1,
                            Name = DTO.Role.ADMINISTRATOR_ROLE_NAME
                        });
            }
        }
        private static Role _administrator;
        
        public static Role Purchaser
        {
            get
            {
                return CacheHelper.Get(ref _purchaser,
                    () =>
                        new Role
                        {
                            Id = 2,
                            Name = DTO.Role.PURCHASER_ROLE_NAME
                        });
            }
        }
        private static Role _purchaser;
        
        public static Role Distributor
        {
            get
            {
                return CacheHelper.Get(ref _distributor,
                    () =>
                        new Role
                        {
                            Id = 3,
                            Name = DTO.Role.DISTRIBUTOR_ROLE_NAME
                        });
            }
        }
        private static Role _distributor;

        public static Role Seller
        {
            get
            {
                return CacheHelper.Get(ref _seller,
                    () =>
                        new Role
                        {
                            Id = 4,
                            Name = DTO.Role.SELLER_ROLE_NAME
                        });
            }
        }
        private static Role _seller;

        public static IDbSet<Role> Roles
        {
            get
            {
                return CacheHelper.Get(ref _roles,
                    () =>
                    {
                        var roles =
                            new[]
                            {
                                Administrator, 
                                Purchaser, 
                                Distributor,
                                Seller
                            };

                        return new DbSetMock<Role>(roles);
                    });
            }
        }
        private static IDbSet<Role> _roles;

        public static void Reset()
        {
            _administrator = null;
            _purchaser = null;
            _distributor = null;
            _seller = null;
            _roles = null;
        }

        public static void InitializeRelations()
        {
        }

        public static void InitializeCollections()
        {
            foreach (var role in Roles)
            {
                role.UserRoles =
                    UserRoleMockFactory.UserRoles
                        .Where(ur => ur.Role == role)
                        .ToArray();
            }
        }
    }
}
