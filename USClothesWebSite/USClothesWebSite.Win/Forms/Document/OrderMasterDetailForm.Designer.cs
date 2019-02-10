namespace USClothesWebSite.Win.Forms.Document
{
    partial class OrderMasterDetailForm
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
            this.ActionButtonPanel.SuspendLayout();
            this.MaterButtonPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainer)).BeginInit();
            this.SplitContainer.Panel1.SuspendLayout();
            this.SplitContainer.Panel2.SuspendLayout();
            this.SplitContainer.SuspendLayout();
            this.DetailButtonPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // MaterButtonPanel
            // 
            this.MaterButtonPanel.Controls.Add(this.label1);
            this.MaterButtonPanel.Controls.Add(this._dateDateIntervalControl);
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
            // DetailFilterControl
            // 
            this.DetailFilterControl.Location = new System.Drawing.Point(612, 5);
            this.DetailFilterControl.Visible = false;
            // 
            // DetailRefreshButton
            // 
            this.DetailRefreshButton.Location = new System.Drawing.Point(210, 5);
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
            // OrderMasterDetailForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 412);
            this.Name = "OrderMasterDetailForm";
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
    }
}