using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using USClothesWebSite.Common.Helpers;
using USClothesWebSite.Common.Services.LocalizedName;
using USClothesWebSite.DTO;
using USClothesWebSite.Win.Logic.Form;

namespace USClothesWebSite.Win.Forms.Base
{
    public abstract class BaseDtoMasterDetailForm<TMasterDto, TDetailDto> : BaseMasterDetailForm, IDtoListForm<TMasterDto>
        where TMasterDto : class, IMasterDto<TMasterDto, TDetailDto>, IDto, ICloneable, new()
        where TDetailDto : class, IDetailDto<TMasterDto, TDetailDto>, IDto, ICloneable, new()
    {
        #region Fields

        private TMasterDto[] _loadedMasterDtos;
        private TMasterDto _selectedMasterDto;
        private TDetailDto _selectedDetailDto;
        private readonly Func<TMasterDto, bool> _filter;

        #endregion


        #region Constructors

        protected BaseDtoMasterDetailForm() { }

        protected BaseDtoMasterDetailForm(ListFormMode mode, TMasterDto dto)
            : this(mode, dto, null)
        {
            _dto = dto;
        }

        protected BaseDtoMasterDetailForm(ListFormMode mode, TMasterDto dto, Func<TMasterDto, bool> filter)
            : base(mode)
        {
            _dto = dto;
            _filter = filter;
        }

        #endregion


        #region Properties

        public TMasterDto Dto
        {
            get
            {
                if (_dto == null)
                    return null;

                return (TMasterDto)_dto.Clone();
            }
        }
        private TMasterDto _dto;

        protected virtual string Caption
        {
            get
            {
                if (Mode == ListFormMode.Choose)
                    return string.Format("Выбор: {0}", IoCContainer.Get<ILocalizedNameService>().GetSingleLocalizedName<TMasterDto>());

                return IoCContainer.Get<ILocalizedNameService>().GetPluralLocalizedName<TMasterDto>();
            }
        }

        protected virtual DataGridViewColumn[] DtoMasterColumns
        {
            get { throw new NotImplementedBaseFormMemberException(); }
        }

        protected sealed override DataGridViewColumn[] MasterColumns
        {
            get
            {
                var idColumn = new DataGridViewTextBoxColumn { Name = "ID", Width = 30 };

                return
                    new DataGridViewColumn[] { idColumn }
                        .Concat(DtoMasterColumns)
                        .ToArray();
            }
        }

        protected virtual DataGridViewColumn[] DtoDetailColumns
        {
            get { throw new NotImplementedBaseFormMemberException(); }
        }

        protected sealed override DataGridViewColumn[] DetailColumns
        {
            get
            {
                var idColumn = new DataGridViewTextBoxColumn { Name = "ID", Width = 30 };

                return
                    new DataGridViewColumn[] { idColumn }
                        .Concat(DtoDetailColumns)
                        .ToArray();
            }
        }

        #endregion


        #region Methods

        #region Form

        protected override void OnLoad()
        {
            base.OnLoad();

            Text = Caption;

            var dto = Dto;
            if (dto != null)
            {
                _selectedMasterDto = dto;
                
                if (Mode == ListFormMode.List)
                    MasterFilterControl.FilterText = string.Format("ID:{0}", dto.Id);
            }

            MasterEditButton.Enabled = false;

            DetailCreateButton.Enabled = false;
            DetailEditButton.Enabled = false;
        }

        protected override void OnChoose()
        {
            _dto = GetSelectedMasterDto();
        }

        #endregion


        #region Master

        protected virtual TMasterDto[] LoadMasterDtosByFilter(string filter)
        {
            throw new NotImplementedBaseFormMemberException();
        }

        protected virtual object[] GetMasterDtoValues(TMasterDto dto)
        {
            throw new NotImplementedBaseFormMemberException();
        }

        protected sealed override object[][] OnMasterRefresh(string filter)
        {
            var dtos = LoadMasterDtosByFilter(filter);

            if (_filter != null)
                dtos = dtos.Where(_filter).ToArray();

            if (dtos.Length == 0)
                return new object[][] { };

            _loadedMasterDtos = dtos;

            return GetValuesByDtos(dtos, GetMasterDtoValues);
        }

        protected override void OnMasterAfterRefresh()
        {
            base.OnMasterAfterRefresh();

            if (_selectedMasterDto != null)
            {
                SelectDataGridViewRow(_selectedMasterDto, MasterDataGridView);
                _selectedMasterDto = null;
            }

            DetailRefreshButton.PerformClick();
        }

        protected override void OnMasterCreate()
        {
            var form = IoCContainer.Get<IFormService>().CreateDtoEditForm<TMasterDto>(EditFormMode.Create);

            if (form.ShowDialog(this) == DialogResult.OK)
            {
                _selectedMasterDto = form.Dto;
                MasterRefreshButton.PerformClick();
            }
        }

        protected override void OnMasterEdit()
        {
            var selectedDto = GetSelectedMasterDto();

            if (selectedDto == null)
                return;

            var form = IoCContainer.Get<IFormService>().CreateDtoEditForm<TMasterDto>(EditFormMode.Edit, selectedDto);

            if (form.ShowDialog(this) == DialogResult.OK)
            {
                _selectedMasterDto = selectedDto;
                MasterRefreshButton.PerformClick();
            }
        }

        protected override void OnMasterView()
        {
            var selectedDto = GetSelectedMasterDto();

            if (selectedDto == null)
                return;

            var form = IoCContainer.Get<IFormService>().CreateDtoEditForm<TMasterDto>(EditFormMode.View, selectedDto);

            form.ShowDialog(this);
        }

        #endregion


        #region Detail

        protected virtual TDetailDto[] LoadDetailDtosByFilter(string filter, TMasterDto masterDto)
        {
            throw new NotImplementedBaseFormMemberException();
        }

        protected virtual object[] GetDetailDtoValues(TDetailDto dto)
        {
            throw new NotImplementedBaseFormMemberException();
        }

        protected sealed override object[][] OnDetailRefresh(string filter)
        {
            var selectedMasterDto = GetSelectedMasterDto();
            if (selectedMasterDto == null)
                return new object[][] { };

            var dtos = LoadDetailDtosByFilter(filter, selectedMasterDto);

            if (dtos.Length == 0)
                return new object[][] { };

            return GetValuesByDtos(dtos, GetDetailDtoValues);
        }

        protected override void OnDetailAfterRefresh()
        {
            base.OnDetailAfterRefresh();

            if (_selectedDetailDto != null)
            {
                SelectDataGridViewRow(_selectedDetailDto, DetailDataGridView);
                _selectedDetailDto = null;
            }
        }

        protected override void OnDetailCreate()
        {
            var selectedMasterDto = GetSelectedMasterDto();

            if (selectedMasterDto == null)
                return;

            var formService = IoCContainer.Get<IFormService>();

            var form = formService.CreateDetailEditForm<TMasterDto, TDetailDto>(EditFormMode.Create, selectedMasterDto);

            if (form.ShowDialog(this) == DialogResult.OK)
            {
                _selectedDetailDto = form.Dto;
                _selectedMasterDto = form.Dto.MasterDto;

                MasterRefreshButton.PerformClick();
            }
        }

        protected override void OnDetailEdit()
        {
            var selectedDetailDto = GetSelectedDetailDto();

            if (selectedDetailDto == null)
                return;

            var formService = IoCContainer.Get<IFormService>();

            var form = formService.CreateDetailEditForm(EditFormMode.Edit, selectedDetailDto.MasterDto, selectedDetailDto);

            if (form.ShowDialog(this) == DialogResult.OK)
            {
                _selectedDetailDto = form.Dto;
                _selectedMasterDto = form.Dto.MasterDto;

                MasterRefreshButton.PerformClick();
            }
        }

        protected override void OnDetailView()
        {
            var selectedDetailDto = GetSelectedDetailDto();

            if (selectedDetailDto == null)
                return;

            var formService = IoCContainer.Get<IFormService>();

            var form = formService.CreateDetailEditForm(EditFormMode.View, selectedDetailDto.MasterDto, selectedDetailDto);

            form.ShowDialog(this);
        }

        #endregion

        private static void SelectDataGridViewRow<TDto>(TDto dto, DataGridView dataGridView)
            where TDto : class, IDto, ICloneable, new()
        {
            CheckHelper.ArgumentNotNull(dataGridView, "dataGridView");

            if (dto == null)
                return;

            foreach (DataGridViewRow row in dataGridView.Rows)
            {
                var id = (int)row.Cells["Id"].Value;

                if (id == dto.Id)
                {
                    row.Selected = true;
                    dataGridView.FirstDisplayedScrollingRowIndex = row.Index;
                    return;
                }
            }
        }

        protected TMasterDto GetSelectedMasterDto()
        {
            if (MasterDataGridView.SelectedRows.Count != 1)
                return null;

            if (_loadedMasterDtos == null || _loadedMasterDtos.Length == 0)
                return null;

            var id = (int)MasterDataGridView.SelectedRows[0].Cells["Id"].Value;

            return _loadedMasterDtos.SingleOrDefault(d => d.Id == id);
        }

        protected TDetailDto GetSelectedDetailDto()
        {
            if (DetailDataGridView.SelectedRows.Count != 1)
                return null;

            var selectedMasterDto = GetSelectedMasterDto();
            var detailDtos = selectedMasterDto.DetailDtos;
            CheckHelper.NotNull(detailDtos, "detailDtos");

            var id = (int)DetailDataGridView.SelectedRows[0].Cells["Id"].Value;

            return detailDtos.SingleOrDefault(d => d.Id == id);
        }

        private static object[][] GetValuesByDtos<TDto>(TDto[] dtos, Func<TDto, object[]> getValuesByDto)
            where TDto : class, IDto, ICloneable, new()
        {
            CheckHelper.ArgumentNotNull(dtos, "dtos");
            CheckHelper.ArgumentNotNull(getValuesByDto, "getValuesByDto");

            if (dtos.Length == 0)
                return new object[][] { };

            var rows = new List<object[]>(dtos.Length);

            foreach (var dto in dtos)
            {
                var dtoValues = getValuesByDto(dto);

                var values =
                    new object[] { dto.Id }
                        .Concat(dtoValues)
                        .ToArray();

                rows.Add(values);
            }

            return rows.ToArray();
        }

        protected override void OnMasterSelect()
        {
            var masterDto = GetSelectedMasterDto();

            MasterEditButton.Enabled = (masterDto != null);
            DetailCreateButton.Enabled = (masterDto != null);
        }

        protected override void OnDetailSelect()
        {
            var detailDto = GetSelectedDetailDto();

            DetailEditButton.Enabled = (detailDto != null);
        }

        #endregion
    }
}
