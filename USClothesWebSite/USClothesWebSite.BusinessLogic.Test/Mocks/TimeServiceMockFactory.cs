using System;
using Moq;
using USClothesWebSite.Common.Services.Time;

namespace USClothesWebSite.BusinessLogic.Test.Mocks
{
    public static class TimeServiceMockFactory
    {
        public static DateTime UtcNow 
        {
            get { return _utcNow; }
        }
        private static readonly DateTime _utcNow = new DateTime(2013, 3, 8);

        public static DateTime Date1
        {
            get { return _date1; }
        }
        private static readonly DateTime _date1 = new DateTime(2013, 2, 3);

        public static DateTime Date2
        {
            get { return _date2; }
        }
        private static readonly DateTime _date2 = new DateTime(2013, 2, 7);

        public static DateTime Date3
        {
            get { return _date3; }
        }
        private static readonly DateTime _date3 = new DateTime(2013, 2, 8);

        public static DateTime Date4
        {
            get { return _date4; }
        }
        private static readonly DateTime _date4 = new DateTime(2013, 2, 14);
        
        public static DateTime Date5
        {
            get { return _date5; }
        }
        private static readonly DateTime _date5 = new DateTime(2013, 2, 23);

        public static Mock<ITimeService> Create()
        {
            var timeServiceMock = new Mock<ITimeService>(MockBehavior.Strict);

            timeServiceMock.Setup(m => m.UtcNow).Returns(UtcNow);

            return timeServiceMock;
        }
    }
}
