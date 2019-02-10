using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using DepIC;
using USClothesWebSite.Common.Extensions;
using USClothesWebSite.Win.Logic;
using USClothesWebSite.Win.Logic.Async;
using USClothesWebSite.Win.Logic.Form;

namespace USClothesWebSite.Win.Forms.Base
{
    public partial class BaseListForm : Form
    {
        #region Constructors

        public BaseListForm()
        {
            InitializeComponent();
        }

        public BaseListForm(ListFormMode mode)
            : this()
        {
            Mode = mode;
        }

        #endregion


        #region Properties

        public ListFormMode Mode { get; private set; }

        protected IReadOnlyContainer IoCContainer
        {
            get { return IoC.Container; }
        }

        protected virtual DataGridViewColumn[] Columns
        {
            get { throw new NotImplementedBaseFormMemberException(); }
        }

        #endregion


        #region Methods
        
        protected virtual void OnLoad()
        {
            if (Mode == ListFormMode.List)
            {
                WindowState = FormWindowState.Maximized;
                ActionButtonPanel.Visible = false;
                ChooseButton.Enabled = ChooseButton.Visible = false;
                CloseButton.Enabled = CloseButton.Visible = false;
                DataGridView.Dock = DockStyle.Fill;
            }
            else if (Mode == ListFormMode.Choose)
            {
                MinimumSize = Size;
                MinimizeBox = false;
                MaximizeBox = false;
            }

            Columns.ForEach(c => DataGridView.Columns.Add(c));
        }

        protected async virtual Task OnLoadAsync()
        {
            OnLoad();
            await OnRefreshAsync();
        }

        protected virtual void OnClose()
        {
            Owner = null;
            MdiParent = null;
        }
        
        protected virtual void OnBeforeRefresh()
        {
            RefreshButton.Enabled = false;
        }

        protected virtual object[][] OnRefresh(string filter)
        {
            return new object[][] { };
        }

        protected virtual void OnAfterRefresh()
        {
            RefreshButton.Enabled = true;
        }

        protected async virtual Task OnRefreshAsync()
        {
            try
            {
                OnBeforeRefresh();

                DataGridView.Rows.Clear();

                var filter = FilterControl.FilterText;

                var asyncService = IoCContainer.Get<IAsyncService>();
                var rows = await asyncService.DoAsync(() => OnRefresh(filter));

                foreach (var values in rows)
                {
                    var row = new DataGridViewRow { Height = 17 };

                    row.CreateCells(DataGridView, values);

                    DataGridView.Rows.Add(row);
                }
            }
            finally
            {
                OnAfterRefresh();
            }
        }

        protected virtual void OnCreate()
        {
            throw new NotImplementedBaseFormMemberException();
        }

        protected virtual void OnEdit()
        {
            throw new NotImplementedBaseFormMemberException();
        }

        protected virtual void OnRowDoubleClick(int rowIndex)
        {
            if (Mode == ListFormMode.Choose)
            {
                OnChoose();
                Close();
                DialogResult = DialogResult.OK;
            }
            else
                OnView();
        }

        protected virtual void OnView()
        {
            throw new NotImplementedBaseFormMemberException();
        }

        protected virtual void OnChoose()
        {
            throw new NotImplementedBaseFormMemberException();
        }

        protected virtual void OnSelect()
        {
        }

        #endregion


        #region Event Handlers
        
        private async void BaseListForm_Load(object sender, EventArgs e)
        {
            if (!DesignMode)
                await OnLoadAsync();
        }

        private void CreateButton_Click(object sender, EventArgs e)
        {
            OnCreate();
        }

        private void EditButton_Click(object sender, EventArgs e)
        {
            OnEdit();
        }

        private async void RefreshButton_Click(object sender, EventArgs e)
        {
            await OnRefreshAsync();
        }

        private void ChooseButton_Click(object sender, EventArgs e)
        {
            OnChoose();
        }

        private void BaseListForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            OnClose();
        }

        private void DataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            OnRowDoubleClick(e.RowIndex);
        }

        private void DataGridView_SelectionChanged(object sender, EventArgs e)
        {
            OnSelect();
        }

        #endregion
    }
}
