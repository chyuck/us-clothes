using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using USClothesWebSite.Common.Services.Time;

namespace USClothesWebSite.Common.Test
{
    [TestClass]
    public class TimeServiceTest
    {
        private static void AssertTimeApproximately(DateTime expected, DateTime actual)
        {
            var areEqual =
                expected.Year == actual.Year &&
                expected.Month == actual.Month &&
                expected.Day == actual.Day &&
                expected.Hour == actual.Hour &&
                expected.Minute == actual.Minute &&
                expected.Second >= actual.Second &&
                expected.Second - 1 <= actual.Second;

            if (!areEqual)
                throw new AssertFailedException(
                    string.Format("Expected: {1}{0}Actual: {2}", Environment.NewLine, expected, actual));
        }

        [TestMethod]
        public void UtcNow_Should_Return_Utc_Time()
        {
            // Arrange
            var timeService = new TimeService();
            
            // Act
            var actual = timeService.UtcNow;

            // Assert
            AssertTimeApproximately(DateTime.UtcNow, actual);
        }

        [TestMethod]
        public void Now_Should_Return_Local_Time()
        {
            // Arrange
            var timeService = new TimeService();

            // Act
            var actual = timeService.LocalNow;

            // Assert
            AssertTimeApproximately(DateTime.Now, actual);
        }

        [TestMethod]
        public void ToUtc_Should_Convert_Local_Time_To_Utc()
        {
            // Arrange
            var timeService = new TimeService();
            var localTime = DateTime.Now.AddMinutes(-9).AddHours(-1);

            // Act
            var actual = timeService.ToUtc(localTime);

            // Assert
            AssertTimeApproximately(DateTime.UtcNow.AddMinutes(-9).AddHours(-1), actual);
        }

        [TestMethod]
        public void ToLocal_Should_Convert_Utc_Time_To_Local()
        {
            // Arrange
            var timeService = new TimeService();
            var utcTime = DateTime.UtcNow.AddMinutes(-9).AddHours(-1);

            // Act
            var actual = timeService.ToLocal(utcTime);

            // Assert
            AssertTimeApproximately(DateTime.Now.AddMinutes(-9).AddHours(-1), actual);
        }

        [TestMethod]
        public void ToUtc_Should_Convert_LocalNow_Time_To_UtcNow()
        {
            // Arrange
            var timeService = new TimeService();

            // Act
            var actual = timeService.ToUtc(DateTime.Now);

            // Assert
            AssertTimeApproximately(DateTime.UtcNow, actual);
        }

        [TestMethod]
        public void ToLocal_Should_Convert_UtcNow_Time_To_LocalNow()
        {
            // Arrange
            var timeService = new TimeService();

            // Act
            var actual = timeService.ToLocal(DateTime.UtcNow);

            // Assert
            AssertTimeApproximately(DateTime.Now, actual);
        }

        [TestMethod]
        public void ToUtc_Should_Convert_Local_Time_To_Utc_When_Kind_Unspecified()
        {
            // Arrange
            var timeService = new TimeService();
            var local = new DateTime(2013, 1, 21, 12, 23, 34, 1, DateTimeKind.Unspecified);

            // Act
            var actual = timeService.ToUtc(local);

            // Assert
            AssertTimeApproximately(new DateTime(2013, 1, 21, 12, 23, 34, 1, DateTimeKind.Local).ToUniversalTime(), actual);
        }

        [TestMethod]
        public void ToLocal_Should_Convert_Utc_Time_To_Local_When_Kind_Unspecified()
        {
            // Arrange
            var timeService = new TimeService();
            var utc = new DateTime(2013, 1, 21, 12, 23, 34, 1, DateTimeKind.Unspecified);

            // Act
            var actual = timeService.ToLocal(utc);

            // Assert
            AssertTimeApproximately(new DateTime(2013, 1, 21, 12, 23, 34, 1, DateTimeKind.Utc).ToLocalTime(), actual);
        }
    }
}
