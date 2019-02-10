using Moq;
using USClothesWebSite.Common.Helpers;
using USClothesWebSite.Common.Services.Encrypt;

namespace USClothesWebSite.BusinessLogic.Test.Mocks
{
    public static class EncryptServiceMockFactory
    {
        public static PasswordData AndreyPasswordData
        {
            get
            {
                return CacheHelper.Get(ref _andreyPasswordData,
                    () =>
                        new PasswordData
                        {
                            Password = "andrey_password",
                            PasswordSalt = "B0987BCD789F45380386458834567891",
                            PasswordHash = "A0987BCD789345380383458834567890",
                        });
            }
        }
        private static PasswordData _andreyPasswordData;

        public static PasswordData JenyaPasswordData
        {
            get
            {
                return CacheHelper.Get(ref _jenyaPasswordData,
                    () =>
                        new PasswordData
                        {
                            Password = "jenya_password",
                            PasswordSalt = "C0987BCD789F44380384354ABBB67891",
                            PasswordHash = "D0987BCD789345380383458FFFF67890",
                        });
            }
        }
        private static PasswordData _jenyaPasswordData;

        public static PasswordData OlesyaPasswordData
        {
            get
            {
                return CacheHelper.Get(ref _olesyaPasswordData,
                    () =>
                        new PasswordData
                        {
                            Password = "olesya_password",
                            PasswordSalt = "F0987BCD789F44345646554ABBB67891",
                            PasswordHash = "B0987BCD780005380383458FF4567890",
                        });
            }
        }
        private static PasswordData _olesyaPasswordData;

        public static PasswordData DianaPasswordData
        {
            get
            {
                return CacheHelper.Get(ref _dianaPasswordData,
                    () =>
                        new PasswordData
                        {
                            Password = "diana_password",
                            PasswordSalt = "A0987BCD789F443456423456BBB67891",
                            PasswordHash = "50987BCD7800F0987683458FF4567890",
                        });
            }
        }
        private static PasswordData _dianaPasswordData;

        public static PasswordData WrongPasswordData
        {
            get
            {
                return CacheHelper.Get(ref _wrongPasswordData,
                    () =>
                        new PasswordData
                        {
                            Password = "wrong_password",
                            PasswordSalt = "B0987BCD789F45789986458834567891",
                            PasswordHash = "A0987BCD789345380383458567887890",
                        });
            }
        }
        private static PasswordData _wrongPasswordData;

        public static PasswordData NewPasswordData
        {
            get
            {
                return CacheHelper.Get(ref _newPasswordData,
                    () =>
                        new PasswordData
                        {
                            Password = "new_password",
                            PasswordSalt = "F0987BCD789F45559986458834567891",
                            PasswordHash = "F0987BCD789345380345FFF567887890",
                        });
            }
        }
        private static PasswordData _newPasswordData;

        public static Mock<IEncryptService> Create()
        {
            var encryptServiceMock = new Mock<IEncryptService>(MockBehavior.Strict);

            encryptServiceMock.Setup(m => m.EncryptPassword(AndreyPasswordData.Password)).Returns(AndreyPasswordData);
            encryptServiceMock.Setup(m => m.EncryptPassword(AndreyPasswordData.Password, AndreyPasswordData.PasswordSalt)).Returns(AndreyPasswordData);

            encryptServiceMock.Setup(m => m.EncryptPassword(JenyaPasswordData.Password)).Returns(JenyaPasswordData);
            encryptServiceMock.Setup(m => m.EncryptPassword(JenyaPasswordData.Password, JenyaPasswordData.PasswordSalt)).Returns(JenyaPasswordData);

            encryptServiceMock.Setup(m => m.EncryptPassword(OlesyaPasswordData.Password)).Returns(OlesyaPasswordData);
            encryptServiceMock.Setup(m => m.EncryptPassword(OlesyaPasswordData.Password, OlesyaPasswordData.PasswordSalt)).Returns(OlesyaPasswordData);

            encryptServiceMock.Setup(m => m.EncryptPassword(DianaPasswordData.Password)).Returns(DianaPasswordData);
            encryptServiceMock.Setup(m => m.EncryptPassword(DianaPasswordData.Password, DianaPasswordData.PasswordSalt)).Returns(DianaPasswordData);

            encryptServiceMock.Setup(m => m.EncryptPassword(WrongPasswordData.Password)).Returns(WrongPasswordData);
            encryptServiceMock.Setup(m => m.EncryptPassword(WrongPasswordData.Password, It.IsAny<string>())).Returns(WrongPasswordData);

            encryptServiceMock.Setup(m => m.EncryptPassword(NewPasswordData.Password)).Returns(NewPasswordData);
            encryptServiceMock.Setup(m => m.EncryptPassword(NewPasswordData.Password, NewPasswordData.PasswordSalt)).Returns(NewPasswordData);

            return encryptServiceMock;
        }
    }
}
