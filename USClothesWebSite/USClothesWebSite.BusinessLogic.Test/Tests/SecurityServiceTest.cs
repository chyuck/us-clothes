using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using USClothesWebSite.BusinessLogic.ActionLog;
using USClothesWebSite.BusinessLogic.Dto;
using USClothesWebSite.BusinessLogic.Security;
using USClothesWebSite.BusinessLogic.Test.Mocks;
using USClothesWebSite.BusinessLogic.Extensions;
using USClothesWebSite.DataAccess;
using USClothesWebSite.Test.Common;
using USClothesWebSite.BusinessLogic.Test.Extensions;

namespace USClothesWebSite.BusinessLogic.Test
{
    [TestClass]
    public class SecurityServiceTest
    {
        [TestMethod]
        public void LogIn_Should_Log_In_User()
        {
            // Arrange
            var container = ContainerMockFactory.Create();
            var securityService = container.Get<ISecurityService>();
            var dtoService = container.Get<IDtoService>();

            // Act
            securityService.LogIn(UserMockFactory.Olesya.Login, EncryptServiceMockFactory.OlesyaPasswordData.Password);

            // Assert
            Assert.IsTrue(securityService.IsLoggedIn);

            var expectedUser = dtoService.CreateUser(UserMockFactory.Olesya);
            Assert.AreEqual(expectedUser, securityService.CurrentUser);
            
            CollectionAssert.AreEqual(expectedUser.Roles, securityService.CurrentUser.Roles);
            CollectionAssert.AreEqual(expectedUser.Roles, securityService.CurrentRoles);
        }

        [TestMethod]
        public void LogIn_Should_Throw_Exception_When_Wrong_Login()
        {
            // Arrange
            var container = ContainerMockFactory.Create();
            var securityService = container.Get<ISecurityService>();
            
            // Act
            // Assert
            ExceptionAssert.Throw<SecurityServiceException>(
                () => securityService.LogIn("wrong_login", EncryptServiceMockFactory.OlesyaPasswordData.Password),
                "Пользователь с заданным логином и паролем не существует.");
        }

        [TestMethod]
        public void LogIn_Should_Throw_Exception_When_Wrong_Password()
        {
            // Arrange
            var container = ContainerMockFactory.Create();
            var securityService = container.Get<ISecurityService>();

            // Act
            // Assert
            ExceptionAssert.Throw<SecurityServiceException>(
                () => securityService.LogIn(UserMockFactory.Olesya.Login, EncryptServiceMockFactory.WrongPasswordData.Password),
                "Пользователь с заданным логином и паролем не существует.");
        }

        [TestMethod]
        public void LogIn_Should_Throw_Exception_When_User_Is_Inactive()
        {
            // Arrange
            var container = ContainerMockFactory.Create();
            var securityService = container.Get<ISecurityService>();

            // Act
            // Assert
            ExceptionAssert.Throw<SecurityServiceException>(
                () => securityService.LogIn(UserMockFactory.Andrey.Login, EncryptServiceMockFactory.AndreyPasswordData.Password),
                "Пользователь с заданным логином отключен администратором.");
        }

        [TestMethod]
        public void LogIn_Should_Throw_Exception_When_Log_In_Twice()
        {
            // Arrange
            var container = ContainerMockFactory.Create();
            var securityService = container.Get<ISecurityService>();
            
            securityService.LogIn(UserMockFactory.Olesya.Login, EncryptServiceMockFactory.OlesyaPasswordData.Password);

            // Act
            // Assert
            ExceptionAssert.Throw<InvalidOperationException>(
                () => securityService.LogIn(UserMockFactory.Olesya.Login, EncryptServiceMockFactory.OlesyaPasswordData.Password),
                "User is already logged in.");
        }

        [TestMethod]
        public void LogOut_Should_Log_Out_User()
        {
            // Arrange
            var container = ContainerMockFactory.Create();
            var securityService = container.Get<ISecurityService>();
            
            securityService.LogIn(UserMockFactory.Olesya.Login, EncryptServiceMockFactory.OlesyaPasswordData.Password);

            // Act
            securityService.LogOut();

            // Assert
            Assert.IsFalse(securityService.IsLoggedIn);
            Assert.IsNull(securityService.CurrentUser);
            CollectionAssert.AreEqual(new DTO.Role[]{}, securityService.CurrentRoles);
        }
        
