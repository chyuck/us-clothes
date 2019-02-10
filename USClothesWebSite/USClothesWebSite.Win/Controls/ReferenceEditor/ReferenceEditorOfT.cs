using System;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using USClothesWebSite.DTO;
using USClothesWebSite.Win.Logic.Async;
using USClothesWebSite.Win.Logic.Form;

namespace USClothesWebSite.Win.Controls.ReferenceEditor
{
    public abstract class ReferenceEditor<TDto> : ReferenceEditor
        where TDto : class, IDto, ICloneable, new()
    {
        #region Constructors

        protected ReferenceEditor()
        {
            AutoComboBoxRefresh = true;
        }

        #endregion


        #region Properties

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public TDto Dto
        {
            get
            {
                var dto = Value as TDto;

                if (dto == null)
                    return null;

                return (TDto)dto.Clone();
            }
            set
            {
                Value = value;
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Func<TDto, bool> Filter
        {
            get { return _filter; }
            set
            {
                if (_filter != value)
                {
                    _filter = value;

                    if (FilterChanged != null)
                        FilterChanged(this, EventArgs.Empty);
                }
            }
        }
        private Func<TDto, bool> _filter;

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public TDto[] Options
        {
            get
            {
                var values = Values;

                if (values == null)
                    return null;

                return values.Cast<TDto>().ToArray();
            }
            set
            {
                object[] values = null;

                if (value != null)
                {
                    var dtos =
                        Filter != null
                            ? value.Where(Filter).ToArray()
                            : value;

                    values = dtos.Cast<object>().ToArray();
                }

                Values = values;
            }
        }

        public bool AutoComboBoxRefresh { get; set; }

        #endregion


        #region Methods
        
        protected override void OnSelect()
        {
            var formService = IoCContainer.Get<IFormService>();

            var form =
                Filter == null
                    ? formService.CreateDtoListForm(ListFormMode.Choose, Dto)
                    : formService.CreateDtoListForm(ListFormMode.Choose, Dto, Filter);
            form.StartPosition = FormStartPosition.CenterParent;

            var dialogResult = form.ShowDialog(ParentForm);

            if (SelectDialogClosed != null)
            {
                var args = new DialogClosedEventArgs(dialogResult);
                SelectDialogClosed(this, args);
            }

            if (dialogResult == DialogResult.OK)
                Dto = form.Dto;
        }

        protected override void OnDispose()
        {
            base.OnDispose();

            SelectDialogClosed = null;
            FilterChanged = null;
        }

        protected override void OnParentChanged()
        {
            if (ParentForm != null)
                ParentForm.Load += ParentForm_Load;
        }

        protected virtual TDto[] GetDtos()
        {
            throw new NotImplementedBaseControlMemberException();
        }

        protected virtual void OnBeforeRefresh()
        {
            Enabled = false;
        }

        private async Task OnRefreshAsync()
        {
            if (IsComboBoxAppearance && AutoComboBoxRefresh)
            {
                try
                {
                    OnBeforeRefresh();

                    var asyncService = IoCContainer.Get<IAsyncService>();
                    Options = await asyncService.DoAsync(() => GetDtos());
                }
                finally
                {
                    OnAfterRefresh();
                }
            }
        }

        protected virtual void OnAfterRefresh()
        {
            Enabled = true;
        }

        #endregion


        #region Event Handlers

        private async void ParentForm_Load(object sender, EventArgs e)
        {
            SelectDialogClosed += ReferenceEditor_SelectDialogClosed;
            FilterChanged += ReferenceEditor_FilterChanged;

            await OnRefreshAsync();
        }

        private async void ReferenceEditor_SelectDialogClosed(object sender, DialogClosedEventArgs e)
        {
            await OnRefreshAsync();
        }

        private async void ReferenceEditor_FilterChanged(object sender, EventArgs e)
        {
            await OnRefreshAsync();
        }

        #endregion


        #region Events

        public event EventHandler<DialogClosedEventArgs> SelectDialogClosed;

        public event EventHandler FilterChanged;

        #endregion
    }
}
