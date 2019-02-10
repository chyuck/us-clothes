namespace USClothesWebSite.Win.Forms.Base
{
    partial class BaseMasterDetailForm
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
            this.MasterDataGridView = new System.Windows.Forms.DataGridView();
            this.ActionButtonPanel = new System.Windows.Forms.Panel();
            this.ChooseButton = new System.Windows.Forms.Button();
            this.CloseButton = new System.Windows.Forms.Button();
            this.MaterButtonPanel = new System.Windows.Forms.Panel();
            this.MasterFilterControl = new USClothesWebSite.Win.Controls.FilterControl();
            this.MasterRefreshButton = new System.Windows.Forms.Button();
            this.MasterEditButton = new System.Windows.Forms.Button();
            this.MasterCreateButton = new System.Windows.Forms.Button();
            this.SplitContainer = new System.Windows.Forms.SplitContainer();
            this.DetailDataGridView = new System.Windows.Forms.DataGridView();
            this.DetailButtonPanel = new System.Windows.Forms.Panel();
            this.DetailFilterControl = new USClothesWebSite.Win.Controls.FilterControl();
            this.DetailRefreshButton = new System.Windows.Forms.Button();
            this.DetailEditButton = new System.Windows.Forms.Button();
            this.DetailCreateButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.MasterDataGridView)).BeginInit();
            this.ActionButtonPanel.SuspendLayout();
            this.MaterButtonPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainer)).BeginInit();
            this.SplitContainer.Panel1.SuspendLayout();
            this.SplitContainer.Panel2.SuspendLayout();
            this.SplitContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DetailDataGridView)).BeginInit();
            this.DetailButtonPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // MasterDataGridView
            // 
            this.MasterDataGridView.AllowUserToAddRows = false;
            this.MasterDataGridView.AllowUserToDeleteRows = false;
            this.MasterDataGridView.AllowUserToResizeRows = false;
            this.MasterDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.MasterDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MasterDataGridView.Location = new System.Drawing.Point(0, 34);
            this.MasterDataGridView.MultiSelect = false;
            this.MasterDataGridView.Name = "MasterDataGridView";
            this.MasterDataGridView.ReadOnly = true;
            this.MasterDataGridView.RowHeadersVisible = false;
            this.MasterDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.MasterDataGridView.Size = new System.Drawing.Size(884, 146);
            this.MasterDataGridView.TabIndex = 0;
            this.MasterDataGridView.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.MasterDataGridView_CellDoubleClick);
            this.MasterDataGridView.SelectionChanged += new System.EventHandler(this.MasterDataGridView_SelectionChanged);
            // 
            // ActionButtonPanel
            // 
            this.ActionButtonPanel.Controls.Add(this.ChooseButton);
            this.ActionButtonPanel.Controls.Add(this.CloseButton);
            this.ActionButtonPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ActionButtonPanel.Location = new System.Drawing.Point(0, 366);
            this.ActionButtonPanel.Name = "ActionButtonPanel";
            this.ActionButtonPanel.Size = new System.Drawing.Size(884, 46);
            this.ActionButtonPanel.TabIndex = 1;
            // 
            // ChooseButton
            // 
            this.ChooseButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ChooseButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.ChooseButton.Location = new System.Drawing.Point(719, 8);
            this.ChooseButton.Name = "ChooseButton";
            this.ChooseButton.Size = new System.Drawing.Size(75, 30);
            this.ChooseButton.TabIndex = 0;
            this.ChooseButton.Text = "Выбрать";
            this.ChooseButton.UseVisualStyleBackColor = true;
            this.ChooseButton.Click += new System.EventHandler(this.ChooseButton_Click);
            // 
            // CloseButton
            // 
            this.CloseButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.CloseButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CloseButton.Location = new System.Drawing.Point(800, 8);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Size = new System.Drawing.Size(75, 30);
            this.CloseButton.TabIndex = 1;
            this.CloseButton.Text = "Закрыть";
            this.CloseButton.UseVisualStyleBackColor = true;
            // 
            // MaterButtonPanel
            // 
            this.MaterButtonPanel.Controls.Add(this.MasterFilterControl);
            this.MaterButtonPanel.Controls.Add(this.MasterRefreshButton);
            this.MaterButtonPanel.Controls.Add(this.MasterEditButton);
            this.MaterButtonPanel.Controls.Add(this.MasterCreateButton);
            this.MaterButtonPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.MaterButtonPanel.Location = new System.Drawing.Point(0, 0);
            this.MaterButtonPanel.Name = "MaterButtonPanel";
            this.MaterButtonPanel.Size = new System.Drawing.Size(884, 34);
            this.MaterButtonPanel.TabIndex = 1;
            // 
            // MasterFilterControl
            // 
            this.MasterFilterControl.FilterText = "";
            this.MasterFilterControl.Location = new System.Drawing.Point(248, 7);
            this.MasterFilterControl.MaximumSize = new System.Drawing.Size(241, 20);
            this.MasterFilterControl.MinimumSize = new System.Drawing.Size(241, 20);
            this.MasterFilterControl.Name = "MasterFilterControl";
            this.MasterFilterControl.Size = new System.Drawing.Size(241, 20);
            this.MasterFilterControl.TabIndex = 2;
            // 
            // MasterRefreshButton
            // 
            this.MasterRefreshButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.MasterRefreshButton.Image = global::USClothesWebSite.Win.Properties.Resources.arrow_refresh;
            this.MasterRefreshButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.MasterRefreshButton.Location = new System.Drawing.Point(495, 5);
            this.MasterRefreshButton.Name = "MasterRefreshButton";
            this.MasterRefreshButton.Size = new System.Drawing.Size(88, 23);
            this.MasterRefreshButton.TabIndex = 3;
            this.MasterRefreshButton.TabStop = false;
            this.MasterRefreshButton.Text = "Обновить";
            this.MasterRefreshButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.MasterRefreshButton.UseVisualStyleBackColor = true;
            this.MasterRefreshButton.Click += new System.EventHandler(this.MasterRefreshButton_Click);
            // 
            // MasterEditButton
            // 
            this.MasterEditButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.MasterEditButton.Image = global::USClothesWebSite.Win.Properties.Resources.pencil;
            this.MasterEditButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.MasterEditButton.Location = new System.Drawing.Point(90, 5);
            this.MasterEditButton.Name = "MasterEditButton";
            this.MasterEditButton.Size = new System.Drawing.Size(114, 23);
            this.MasterEditButton.TabIndex = 1;
            this.MasterEditButton.TabStop = false;
            this.MasterEditButton.Text = "Редактировать";
            this.MasterEditButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.MasterEditButton.UseVisualStyleBackColor = true;
            this.MasterEditButton.Click += new System.EventHandler(this.MasterEditButton_Click);
            // 
            // MasterCreateButton
            // 
            this.MasterCreateButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.MasterCreateButton.Image = global::USClothesWebSite.Win.Properties.Resources.asterisk_orange;
            this.MasterCreateButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.MasterCreateButton.Location = new System.Drawing.Point(6, 5);
            this.MasterCreateButton.Name = "MasterCreateButton";
            this.MasterCreateButton.Size = new System.Drawing.Size(78, 23);
            this.MasterCreateButton.TabIndex = 0;
            this.MasterCreateButton.TabStop = false;
            this.MasterCreateButton.Text = "Создать";
            this.MasterCreateButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.MasterCreateButton.UseVisualStyleBackColor = true;
            this.MasterCreateButton.Click += new System.EventHandler(this.MasterCreateButton_Click);
            // 
            // SplitContainer
            // 
            this.SplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SplitContainer.Location = new System.Drawing.Point(0, 0);
            this.SplitContainer.Name = "SplitContainer";
            this.SplitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // SplitContainer.Panel1
            // 
            this.SplitContainer.Panel1.Controls.Add(this.MasterDataGridView);
            this.SplitContainer.Panel1.Controls.Add(this.MaterButtonPanel);
            this.SplitContainer.Panel1MinSize = 150;
            // 
            // SplitContainer.Panel2
            // 
            this.SplitContainer.Panel2.Controls.Add(this.DetailDataGridView);
            this.SplitContainer.Panel2.Controls.Add(this.DetailButtonPanel);
            this.SplitContainer.Panel2MinSize = 150;
            this.SplitContainer.Size = new System.Drawing.Size(884, 366);
            this.SplitContainer.SplitterDistance = 180;
            this.SplitContainer.TabIndex = 0;
            // 
            // DetailDataGridView
            // 
            this.DetailDataGridView.AllowUserToAddRows = false;
            this.DetailDataGridView.AllowUserToDeleteRows = false;
            this.DetailDataGridView.AllowUserToResizeRows = false;
            this.DetailDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DetailDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DetailDataGridView.Location = new System.Drawing.Point(0, 34);
            this.DetailDataGridView.MultiSelect = false;
            this.DetailDataGridView.Name = "DetailDataGridView";
            this.DetailDataGridView.ReadOnly = true;
            this.DetailDataGridView.RowHeadersVisible = false;
            this.DetailDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DetailDataGridView.Size = new System.Drawing.Size(884, 148);
            this.DetailDataGridView.TabIndex = 0;
            this.DetailDataGridView.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DetailDataGridView_CellDoubleClick);
            this.DetailDataGridView.SelectionChanged += new System.EventHandler(this.DetailDataGridView_SelectionChanged);
            // 
            // DetailButtonPanel
            // 
            this.DetailButtonPanel.Controls.Add(this.DetailFilterControl);
            this.DetailButtonPanel.Controls.Add(this.DetailRefreshButton);
            this.DetailButtonPanel.Controls.Add(this.DetailEditButton);
            this.DetailButtonPanel.Controls.Add(this.DetailCreateButton);
            this.DetailButtonPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.DetailButtonPanel.Location = new System.Drawing.Point(0, 0);
            this.DetailButtonPanel.Name = "DetailButtonPanel";
            this.DetailButtonPanel.Size = new System.Drawing.Size(884, 34);
            this.DetailButtonPanel.TabIndex = 0;
            // 
            // DetailFilterControl
            // 
            this.DetailFilterControl.FilterText = "";
            this.DetailFilterControl.Location = new System.Drawing.Point(248, 7);
            this.DetailFilterControl.MaximumSize = new System.Drawing.Size(241, 20);
            this.DetailFilterControl.MinimumSize = new System.Drawing.Size(241, 20);
            this.DetailFilterControl.Name = "DetailFilterControl";
            this.DetailFilterControl.Size = new System.Drawing.Size(241, 20);
            this.DetailFilterControl.TabIndex = 3;
            // 
            // DetailRefreshButton
            // 
            this.DetailRefreshButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DetailRefreshButton.Image = global::USClothesWebSite.Win.Properties.Resources.arrow_refresh;
            this.DetailRefreshButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.DetailRefreshButton.Location = new System.Drawing.Point(495, 5);
            this.DetailRefreshButton.Name = "DetailRefreshButton";
            this.DetailRefreshButton.Size = new System.Drawing.Size(88, 23);
            this.DetailRefreshButton.TabIndex = 0;
            this.DetailRefreshButton.TabStop = false;
            this.DetailRefreshButton.Text = "Обновить";
            this.DetailRefreshButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.DetailRefreshButton.UseVisualStyleBackColor = true;
            this.DetailRefreshButton.Click += new System.EventHandler(this.DetailRefreshButton_Click);
            // 
            // DetailEditButton
            // 
            this.DetailEditButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DetailEditButton.Image = global::USClothesWebSite.Win.Properties.Resources.pencil;
            this.DetailEditButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.DetailEditButton.Location = new System.Drawing.Point(90, 5);
            this.DetailEditButton.Name = "DetailEditButton";
            this.DetailEditButton.Size = new System.Drawing.Size(114, 23);
            this.DetailEditButton.TabIndex = 2;
            this.DetailEditButton.TabStop = false;
            this.DetailEditButton.Text = "Редактировать";
            this.DetailEditButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.DetailEditButton.UseVisualStyleBackColor = true;
            this.DetailEditButton.Click += new System.EventHandler(this.DetailEditButton_Click);
            // 
            // DetailCreateButton
            // 
            this.DetailCreateButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DetailCreateButton.Image = global::USClothesWebSite.Win.Properties.Resources.asterisk_orange;
            this.DetailCreateButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.DetailCreateButton.Location = new System.Drawing.Point(6, 5);
            this.DetailCreateButton.Name = "DetailCreateButton";
            this.DetailCreateButton.Size = new System.Drawing.Size(78, 23);
            this.DetailCreateButton.TabIndex = 1;
            this.DetailCreateButton.TabStop = false;
            this.DetailCreateButton.Text = "Создать";
            this.DetailCreateButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.DetailCreateButton.UseVisualStyleBackColor = true;
            this.DetailCreateButton.Click += new System.EventHandler(this.DetailCreateButton_Click);
            // 
            // BaseMasterDetailForm
            // 
            this.AcceptButton = this.ChooseButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.CloseButton;
            this.ClientSize = new System.Drawing.Size(884, 412);
            this.Controls.Add(this.SplitContainer);
            this.Controls.Add(this.ActionButtonPanel);
            this.Name = "BaseMasterDetailForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.BaseMasterDetailForm_FormClosed);
            this.Load += new System.EventHandler(this.BaseMasterDetailForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.MasterDataGridView)).EndInit();
            this.ActionButtonPanel.ResumeLayout(false);
            this.MaterButtonPanel.ResumeLayout(false);
            this.SplitContainer.Panel1.ResumeLayout(false);
            this.SplitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainer)).EndInit();
            this.SplitContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DetailDataGridView)).EndInit();
            this.DetailButtonPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        protected System.Windows.Forms.DataGridView MasterDataGridView;
        protected System.Windows.Forms.Panel ActionButtonPanel;
        protected System.Windows.Forms.Panel MaterButtonPanel;
        protected System.Windows.Forms.SplitContainer SplitContainer;
        protected System.Windows.Forms.DataGridView DetailDataGridView;
        protected System.Windows.Forms.Panel DetailButtonPanel;
        protected Controls.FilterControl MasterFilterControl;
        protected System.Windows.Forms.Button MasterRefreshButton;
        protected System.Windows.Forms.Button MasterEditButton;
        protected System.Windows.Forms.Button MasterCreateButton;
        protected Controls.FilterControl DetailFilterControl;
        protected System.Windows.Forms.Button DetailRefreshButton;
        protected System.Windows.Forms.Button DetailEditButton;
        protected System.Windows.Forms.Button DetailCreateButton;
        protected System.Windows.Forms.Button ChooseButton;
        protected System.Windows.Forms.Button CloseButton;
    }
}