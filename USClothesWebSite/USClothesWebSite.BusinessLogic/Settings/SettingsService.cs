using System.Linq;
using DepIC;
using DepIC.Attributes;
using USClothesWebSite.BusinessLogic.Dto;
using USClothesWebSite.BusinessLogic.Extensions;
using USClothesWebSite.BusinessLogic.Security;
using USClothesWebSite.Common.Helpers;
using USClothesWebSite.Common.Services;
using USClothesWebSite.Common.Services.Validate;
using USClothesWebSite.DataAccess;

namespace USClothesWebSite.BusinessLogic.Settings
{
    internal class SettingsService : BaseService, ISettingsService
    {
        #region Constructors

        [Inject]
        public SettingsService(IReadOnlyContainer container)
            : base(container)
        {
        }

        #endregion


        #region Properties

        private ISecurityService SecurityService
        {
            get { return Container.Get<ISecurityService>(); }
        }

        #endregion


        #region ISettingsService

        public DTO.Settings Settings
        {
            get
            {
                CheckHelper.WithinCondition(SecurityService.IsLoggedIn, "User is not logged in.");

                return
                    CacheHelper.Get(
                        ref _settings,
                        () =>
                        {
                            var settings = 
                                Container
                                    .Get<IPersistentService>()
                                    .GetEntitySet<DataAccess.Settings>()
                                    .SingleOrDefault();
                            CheckHelper.NotNull(settings, "Cannot find settings.");

                            return Container.Get<IDtoService>().CreateSettings(settings);
                        });
            }
        }
        private DTO.Settings _settings;

        public void UpdateSettings(DTO.Settings updatedSettings)
        {
            CheckHelper.ArgumentNotNull(updatedSettings, "updatedSettings");
            CheckHelper.ArgumentWithinCondition(!updatedSettings.IsNew(), "!updatedSettings.IsNew()");
            Container.Get<IValidateService>().CheckIsValid(updatedSettings);

            CheckHelper.WithinCondition(SecurityService.IsLoggedIn, "User is not logged in.");
            CheckHelper.WithinCondition(SecurityService.IsCurrentUserAdministrator, "Only administrator can update settings.");

            var persistentService = Container.Get<IPersistentService>();

            var settings = 
                Container
                    .Get<IPersistentService>()
                    .GetEntitySet<DataAccess.Settings>()
                    .SingleOrDefault();
            CheckHelper.ArgumentNotNull(settings, "Cannot find settings.");
            CheckHelper.WithinCondition(settings.Id == updatedSettings.Id, "settings.Id == updatedSettings.Id");

            settings.RublesPerDollar = updatedSettings.RublesPerDollar;

            settings.UpdateTrackFields(Container);

            persistentService.SaveChanges();

            _settings = null;
        }
        
        #endregion
    }
}
