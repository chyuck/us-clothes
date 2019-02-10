namespace USClothesWebSite.Win.Forms
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this._mainMenu = new System.Windows.Forms.MenuStrip();
            this._dictionariesMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._brandsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._categoriesMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._sizesMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._productsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._documentsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._ordersMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._parcelsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._distributorTransfersMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._securityMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._currentUserMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._changePasswordMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this._usersMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._administrationMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._logsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._settingsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._windowMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._cascadeMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._horizontalMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._verticalMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._helpMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._aboutMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._mainStatusBar = new System.Windows.Forms.StatusStrip();
            this._asyncStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this._asyncStatusProgressBar = new System.Windows.Forms.ToolStripProgressBar();
            this._reportsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._parcelReportMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._distributorReportMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._mainMenu.SuspendLayout();
            this._mainStatusBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // _mainMenu
            // 
            this._mainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._dictionariesMenuItem,
            this._documentsMenuItem,
            this._reportsMenuItem,
            this._securityMenuItem,
            this._administrationMenuItem,
            this._windowMenuItem,
            this._helpMenuItem});
            this._mainMenu.Location = new System.Drawing.Point(0, 0);
            this._mainMenu.Name = "_mainMenu";
            this._mainMenu.Size = new System.Drawing.Size(795, 24);
            this._mainMenu.TabIndex = 1;
            this._mainMenu.Text = "MainMenu";
            // 
            // _dictionariesMenuItem
            // 
            this._dictionariesMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._brandsMenuItem,
            this._categoriesMenuItem,
            this._sizesMenuItem,
            this._productsMenuItem});
            this._dictionariesMenuItem.Name = "_dictionariesMenuItem";
            this._dictionariesMenuItem.Size = new System.Drawing.Size(94, 20);
            this._dictionariesMenuItem.Text = "Справочники";
            // 
            // _brandsMenuItem
            // 
            this._brandsMenuItem.Name = "_brandsMenuItem";
            this._brandsMenuItem.Size = new System.Drawing.Size(131, 22);
            this._brandsMenuItem.Text = "Брэнды";
            this._brandsMenuItem.Click += new System.EventHandler(this.BrandsMenuItem_Click);
            // 
            // _categoriesMenuItem
            // 
            this._categoriesMenuItem.Name = "_categoriesMenuItem";
            this._categoriesMenuItem.Size = new System.Drawing.Size(131, 22);
            this._categoriesMenuItem.Text = "Категории";
            this._categoriesMenuItem.Click += new System.EventHandler(this.CategoriesMenuItem_Click);
            // 
            // _sizesMenuItem
            // 
            this._sizesMenuItem.Name = "_sizesMenuItem";
            this._sizesMenuItem.Size = new System.Drawing.Size(131, 22);
            this._sizesMenuItem.Text = "Размеры";
            this._sizesMenuItem.Click += new System.EventHandler(this.SizesMenuItem_Click);
            // 
            // _productsMenuItem
            // 
            this._productsMenuItem.Name = "_productsMenuItem";
            this._productsMenuItem.Size = new System.Drawing.Size(131, 22);
            this._productsMenuItem.Text = "Товары";
            this._productsMenuItem.Click += new System.EventHandler(this.ProductsMenuItem_Click);
            // 
            // _documentsMenuItem
            // 
            this._documentsMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._ordersMenuItem,
            this._parcelsMenuItem,
            this._distributorTransfersMenuItem});
            this._documentsMenuItem.Name = "_documentsMenuItem";
            this._documentsMenuItem.Size = new System.Drawing.Size(82, 20);
            this._documentsMenuItem.Text = "Документы";
            // 
            // _ordersMenuItem
            // 
            this._ordersMenuItem.Name = "_ordersMenuItem";
            this._ordersMenuItem.Size = new System.Drawing.Size(242, 22);
            this._ordersMenuItem.Text = "Заказы";
            this._ordersMenuItem.Click += new System.EventHandler(this.OrdersMenuItem_Click);
            // 
            // _parcelsMenuItem
            // 
            this._parcelsMenuItem.Name = "_parcelsMenuItem";
            this._parcelsMenuItem.Size = new System.Drawing.Size(242, 22);
            this._parcelsMenuItem.Text = "Посылки";
            this._parcelsMenuItem.Click += new System.EventHandler(this.ParcelsMenuItem_Click);
            // 
            // _distributorTransfersMenuItem
            // 
            this._distributorTransfersMenuItem.Name = "_distributorTransfersMenuItem";
            this._distributorTransfersMenuItem.Size = new System.Drawing.Size(242, 22);
            this._distributorTransfersMenuItem.Text = "Переводы распространителей";
            this._distributorTransfersMenuItem.Click += new System.EventHandler(this.DistributorTransfersMenuItem_Click);
            // 
            // _securityMenuItem
            // 
            this._securityMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._currentUserMenuItem,
            this._changePasswordMenuItem,
            this.toolStripMenuItem1,
            this._usersMenuItem});
            this._securityMenuItem.Name = "_securityMenuItem";
            this._securityMenuItem.Size = new System.Drawing.Size(94, 20);
            this._securityMenuItem.Text = "Безопасность";
            // 
            // _currentUserMenuItem
            // 
            this._currentUserMenuItem.Name = "_currentUserMenuItem";
            this._currentUserMenuItem.Size = new System.Drawing.Size(202, 22);
            this._currentUserMenuItem.Text = "Текущий пользователь";
            this._currentUserMenuItem.Click += new System.EventHandler(this.CurrentUserMenuItem_Click);
            // 
            // _changePasswordMenuItem
            // 
            this._changePasswordMenuItem.Name = "_changePasswordMenuItem";
            this._changePasswordMenuItem.Size = new System.Drawing.Size(202, 22);
            this._changePasswordMenuItem.Text = "Сменить пароль";
            this._changePasswordMenuItem.Click += new System.EventHandler(this.ChangePasswordMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(199, 6);
            // 
            // _usersMenuItem
            // 
            this._usersMenuItem.Image = global::USClothesWebSite.Win.Properties.Resources.group;
            this._usersMenuItem.Name = "_usersMenuItem";
            this._usersMenuItem.Size = new System.Drawing.Size(202, 22);
            this._usersMenuItem.Text = "Пользователи";
            this._usersMenuItem.Click += new System.EventHandler(this.UsersMenuItem_Click);
            // 
            // _administrationMenuItem
            // 
            this._administrationMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._logsMenuItem,
            this._settingsMenuItem});
            this._administrationMenuItem.Name = "_administrationMenuItem";
            this._administrationMenuItem.Size = new System.Drawing.Size(134, 20);
            this._administrationMenuItem.Text = "Администрирование";
            // 
            // _logsMenuItem
            // 
            this._logsMenuItem.Name = "_logsMenuItem";
            this._logsMenuItem.Size = new System.Drawing.Size(152, 22);
            this._logsMenuItem.Text = "Логи";
            this._logsMenuItem.Click += new System.EventHandler(this.LogsMenuItem_Click);
            // 
            // _settingsMenuItem
            // 
            this._settingsMenuItem.Name = "_settingsMenuItem";
            this._settingsMenuItem.Size = new System.Drawing.Size(152, 22);
            this._settingsMenuItem.Text = "Настройки";
            this._settingsMenuItem.Click += new System.EventHandler(this.SettingsMenuItem_Click);
            // 
            // _windowMenuItem
            // 
            this._windowMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._cascadeMenuItem,
            this._horizontalMenuItem,
            this._verticalMenuItem});
            this._windowMenuItem.Name = "_windowMenuItem";
            this._windowMenuItem.Size = new System.Drawing.Size(48, 20);
            this._windowMenuItem.Text = "Окно";
            // 
            // _cascadeMenuItem
            // 
            this._cascadeMenuItem.Image = global::USClothesWebSite.Win.Properties.Resources.application_cascade;
            this._cascadeMenuItem.Name = "_cascadeMenuItem";
            this._cascadeMenuItem.Size = new System.Drawing.Size(158, 22);
            this._cascadeMenuItem.Text = "Каскадно";
            this._cascadeMenuItem.Click += new System.EventHandler(this.CascadeMenuItem_Click);
            // 
            // _horizontalMenuItem
            // 
            this._horizontalMenuItem.Image = global::USClothesWebSite.Win.Properties.Resources.application_tile_horizontal;
            this._horizontalMenuItem.Name = "_horizontalMenuItem";
            this._horizontalMenuItem.Size = new System.Drawing.Size(158, 22);
            this._horizontalMenuItem.Text = "Горизонтально";
            this._horizontalMenuItem.Click += new System.EventHandler(this.HorizontalMenuItem_Click);
            // 
            // _verticalMenuItem
            // 
            this._verticalMenuItem.Image = global::USClothesWebSite.Win.Properties.Resources.application_tile_vertical;
            this._verticalMenuItem.Name = "_verticalMenuItem";
            this._verticalMenuItem.Size = new System.Drawing.Size(158, 22);
            this._verticalMenuItem.Text = "Вертикально";
            this._verticalMenuItem.Click += new System.EventHandler(this.VerticalMenuItem_Click);
            // 
            // _helpMenuItem
            // 
            this._helpMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._aboutMenuItem});
            this._helpMenuItem.Name = "_helpMenuItem";
            this._helpMenuItem.Size = new System.Drawing.Size(68, 20);
            this._helpMenuItem.Text = "Помощь";
            // 
            // _aboutMenuItem
            // 
            this._aboutMenuItem.Image = global::USClothesWebSite.Win.Properties.Resources.information;
            this._aboutMenuItem.Name = "_aboutMenuItem";
            this._aboutMenuItem.Size = new System.Drawing.Size(149, 22);
            this._aboutMenuItem.Text = "О программе";
            this._aboutMenuItem.Click += new System.EventHandler(this.AboutMenuItem_Click);
            // 
            // _mainStatusBar
            // 
            this._mainStatusBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._asyncStatusLabel,
            this._asyncStatusProgressBar});
            this._mainStatusBar.Location = new System.Drawing.Point(0, 420);
            this._mainStatusBar.Name = "_mainStatusBar";
            this._mainStatusBar.Size = new System.Drawing.Size(795, 22);
            this._mainStatusBar.TabIndex = 3;
            this._mainStatusBar.Text = "MainStatusBar";
            // 
            // _asyncStatusLabel
            // 
            this._asyncStatusLabel.Name = "_asyncStatusLabel";
            this._asyncStatusLabel.Size = new System.Drawing.Size(145, 17);
            this._asyncStatusLabel.Text = "Выполняется операция...";
            // 
            // _asyncStatusProgressBar
            // 
            this._asyncStatusProgressBar.Name = "_asyncStatusProgressBar";
            this._asyncStatusProgressBar.Size = new System.Drawing.Size(100, 16);
            this._asyncStatusProgressBar.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            // 
            // _reportsMenuItem
            // 
            this._reportsMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._parcelReportMenuItem,
            this._distributorReportMenuItem});
            this._reportsMenuItem.Name = "_reportsMenuItem";
            this._reportsMenuItem.Size = new System.Drawing.Size(60, 20);
            this._reportsMenuItem.Text = "Отчеты";
            // 
            // _parcelReportMenuItem
            // 
            this._parcelReportMenuItem.Name = "_parcelReportMenuItem";
            this._parcelReportMenuItem.Size = new System.Drawing.Size(237, 22);
            this._parcelReportMenuItem.Text = "Отчет по посылкам";
            this._parcelReportMenuItem.Click += new System.EventHandler(this.ParcelReportMenuItem_Click);
            // 
            // _distributorReportMenuItem
            // 
            this._distributorReportMenuItem.Name = "_distributorReportMenuItem";
            this._distributorReportMenuItem.Size = new System.Drawing.Size(237, 22);
            this._distributorReportMenuItem.Text = "Отчет по распространителям";
            this._distributorReportMenuItem.Click += new System.EventHandler(this.DistributorReportMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(795, 442);
            this.Controls.Add(this._mainStatusBar);
            this.Controls.Add(this._mainMenu);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this._mainMenu;
            this.MinimumSize = new System.Drawing.Size(540, 480);
            this.Name = "MainForm";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this._mainMenu.ResumeLayout(false);
            this._mainMenu.PerformLayout();
            this._mainStatusBar.ResumeLayout(false);
            this._mainStatusBar.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip _mainMenu;
        private System.Windows.Forms.ToolStripMenuItem _helpMenuItem;
        private System.Windows.Forms.ToolStripMenuItem _aboutMenuItem;
        private System.Windows.Forms.StatusStrip _mainStatusBar;
        private System.Windows.Forms.ToolStripMenuItem _securityMenuItem;
        private System.Windows.Forms.ToolStripMenuItem _currentUserMenuItem;
        private System.Windows.Forms.ToolStripMenuItem _changePasswordMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem _usersMenuItem;
        private System.Windows.Forms.ToolStripMenuItem _dictionariesMenuItem;
        private System.Windows.Forms.ToolStripMenuItem _brandsMenuItem;
        private System.Windows.Forms.ToolStripMenuItem _categoriesMenuItem;
        private System.Windows.Forms.ToolStripMenuItem _sizesMenuItem;
        private System.Windows.Forms.ToolStripMenuItem _productsMenuItem;
        private System.Windows.Forms.ToolStripMenuItem _documentsMenuItem;
        private System.Windows.Forms.ToolStripMenuItem _ordersMenuItem;
        private System.Windows.Forms.ToolStripMenuItem _administrationMenuItem;
        private System.Windows.Forms.ToolStripMenuItem _logsMenuItem;
        private System.Windows.Forms.ToolStripMenuItem _windowMenuItem;
        private System.Windows.Forms.ToolStripMenuItem _cascadeMenuItem;
        private System.Windows.Forms.ToolStripMenuItem _horizontalMenuItem;
        private System.Windows.Forms.ToolStripMenuItem _verticalMenuItem;
        private System.Windows.Forms.ToolStripProgressBar _asyncStatusProgressBar;
        private System.Windows.Forms.ToolStripStatusLabel _asyncStatusLabel;
        private System.Windows.Forms.ToolStripMenuItem _settingsMenuItem;
        private System.Windows.Forms.ToolStripMenuItem _parcelsMenuItem;
        private System.Windows.Forms.ToolStripMenuItem _distributorTransfersMenuItem;
        private System.Windows.Forms.ToolStripMenuItem _reportsMenuItem;
        private System.Windows.Forms.ToolStripMenuItem _parcelReportMenuItem;
        private System.Windows.Forms.ToolStripMenuItem _distributorReportMenuItem;
    }
}

