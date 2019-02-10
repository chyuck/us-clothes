using DepIC;
using DepIC.Attributes;
using USClothesWebSite.Common.Helpers;
using USClothesWebSite.Common.Services;
using USClothesWebSite.Common.Services.Validate;
using USClothesWebSite.DTO;
using USClothesWebSite.Win.Logic.AdministrationAPI;
using USClothesWebSite.Win.Logic.Helpers;
using USClothesWebSite.Win.Logic.Security;

namespace USClothesWebSite.Win.Logic.Administration
{
    internal class AdministrationService : BaseService, IAdministrationService
    {
        [Inject]
        public AdministrationService(IReadOnlyContainer container) 
            : base(container)
        {
        }

        private ISecurityService SecurityService
        {
            get { return Container.Get<ISecurityService>(); }
        }

        public Settings Settings
        {
            get
            {
                CheckHelper.WithinCondition(SecurityService.IsLoggedIn, "SecurityService.IsLoggedIn");

                if (_settings == null)
                {
                    _settings = APIClientHelper<AdministrationAPIClient>.Call(c => c.GetSettings());
                    CheckHelper.NotNull(_settings, "_settings");
                }

                return (Settings)_settings.Clone();
            }
        }
        private Settings _settings;

        public string UpdateSettings(Settings settings)
        {
            CheckHelper.ArgumentNotNull(settings, "settings");
            CheckHelper.WithinCondition(SecurityService.IsLoggedIn, "SecurityService.IsLoggedIn");

            var errors = IoC.Container.Get<IValidateService>().Validate(settings);
            if (errors != null)
                return errors.ToErrorMessage();

            var errorMessage = APIClientHelper<AdministrationAPIClient>.Call(c => c.UpdateSettings(settings));
            
            if (errorMessage == null)
                _settings = null;

            return errorMessage;
        }
    }
}
