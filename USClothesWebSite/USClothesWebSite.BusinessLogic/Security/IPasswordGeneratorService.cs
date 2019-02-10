namespace USClothesWebSite.BusinessLogic.Security
{
    internal interface IPasswordGeneratorService
    {
        string GenerateTemporaryPassword(string login);
    }
}