        [TestMethod]
        public void AvailableRoles_Should_Return_All_Roles()
        {
            // Arrange
            var container = ContainerMockFactory.Create();
            var securityService = container.Get<ISecurityService>();

            securityService.LogInGuest();
            
            var dtoService = container.Get<IDtoService>();
            
            // Act
            var roles = securityService.AvailableRoles;

            // Assert
            var expectedRoles = 
                new[]
                {
                    dtoService.CreateRole(RoleMockFactory.Administrator),
                    dtoService.CreateRole(RoleMockFactory.Purchaser),
                    dtoService.CreateRole(RoleMockFactory.Seller),
                    dtoService.CreateRole(RoleMockFactory.Distributor)
                };

            CollectionAssert.AreEqual(expectedRoles, roles);
        }

        [TestMethod]
        public void LogInGuest_Should_Log_In_As_Guest()
        {
            // Arrange
            var container = ContainerMockFactory.Create();
            var securityService = container.Get<ISecurityService>();

            var dtoService = container.Get<IDtoService>();

            // Act
            securityService.LogInGuest();

            // Assert
            Assert.IsTrue(securityService.IsLoggedIn);

            var expectedUser = dtoService.CreateUser(UserMockFactory.Guest);
            Assert.AreEqual(expectedUser, securityService.CurrentUser);

            CollectionAssert.AreEqual(expectedUser.Roles, securityService.CurrentUser.Roles);
            CollectionAssert.AreEqual(expectedUser.Roles, securityService.CurrentRoles);
        }

        [TestMethod]
        public void ChangePassword_Should_Change_Password()
        {
            // Arrange
            var container = ContainerMockFactory.Create();
            var securityService = container.Get<ISecurityService>();

            securityService.LogIn(UserMockFactory.Diana.Login, EncryptServiceMockFactory.DianaPasswordData.Password);
            
            // Act
            securityService.ChangePassword(EncryptServiceMockFactory.NewPasswordData.Password);

            // Assert
            securityService.LogOut();
            securityService.LogIn(UserMockFactory.Diana.Login, EncryptServiceMockFactory.NewPasswordData.Password);
            Assert.IsTrue(securityService.IsLoggedIn);
        }
        
        [TestMethod]
        public void ChangePassword_Should_Throw_Exception_When_Guest_Attempts_Change_Password()
        {
            // Arrange
            var container = ContainerMockFactory.Create();
            var securityService = container.Get<ISecurityService>();

            securityService.LogInGuest();

            // Act
            // Assert
            ExceptionAssert.Throw<InvalidOperationException>(
                () => securityService.ChangePassword(EncryptServiceMockFactory.NewPasswordData.Password),
                "Guest cannot change password.");
        }

        [TestMethod]
        public void ChangePassword_Should_Create_ActionLog()
        {
            // Arrange
            var container = ContainerMockFactory.Create();
            var securityService = container.Get<ISecurityService>();

            securityService.LogIn(UserMockFactory.Jenya.Login, EncryptServiceMockFactory.JenyaPasswordData.Password);

            // Act
            securityService.ChangePassword(EncryptServiceMockFactory.NewPasswordData.Password);

            // Assert
            var actionLogService = container.Get<IActionLogService>();

            var actionLog =
                actionLogService    
                    .GetActionLogs(TimeServiceMockFactory.UtcNow, TimeServiceMockFactory.UtcNow, null)
                    .Single();

            Assert.AreEqual(string.Format("{0} сменил пароль.", UserMockFactory.Jenya.GetDataString()), actionLog.Text);
            Assert.AreEqual(UserMockFactory.Jenya.Id, actionLog.DocumentId);
            Assert.AreEqual(actionLogService.UserChangedPasswordType, actionLog.ActionLogType);
            Assert.AreEqual(UserMockFactory.Jenya.GetFullName(), actionLog.CreateUser);
        }
        
