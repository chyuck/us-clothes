namespace USClothesWebSite.Common.Services.Encrypt
{
    public interface IEncryptService
    {
        string GeneratePasswordSalt();

        PasswordData EncryptPassword(string password);

        PasswordData EncryptPassword(string password, string passwordSalt);
    }
}
