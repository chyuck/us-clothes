namespace USClothesWebSite.Win.Forms.Report
{
    partial class DistributorReportListForm
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
            this.ActionButtonPanel.SuspendLayout();
            this.ButtonPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // RefreshButton
            // 
            this.RefreshButton.Location = new System.Drawing.Point(6, 5);
            this.RefreshButton.TabIndex = 0;
            // 
            // EditButton
            // 
            this.EditButton.Location = new System.Drawing.Point(891, 5);
            this.EditButton.Visible = false;
            // 
            // CreateButton
            // 
            this.CreateButton.Location = new System.Drawing.Point(807, 5);
            this.CreateButton.Visible = false;
            // 
            // FilterControl
            // 
            this.FilterControl.Location = new System.Drawing.Point(1049, 7);
            this.FilterControl.Visible = false;
            // 
            // DistributorReportListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 362);
            this.Name = "DistributorReportListForm";
            this.ActionButtonPanel.ResumeLayout(false);
            this.ButtonPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
    }
}