using System.Configuration;

namespace USClothesWebSite.BusinessLogic.Configuration
{
    internal class BusinessLogicConfigurationSection : ConfigurationSection
    {
        private const string SECTION_NAME = "USClothesWebSite.BusinessLogic";

        public static BusinessLogicConfigurationSection Current
        {
            get
            {
                return (BusinessLogicConfigurationSection)ConfigurationManager.GetSection(SECTION_NAME);
            }
        }

        [ConfigurationProperty(IMAGES_DIRECTORY_NAME_ELEM, IsRequired = true)]
        public string ImagesDirectoryName
        {
            get { return (string)this[IMAGES_DIRECTORY_NAME_ELEM]; }
            set { this[IMAGES_DIRECTORY_NAME_ELEM] = value; }
        }
        private const string IMAGES_DIRECTORY_NAME_ELEM = "imagesDirectoryName";

        [ConfigurationProperty(LOGS_DIRECTORY_NAME_ELEM, IsRequired = true)]
        public string LogsDirectoryName
        {
            get { return (string)this[LOGS_DIRECTORY_NAME_ELEM]; }
            set { this[LOGS_DIRECTORY_NAME_ELEM] = value; }
        }
        private const string LOGS_DIRECTORY_NAME_ELEM = "logsDirectoryName";
    }
}
