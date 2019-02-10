using System.Security.Cryptography;
using System.Text;
using USClothesWebSite.Common.Extensions;
using USClothesWebSite.Common.Helpers;

namespace USClothesWebSite.Common.Services.Encrypt
{
    internal class EncryptService : IEncryptService
    {
        public string GeneratePasswordSalt()
        {
            var buffer = new byte[16];

            using (var rng = new RNGCryptoServiceProvider())
                rng.GetBytes(buffer);

            var sb = new StringBuilder(32);
            buffer.ForEach(hashByte => sb.AppendFormat("{0:X2}", hashByte));

            return sb.ToString();
        }
        
        public PasswordData EncryptPassword(string password)
        {
            CheckHelper.ArgumentNotNullAndNotEmpty(password, "password");
            
            var passwordSalt = GeneratePasswordSalt();

            return EncryptPassword(password, passwordSalt);
        }
        
        public PasswordData EncryptPassword(string password, string passwordSalt)
        {
            CheckHelper.ArgumentNotNullAndNotEmpty(password, "password");
            CheckHelper.ArgumentNotNullAndNotEmpty(passwordSalt, "passwordSalt");

            var bytes = Encoding.Unicode.GetBytes(password + passwordSalt);

            byte[] hashBytes;

            using (var md5 = new MD5CryptoServiceProvider())
                hashBytes = md5.ComputeHash(bytes);

            var sb = new StringBuilder(32);
            hashBytes.ForEach(hashByte => sb.AppendFormat("{0:X2}", hashByte));

            return
                new PasswordData
                {
                    Password = password,
                    PasswordSalt = passwordSalt,
                    PasswordHash = sb.ToString()
                };
        }
    }
}
