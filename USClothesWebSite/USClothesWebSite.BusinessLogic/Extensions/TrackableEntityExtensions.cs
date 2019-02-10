using DepIC;
using USClothesWebSite.BusinessLogic.Security;
using USClothesWebSite.Common.Helpers;
using USClothesWebSite.Common.Services.Time;
using USClothesWebSite.DataAccess;

namespace USClothesWebSite.BusinessLogic.Extensions
{
    internal static class TrackableEntityExtensions
    {
        public static void UpdateTrackFields(this ITrackableEntity trackableEntity, IReadOnlyContainer container)
        {
            CheckHelper.ArgumentNotNull(trackableEntity, "trackableEntity");
            CheckHelper.ArgumentNotNull(container, "container");

            var utcNow = container.Get<ITimeService>().UtcNow;

            var currentUserDto = container.Get<ISecurityService>().CurrentUser;
            CheckHelper.NotNull(currentUserDto, "currentUserDto");

            var currentUser = container.Get<IPersistentService>().GetEntityById<User>(currentUserDto.Id);
            
            if (trackableEntity.IsNew())
            {
                trackableEntity.CreateDate = utcNow;
                trackableEntity.CreatedBy = currentUser;
                trackableEntity.CreateUserId = currentUser.Id;
            }

            trackableEntity.ChangeDate = utcNow;
            trackableEntity.ChangedBy = currentUser;
            trackableEntity.ChangeUserId = currentUser.Id;
        }
    }
}
