namespace USClothesWebSite.Win.Forms.Security
{
    partial class UserListForm
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
            this._resetPasswordButton = new System.Windows.Forms.Button();
            this.ActionButtonPanel.SuspendLayout();
            this.ButtonPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // ButtonPanel
            // 
            this.ButtonPanel.Controls.Add(this._resetPasswordButton);
            this.ButtonPanel.Controls.SetChildIndex(this.FilterControl, 0);
            this.ButtonPanel.Controls.SetChildIndex(this.CreateButton, 0);
            this.ButtonPanel.Controls.SetChildIndex(this.EditButton, 0);
            this.ButtonPanel.Controls.SetChildIndex(this.RefreshButton, 0);
            this.ButtonPanel.Controls.SetChildIndex(this._resetPasswordButton, 0);
            // 
            // RefreshButton
            // 
            this.RefreshButton.Location = new System.Drawing.Point(614, 5);
            this.RefreshButton.TabIndex = 6;
            // 
            // FilterControl
            // 
            this.FilterControl.Location = new System.Drawing.Point(367, 7);
            // 
            // _resetPasswordButton
            // 
            this._resetPasswordButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._resetPasswordButton.Image = global::USClothesWebSite.Win.Properties.Resources.GetPermission_16x16_72;
            this._resetPasswordButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this._resetPasswordButton.Location = new System.Drawing.Point(210, 5);
            this._resetPasswordButton.Name = "_resetPasswordButton";
            this._resetPasswordButton.Size = new System.Drawing.Size(124, 23);
            this._resetPasswordButton.TabIndex = 2;
            this._resetPasswordButton.TabStop = false;
            this._resetPasswordButton.Text = "Сбросить пароль";
            this._resetPasswordButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this._resetPasswordButton.UseVisualStyleBackColor = true;
            this._resetPasswordButton.Click += new System.EventHandler(this.ResetPasswordButton_Click);
            // 
            // UserListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 362);
            this.Name = "UserListForm";
            this.ActionButtonPanel.ResumeLayout(false);
            this.ButtonPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        protected System.Windows.Forms.Button _resetPasswordButton;

    }
}