namespace USClothesWebSite.BusinessLogic.Settings
{
    public interface ISettingsService
    {
        DTO.Settings Settings { get; }

        void UpdateSettings(DTO.Settings updatedSettings);
    }
}
