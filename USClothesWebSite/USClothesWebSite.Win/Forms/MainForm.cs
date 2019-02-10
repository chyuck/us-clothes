using System;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using USClothesWebSite.Common.Helpers;
using USClothesWebSite.DTO;
using USClothesWebSite.Win.Forms.Security;
using USClothesWebSite.Win.Helpers;
using USClothesWebSite.Win.Logic;
using USClothesWebSite.Win.Logic.Administration;
using USClothesWebSite.Win.Logic.Async;
using USClothesWebSite.Win.Logic.Form;
using USClothesWebSite.Win.Logic.Menu;
using USClothesWebSite.Win.Logic.Security;

namespace USClothesWebSite.Win.Forms
{
    public partial class MainForm : Form, IMenuHolder, IAsyncStatusPresenter
    {
        #region Fields

        private bool _closeApplication;
        
        #endregion


        #region Constructors

        public MainForm()
        {
            InitializeComponent();
        }
        
        #endregion


        #region Methods

        private static Version GetVersion()
        {
            return Assembly.GetAssembly(typeof(MainForm)).GetName().Version;
        }

        private void LogIn()
        {
            var logInForm = new LoginForm();
            if (logInForm.ShowDialog(this) == DialogResult.Cancel)
            {
                _closeApplication = true;
                Close();
            }
        }

        private void ShowMdiListForm<TDto>()
            where TDto : class, IDto, ICloneable, new()
        {
            var form = IoC.Container.Get<IFormService>().CreateDtoListForm<TDto>(ListFormMode.List);
            form.MdiParent = this;
            form.Show();
        }

        private void UpdateCaption()
        {
            var stringBuilder = new StringBuilder(@"Магазин элитной одежды для всей семьи ""US Clothes""");

            // Version
            var version = GetVersion();
            stringBuilder.Append(string.Format(" - Версия {0}", version));

            // User Name
            var securityService = IoC.Container.Get<ISecurityService>();
            if (securityService.IsLoggedIn)
            {
                var currentUser = IoC.Container.Get<ISecurityService>().CurrentUser;
                stringBuilder.Append(string.Format(" - {0} {1}", currentUser.LastName, currentUser.FirstName));
            }

            Text = stringBuilder.ToString();
        }

        #endregion


        #region Event Handlers


        #region Form
        