        [TestMethod]
        public void UpdateUser_Should_Update_User_Data()
        {
            // Arrange
            var container = ContainerMockFactory.Create();
            var securityService = container.Get<ISecurityService>();

            securityService.LogIn(UserMockFactory.Jenya.Login, EncryptServiceMockFactory.JenyaPasswordData.Password);

            var dtoService = container.Get<IDtoService>();

            var updatedUser =
                new DTO.User
                {
                    Id = UserMockFactory.Olesya.Id,
                    Email = "newemail@mail.com",
                    FirstName = "New First Name",
                    LastName = "New Last Name",
                    Login = "new_login",
                    Active = true,
                    Roles = 
                        new[]
                        {
                            dtoService.CreateRole(RoleMockFactory.Purchaser),
                            dtoService.CreateRole(RoleMockFactory.Distributor)
                        }
                };

            // Act
            securityService.UpdateUser(updatedUser);

            // Assert
            securityService.LogOut();
            securityService.LogIn(updatedUser.Login, EncryptServiceMockFactory.OlesyaPasswordData.Password);

            Assert.AreEqual(updatedUser, securityService.CurrentUser);
            CollectionAssert.AreEqual(updatedUser.Roles, securityService.CurrentRoles);
        }

        [TestMethod]
        public void UpdateUser_Should_Update_User_Data_When_Login_Is_Not_Changed()
        {
            // Arrange
            var container = ContainerMockFactory.Create();
            var securityService = container.Get<ISecurityService>();

            securityService.LogIn(UserMockFactory.Jenya.Login, EncryptServiceMockFactory.JenyaPasswordData.Password);

            var dtoService = container.Get<IDtoService>();

            var updatedUser =
                new DTO.User
                {
                    Id = UserMockFactory.Olesya.Id,
                    Email = "newemail@mail.com",
                    FirstName = "New First Name",
                    LastName = "New Last Name",
                    Login = UserMockFactory.Olesya.Login,
                    Active = true,
                    Roles =
                        new[]
                        {
                            dtoService.CreateRole(RoleMockFactory.Purchaser),
                            dtoService.CreateRole(RoleMockFactory.Distributor)
                        }
                };

            // Act
            securityService.UpdateUser(updatedUser);

            // Assert
            securityService.LogOut();
            securityService.LogIn(updatedUser.Login, EncryptServiceMockFactory.OlesyaPasswordData.Password);

            Assert.AreEqual(updatedUser, securityService.CurrentUser);
            CollectionAssert.AreEqual(updatedUser.Roles, securityService.CurrentRoles);
        }

        [TestMethod]
        public void UpdateUser_Should_Update_CurrentUser_When_CurrentUser_Updates_His_Data()
        {
            // Arrange
            var container = ContainerMockFactory.Create();
            var securityService = container.Get<ISecurityService>();

            securityService.LogIn(UserMockFactory.Jenya.Login, EncryptServiceMockFactory.JenyaPasswordData.Password);

            var dtoService = container.Get<IDtoService>();

            var updatedUser =
                new DTO.User
                {
                    Id = UserMockFactory.Jenya.Id,
                    Email = "newemail@mail.com",
                    FirstName = "New First Name",
                    LastName = "New Last Name",
                    Login = "new_login",
                    Active = true,
                    Roles =
                        new[]
                        {
                            dtoService.CreateRole(RoleMockFactory.Administrator),
                            dtoService.CreateRole(RoleMockFactory.Distributor)
                        }
                };

            // Act
            securityService.UpdateUser(updatedUser);

            // Assert
            Assert.AreEqual(updatedUser, securityService.CurrentUser);
            CollectionAssert.AreEqual(updatedUser.Roles, securityService.CurrentRoles);
        }

        [TestMethod]
        public void UpdateUser_Should_Throw_Exception_When_Current_User_Is_Not_Administrator()
        {
            // Arrange
            var container = ContainerMockFactory.Create();
            var securityService = container.Get<ISecurityService>();

            securityService.LogIn(UserMockFactory.Diana.Login, EncryptServiceMockFactory.DianaPasswordData.Password);

            // Act
            // Assert
            ExceptionAssert.Throw<InvalidOperationException>(
                () => securityService.UpdateUser(securityService.CurrentUser),
                "Only administrator can change user data.");
        }

