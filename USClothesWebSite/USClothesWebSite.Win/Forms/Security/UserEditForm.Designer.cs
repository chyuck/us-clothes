namespace USClothesWebSite.Win.Forms.Security
{
    partial class UserEditForm
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
            this._firstNameTextBox = new USClothesWebSite.Win.Controls.WatermarkedTextBox();
            this._lastNameTextBox = new USClothesWebSite.Win.Controls.WatermarkedTextBox();
            this._emailTextBox = new USClothesWebSite.Win.Controls.WatermarkedTextBox();
            this._loginTextBox = new USClothesWebSite.Win.Controls.WatermarkedTextBox();
            this._activeCheckBox = new System.Windows.Forms.CheckBox();
            this._rolesCheckedListBox = new System.Windows.Forms.CheckedListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this._trackableDtoAttributes = new USClothesWebSite.Win.Controls.TrackableDtoAttributes();
            this.SuspendLayout();
            // 
            // IdTextBox
            // 
            this.IdTextBox.Location = new System.Drawing.Point(133, 68);
            this.IdTextBox.TabIndex = 2;
            // 
            // IdLabel
            // 
            this.IdLabel.Location = new System.Drawing.Point(109, 71);
            this.IdLabel.TabIndex = 1;
            // 
            // CloseButton
            // 
            this.CloseButton.Location = new System.Drawing.Point(431, 404);
            this.CloseButton.TabIndex = 17;
            // 
            // SaveButton
            // 
            this.SaveButton.Location = new System.Drawing.Point(350, 404);
            this.SaveButton.TabIndex = 16;
            // 
            // ErrorMessageTextBox
            // 
            this.ErrorMessageTextBox.Location = new System.Drawing.Point(15, 12);
            this.ErrorMessageTextBox.Size = new System.Drawing.Size(487, 50);
            this.ErrorMessageTextBox.TabIndex = 0;
            // 
            // _firstNameTextBox
            // 
            this._firstNameTextBox.Location = new System.Drawing.Point(133, 94);
            this._firstNameTextBox.MaxLength = 50;
            this._firstNameTextBox.Name = "_firstNameTextBox";
            this._firstNameTextBox.Size = new System.Drawing.Size(369, 20);
            this._firstNameTextBox.TabIndex = 4;
            this._firstNameTextBox.Watermark = "Введите имя";
            // 
            // _lastNameTextBox
            // 
            this._lastNameTextBox.Location = new System.Drawing.Point(133, 120);
            this._lastNameTextBox.MaxLength = 50;
            this._lastNameTextBox.Name = "_lastNameTextBox";
            this._lastNameTextBox.Size = new System.Drawing.Size(369, 20);
            this._lastNameTextBox.TabIndex = 6;
            this._lastNameTextBox.Watermark = "Введите фамилию";
            // 
            // _emailTextBox
            // 
            this._emailTextBox.Location = new System.Drawing.Point(133, 146);
            this._emailTextBox.MaxLength = 50;
            this._emailTextBox.Name = "_emailTextBox";
            this._emailTextBox.Size = new System.Drawing.Size(369, 20);
            this._emailTextBox.TabIndex = 8;
            this._emailTextBox.Watermark = "Введите электронную почту";
            // 
            // _loginTextBox
            // 
            this._loginTextBox.Location = new System.Drawing.Point(133, 172);
            this._loginTextBox.MaxLength = 50;
            this._loginTextBox.Name = "_loginTextBox";
            this._loginTextBox.Size = new System.Drawing.Size(369, 20);
            this._loginTextBox.TabIndex = 10;
            this._loginTextBox.Watermark = "Введите логин";
            // 
            // _activeCheckBox
            // 
            this._activeCheckBox.AutoSize = true;
            this._activeCheckBox.Checked = true;
            this._activeCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this._activeCheckBox.Location = new System.Drawing.Point(133, 198);
            this._activeCheckBox.Name = "_activeCheckBox";
            this._activeCheckBox.Size = new System.Drawing.Size(15, 14);
            this._activeCheckBox.TabIndex = 12;
            this._activeCheckBox.UseVisualStyleBackColor = true;
            // 
            // _rolesCheckedListBox
            // 
            this._rolesCheckedListBox.CheckOnClick = true;
            this._rolesCheckedListBox.Items.AddRange(new object[] {
            "Администратор",
            "Поставщик",
            "Продавец",
            "Дистрибьютор"});
            this._rolesCheckedListBox.Location = new System.Drawing.Point(133, 322);
            this._rolesCheckedListBox.Name = "_rolesCheckedListBox";
            this._rolesCheckedListBox.Size = new System.Drawing.Size(139, 64);
            this._rolesCheckedListBox.TabIndex = 15;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(95, 97);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Имя";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(64, 123);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Фамилия";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(6, 149);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(121, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Электронная почта";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(84, 175);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Логин";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(70, 198);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(57, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Активный";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label10.Location = new System.Drawing.Point(91, 322);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(36, 13);
            this.label10.TabIndex = 14;
            this.label10.Text = "Роли";
            // 
            // _trackableDtoAttributes
            // 
            this._trackableDtoAttributes.Location = new System.Drawing.Point(74, 218);
            this._trackableDtoAttributes.Name = "_trackableDtoAttributes";
            this._trackableDtoAttributes.Size = new System.Drawing.Size(428, 98);
            this._trackableDtoAttributes.TabIndex = 13;
            // 
            // UserEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(516, 446);
            this.Controls.Add(this._trackableDtoAttributes);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this._rolesCheckedListBox);
            this.Controls.Add(this._activeCheckBox);
            this.Controls.Add(this._loginTextBox);
            this.Controls.Add(this._emailTextBox);
            this.Controls.Add(this._lastNameTextBox);
            this.Controls.Add(this._firstNameTextBox);
            this.Name = "UserEditForm";
            this.Text = "";
            this.Controls.SetChildIndex(this.IdLabel, 0);
            this.Controls.SetChildIndex(this.IdTextBox, 0);
            this.Controls.SetChildIndex(this.SaveButton, 0);
            this.Controls.SetChildIndex(this.CloseButton, 0);
            this.Controls.SetChildIndex(this.ErrorMessageTextBox, 0);
            this.Controls.SetChildIndex(this._firstNameTextBox, 0);
            this.Controls.SetChildIndex(this._lastNameTextBox, 0);
            this.Controls.SetChildIndex(this._emailTextBox, 0);
            this.Controls.SetChildIndex(this._loginTextBox, 0);
            this.Controls.SetChildIndex(this._activeCheckBox, 0);
            this.Controls.SetChildIndex(this._rolesCheckedListBox, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.label5, 0);
            this.Controls.SetChildIndex(this.label10, 0);
            this.Controls.SetChildIndex(this._trackableDtoAttributes, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Controls.WatermarkedTextBox _firstNameTextBox;
        private Controls.WatermarkedTextBox _lastNameTextBox;
        private Controls.WatermarkedTextBox _emailTextBox;
        private Controls.WatermarkedTextBox _loginTextBox;
        private System.Windows.Forms.CheckBox _activeCheckBox;
        private System.Windows.Forms.CheckedListBox _rolesCheckedListBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label10;
        private Controls.TrackableDtoAttributes _trackableDtoAttributes;

    }
}