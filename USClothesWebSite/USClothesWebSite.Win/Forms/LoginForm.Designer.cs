namespace USClothesWebSite.Win.Forms
{
    partial class LoginForm
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
            this.label2 = new System.Windows.Forms.Label();
            this._loginTextBox = new USClothesWebSite.Win.Controls.WatermarkedTextBox();
            this._passwordMaskedTextBox = new USClothesWebSite.Win.Controls.WatermarkedMaskedTextBox();
            this.SuspendLayout();
            // 
            // CloseButton
            // 
            this.CloseButton.Location = new System.Drawing.Point(176, 108);
            this.CloseButton.TabIndex = 6;
            this.CloseButton.Text = "Выйти";
            // 
            // SaveButton
            // 
            this.SaveButton.Location = new System.Drawing.Point(84, 108);
            this.SaveButton.TabIndex = 5;
            this.SaveButton.Text = "Войти";
            // 
            // ErrorMessageTextBox
            // 
            this.ErrorMessageTextBox.Location = new System.Drawing.Point(12, 10);
            this.ErrorMessageTextBox.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.ErrorMessageTextBox.Size = new System.Drawing.Size(303, 36);
            this.ErrorMessageTextBox.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Логин";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 81);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Пароль";
            // 
            // _loginTextBox
            // 
            this._loginTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._loginTextBox.Location = new System.Drawing.Point(63, 52);
            this._loginTextBox.Name = "_loginTextBox";
            this._loginTextBox.Size = new System.Drawing.Size(252, 20);
            this._loginTextBox.TabIndex = 2;
            this._loginTextBox.Watermark = "Введите логин";
            // 
            // _passwordMaskedTextBox
            // 
            this._passwordMaskedTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._passwordMaskedTextBox.Location = new System.Drawing.Point(63, 78);
            this._passwordMaskedTextBox.Name = "_passwordMaskedTextBox";
            this._passwordMaskedTextBox.PasswordChar = '*';
            this._passwordMaskedTextBox.Size = new System.Drawing.Size(252, 20);
            this._passwordMaskedTextBox.TabIndex = 4;
            this._passwordMaskedTextBox.Watermark = "Введите пароль";
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(327, 148);
            this.ControlBox = false;
            this.Controls.Add(this._loginTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this._passwordMaskedTextBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "LoginForm";
            this.Text = "Вход";
            this.Controls.SetChildIndex(this._passwordMaskedTextBox, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this._loginTextBox, 0);
            this.Controls.SetChildIndex(this.SaveButton, 0);
            this.Controls.SetChildIndex(this.CloseButton, 0);
            this.Controls.SetChildIndex(this.ErrorMessageTextBox, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Controls.WatermarkedMaskedTextBox _passwordMaskedTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private Controls.WatermarkedTextBox _loginTextBox;
    }
}