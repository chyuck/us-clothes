using USClothesWebSite.BusinessLogic.Settings;
using USClothesWebSite.DTO;

namespace USClothesWebSite.Web.WebServices
{
    public class AdministrationAPI : BaseAPI, IAdministrationAPI
    {
        public Settings GetSettings()
        {
            return Container.Get<ISettingsService>().Settings;
        }

        public string UpdateSettings(Settings updatedSettings)
        {
            Container.Get<ISettingsService>().UpdateSettings(updatedSettings);

            return null;
        }
    }
}
