using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using USClothesWebSite.Common.Services.LocalizedName;
using USClothesWebSite.DTO;
using USClothesWebSite.Win.Logic.Form;

namespace USClothesWebSite.Win.Forms.Base
{
    public abstract class BaseDtoListForm<TDto> : BaseListForm, IDtoListForm<TDto> 
        where TDto : class, IDto, ICloneable, new()
    {
        #region Fields

        private TDto[] _loadedDtos;
        private TDto _selectedDto;
        private readonly Func<TDto, bool> _filter;

	    #endregion
            

        #region Constructors

        protected BaseDtoListForm() { }

        protected BaseDtoListForm(ListFormMode mode, TDto dto)
            : this(mode, dto, null)
        {
        }

        protected BaseDtoListForm(ListFormMode mode, TDto dto, Func<TDto, bool> filter)
            : base(mode)
        {
            _dto = dto;
            _filter = filter;
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
                if (Mode == ListFormMode.Choose)
                    return string.Format("Выбор: {0}", IoCContainer.Get<ILocalizedNameService>().GetSingleLocalizedName<TDto>());

                return IoCContainer.Get<ILocalizedNameService>().GetPluralLocalizedName<TDto>();
            }
        }

        protected virtual DataGridViewColumn[] DtoColumns
        {
            get { throw new NotImplementedBaseFormMemberException(); }
        }

        protected sealed override DataGridViewColumn[] Columns
        {
            get
            {
                var idColumn = new DataGridViewTextBoxColumn { Name = "ID", Width = 30 };

                return
                    new DataGridViewColumn[] { idColumn }
                        .Concat(DtoColumns)
                        .ToArray();
            }
        }

        #endregion


        #region Methods

        protected override void OnLoad()
        {
            base.OnLoad();

            Text = Caption;

            var dto = Dto;
            if (dto != null)
            {
                _selectedDto = dto;

                if (Mode == ListFormMode.List)
                    FilterControl.FilterText = string.Format("ID:{0}", dto.Id);
            }

            EditButton.Enabled = false;
        }

        protected virtual TDto[] LoadDtosByFilter(string filter)
        {
            throw new NotImplementedBaseFormMemberException();
        }

        protected virtual object[] GetDtoValues(TDto dto)
        {
            throw new NotImplementedBaseFormMemberException();
        }

        protected sealed override object[][] OnRefresh(string filter)
        {
            var dtos = LoadDtosByFilter(filter);

            if (_filter != null)
                dtos = dtos.Where(_filter).ToArray();

            if (dtos.Length == 0)
                return new object[][] { };

            var rows = new List<object[]>(dtos.Length);

            foreach (var dto in dtos)
            {
                var dtoValues = GetDtoValues(dto);

                var values =
                    new object[] { dto.Id }
                        .Concat(dtoValues)
                        .ToArray();

                rows.Add(values);
            }

            _loadedDtos = dtos;
            
            return rows.ToArray();
        }

        protected override void OnAfterRefresh()
        {
            base.OnAfterRefresh();

            if (_selectedDto != null)
            {
                SelectDataGridViewRow(_selectedDto);
                _selectedDto = null;
            }
        }

        protected override void OnCreate()
        {
            var form = IoCContainer.Get<IFormService>().CreateDtoEditForm<TDto>(EditFormMode.Create);

            if (form.ShowDialog(this) == DialogResult.OK)
                RefreshAndSelect(form.Dto);
        }

        protected override void OnEdit()
        {
            var selectedDto = GetSelectedDto();

            if (selectedDto == null)
                return;
            
            var form = IoCContainer.Get<IFormService>().CreateDtoEditForm<TDto>(EditFormMode.Edit, selectedDto);

            if (form.ShowDialog(this) == DialogResult.OK)
                RefreshAndSelect(selectedDto);
        }

        protected void RefreshAndSelect(TDto dto)
        {
            _selectedDto = dto;
            RefreshButton.PerformClick();
        }

        protected TDto GetSelectedDto()
        {
            if (DataGridView.SelectedRows.Count != 1)
                return null;

            if (_loadedDtos == null || _loadedDtos.Length == 0)
                return null;

            var id = (int) DataGridView.SelectedRows[0].Cells["Id"].Value;

            return _loadedDtos.SingleOrDefault(d => d.Id == id);
        }

        private void SelectDataGridViewRow(TDto dto)
        {
            if (dto == null)
                return;
            
            foreach (DataGridViewRow row in DataGridView.Rows)
            {
                var id = (int) row.Cells["Id"].Value;

                if (id == dto.Id)
                {
                    row.Selected = true;
                    DataGridView.FirstDisplayedScrollingRowIndex = row.Index;
                    return;
                }
            }
        }

        protected override void OnView()
        {
            var selectedDto = GetSelectedDto();

            if (selectedDto == null)
                return;

            var form = IoCContainer.Get<IFormService>().CreateDtoEditForm<TDto>(EditFormMode.View, selectedDto);

            form.ShowDialog(this);
        }

        protected override void OnChoose()
        {
            _dto = GetSelectedDto();
        }

        protected override void OnSelect()
        {
            var dto = GetSelectedDto();

            EditButton.Enabled = (dto != null);
        }

        #endregion
    }
}
