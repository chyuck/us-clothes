namespace USClothesWebSite.Win.Forms.Base
{
    partial class BaseListForm
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
            this.CloseButton = new System.Windows.Forms.Button();
            this.ChooseButton = new System.Windows.Forms.Button();
            this.ActionButtonPanel = new System.Windows.Forms.Panel();
            this.DataGridView = new System.Windows.Forms.DataGridView();
            this.ButtonPanel = new System.Windows.Forms.Panel();
            this.FilterControl = new USClothesWebSite.Win.Controls.FilterControl();
            this.RefreshButton = new System.Windows.Forms.Button();
            this.EditButton = new System.Windows.Forms.Button();
            this.CreateButton = new System.Windows.Forms.Button();
            this.ActionButtonPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView)).BeginInit();
            this.ButtonPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // CloseButton
            // 
            this.CloseButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.CloseButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CloseButton.Location = new System.Drawing.Point(699, 8);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Size = new System.Drawing.Size(75, 30);
            this.CloseButton.TabIndex = 1;
            this.CloseButton.Text = "Закрыть";
            this.CloseButton.UseVisualStyleBackColor = true;
            // 
            // ChooseButton
            // 
            this.ChooseButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ChooseButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.ChooseButton.Location = new System.Drawing.Point(618, 8);
            this.ChooseButton.Name = "ChooseButton";
            this.ChooseButton.Size = new System.Drawing.Size(75, 30);
            this.ChooseButton.TabIndex = 0;
            this.ChooseButton.Text = "Выбрать";
            this.ChooseButton.UseVisualStyleBackColor = true;
            this.ChooseButton.Click += new System.EventHandler(this.ChooseButton_Click);
            // 
            // ActionButtonPanel
            // 
            this.ActionButtonPanel.Controls.Add(this.ChooseButton);
            this.ActionButtonPanel.Controls.Add(this.CloseButton);
            this.ActionButtonPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ActionButtonPanel.Location = new System.Drawing.Point(0, 316);
            this.ActionButtonPanel.Name = "ActionButtonPanel";
            this.ActionButtonPanel.Size = new System.Drawing.Size(784, 46);
            this.ActionButtonPanel.TabIndex = 2;
            // 
            // DataGridView
            // 
            this.DataGridView.AllowUserToAddRows = false;
            this.DataGridView.AllowUserToDeleteRows = false;
            this.DataGridView.AllowUserToResizeRows = false;
            this.DataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DataGridView.Location = new System.Drawing.Point(0, 34);
            this.DataGridView.MultiSelect = false;
            this.DataGridView.Name = "DataGridView";
            this.DataGridView.ReadOnly = true;
            this.DataGridView.RowHeadersVisible = false;
            this.DataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DataGridView.Size = new System.Drawing.Size(784, 282);
            this.DataGridView.TabIndex = 1;
            this.DataGridView.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridView_CellDoubleClick);
            this.DataGridView.SelectionChanged += new System.EventHandler(this.DataGridView_SelectionChanged);
            // 
            // ButtonPanel
            // 
            this.ButtonPanel.Controls.Add(this.FilterControl);
            this.ButtonPanel.Controls.Add(this.RefreshButton);
            this.ButtonPanel.Controls.Add(this.EditButton);
            this.ButtonPanel.Controls.Add(this.CreateButton);
            this.ButtonPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.ButtonPanel.Location = new System.Drawing.Point(0, 0);
            this.ButtonPanel.Name = "ButtonPanel";
            this.ButtonPanel.Size = new System.Drawing.Size(784, 34);
            this.ButtonPanel.TabIndex = 0;
            // 
            // FilterControl
            // 
            this.FilterControl.FilterText = "";
            this.FilterControl.Location = new System.Drawing.Point(248, 7);
            this.FilterControl.MaximumSize = new System.Drawing.Size(241, 20);
            this.FilterControl.MinimumSize = new System.Drawing.Size(241, 20);
            this.FilterControl.Name = "FilterControl";
            this.FilterControl.Size = new System.Drawing.Size(241, 20);
            this.FilterControl.TabIndex = 2;
            // 
            // RefreshButton
            // 
            this.RefreshButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.RefreshButton.Image = global::USClothesWebSite.Win.Properties.Resources.arrow_refresh;
            this.RefreshButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.RefreshButton.Location = new System.Drawing.Point(495, 5);
            this.RefreshButton.Name = "RefreshButton";
            this.RefreshButton.Size = new System.Drawing.Size(88, 23);
            this.RefreshButton.TabIndex = 3;
            this.RefreshButton.TabStop = false;
            this.RefreshButton.Text = "Обновить";
            this.RefreshButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.RefreshButton.UseVisualStyleBackColor = true;
            this.RefreshButton.Click += new System.EventHandler(this.RefreshButton_Click);
            // 
            // EditButton
            // 
            this.EditButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.EditButton.Image = global::USClothesWebSite.Win.Properties.Resources.pencil;
            this.EditButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.EditButton.Location = new System.Drawing.Point(90, 5);
            this.EditButton.Name = "EditButton";
            this.EditButton.Size = new System.Drawing.Size(114, 23);
            this.EditButton.TabIndex = 1;
            this.EditButton.TabStop = false;
            this.EditButton.Text = "Редактировать";
            this.EditButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.EditButton.UseVisualStyleBackColor = true;
            this.EditButton.Click += new System.EventHandler(this.EditButton_Click);
            // 
            // CreateButton
            // 
            this.CreateButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CreateButton.Image = global::USClothesWebSite.Win.Properties.Resources.asterisk_orange;
            this.CreateButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.CreateButton.Location = new System.Drawing.Point(6, 5);
            this.CreateButton.Name = "CreateButton";
            this.CreateButton.Size = new System.Drawing.Size(78, 23);
            this.CreateButton.TabIndex = 0;
            this.CreateButton.TabStop = false;
            this.CreateButton.Text = "Создать";
            this.CreateButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.CreateButton.UseVisualStyleBackColor = true;
            this.CreateButton.Click += new System.EventHandler(this.CreateButton_Click);
            // 
            // BaseListForm
            // 
            this.AcceptButton = this.ChooseButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.CloseButton;
            this.ClientSize = new System.Drawing.Size(784, 362);
            this.Controls.Add(this.DataGridView);
            this.Controls.Add(this.ButtonPanel);
            this.Controls.Add(this.ActionButtonPanel);
            this.Name = "BaseListForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.BaseListForm_FormClosed);
            this.Load += new System.EventHandler(this.BaseListForm_Load);
            this.ActionButtonPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView)).EndInit();
            this.ButtonPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        protected System.Windows.Forms.Button CloseButton;
        protected System.Windows.Forms.Button ChooseButton;
        protected System.Windows.Forms.Panel ActionButtonPanel;
        protected System.Windows.Forms.DataGridView DataGridView;
        protected System.Windows.Forms.Panel ButtonPanel;
        protected System.Windows.Forms.Button RefreshButton;
        protected System.Windows.Forms.Button EditButton;
        protected System.Windows.Forms.Button CreateButton;
        protected Controls.FilterControl FilterControl;
    }
}