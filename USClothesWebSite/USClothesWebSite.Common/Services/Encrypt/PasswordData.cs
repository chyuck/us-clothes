namespace USClothesWebSite.Common.Services.Encrypt
{
    public class PasswordData
    {
        public string Password { get; set; }
        public string PasswordHash { get; set; }
        public string PasswordSalt { get; set; }
    }
}
