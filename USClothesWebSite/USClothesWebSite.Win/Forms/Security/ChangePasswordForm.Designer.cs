namespace USClothesWebSite.Win.Forms.Security
{
    partial class ChangePasswordForm
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
            this.label2 = new System.Windows.Forms.Label();
            this._newPasswordMaskedTextBox = new USClothesWebSite.Win.Controls.WatermarkedMaskedTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this._passwordConfirmationMaskedTextBox = new USClothesWebSite.Win.Controls.WatermarkedMaskedTextBox();
            this.SuspendLayout();
            // 
            // CloseButton
            // 
            this.CloseButton.Location = new System.Drawing.Point(334, 123);
            this.CloseButton.TabIndex = 6;
            // 
            // SaveButton
            // 
            this.SaveButton.Location = new System.Drawing.Point(253, 123);
            this.SaveButton.TabIndex = 5;
            // 
            // ErrorMessageTextBox
            // 
            this.ErrorMessageTextBox.Size = new System.Drawing.Size(397, 34);
            this.ErrorMessageTextBox.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(59, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Новый пароль";
            // 
            // _newPasswordMaskedTextBox
            // 
            this._newPasswordMaskedTextBox.Location = new System.Drawing.Point(157, 61);
            this._newPasswordMaskedTextBox.Name = "_newPasswordMaskedTextBox";
            this._newPasswordMaskedTextBox.PasswordChar = '*';
            this._newPasswordMaskedTextBox.Size = new System.Drawing.Size(252, 20);
            this._newPasswordMaskedTextBox.TabIndex = 2;
            this._newPasswordMaskedTextBox.Watermark = "Введите новый пароль";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(4, 90);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(147, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Подтверждение пароля";
            // 
            // _passwordConfirmationMaskedTextBox
            // 
            this._passwordConfirmationMaskedTextBox.Location = new System.Drawing.Point(157, 87);
            this._passwordConfirmationMaskedTextBox.Name = "_passwordConfirmationMaskedTextBox";
            this._passwordConfirmationMaskedTextBox.PasswordChar = '*';
            this._passwordConfirmationMaskedTextBox.Size = new System.Drawing.Size(252, 20);
            this._passwordConfirmationMaskedTextBox.TabIndex = 4;
            this._passwordConfirmationMaskedTextBox.Watermark = "Введите подтверждение пароля";
            // 
            // ChangePasswordForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(418, 161);
            this.Controls.Add(this._passwordConfirmationMaskedTextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this._newPasswordMaskedTextBox);
            this.Name = "ChangePasswordForm";
            this.Text = "Смена пароля";
            this.Controls.SetChildIndex(this.SaveButton, 0);
            this.Controls.SetChildIndex(this.CloseButton, 0);
            this.Controls.SetChildIndex(this.ErrorMessageTextBox, 0);
            this.Controls.SetChildIndex(this._newPasswordMaskedTextBox, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this._passwordConfirmationMaskedTextBox, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private Controls.WatermarkedMaskedTextBox _newPasswordMaskedTextBox;
        private System.Windows.Forms.Label label1;
        private Controls.WatermarkedMaskedTextBox _passwordConfirmationMaskedTextBox;
    }
}