        [TestMethod]
        public void UpdateUser_Should_Throw_Exception_When_User_Tries_Make_Himself_Inactive()
        {
            // Arrange
            var container = ContainerMockFactory.Create();
            var securityService = container.Get<ISecurityService>();

            securityService.LogIn(UserMockFactory.Jenya.Login, EncryptServiceMockFactory.JenyaPasswordData.Password);

            var dtoService = container.Get<IDtoService>();

            var updatedUser =
                new DTO.User
                {
                    Id = UserMockFactory.Jenya.Id,
                    Email = "newemail@mail.com",
                    FirstName = "New First Name",
                    LastName = "New Last Name",
                    Login = "new_login",
                    Active = false,
                    Roles =
                        new[]
                        {
                            dtoService.CreateRole(RoleMockFactory.Administrator),
                            dtoService.CreateRole(RoleMockFactory.Purchaser),
                            dtoService.CreateRole(RoleMockFactory.Distributor)
                        }
                };

            // Act
            // Assert
            ExceptionAssert.Throw<SecurityServiceException>(
                () => securityService.UpdateUser(updatedUser),
                "Пользователь не может отключить себя.");
        }

        [TestMethod]
        public void UpdateUser_Should_Throw_Exception_When_User_Tries_Remove_Administrator_Role()
        {
            // Arrange
            var container = ContainerMockFactory.Create();
            var securityService = container.Get<ISecurityService>();

            securityService.LogIn(UserMockFactory.Jenya.Login, EncryptServiceMockFactory.JenyaPasswordData.Password);

            var dtoService = container.Get<IDtoService>();

            var updatedUser =
                new DTO.User
                {
                    Id = UserMockFactory.Jenya.Id,
                    Email = "newemail@mail.com",
                    FirstName = "New First Name",
                    LastName = "New Last Name",
                    Login = "new_login",
                    Active = true,
                    Roles =
                        new[]
                        {
                            dtoService.CreateRole(RoleMockFactory.Purchaser),
                            dtoService.CreateRole(RoleMockFactory.Distributor)
                        }
                };

            // Act
            // Assert
            ExceptionAssert.Throw<SecurityServiceException>(
                () => securityService.UpdateUser(updatedUser),
                "Пользователь не может удалить роль администратора у себя.");
        }

        [TestMethod]
        public void UpdateUser_Should_Throw_Exception_When_User_With_The_Same_Login_Already_Exists()
        {
            // Arrange
            var container = ContainerMockFactory.Create();
            var securityService = container.Get<ISecurityService>();

            securityService.LogIn(UserMockFactory.Jenya.Login, EncryptServiceMockFactory.JenyaPasswordData.Password);

            var dtoService = container.Get<IDtoService>();

            var updatedUser =
                new DTO.User
                {
                    Id = UserMockFactory.Jenya.Id,
                    Email = "newemail@mail.com",
                    FirstName = "New First Name",
                    LastName = "New Last Name",
                    Login = UserMockFactory.Olesya.Login,
                    Active = true,
                    Roles =
                        new[]
                        {
                            dtoService.CreateRole(RoleMockFactory.Administrator),
                            dtoService.CreateRole(RoleMockFactory.Purchaser),
                            dtoService.CreateRole(RoleMockFactory.Distributor)
                        }
                };

            // Act
            // Assert
            ExceptionAssert.Throw<SecurityServiceException>(
                () => securityService.UpdateUser(updatedUser),
                "Пользователь с заданным логином уже существует.");
        }

