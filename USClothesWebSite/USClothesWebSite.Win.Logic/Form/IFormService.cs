using System;
using USClothesWebSite.DTO;

namespace USClothesWebSite.Win.Logic.Form
{
    public interface IFormService
    {
        void RegisterEditForm<TDto, TForm>()
            where TDto : class, IDto, ICloneable, new()
            where TForm : System.Windows.Forms.Form, IDtoEditForm<TDto>;

        void RegisterListForm<TDto, TForm>()
            where TDto : class, IDto, ICloneable, new()
            where TForm : System.Windows.Forms.Form, IDtoListForm<TDto>;

        IDtoEditForm<TDto> CreateDtoEditForm<TDto>(EditFormMode mode, TDto dto = null)
            where TDto : class, IDto, ICloneable, new();

        IDetailEditForm<TMasterDto, TDetailDto> CreateDetailEditForm<TMasterDto, TDetailDto>(
            EditFormMode mode, TMasterDto masterDto, TDetailDto detailDto = null)
            where TMasterDto : class, IMasterDto<TMasterDto, TDetailDto>, IDto, ICloneable, new()
            where TDetailDto : class, IDetailDto<TMasterDto, TDetailDto>, IDto, ICloneable, new();

        IDtoListForm<TDto> CreateDtoListForm<TDto>(ListFormMode mode, TDto dto = null, Func<TDto, bool> filter = null)
            where TDto : class, IDto, ICloneable, new();
    }
}
