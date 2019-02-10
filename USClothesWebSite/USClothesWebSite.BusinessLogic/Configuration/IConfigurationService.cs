namespace USClothesWebSite.BusinessLogic.Configuration
{
    internal interface IConfigurationService
    {
        string ImagesDirectoryName { get; }

        string LogsDirectoryName { get; }
    }
}