        private void MainForm_Load(object sender, EventArgs e)
        {
            // Settings
            Size = Properties.Settings.Default.MainForm_Size;
            Location = Properties.Settings.Default.MainForm_Location;
            WindowState = Properties.Settings.Default.MainForm_WindowState;

            // Caption
            UpdateCaption();

            // Menu
            IoC.RegisterMenuHolder(this);
            IoC.Container.Get<IMenuService>().SetUpMenu();

            // Async Status
            IoC.RegisterAsyncStatusPresenter(this);
            SetAsyncStatus(false);

            // Forms
            FormRegistrationHelper.Register();

            // Log In
            LogIn();
            IoC.Container.Get<IMenuService>().SetUpMenu();

            // Caption
            UpdateCaption();
        }
        
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing && !_closeApplication)
            {
                if (!PopupHelper.ShowYesNoDialog(this, "Выйти из программы?", "Выход"))
                    e.Cancel = true;
            }
        }
        
        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Properties.Settings.Default.MainForm_Size = Size;
            Properties.Settings.Default.MainForm_WindowState = WindowState;
            Properties.Settings.Default.MainForm_Location = Location;

            Properties.Settings.Default.Save();
        }
        
        #endregion


        #region Dictionaries

        private void BrandsMenuItem_Click(object sender, EventArgs e)
        {
            ShowMdiListForm<Brand>();
        }

        private void CategoriesMenuItem_Click(object sender, EventArgs e)
        {
            ShowMdiListForm<Category>();
        }

        private void SizesMenuItem_Click(object sender, EventArgs e)
        {
            ShowMdiListForm<Size>();
        }
        
        private void ProductsMenuItem_Click(object sender, EventArgs e)
        {
            ShowMdiListForm<DTO.Product>();
        }
        
        #endregion


        #region Documents

        private void OrdersMenuItem_Click(object sender, EventArgs e)
        {
            ShowMdiListForm<Order>();
        }

        private void ParcelsMenuItem_Click(object sender, EventArgs e)
        {
            ShowMdiListForm<Parcel>();
        }

        private void DistributorTransfersMenuItem_Click(object sender, EventArgs e)
        {
            ShowMdiListForm<DistributorTransfer>();
        }

        #endregion


        #region Reports
        
        private void ParcelReportMenuItem_Click(object sender, EventArgs e)
        {
            ShowMdiListForm<ParcelReportItem>();
        }

        private void DistributorReportMenuItem_Click(object sender, EventArgs e)
        {
            ShowMdiListForm<DistributorReportItem>();
        }
        
        #endregion


        #region Security

        private void CurrentUserMenuItem_Click(object sender, EventArgs e)
        {
            var securityService = IoC.Container.Get<ISecurityService>();
            
            CheckHelper.WithinCondition(securityService.IsLoggedIn, "securityService.IsLoggedIn");

            var editFormMode = securityService.IsCurrentUserAdministrator ? EditFormMode.Edit : EditFormMode.View;
            var currentUser = securityService.CurrentUser;

            var form = IoC.Container.Get<IFormService>().CreateDtoEditForm<User>(editFormMode, currentUser);
            form.ShowDialog(this);
        }
        
        private void ChangePasswordMenuItem_Click(object sender, EventArgs e)
        {
            var securityService = IoC.Container.Get<ISecurityService>();

            CheckHelper.WithinCondition(securityService.IsLoggedIn, "securityService.IsLoggedIn");

            var form = new ChangePasswordForm();
            form.ShowDialog(this);
        }

        private void UsersMenuItem_Click(object sender, EventArgs e)
        {
            ShowMdiListForm<User>();
        }
        
        #endregion


        #region Administration

        private void LogsMenuItem_Click(object sender, EventArgs e)
        {
            ShowMdiListForm<ActionLog>();
        }

        private void SettingsMenuItem_Click(object sender, EventArgs e)
        {
            var securityService = IoC.Container.Get<ISecurityService>();

            CheckHelper.WithinCondition(securityService.IsLoggedIn, "securityService.IsLoggedIn");
            CheckHelper.WithinCondition(securityService.IsCurrentUserAdministrator, "securityService.IsCurrentUserAdministrator");

            var settings = IoC.Container.Get<IAdministrationService>().Settings;

            var form = IoC.Container.Get<IFormService>().CreateDtoEditForm<Settings>(EditFormMode.Edit, settings);
            form.ShowDialog(this);
        }

        #endregion


        #region Window

        private void CascadeMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }
        
        private void HorizontalMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }
        
        private void VerticalMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        #endregion


        #region Help

        private void AboutMenuItem_Click(object sender, EventArgs e)
        {
            var version = GetVersion();
            var aboutForm = new AboutForm(version);
            
            aboutForm.ShowDialog(this);
        }
        
        #endregion


        #endregion


        #region IMenuHolder
        
        public ToolStripMenuItem DictionariesMenuItem
        {
            get { return _dictionariesMenuItem; }
        }

        public ToolStripMenuItem BrandsMenuItem
        {
            get { return _brandsMenuItem; }
        }

        public ToolStripMenuItem CategoriesMenuItem
        {
            get { return _categoriesMenuItem; }
        }

        public ToolStripMenuItem SizesMenuItem
        {
            get { return _sizesMenuItem; }
        }

        public ToolStripMenuItem ProductsMenuItem
        {
            get { return _productsMenuItem; }
        }

        public ToolStripMenuItem DocumentsMenuItem
        {
            get { return _documentsMenuItem; }
        }

        public ToolStripMenuItem OrdersMenuItem
        {
            get { return _ordersMenuItem; }
        }

        public ToolStripMenuItem ParcelsMenuItem
        {
            get { return _parcelsMenuItem; }
        }

        public ToolStripMenuItem DistributorTransfersMenuItem
        {
            get { return _distributorTransfersMenuItem; }
        }

        public ToolStripMenuItem SecurityMenuItem
        {
            get { return _securityMenuItem; }
        }

        public ToolStripMenuItem CurrentUserMenuItem
        {
            get { return _currentUserMenuItem; }
        }

        public ToolStripMenuItem ChangePasswordMenuItem
        {
            get { return _changePasswordMenuItem; }
        }

        public ToolStripMenuItem UsersMenuItem
        {
            get { return _usersMenuItem; }
        }

        public ToolStripMenuItem AdministrationMenuItem
        {
            get { return _administrationMenuItem; }
        }

        public ToolStripMenuItem LogsMenuItem
        {
            get { return _logsMenuItem; }
        }

        public ToolStripMenuItem SettingsMenuItem
        {
            get { return _settingsMenuItem; }
        }
        
        public ToolStripMenuItem ReportsMenuItem
        {
            get { return _reportsMenuItem; }
        }

        public ToolStripMenuItem ParcelReportMenuItem
        {
            get { return _parcelReportMenuItem; }
        }

        public ToolStripMenuItem DistributorReportMenuItem
        {
            get { return _distributorReportMenuItem; }
        }

        #endregion


        #region IAsyncStatusPresenter

        public void SetAsyncStatus(bool isActive)
        {
            _asyncStatusProgressBar.Visible = isActive;
            _asyncStatusLabel.Visible = isActive;
        }

        #endregion
    }
}
