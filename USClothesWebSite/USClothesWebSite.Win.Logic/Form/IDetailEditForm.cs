using System;
using USClothesWebSite.DTO;

namespace USClothesWebSite.Win.Logic.Form
{
    public interface IDetailEditForm<TMasterDto, out TDetailDto> : IDtoEditForm<TDetailDto>
        where TMasterDto : class, IMasterDto<TMasterDto, TDetailDto>, IDto, ICloneable, new()
        where TDetailDto : class, IDetailDto<TMasterDto, TDetailDto>, IDto, ICloneable, new()
    {
    }
}
