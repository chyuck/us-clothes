using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using DepIC;
using USClothesWebSite.Common.Extensions;
using USClothesWebSite.Common.Helpers;
using USClothesWebSite.Win.Logic;
using USClothesWebSite.Win.Logic.Async;
using USClothesWebSite.Win.Logic.Form;

namespace USClothesWebSite.Win.Forms.Base
{
    public partial class BaseMasterDetailForm : Form
    {
        #region Constructors

        public BaseMasterDetailForm()
        {
            InitializeComponent();
        }

        public BaseMasterDetailForm(ListFormMode mode)
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

        protected virtual DataGridViewColumn[] MasterColumns
        {
            get { throw new NotImplementedBaseFormMemberException(); }
        }

        protected virtual DataGridViewColumn[] DetailColumns
        {
            get { throw new NotImplementedBaseFormMemberException(); }
        }

        #endregion


        #region Methods

        #region Form
        
        protected virtual void OnLoad()
        {
            if (Mode == ListFormMode.List)
            {
                WindowState = FormWindowState.Maximized;
                ActionButtonPanel.Visible = false;
                ChooseButton.Enabled = ChooseButton.Visible = false;
                CloseButton.Enabled = CloseButton.Visible = false;
                SplitContainer.Dock = DockStyle.Fill;
            }
            else if (Mode == ListFormMode.Choose)
            {
                MinimumSize = Size;
                MinimizeBox = false;
                MaximizeBox = false;
            }

            MasterColumns.ForEach(c => MasterDataGridView.Columns.Add(c));
            DetailColumns.ForEach(c => DetailDataGridView.Columns.Add(c));
        }

        protected async virtual Task OnLoadAsync()
        {
            OnLoad();
            await OnMasterRefreshAsync();
        }

        protected virtual void OnClose()
        {
            Owner = null;
            MdiParent = null;
        }

        protected virtual void OnChoose()
        {
            throw new NotImplementedBaseFormMemberException();
        }

        #endregion


        #region Master

        protected virtual void OnMasterBeforeRefresh()
        {
            MasterRefreshButton.Enabled = false;
            DetailRefreshButton.Enabled = false;
        }

        protected virtual object[][] OnMasterRefresh(string filter)
        {
            throw new NotImplementedBaseFormMemberException();
        }

        protected virtual void OnMasterAfterRefresh()
        {
            MasterRefreshButton.Enabled = true;
            DetailRefreshButton.Enabled = true;
        }

        protected async virtual Task OnMasterRefreshAsync()
        {
            try
            {
                OnMasterBeforeRefresh();

                MasterDataGridView.Rows.Clear();

                var filter = MasterFilterControl.FilterText;

                var asyncService = IoCContainer.Get<IAsyncService>();
                var rows = await asyncService.DoAsync(() => OnMasterRefresh(filter));

                RefreshDataGridView(rows, MasterDataGridView);
            }
            finally
            {
                OnMasterAfterRefresh();
            }
        }

        protected virtual void OnMasterCreate()
        {
            throw new NotImplementedBaseFormMemberException();
        }

        protected virtual void OnMasterEdit()
        {
            throw new NotImplementedBaseFormMemberException();
        }

        protected virtual void OnMasterRowDoubleClick(int rowIndex)
        {
            if (Mode == ListFormMode.Choose)
            {
                OnChoose();
                Close();
                DialogResult = DialogResult.OK;
            }
            else
                OnMasterView();
        }

        protected virtual void OnMasterView()
        {
            throw new NotImplementedBaseFormMemberException();
        }

        protected virtual void OnMasterSelect()
        {
            DetailRefreshButton.PerformClick();
        }

        #endregion


        #region Detail
        
        protected virtual void OnDetailCreate()
        {
            throw new NotImplementedBaseFormMemberException();
        }

        protected virtual void OnDetailEdit()
        {
            throw new NotImplementedBaseFormMemberException();
        }

        protected virtual void OnDetailRowDoubleClick(int rowIndex)
        {
            OnDetailView();
        }

        protected virtual void OnDetailView()
        {
            throw new NotImplementedBaseFormMemberException();
        }

        protected virtual void OnDetailSelect()
        {
        }

        protected virtual void OnDetailBeforeRefresh()
        {
            MasterRefreshButton.Enabled = false;
            DetailRefreshButton.Enabled = false;
        }

        protected virtual object[][] OnDetailRefresh(string filter)
        {
            throw new NotImplementedBaseFormMemberException();
        }

        protected virtual void OnDetailAfterRefresh()
        {
            MasterRefreshButton.Enabled = true;
            DetailRefreshButton.Enabled = true;
        }

        protected virtual async Task OnDetailRefreshAsync()
        {
            try
            {
                OnDetailBeforeRefresh();

                DetailDataGridView.Rows.Clear();

                var filter = DetailFilterControl.FilterText;

                var asyncService = IoCContainer.Get<IAsyncService>();
                var rows = await asyncService.DoAsync(() => OnDetailRefresh(filter));

                RefreshDataGridView(rows, DetailDataGridView);
            }
            finally
            {
                OnDetailAfterRefresh();
            }
        }
        
        #endregion
        

        protected static void RefreshDataGridView(object[][] rows, DataGridView dataGridView)
        {
            CheckHelper.ArgumentNotNull(rows, "rows");
            CheckHelper.ArgumentNotNull(dataGridView, "dataGridView");
            
            dataGridView.Rows.Clear();
            
            foreach (var values in rows)
            {
                var row = new DataGridViewRow { Height = 17 };

                row.CreateCells(dataGridView, values);

                dataGridView.Rows.Add(row);
            }
        }

        #endregion


        #region Event Handlers

        private async void BaseMasterDetailForm_Load(object sender, EventArgs e)
        {
            if (!DesignMode)
                await OnLoadAsync();
        }

        private void MasterCreateButton_Click(object sender, EventArgs e)
        {
            OnMasterCreate();
        }

        private void MasterEditButton_Click(object sender, EventArgs e)
        {
            OnMasterEdit();
        }

        private async void MasterRefreshButton_Click(object sender, EventArgs e)
        {
            await OnMasterRefreshAsync();
        }

        private void MasterDataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            OnMasterRowDoubleClick(e.RowIndex);
        }

        private void MasterDataGridView_SelectionChanged(object sender, EventArgs e)
        {
            OnMasterSelect();
        }

        private void DetailCreateButton_Click(object sender, EventArgs e)
        {
            OnDetailCreate();
        }

        private void DetailEditButton_Click(object sender, EventArgs e)
        {
            OnDetailEdit();
        }

        private async void DetailRefreshButton_Click(object sender, EventArgs e)
        {
            await OnDetailRefreshAsync();
        }

        private void DetailDataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            OnDetailView();
        }
        
        private void DetailDataGridView_SelectionChanged(object sender, EventArgs e)
        {
            OnDetailSelect();
        }
        
        private void ChooseButton_Click(object sender, EventArgs e)
        {
            OnChoose();
        }

        private void BaseMasterDetailForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            OnClose();
        }

        #endregion
    }
}
