using System;
using USClothesWebSite.Common.Helpers;
using USClothesWebSite.Common.Services.LocalizedName;
using USClothesWebSite.DTO;
using USClothesWebSite.Win.Extensions;
using USClothesWebSite.Win.Logic.Form;

namespace USClothesWebSite.Win.Forms.Base
{
    public abstract class BaseDtoEditForm<TDto> : BaseDtoEditForm, IDtoEditForm<TDto>
        where TDto : class, IDto, ICloneable, new()
    {
        #region Constructors

        protected BaseDtoEditForm() { }

        protected BaseDtoEditForm(EditFormMode mode, TDto dto)
            : base(mode, dto)
        {
            _dto = dto;
        }

        #endregion


        #region Properties

        public TDto Dto
        {
            get
            {
                if (_dto == null)
                    return null;

                return (TDto)_dto.Clone();
            }
        }
        private TDto _dto;


        protected virtual string Caption
        {
            get
            {
                return
                    string.Format("{0}: {1}",
                        Mode.ToLocalizedName(),
                        IoCContainer.Get<ILocalizedNameService>().GetSingleLocalizedName<TDto>());
            }
        }
        
        #endregion
        

        #region Methods

        protected override void OnLoad()
        {
            base.OnLoad();

            Text = Caption;
        }

        protected virtual void SetDtoToControls(TDto dto)
        {
            throw new NotImplementedBaseFormMemberException();
        }

        protected virtual void SetControlsToDto(TDto dto)
        {
            throw new NotImplementedBaseFormMemberException();
        }

        protected virtual string OnInsert(TDto dto)
        {
            throw new NotImplementedBaseFormMemberException();
        }

        protected virtual string OnUpdate(TDto dto)
        {
            throw new NotImplementedBaseFormMemberException();
        }

        protected sealed override string OnSave()
        {
            CheckHelper.ArgumentWithinCondition(Mode != EditFormMode.View, "Mode != EditFormMode.View");
            
            var dto =
                Mode == EditFormMode.Create
                    ? new TDto()
                    : Dto;

            SetControlsToDto(dto);

            var errorMessage = 
                Mode == EditFormMode.Create
                    ? OnInsert(dto)
                    : OnUpdate(dto);

            if (string.IsNullOrEmpty(errorMessage))
                _dto = dto;

            return errorMessage;
        }

        protected sealed override void SetDataToControls()
        {
            base.SetDataToControls();

            if (_dto != null)
                SetDtoToControls(_dto);
        }

        #endregion
    }
}
