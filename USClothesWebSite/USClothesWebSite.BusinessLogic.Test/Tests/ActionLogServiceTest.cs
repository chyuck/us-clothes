using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using USClothesWebSite.BusinessLogic.ActionLog;
using USClothesWebSite.BusinessLogic.Dto;
using USClothesWebSite.BusinessLogic.Security;
using USClothesWebSite.BusinessLogic.Test.Mocks;
using USClothesWebSite.Test.Common;
using USClothesWebSite.BusinessLogic.Test.Extensions;

namespace USClothesWebSite.BusinessLogic.Test
{
    [TestClass]
    public class ActionLogServiceTest
    {
        [TestMethod]
        public void GetActionLogs_Should_Return_All_ActionLogs_Within_Date_Range()
        {
            // Arrange
            var container = ContainerMockFactory.Create();

            container.Get<ISecurityService>().LogIn(UserMockFactory.Jenya.Login, EncryptServiceMockFactory.JenyaPasswordData.Password);

            var dtoService = container.Get<IDtoService>();
            var actionLogService = container.Get<IActionLogService>();

            // Act
            var actionLogs = actionLogService.GetActionLogs(TimeServiceMockFactory.Date2, TimeServiceMockFactory.Date5, null);

            // Assert
            var expectedActionLogs =
                new[]
                {
                    dtoService.CreateActionLog(ActionLogMockFactory.JenyaCreated),
                    dtoService.CreateActionLog(ActionLogMockFactory.AndreyChanged),
                    dtoService.CreateActionLog(ActionLogMockFactory.JenyaChangedPassword)
                };

            CollectionAssert.AreEqual(expectedActionLogs, actionLogs);
        }

        [TestMethod]
        public void GetActionLogs_Should_Return_ActionLogs_By_Filter()
        {
            // Arrange
            var container = ContainerMockFactory.Create();

            container.Get<ISecurityService>().LogIn(UserMockFactory.Jenya.Login, EncryptServiceMockFactory.JenyaPasswordData.Password);

            var dtoService = container.Get<IDtoService>();
            var actionLogService = container.Get<IActionLogService>();

            // Act
            var actionLogs = actionLogService.GetActionLogs(TimeServiceMockFactory.Date1, TimeServiceMockFactory.Date5, "создан");

            // Assert
            var expectedActionLogs =
                new[]
                {
                    dtoService.CreateActionLog(ActionLogMockFactory.AndreyCreated),
                    dtoService.CreateActionLog(ActionLogMockFactory.JenyaCreated)
                };

            CollectionAssert.AreEqual(expectedActionLogs, actionLogs);
        }

        [TestMethod]
        public void GetActionLogs_Should_Throw_Exception_When_User_Is_Not_Logged_In()
        {
            // Arrange
            var container = ContainerMockFactory.Create();

            var actionLogService = container.Get<IActionLogService>();

            // Act
            // Assert
            ExceptionAssert.Throw<InvalidOperationException>(
               () => actionLogService.GetActionLogs(TimeServiceMockFactory.Date2, TimeServiceMockFactory.Date5, null),
               "User is not logged in.");
        }

        [TestMethod]
        public void GetActionLogs_Should_Throw_Exception_When_User_Is_Not_Administrator()
        {
            // Arrange
            var container = ContainerMockFactory.Create();

            container.Get<ISecurityService>().LogIn(UserMockFactory.Diana.Login, EncryptServiceMockFactory.DianaPasswordData.Password);

            var actionLogService = container.Get<IActionLogService>();

            // Act
            // Assert
            ExceptionAssert.Throw<InvalidOperationException>(
               () => actionLogService.GetActionLogs(TimeServiceMockFactory.Date2, TimeServiceMockFactory.Date5, null),
               "User is not administrator.");
        }
        
        [TestMethod]
        public void CreateActionLog_Should_Create_Action_Log()
        {
            // Arrange
            var container = ContainerMockFactory.Create();

            var securityService = container.Get<ISecurityService>();

            securityService.LogInGuest();

            var actionLogService = container.Get<IActionLogService>();

            var createdActionLog =
                new DTO.ActionLog
                {
                    Text = "User Diana is changed",
                    DocumentId = UserMockFactory.Diana.Id,
                    ActionLogType = actionLogService.UserChangedType
                };

            // Act
            actionLogService.CreateActionLog(createdActionLog);

            // Assert
            securityService.LogOut();
            container.Get<ISecurityService>().LogIn(UserMockFactory.Jenya.Login, EncryptServiceMockFactory.JenyaPasswordData.Password);

            var actionLog = 
                actionLogService
                    .GetActionLogs(TimeServiceMockFactory.UtcNow, TimeServiceMockFactory.UtcNow, null)
                    .Single();

            Assert.AreEqual(createdActionLog, actionLog);
        }

        [TestMethod]
        public void CreateActionLog_Should_Throw_Exception_When_User_Is_Not_Logged_In()
        {
            // Arrange
            var container = ContainerMockFactory.Create();

            var actionLogService = container.Get<IActionLogService>();
            
            var createdActionLog =
                new DTO.ActionLog
                {
                    Text = "User Diana is changed",
                    DocumentId = UserMockFactory.Diana.Id,
                    ActionLogType = actionLogService.UserChangedType
                };

            // Act
            // Assert
            ExceptionAssert.Throw<InvalidOperationException>(
               () => actionLogService.CreateActionLog(createdActionLog),
               "User is not logged in.");
        }
    }
}