        [TestMethod]
        public void UpdateUser_Should_Create_ActionLog()
        {
            // Arrange
            var container = ContainerMockFactory.Create();
            var securityService = container.Get<ISecurityService>();

            securityService.LogIn(UserMockFactory.Jenya.Login, EncryptServiceMockFactory.JenyaPasswordData.Password);

            var dtoService = container.Get<IDtoService>();

            var updatedUser =
                new DTO.User
                {
                    Id = UserMockFactory.Olesya.Id,
                    Email = "newemail@mail.com",
                    FirstName = "New First Name",
                    LastName = "New Last Name",
                    Login = "new_login",
                    Active = true,
                    Roles =
                        new[]
                        {
                            dtoService.CreateRole(RoleMockFactory.Purchaser),
                            dtoService.CreateRole(RoleMockFactory.Distributor)
                        }
                };

            // Act
            securityService.UpdateUser(updatedUser);

            // Assert
            var actionLogService = container.Get<IActionLogService>();

            var actionLog =
                actionLogService
                    .GetActionLogs(TimeServiceMockFactory.UtcNow, TimeServiceMockFactory.UtcNow, null)
                    .Single();

            Assert.AreEqual(string.Format("{0} изменен.", UserMockFactory.Olesya.GetDataString()), actionLog.Text);
            Assert.AreEqual(UserMockFactory.Olesya.Id, actionLog.DocumentId);
            Assert.AreEqual(actionLogService.UserChangedType, actionLog.ActionLogType);
            Assert.AreEqual(UserMockFactory.Jenya.GetFullName(), actionLog.CreateUser);
        }

        [TestMethod]
        public void CreateUser_Should_Create_User()
        {
            // Arrange
            var container = ContainerMockFactory.Create();
            var securityService = container.Get<ISecurityService>();

            securityService.LogIn(UserMockFactory.Jenya.Login, EncryptServiceMockFactory.JenyaPasswordData.Password);

            var dtoService = container.Get<IDtoService>();

            var createdUser =
                new DTO.User
                {
                    Email = "newemail@mail.com",
                    FirstName = "New First Name",
                    LastName = "New Last Name",
                    Login = "new_login",
                    Active = true,
                    Roles =
                        new[]
                        {
                            dtoService.CreateRole(RoleMockFactory.Purchaser),
                            dtoService.CreateRole(RoleMockFactory.Distributor)
                        }
                };

            container.Remove<IPasswordGeneratorService>();
            var passwordGeneratorServiceMock = new Mock<IPasswordGeneratorService>();
            passwordGeneratorServiceMock
                .Setup(m => m.GenerateTemporaryPassword(createdUser.Login))
                .Returns(EncryptServiceMockFactory.NewPasswordData.Password);
            container.SetConstant<IPasswordGeneratorService, IPasswordGeneratorService>(passwordGeneratorServiceMock.Object);

            // Act
            securityService.CreateUser(createdUser);

            // Assert
            securityService.LogOut();
            securityService.LogIn(createdUser.Login, EncryptServiceMockFactory.NewPasswordData.Password);

            Assert.AreEqual(createdUser, securityService.CurrentUser);
            CollectionAssert.AreEqual(createdUser.Roles, securityService.CurrentRoles);
        }

        [TestMethod]
        public void CreateUser_Should_Throw_Exception_When_Current_User_Is_Not_Administrator()
        {
            // Arrange
            var container = ContainerMockFactory.Create();
            var securityService = container.Get<ISecurityService>();

            securityService.LogIn(UserMockFactory.Olesya.Login, EncryptServiceMockFactory.OlesyaPasswordData.Password);

            var dtoService = container.Get<IDtoService>();

            var createdUser =
                new DTO.User
                {
                    Email = "newemail@mail.com",
                    FirstName = "New First Name",
                    LastName = "New Last Name",
                    Login = "new_login",
                    Active = true,
                    Roles =
                        new[]
                        {
                            dtoService.CreateRole(RoleMockFactory.Purchaser),
                            dtoService.CreateRole(RoleMockFactory.Distributor)
                        }
                };

            container.Remove<IPasswordGeneratorService>();
            var passwordGeneratorServiceMock = new Mock<IPasswordGeneratorService>();
            passwordGeneratorServiceMock
                .Setup(m => m.GenerateTemporaryPassword(createdUser.Login))
                .Returns(EncryptServiceMockFactory.NewPasswordData.Password);
            container.SetConstant<IPasswordGeneratorService, IPasswordGeneratorService>(passwordGeneratorServiceMock.Object);

            // Act
            // Assert
            ExceptionAssert.Throw<InvalidOperationException>(
                () => securityService.CreateUser(createdUser),
                "Only administrator can create user.");
        }

