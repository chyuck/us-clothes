using System;
using System.Collections.Generic;
using USClothesWebSite.Common.Helpers;
using USClothesWebSite.DTO;

namespace USClothesWebSite.Win.Logic.Form
{
    internal class FormService : IFormService
    {
        private readonly IDictionary<Type, Type> _editForms = 
            new Dictionary<Type, Type>();

        private readonly IDictionary<Type, Type> _listForms =
            new Dictionary<Type, Type>();

        public void RegisterEditForm<TDto, TForm>()
            where TDto : class, IDto, ICloneable, new()
            where TForm : System.Windows.Forms.Form, IDtoEditForm<TDto>
        {
            var dtoType = typeof (TDto);

            if (_editForms.ContainsKey(dtoType))
                throw new FormServiceException("DTO {0} has already been registered to create edit form.", dtoType);

            _editForms.Add(dtoType, typeof(TForm));
        }

        public void RegisterListForm<TDto, TForm>()
            where TDto : class, IDto, ICloneable, new()
            where TForm : System.Windows.Forms.Form, IDtoListForm<TDto>
        {
            var dtoType = typeof(TDto);

            if (_listForms.ContainsKey(dtoType))
                throw new FormServiceException("DTO {0} has already been registered to create list form.", dtoType);

            _listForms.Add(dtoType, typeof(TForm));
        }

        private Type GetEditFormType<TDto>()
            where TDto : class, IDto, ICloneable, new()
        {
            var dtoType = typeof(TDto);

            if (!_editForms.ContainsKey(dtoType))
                throw new FormServiceException("DTO {0} is not registered to create edit form.", dtoType);

            return _editForms[dtoType];
        }

        public IDtoEditForm<TDto> CreateDtoEditForm<TDto>(EditFormMode mode, TDto dto = null)
            where TDto : class, IDto, ICloneable, new()
        {
            var formType = GetEditFormType<TDto>();

            return (IDtoEditForm<TDto>) Activator.CreateInstance(formType, mode, dto);
        }
        
        public IDetailEditForm<TMasterDto, TDetailDto> CreateDetailEditForm<TMasterDto, TDetailDto>(
            EditFormMode mode, TMasterDto masterDto, TDetailDto detailDto = null)
            where TMasterDto : class, IMasterDto<TMasterDto, TDetailDto>, IDto, ICloneable, new()
            where TDetailDto : class, IDetailDto<TMasterDto, TDetailDto>, IDto, ICloneable, new()
        {
            CheckHelper.ArgumentNotNull(masterDto, "masterDto");

            var formType = GetEditFormType<TDetailDto>();

            return (IDetailEditForm<TMasterDto, TDetailDto>)Activator.CreateInstance(formType, mode, detailDto, masterDto);
        }

        public IDtoListForm<TDto> CreateDtoListForm<TDto>(ListFormMode mode, TDto dto = null, Func<TDto, bool> filter = null)
            where TDto : class, IDto, ICloneable, new()
        {
            var dtoType = typeof(TDto);

            if (!_listForms.ContainsKey(dtoType))
                throw new FormServiceException("DTO {0} is not registered to create list form.", dtoType);

            var formType = _listForms[dtoType];

            if (filter != null)
                return (IDtoListForm<TDto>) Activator.CreateInstance(formType, mode, dto, filter);

            return (IDtoListForm<TDto>) Activator.CreateInstance(formType, mode, dto);
        }
    }
}
