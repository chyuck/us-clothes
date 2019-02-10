namespace USClothesWebSite.Win.Forms.Dictionary
{
    partial class SizeEditForm
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
            this._trackableDtoAttributes = new USClothesWebSite.Win.Controls.TrackableDtoAttributes();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this._activeCheckBox = new System.Windows.Forms.CheckBox();
            this._nameTextBox = new USClothesWebSite.Win.Controls.WatermarkedTextBox();
            this._subCategoryReferenceEditor = new USClothesWebSite.Win.Controls.ReferenceEditor.SubCategoryReferenceEditor();
            this.label3 = new System.Windows.Forms.Label();
            this._brandReferenceEditor = new USClothesWebSite.Win.Controls.ReferenceEditor.BrandReferenceEditor();
            this.label4 = new System.Windows.Forms.Label();
            this._weightTextBox = new USClothesWebSite.Win.Controls.WatermarkedTextBox();
            this._heightTextBox = new USClothesWebSite.Win.Controls.WatermarkedTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // IdTextBox
            // 
            this.IdTextBox.Location = new System.Drawing.Point(103, 72);
            this.IdTextBox.TabIndex = 2;
            // 
            // IdLabel
            // 
            this.IdLabel.Location = new System.Drawing.Point(79, 75);
            this.IdLabel.TabIndex = 1;
            // 
            // CloseButton
            // 
            this.CloseButton.Location = new System.Drawing.Point(397, 364);
            this.CloseButton.TabIndex = 17;
            // 
            // SaveButton
            // 
            this.SaveButton.Location = new System.Drawing.Point(316, 364);
            this.SaveButton.TabIndex = 16;
            // 
            // ErrorMessageTextBox
            // 
            this.ErrorMessageTextBox.Location = new System.Drawing.Point(13, 12);
            this.ErrorMessageTextBox.Size = new System.Drawing.Size(459, 50);
            this.ErrorMessageTextBox.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(6, 147);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Подкатегория";
            // 
            // _trackableDtoAttributes
            // 
            this._trackableDtoAttributes.Location = new System.Drawing.Point(44, 248);
            this._trackableDtoAttributes.Name = "_trackableDtoAttributes";
            this._trackableDtoAttributes.Size = new System.Drawing.Size(428, 98);
            this._trackableDtoAttributes.TabIndex = 15;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(40, 124);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(57, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "Активный";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(32, 101);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Название";
            // 
            // _activeCheckBox
            // 
            this._activeCheckBox.AutoSize = true;
            this._activeCheckBox.Checked = true;
            this._activeCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this._activeCheckBox.Location = new System.Drawing.Point(103, 124);
            this._activeCheckBox.Name = "_activeCheckBox";
            this._activeCheckBox.Size = new System.Drawing.Size(15, 14);
            this._activeCheckBox.TabIndex = 6;
            this._activeCheckBox.UseVisualStyleBackColor = true;
            // 
            // _nameTextBox
            // 
            this._nameTextBox.Location = new System.Drawing.Point(103, 98);
            this._nameTextBox.MaxLength = 50;
            this._nameTextBox.Name = "_nameTextBox";
            this._nameTextBox.Size = new System.Drawing.Size(369, 20);
            this._nameTextBox.TabIndex = 4;
            this._nameTextBox.Watermark = "Например \"3M\"";
            // 
            // _subCategoryReferenceEditor
            // 
            this._subCategoryReferenceEditor.AutoComboBoxRefresh = true;
            this._subCategoryReferenceEditor.CanBeCleared = true;
            this._subCategoryReferenceEditor.Location = new System.Drawing.Point(103, 143);
            this._subCategoryReferenceEditor.Mode = USClothesWebSite.Win.Controls.ReferenceEditor.ReferenceEditorMode.ComboBox;
            this._subCategoryReferenceEditor.Name = "_subCategoryReferenceEditor";
            this._subCategoryReferenceEditor.ReadOnly = false;
            this._subCategoryReferenceEditor.Size = new System.Drawing.Size(369, 21);
            this._subCategoryReferenceEditor.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(54, 173);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Бренд";
            // 
            // _brandReferenceEditor
            // 
            this._brandReferenceEditor.AutoComboBoxRefresh = true;
            this._brandReferenceEditor.CanBeCleared = true;
            this._brandReferenceEditor.Location = new System.Drawing.Point(103, 169);
            this._brandReferenceEditor.Mode = USClothesWebSite.Win.Controls.ReferenceEditor.ReferenceEditorMode.ComboBox;
            this._brandReferenceEditor.Name = "_brandReferenceEditor";
            this._brandReferenceEditor.ReadOnly = false;
            this._brandReferenceEditor.Size = new System.Drawing.Size(369, 21);
            this._brandReferenceEditor.TabIndex = 10;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(71, 225);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(26, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "Вес";
            // 
            // _weightTextBox
            // 
            this._weightTextBox.Location = new System.Drawing.Point(103, 222);
            this._weightTextBox.MaxLength = 30;
            this._weightTextBox.Name = "_weightTextBox";
            this._weightTextBox.Size = new System.Drawing.Size(246, 20);
            this._weightTextBox.TabIndex = 14;
            this._weightTextBox.Watermark = "Например \"3,6 – 5,7 кг\"";
            // 
            // _heightTextBox
            // 
            this._heightTextBox.Location = new System.Drawing.Point(103, 196);
            this._heightTextBox.MaxLength = 30;
            this._heightTextBox.Name = "_heightTextBox";
            this._heightTextBox.Size = new System.Drawing.Size(246, 20);
            this._heightTextBox.TabIndex = 12;
            this._heightTextBox.Watermark = "Например \"55 – 61 см\"";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(66, 199);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(31, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Рост";
            // 
            // SizeEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 406);
            this.Controls.Add(this._heightTextBox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this._weightTextBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this._brandReferenceEditor);
            this.Controls.Add(this.label3);
            this.Controls.Add(this._subCategoryReferenceEditor);
            this.Controls.Add(this.label2);
            this.Controls.Add(this._trackableDtoAttributes);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label1);
            this.Controls.Add(this._activeCheckBox);
            this.Controls.Add(this._nameTextBox);
            this.Name = "SizeEditForm";
            this.Text = "";
            this.Controls.SetChildIndex(this.IdLabel, 0);
            this.Controls.SetChildIndex(this.IdTextBox, 0);
            this.Controls.SetChildIndex(this.SaveButton, 0);
            this.Controls.SetChildIndex(this.CloseButton, 0);
            this.Controls.SetChildIndex(this.ErrorMessageTextBox, 0);
            this.Controls.SetChildIndex(this._nameTextBox, 0);
            this.Controls.SetChildIndex(this._activeCheckBox, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label5, 0);
            this.Controls.SetChildIndex(this._trackableDtoAttributes, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this._subCategoryReferenceEditor, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this._brandReferenceEditor, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this._weightTextBox, 0);
            this.Controls.SetChildIndex(this.label6, 0);
            this.Controls.SetChildIndex(this._heightTextBox, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private Controls.TrackableDtoAttributes _trackableDtoAttributes;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox _activeCheckBox;
        private Controls.WatermarkedTextBox _nameTextBox;
        private Controls.ReferenceEditor.SubCategoryReferenceEditor _subCategoryReferenceEditor;
        private System.Windows.Forms.Label label3;
        private Controls.ReferenceEditor.BrandReferenceEditor _brandReferenceEditor;
        private System.Windows.Forms.Label label4;
        private Controls.WatermarkedTextBox _weightTextBox;
        private Controls.WatermarkedTextBox _heightTextBox;
        private System.Windows.Forms.Label label6;
    }
}