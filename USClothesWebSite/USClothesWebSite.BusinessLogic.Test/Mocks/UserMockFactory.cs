using System.Data.Entity;
using System.Linq;
using USClothesWebSite.Common.Helpers;
using USClothesWebSite.DataAccess;

namespace USClothesWebSite.BusinessLogic.Test.Mocks
{
    public static class UserMockFactory
    {
        public static User Andrey
        {
            get
            {
                return CacheHelper.Get(ref _andrey,
                    () =>
                        new User
                            {
                                Id = 1,
                                FirstName = "Андрей",
                                LastName = "Test",
                                Email = "test@test.com",
                                Login = "chyuck",
                                PasswordHash = EncryptServiceMockFactory.AndreyPasswordData.PasswordHash,
                                PasswordSalt = EncryptServiceMockFactory.AndreyPasswordData.PasswordSalt,
                                Active = false,
                                CreateDate = TimeServiceMockFactory.Date1,
                                ChangeDate = TimeServiceMockFactory.Date3
                            });
            }
        }
        private static User _andrey;
        
        public static User Guest
        {
            get
            {
                return CacheHelper.Get(ref _guest,
                    () =>
                        new User
                        {
                            Id = 2,
                            FirstName = "Гость",
                            LastName = string.Empty,
                            Email = string.Empty,
                            Login = "guest",
                            PasswordHash = string.Empty,
                            PasswordSalt = string.Empty,
                            Active = true,
                            CreateDate = TimeServiceMockFactory.Date1,
                            ChangeDate = TimeServiceMockFactory.Date1
                        });
            }
        }
        private static User _guest;
        
        public static User Jenya
        {
            get
            {
                return CacheHelper.Get(ref _jenya,
                    () =>
                        new User
                        {
                            Id = 3,
                            FirstName = "Евгения",
                            LastName = "Test",
                            Email = "test1@test.ru",
                            Login = "Jenya",
                            PasswordHash = EncryptServiceMockFactory.JenyaPasswordData.PasswordHash,
                            PasswordSalt = EncryptServiceMockFactory.JenyaPasswordData.PasswordSalt,
                            Active = true,
                            CreateDate = TimeServiceMockFactory.Date2,
                            ChangeDate = TimeServiceMockFactory.Date3
                        });
            }
        }
        private static User _jenya;

        public static User Olesya
        {
            get
            {
                return CacheHelper.Get(ref _olesya,
                    () =>
                        new User
                        {
                            Id = 4,
                            FirstName = "Олеся",
                            LastName = "Test",
                            Email = "test2@test.ru",
                            Login = "Olesya",
                            PasswordHash = EncryptServiceMockFactory.OlesyaPasswordData.PasswordHash,
                            PasswordSalt = EncryptServiceMockFactory.OlesyaPasswordData.PasswordSalt,
                            Active = true,
                            CreateDate = TimeServiceMockFactory.Date2,
                            ChangeDate = TimeServiceMockFactory.Date2
                        });
            }
        }
        private static User _olesya;

        public static User Diana
        {
            get
            {
                return CacheHelper.Get(ref _diana,
                    () =>
                        new User
                        {
                            Id = 5,
                            FirstName = "Диана",
                            LastName = "Test",
                            Email = "test3@mail.ru",
                            Login = "Diana",
                            PasswordHash = EncryptServiceMockFactory.DianaPasswordData.PasswordHash,
                            PasswordSalt = EncryptServiceMockFactory.DianaPasswordData.PasswordSalt,
                            Active = true,
                            CreateDate = TimeServiceMockFactory.Date4,
                            ChangeDate = TimeServiceMockFactory.Date5
                        });
            }
        }
        private static User _diana;

        public static IDbSet<User> Users
        {
            get
            {
                return CacheHelper.Get(ref _users,
                    () =>
                    {
                        var users =
                            new[]
                            {
                                Andrey, 
                                Guest,
                                Jenya, 
                                Olesya, 
                                Diana
                            };

                        return new DbSetMock<User>(users);
                    });
            }
        }
        private static IDbSet<User> _users;

        public static void Reset()
        {
            _andrey = null;
            _guest = null;
            _jenya = null;
            _olesya = null;
            _diana = null;
            _users = null;
        }

        public static void InitializeRelations()
        {
            // Андрей
            Andrey.CreateUserId = Andrey.Id;
            Andrey.CreatedBy = Andrey;
            Andrey.ChangeUserId = Andrey.Id;
            Andrey.ChangedBy = Andrey;

            // Гость
            Guest.CreateUserId = Andrey.Id;
            Guest.CreatedBy = Andrey;
            Guest.ChangeUserId = Andrey.Id;
            Guest.ChangedBy = Andrey;

            // Евгения
            Jenya.CreateUserId = Andrey.Id;
            Jenya.CreatedBy = Andrey;
            Jenya.ChangeUserId = Jenya.Id;
            Jenya.ChangedBy = Jenya;

            // Олеся
            Olesya.CreateUserId = Jenya.Id;
            Olesya.CreatedBy = Jenya;
            Olesya.ChangeUserId = Jenya.Id;
            Olesya.ChangedBy = Jenya;

            // Диана
            Diana.CreateUserId = Jenya.Id;
            Diana.CreatedBy = Jenya;
            Diana.ChangeUserId = Diana.Id;
            Diana.ChangedBy = Diana;
        }

        public static void InitializeCollections()
        {
            foreach (var user in Users)
            {
                user.UserRoles =
                    UserRoleMockFactory.UserRoles
                        .Where(ur => ur.User == user)
                        .ToArray();
            }
        }
    }
}
