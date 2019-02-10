namespace USClothesWebSite.Win.Forms.Base
{
    partial class BaseEditForm
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
            this.SaveButton = new System.Windows.Forms.Button();
            this.ErrorMessageTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // CloseButton
            // 
            this.CloseButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CloseButton.Location = new System.Drawing.Point(383, 304);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Size = new System.Drawing.Size(75, 30);
            this.CloseButton.TabIndex = 10;
            this.CloseButton.Text = "Закрыть";
            this.CloseButton.UseVisualStyleBackColor = true;
            // 
            // SaveButton
            // 
            this.SaveButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.SaveButton.Location = new System.Drawing.Point(302, 304);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(75, 30);
            this.SaveButton.TabIndex = 9;
            this.SaveButton.Text = "Сохранить";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // ErrorMessageTextBox
            // 
            this.ErrorMessageTextBox.BackColor = System.Drawing.SystemColors.Control;
            this.ErrorMessageTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ErrorMessageTextBox.ForeColor = System.Drawing.SystemColors.WindowText;
            this.ErrorMessageTextBox.Location = new System.Drawing.Point(12, 12);
            this.ErrorMessageTextBox.Multiline = true;
            this.ErrorMessageTextBox.Name = "ErrorMessageTextBox";
            this.ErrorMessageTextBox.ReadOnly = true;
            this.ErrorMessageTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.ErrorMessageTextBox.Size = new System.Drawing.Size(446, 50);
            this.ErrorMessageTextBox.TabIndex = 13;
            this.ErrorMessageTextBox.TabStop = false;
            this.ErrorMessageTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // BaseEditForm
            // 
            this.AcceptButton = this.SaveButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.CloseButton;
            this.ClientSize = new System.Drawing.Size(470, 346);
            this.Controls.Add(this.ErrorMessageTextBox);
            this.Controls.Add(this.CloseButton);
            this.Controls.Add(this.SaveButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "BaseEditForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.BaseEditForm_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.BaseEditForm_FormClosed);
            this.Load += new System.EventHandler(this.BaseEditForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        protected System.Windows.Forms.Button CloseButton;
        protected System.Windows.Forms.Button SaveButton;
        protected System.Windows.Forms.TextBox ErrorMessageTextBox;

    }
}