        [TestMethod]
        public void CreateUser_Should_Throw_Exception_When_User_With_The_Same_Login_Already_Exists()
        {
            // Arrange
            var container = ContainerMockFactory.Create();
            var securityService = container.Get<ISecurityService>();

            securityService.LogIn(UserMockFactory.Jenya.Login, EncryptServiceMockFactory.JenyaPasswordData.Password);

            var dtoService = container.Get<IDtoService>();

            var createdUser =
                new DTO.User
                {
                    Email = "newemail@mail.com",
                    FirstName = "New First Name",
                    LastName = "New Last Name",
                    Login = UserMockFactory.Andrey.Login,
                    Active = true,
                    Roles =
                        new[]
                        {
                            dtoService.CreateRole(RoleMockFactory.Purchaser),
                            dtoService.CreateRole(RoleMockFactory.Distributor)
                        }
                };

            container.Remove<IPasswordGeneratorService>();
            var passwordGeneratorServiceMock = new Mock<IPasswordGeneratorService>();
            passwordGeneratorServiceMock
                .Setup(m => m.GenerateTemporaryPassword(createdUser.Login))
                .Returns(EncryptServiceMockFactory.NewPasswordData.Password);
            container.SetConstant<IPasswordGeneratorService, IPasswordGeneratorService>(passwordGeneratorServiceMock.Object);
            
            // Act
            // Assert
            ExceptionAssert.Throw<SecurityServiceException>(
                () => securityService.CreateUser(createdUser),
                "Пользователь с заданным логином уже существует.");
        }

        [TestMethod]
        public void CreateUser_Should_Create_ActionLog()
        {
            // Arrange
            var container = ContainerMockFactory.Create();
            var securityService = container.Get<ISecurityService>();

            securityService.LogIn(UserMockFactory.Jenya.Login, EncryptServiceMockFactory.JenyaPasswordData.Password);

            var dtoService = container.Get<IDtoService>();

            var createdUser =
                new DTO.User
                {
                    Email = "newemail@mail.com",
                    FirstName = "New First Name",
                    LastName = "New Last Name",
                    Login = "new_login",
                    Active = true,
                    Roles =
                        new[]
                        {
                            dtoService.CreateRole(RoleMockFactory.Purchaser),
                            dtoService.CreateRole(RoleMockFactory.Distributor)
                        }
                };

            container.Remove<IPasswordGeneratorService>();
            var passwordGeneratorServiceMock = new Mock<IPasswordGeneratorService>();
            passwordGeneratorServiceMock
                .Setup(m => m.GenerateTemporaryPassword(createdUser.Login))
                .Returns(EncryptServiceMockFactory.NewPasswordData.Password);
            container.SetConstant<IPasswordGeneratorService, IPasswordGeneratorService>(passwordGeneratorServiceMock.Object);

            // Act
            securityService.CreateUser(createdUser);

            // Assert
            var actionLogService = container.Get<IActionLogService>();

            var actionLog =
                actionLogService
                    .GetActionLogs(TimeServiceMockFactory.UtcNow, TimeServiceMockFactory.UtcNow, null)
                    .Single();

            var user = container.Get<IPersistentService>().GetEntityById<User>(createdUser.Id);

            Assert.AreEqual(string.Format("{0} создан.", user.GetDataString()), actionLog.Text);
            Assert.AreEqual(user.Id, actionLog.DocumentId);
            Assert.AreEqual(actionLogService.UserCreatedType, actionLog.ActionLogType);
            Assert.AreEqual(UserMockFactory.Jenya.GetFullName(), actionLog.CreateUser);
        }

        [TestMethod]
        public void GetUsers_Should_Return_All_Users_When_Filter_Is_Empty()
        {
            // Arrange
            var container = ContainerMockFactory.Create();
            var securityService = container.Get<ISecurityService>();

            securityService.LogIn(UserMockFactory.Jenya.Login, EncryptServiceMockFactory.JenyaPasswordData.Password);

            var dtoService = container.Get<IDtoService>();

            // Act
            var users = securityService.GetUsers(null);

            // Assert
            var expectedUsers =
                new[]
                {
                    dtoService.CreateUser(UserMockFactory.Andrey),
                    dtoService.CreateUser(UserMockFactory.Jenya),
                    dtoService.CreateUser(UserMockFactory.Olesya),
                    dtoService.CreateUser(UserMockFactory.Diana)
                };

            CollectionAssert.AreEqual(expectedUsers, users);
        }

