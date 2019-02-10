using USClothesWebSite.Common.Helpers;

namespace USClothesWebSite.BusinessLogic.Configuration
{
    internal class ConfigurationService : IConfigurationService
    {
        private static BusinessLogicConfigurationSection Configuration
        {
            get
            {
                var configuration = BusinessLogicConfigurationSection.Current;
                CheckHelper.NotNull(configuration, "configuration");

                return configuration;
            }
        }

        public string ImagesDirectoryName
        {
            get { return Configuration.ImagesDirectoryName; }
        }
        
        public string LogsDirectoryName
        {
            get { return Configuration.LogsDirectoryName; }
        }
    }
}
