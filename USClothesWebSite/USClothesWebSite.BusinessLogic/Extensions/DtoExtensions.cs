using USClothesWebSite.Common.Helpers;
using USClothesWebSite.DTO;

namespace USClothesWebSite.BusinessLogic.Extensions
{
    internal static class DtoExtensions
    {
        public static bool IsNew(this IDto dto)
        {
            CheckHelper.ArgumentNotNull(dto, "dto");

            return dto.Id <= 0;
        }
    }
}