        [TestMethod]
        public void GetUsers_Should_Return_Users_By_Filter()
        {
            // Arrange
            var container = ContainerMockFactory.Create();
            var securityService = container.Get<ISecurityService>();

            securityService.LogIn(UserMockFactory.Jenya.Login, EncryptServiceMockFactory.JenyaPasswordData.Password);

            var dtoService = container.Get<IDtoService>();
            
            // Act
            var users = securityService.GetUsers("hyu");

            // Assert
            var expectedUsers =
                new[]
                {
                    dtoService.CreateUser(UserMockFactory.Andrey),
                    dtoService.CreateUser(UserMockFactory.Jenya)
                };

            CollectionAssert.AreEqual(expectedUsers, users);
        }

        [TestMethod]
        public void GetUsers_Should_Throw_Exception_When_Current_User_Is_Not_Administrator_And_Not_Purchaser()
        {
            // Arrange
            var container = ContainerMockFactory.Create();
            var securityService = container.Get<ISecurityService>();

            securityService.LogIn(UserMockFactory.Olesya.Login, EncryptServiceMockFactory.OlesyaPasswordData.Password);

            // Act
            // Assert
            ExceptionAssert.Throw<InvalidOperationException>(
                () => securityService.GetUsers(null),
                "Only administrator and purchaser can get all users.");
        }

        [TestMethod]
        public void GetUsers_Should_Return_Only_Active_Distributors_When_Current_User_Is_Purchaser()
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

            // Act
            var users = securityService.GetUsers(null);

            // Assert
            var expectedUsers =
                new[]
                {
                    dtoService.CreateUser(UserMockFactory.Olesya),
                    dtoService.CreateUser(UserMockFactory.Diana)
                };

            CollectionAssert.AreEqual(expectedUsers, users);
        }

        [TestMethod]
        public void ResetPassword_Should_Reset_Password_For_User()
        {
            // Arrange
            var container = ContainerMockFactory.Create();
            var securityService = container.Get<ISecurityService>();

            securityService.LogIn(UserMockFactory.Jenya.Login, EncryptServiceMockFactory.JenyaPasswordData.Password);

            var dtoService = container.Get<IDtoService>();

            var changedUser = dtoService.CreateUser(UserMockFactory.Olesya);

            container.Remove<IPasswordGeneratorService>();
            var passwordGeneratorServiceMock = new Mock<IPasswordGeneratorService>();
            passwordGeneratorServiceMock
                .Setup(m => m.GenerateTemporaryPassword(changedUser.Login))
                .Returns(EncryptServiceMockFactory.NewPasswordData.Password);
            container.SetConstant<IPasswordGeneratorService, IPasswordGeneratorService>(passwordGeneratorServiceMock.Object);

            // Act
            securityService.ResetPassword(changedUser);

            // Assert
            securityService.LogOut();
            securityService.LogIn(changedUser.Login, EncryptServiceMockFactory.NewPasswordData.Password);
        }

        [TestMethod]
        public void ResetPassword_Should_Throw_Exception_When_Current_User_Is_Not_Administrator()
        {
            // Arrange
            var container = ContainerMockFactory.Create();
            var securityService = container.Get<ISecurityService>();

            securityService.LogIn(UserMockFactory.Diana.Login, EncryptServiceMockFactory.DianaPasswordData.Password);

            var dtoService = container.Get<IDtoService>();

            var changedUser = dtoService.CreateUser(UserMockFactory.Olesya);

            container.Remove<IPasswordGeneratorService>();
            var passwordGeneratorServiceMock = new Mock<IPasswordGeneratorService>();
            passwordGeneratorServiceMock
                .Setup(m => m.GenerateTemporaryPassword(changedUser.Login))
                .Returns(EncryptServiceMockFactory.NewPasswordData.Password);
            container.SetConstant<IPasswordGeneratorService, IPasswordGeneratorService>(passwordGeneratorServiceMock.Object);

            // Act
            // Assert
            ExceptionAssert.Throw<InvalidOperationException>(
                () => securityService.ResetPassword(changedUser),
                "Only administrator can reset password.");
        }

