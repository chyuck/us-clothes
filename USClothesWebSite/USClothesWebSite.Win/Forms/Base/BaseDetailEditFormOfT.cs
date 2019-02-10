using System;
using USClothesWebSite.DTO;
using USClothesWebSite.Win.Controls.ReferenceEditor;
using USClothesWebSite.Win.Logic.Form;

namespace USClothesWebSite.Win.Forms.Base
{
    public abstract class BaseDetailEditForm<TMasterDto, TDetailDto> : BaseDtoEditForm<TDetailDto>, IDetailEditForm<TMasterDto, TDetailDto> 
        where TMasterDto : class, IMasterDto<TMasterDto, TDetailDto>, IDto, ICloneable, new()
        where TDetailDto : class, IDetailDto<TMasterDto, TDetailDto>, IDto, ICloneable, new()
    {
        #region Constructors

        private readonly TMasterDto _initialMasterDto;

        protected BaseDetailEditForm() { }

        protected BaseDetailEditForm(EditFormMode mode, TDetailDto detailDto, TMasterDto masterDto)
            : base(mode, detailDto)
        {
            _initialMasterDto = masterDto;
        }

        #endregion


        #region Properties

        protected virtual ReferenceEditor<TMasterDto> MasterDtoEditor
        {
            get { throw new NotImplementedBaseFormMemberException(); }
        }

        #endregion


        #region Methods

        protected override void OnLoad()
        {
            base.OnLoad();

            if (Mode == EditFormMode.Create)
                MasterDtoEditor.Dto = _initialMasterDto;
        }

        #endregion
    }
}
