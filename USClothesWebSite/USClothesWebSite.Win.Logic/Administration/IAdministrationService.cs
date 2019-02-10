using USClothesWebSite.DTO;

namespace USClothesWebSite.Win.Logic.Administration
{
    public interface IAdministrationService
    {
        Settings Settings { get; }

        string UpdateSettings(Settings settings);
    }
}