        [TestMethod]
        public void ResetPassword_Should_Throw_Exception_When_User_Is_Inactive()
        {
            // Arrange
            var container = ContainerMockFactory.Create();
            var securityService = container.Get<ISecurityService>();

            securityService.LogIn(UserMockFactory.Jenya.Login, EncryptServiceMockFactory.JenyaPasswordData.Password);

            var dtoService = container.Get<IDtoService>();

            var changedUser = dtoService.CreateUser(UserMockFactory.Andrey);

            container.Remove<IPasswordGeneratorService>();
            var passwordGeneratorServiceMock = new Mock<IPasswordGeneratorService>();
            passwordGeneratorServiceMock
                .Setup(m => m.GenerateTemporaryPassword(changedUser.Login))
                .Returns(EncryptServiceMockFactory.NewPasswordData.Password);
            container.SetConstant<IPasswordGeneratorService, IPasswordGeneratorService>(passwordGeneratorServiceMock.Object);

            // Act
            // Assert
            ExceptionAssert.Throw<SecurityServiceException>(
                () => securityService.ResetPassword(changedUser),
                "Пользователь отключен администратором.");
        }

        [TestMethod]
        public void ResetPassword_Should_Throw_Exception_When_CurrentUser_Tries_To_Reset_Password_To_Himself()
        {
            // Arrange
            var container = ContainerMockFactory.Create();
            var securityService = container.Get<ISecurityService>();

            securityService.LogIn(UserMockFactory.Jenya.Login, EncryptServiceMockFactory.JenyaPasswordData.Password);

            var dtoService = container.Get<IDtoService>();

            var changedUser = dtoService.CreateUser(UserMockFactory.Jenya);

            container.Remove<IPasswordGeneratorService>();
            var passwordGeneratorServiceMock = new Mock<IPasswordGeneratorService>();
            passwordGeneratorServiceMock
                .Setup(m => m.GenerateTemporaryPassword(changedUser.Login))
                .Returns(EncryptServiceMockFactory.NewPasswordData.Password);
            container.SetConstant<IPasswordGeneratorService, IPasswordGeneratorService>(passwordGeneratorServiceMock.Object);

            // Act
            // Assert
            ExceptionAssert.Throw<SecurityServiceException>(
                () => securityService.ResetPassword(changedUser),
                "Пользователь не может сбросить себе пароль.");
        }

        [TestMethod]
        public void ResetPassword_Should_Create_ActionLog()
        {
            // Arrange
            var container = ContainerMockFactory.Create();
            var securityService = container.Get<ISecurityService>();

            securityService.LogIn(UserMockFactory.Jenya.Login, EncryptServiceMockFactory.JenyaPasswordData.Password);

            var dtoService = container.Get<IDtoService>();

            var changedUser = dtoService.CreateUser(UserMockFactory.Olesya);

            container.Remove<IPasswordGeneratorService>();
            var passwordGeneratorServiceMock = new Mock<IPasswordGeneratorService>();
            passwordGeneratorServiceMock
                .Setup(m => m.GenerateTemporaryPassword(changedUser.Login))
                .Returns(EncryptServiceMockFactory.NewPasswordData.Password);
            container.SetConstant<IPasswordGeneratorService, IPasswordGeneratorService>(passwordGeneratorServiceMock.Object);

            // Act
            securityService.ResetPassword(changedUser);

            // Assert
            var actionLogService = container.Get<IActionLogService>();

            var actionLog =
                actionLogService
                    .GetActionLogs(TimeServiceMockFactory.UtcNow, TimeServiceMockFactory.UtcNow, null)
                    .Single();

            var user = container.Get<IPersistentService>().GetEntityById<User>(changedUser.Id);

            Assert.AreEqual(string.Format("Для {0} был сброшен пароль.", user.GetDataString()), actionLog.Text);
            Assert.AreEqual(user.Id, actionLog.DocumentId);
            Assert.AreEqual(actionLogService.PasswordWasResetedForUserType, actionLog.ActionLogType);
            Assert.AreEqual(UserMockFactory.Jenya.GetFullName(), actionLog.CreateUser);
        }
    }
}
