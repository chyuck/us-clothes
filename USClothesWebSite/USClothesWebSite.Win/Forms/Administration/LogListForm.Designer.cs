namespace USClothesWebSite.Win.Forms.Administration
{
    partial class LogListForm
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
            this._dateDateIntervalControl = new USClothesWebSite.Win.Controls.DateIntervalControl();
            this.label1 = new System.Windows.Forms.Label();
            this.ActionButtonPanel.SuspendLayout();
            this.ButtonPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // ButtonPanel
            // 
            this.ButtonPanel.Controls.Add(this.label1);
            this.ButtonPanel.Controls.Add(this._dateDateIntervalControl);
            this.ButtonPanel.Controls.SetChildIndex(this.CreateButton, 0);
            this.ButtonPanel.Controls.SetChildIndex(this.EditButton, 0);
            this.ButtonPanel.Controls.SetChildIndex(this.RefreshButton, 0);
            this.ButtonPanel.Controls.SetChildIndex(this.FilterControl, 0);
            this.ButtonPanel.Controls.SetChildIndex(this._dateDateIntervalControl, 0);
            this.ButtonPanel.Controls.SetChildIndex(this.label1, 0);
            // 
            // RefreshButton
            // 
            this.RefreshButton.Location = new System.Drawing.Point(540, 5);
            // 
            // EditButton
            // 
            this.EditButton.Location = new System.Drawing.Point(911, 3);
            this.EditButton.Visible = false;
            // 
            // CreateButton
            // 
            this.CreateButton.Location = new System.Drawing.Point(827, 3);
            this.CreateButton.Visible = false;
            // 
            // FilterControl
            // 
            this.FilterControl.Location = new System.Drawing.Point(293, 7);
            // 
            // _dateDateIntervalControl
            // 
            this._dateDateIntervalControl.Location = new System.Drawing.Point(47, 7);
            this._dateDateIntervalControl.Name = "_dateDateIntervalControl";
            this._dateDateIntervalControl.Size = new System.Drawing.Size(240, 20);
            this._dateDateIntervalControl.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Дата,";
            // 
            // LogListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 362);
            this.Name = "LogListForm";
            this.ActionButtonPanel.ResumeLayout(false);
            this.ButtonPanel.ResumeLayout(false);
            this.ButtonPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private Controls.DateIntervalControl _dateDateIntervalControl;
    }
}