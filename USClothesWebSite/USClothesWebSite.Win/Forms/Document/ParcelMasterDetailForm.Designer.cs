namespace USClothesWebSite.Win.Forms.Document
{
    partial class ParcelMasterDetailForm
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
            this.label1 = new System.Windows.Forms.Label();
            this._dateDateIntervalControl = new USClothesWebSite.Win.Controls.DateIntervalControl();
            this.DetailAddButton = new System.Windows.Forms.Button();
            this.GoButton = new System.Windows.Forms.Button();
            this.ActionButtonPanel.SuspendLayout();
            this.MaterButtonPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainer)).BeginInit();
            this.SplitContainer.Panel1.SuspendLayout();
            this.SplitContainer.Panel2.SuspendLayout();
            this.SplitContainer.SuspendLayout();
            this.DetailButtonPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // ActionButtonPanel
            // 
            this.ActionButtonPanel.TabIndex = 0;
            // 
            // MaterButtonPanel
            // 
            this.MaterButtonPanel.Controls.Add(this.label1);
            this.MaterButtonPanel.Controls.Add(this._dateDateIntervalControl);
            this.MaterButtonPanel.TabIndex = 0;
            this.MaterButtonPanel.Controls.SetChildIndex(this.MasterCreateButton, 0);
            this.MaterButtonPanel.Controls.SetChildIndex(this.MasterEditButton, 0);
            this.MaterButtonPanel.Controls.SetChildIndex(this.MasterRefreshButton, 0);
            this.MaterButtonPanel.Controls.SetChildIndex(this.MasterFilterControl, 0);
            this.MaterButtonPanel.Controls.SetChildIndex(this._dateDateIntervalControl, 0);
            this.MaterButtonPanel.Controls.SetChildIndex(this.label1, 0);
            // 
            // SplitContainer
            // 
            // 
            // DetailButtonPanel
            // 
            this.DetailButtonPanel.Controls.Add(this.GoButton);
            this.DetailButtonPanel.Controls.Add(this.DetailAddButton);
            this.DetailButtonPanel.Controls.SetChildIndex(this.DetailCreateButton, 0);
            this.DetailButtonPanel.Controls.SetChildIndex(this.DetailEditButton, 0);
            this.DetailButtonPanel.Controls.SetChildIndex(this.DetailRefreshButton, 0);
            this.DetailButtonPanel.Controls.SetChildIndex(this.DetailFilterControl, 0);
            this.DetailButtonPanel.Controls.SetChildIndex(this.DetailAddButton, 0);
            this.DetailButtonPanel.Controls.SetChildIndex(this.GoButton, 0);
            // 
            // MasterFilterControl
            // 
            this.MasterFilterControl.Location = new System.Drawing.Point(518, 7);
            this.MasterFilterControl.TabIndex = 4;
            // 
            // MasterRefreshButton
            // 
            this.MasterRefreshButton.Location = new System.Drawing.Point(765, 5);
            this.MasterRefreshButton.TabIndex = 5;
            // 
            // MasterEditButton
            // 
            this.MasterEditButton.Enabled = false;
            // 
            // DetailFilterControl
            // 
            this.DetailFilterControl.Location = new System.Drawing.Point(450, 7);
            this.DetailFilterControl.TabIndex = 4;
            // 
            // DetailRefreshButton
            // 
            this.DetailRefreshButton.Location = new System.Drawing.Point(697, 5);
            this.DetailRefreshButton.TabIndex = 5;
            // 
            // DetailEditButton
            // 
            this.DetailEditButton.Enabled = false;
            this.DetailEditButton.TabIndex = 1;
            // 
            // DetailCreateButton
            // 
            this.DetailCreateButton.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(224, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Дата,";
            // 
            // _dateDateIntervalControl
            // 
            this._dateDateIntervalControl.Location = new System.Drawing.Point(259, 7);
            this._dateDateIntervalControl.Name = "_dateDateIntervalControl";
            this._dateDateIntervalControl.Size = new System.Drawing.Size(240, 20);
            this._dateDateIntervalControl.TabIndex = 3;
            // 
            // DetailAddButton
            // 
            this.DetailAddButton.Enabled = false;
            this.DetailAddButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DetailAddButton.Image = global::USClothesWebSite.Win.Properties.Resources.add;
            this.DetailAddButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.DetailAddButton.Location = new System.Drawing.Point(210, 5);
            this.DetailAddButton.Name = "DetailAddButton";
            this.DetailAddButton.Size = new System.Drawing.Size(86, 23);
            this.DetailAddButton.TabIndex = 2;
            this.DetailAddButton.TabStop = false;
            this.DetailAddButton.Text = "Добавить";
            this.DetailAddButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.DetailAddButton.UseVisualStyleBackColor = true;
            this.DetailAddButton.Click += new System.EventHandler(this.DetailAddButton_Click);
            // 
            // GoButton
            // 
            this.GoButton.Enabled = false;
            this.GoButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.GoButton.Image = global::USClothesWebSite.Win.Properties.Resources.GoToNextHS;
            this.GoButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.GoButton.Location = new System.Drawing.Point(302, 5);
            this.GoButton.Name = "GoButton";
            this.GoButton.Size = new System.Drawing.Size(124, 23);
            this.GoButton.TabIndex = 3;
            this.GoButton.TabStop = false;
            this.GoButton.Text = "Перейти к заказу";
            this.GoButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.GoButton.UseVisualStyleBackColor = true;
            this.GoButton.Click += new System.EventHandler(this.GoButton_Click);
            // 
            // ParcelMasterDetailForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 412);
            this.Name = "ParcelMasterDetailForm";
            this.ActionButtonPanel.ResumeLayout(false);
            this.MaterButtonPanel.ResumeLayout(false);
            this.MaterButtonPanel.PerformLayout();
            this.SplitContainer.Panel1.ResumeLayout(false);
            this.SplitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainer)).EndInit();
            this.SplitContainer.ResumeLayout(false);
            this.DetailButtonPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private Controls.DateIntervalControl _dateDateIntervalControl;
        private System.Windows.Forms.Button DetailAddButton;
        private System.Windows.Forms.Button GoButton;
    }
}