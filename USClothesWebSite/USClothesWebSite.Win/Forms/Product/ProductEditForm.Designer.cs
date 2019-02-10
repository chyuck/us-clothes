namespace USClothesWebSite.Win.Forms.Product
{
    partial class ProductEditForm
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
            this._trackableDtoAttributes = new USClothesWebSite.Win.Controls.TrackableDtoAttributes();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this._activeCheckBox = new System.Windows.Forms.CheckBox();
            this._nameTextBox = new USClothesWebSite.Win.Controls.WatermarkedTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this._descriptionTextBox = new System.Windows.Forms.TextBox();
            this._subCategoryReferenceEditor = new USClothesWebSite.Win.Controls.ReferenceEditor.SubCategoryReferenceEditor();
            this.label4 = new System.Windows.Forms.Label();
            this._brandReferenceEditor = new USClothesWebSite.Win.Controls.ReferenceEditor.BrandReferenceEditor();
            this.label6 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this._vendorURLWatermarkedTextBox = new USClothesWebSite.Win.Controls.WatermarkedTextBox();
            this._previewPicture = new USClothesWebSite.Win.Controls.PreviewPicture.PreviewPicture();
            this.SuspendLayout();
            // 
            // IdTextBox
            // 
            this.IdTextBox.Location = new System.Drawing.Point(270, 75);
            this.IdTextBox.TabIndex = 3;
            // 
            // IdLabel
            // 
            this.IdLabel.Location = new System.Drawing.Point(246, 78);
            this.IdLabel.TabIndex = 2;
            // 
            // CloseButton
            // 
            this.CloseButton.Location = new System.Drawing.Point(565, 445);
            this.CloseButton.TabIndex = 18;
            // 
            // SaveButton
            // 
            this.SaveButton.Location = new System.Drawing.Point(484, 445);
            this.SaveButton.TabIndex = 17;
            // 
            // ErrorMessageTextBox
            // 
            this.ErrorMessageTextBox.Size = new System.Drawing.Size(627, 50);
            this.ErrorMessageTextBox.TabIndex = 0;
            // 
            // _trackableDtoAttributes
            // 
            this._trackableDtoAttributes.Location = new System.Drawing.Point(211, 320);
            this._trackableDtoAttributes.Name = "_trackableDtoAttributes";
            this._trackableDtoAttributes.Size = new System.Drawing.Size(428, 98);
            this._trackableDtoAttributes.TabIndex = 16;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(207, 300);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(57, 13);
            this.label5.TabIndex = 14;
            this.label5.Text = "Активный";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(199, 104);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Название";
            // 
            // _activeCheckBox
            // 
            this._activeCheckBox.AutoSize = true;
            this._activeCheckBox.Checked = true;
            this._activeCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this._activeCheckBox.Location = new System.Drawing.Point(270, 300);
            this._activeCheckBox.Name = "_activeCheckBox";
            this._activeCheckBox.Size = new System.Drawing.Size(15, 14);
            this._activeCheckBox.TabIndex = 15;
            this._activeCheckBox.UseVisualStyleBackColor = true;
            // 
            // _nameTextBox
            // 
            this._nameTextBox.Location = new System.Drawing.Point(270, 101);
            this._nameTextBox.MaxLength = 50;
            this._nameTextBox.Name = "_nameTextBox";
            this._nameTextBox.Size = new System.Drawing.Size(370, 20);
            this._nameTextBox.TabIndex = 5;
            this._nameTextBox.Watermark = "Например \"Платье, розовое, летнее\"";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(207, 182);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Описание";
            // 
            // _descriptionTextBox
            // 
            this._descriptionTextBox.Location = new System.Drawing.Point(270, 179);
            this._descriptionTextBox.MaxLength = 1000;
            this._descriptionTextBox.Multiline = true;
            this._descriptionTextBox.Name = "_descriptionTextBox";
            this._descriptionTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this._descriptionTextBox.Size = new System.Drawing.Size(370, 89);
            this._descriptionTextBox.TabIndex = 11;
            // 
            // _subCategoryReferenceEditor
            // 
            this._subCategoryReferenceEditor.AutoComboBoxRefresh = true;
            this._subCategoryReferenceEditor.CanBeCleared = true;
            this._subCategoryReferenceEditor.Location = new System.Drawing.Point(270, 126);
            this._subCategoryReferenceEditor.Mode = USClothesWebSite.Win.Controls.ReferenceEditor.ReferenceEditorMode.ComboBox;
            this._subCategoryReferenceEditor.Name = "_subCategoryReferenceEditor";
            this._subCategoryReferenceEditor.ReadOnly = false;
            this._subCategoryReferenceEditor.Size = new System.Drawing.Size(370, 21);
            this._subCategoryReferenceEditor.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(173, 130);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(91, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Подкатегория";
            // 
            // _brandReferenceEditor
            // 
            this._brandReferenceEditor.AutoComboBoxRefresh = true;
            this._brandReferenceEditor.CanBeCleared = true;
            this._brandReferenceEditor.Location = new System.Drawing.Point(270, 152);
            this._brandReferenceEditor.Mode = USClothesWebSite.Win.Controls.ReferenceEditor.ReferenceEditorMode.ComboBox;
            this._brandReferenceEditor.Name = "_brandReferenceEditor";
            this._brandReferenceEditor.ReadOnly = false;
            this._brandReferenceEditor.Size = new System.Drawing.Size(370, 21);
            this._brandReferenceEditor.TabIndex = 9;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(221, 156);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(43, 13);
            this.label6.TabIndex = 8;
            this.label6.Text = "Бренд";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(97, 277);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(167, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Ссылка на сайт производителя";
            // 
            // _vendorURLWatermarkedTextBox
            // 
            this._vendorURLWatermarkedTextBox.Location = new System.Drawing.Point(270, 274);
            this._vendorURLWatermarkedTextBox.MaxLength = 1000;
            this._vendorURLWatermarkedTextBox.Name = "_vendorURLWatermarkedTextBox";
            this._vendorURLWatermarkedTextBox.Size = new System.Drawing.Size(370, 20);
            this._vendorURLWatermarkedTextBox.TabIndex = 13;
            this._vendorURLWatermarkedTextBox.Watermark = "";
            // 
            // _previewPicture
            // 
            this._previewPicture.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this._previewPicture.Location = new System.Drawing.Point(12, 68);
            this._previewPicture.Name = "_previewPicture";
            this._previewPicture.Size = new System.Drawing.Size(150, 155);
            this._previewPicture.TabIndex = 1;
            // 
            // ProductEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(653, 486);
            this.Controls.Add(this._previewPicture);
            this.Controls.Add(this.label2);
            this.Controls.Add(this._vendorURLWatermarkedTextBox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this._brandReferenceEditor);
            this.Controls.Add(this.label4);
            this.Controls.Add(this._subCategoryReferenceEditor);
            this.Controls.Add(this._descriptionTextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this._trackableDtoAttributes);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label1);
            this.Controls.Add(this._activeCheckBox);
            this.Controls.Add(this._nameTextBox);
            this.Name = "ProductEditForm";
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
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this._descriptionTextBox, 0);
            this.Controls.SetChildIndex(this._subCategoryReferenceEditor, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this._brandReferenceEditor, 0);
            this.Controls.SetChildIndex(this.label6, 0);
            this.Controls.SetChildIndex(this._vendorURLWatermarkedTextBox, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this._previewPicture, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Controls.TrackableDtoAttributes _trackableDtoAttributes;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox _activeCheckBox;
        private Controls.WatermarkedTextBox _nameTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox _descriptionTextBox;
        private Controls.ReferenceEditor.SubCategoryReferenceEditor _subCategoryReferenceEditor;
        private System.Windows.Forms.Label label4;
        private Controls.ReferenceEditor.BrandReferenceEditor _brandReferenceEditor;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label2;
        private Controls.WatermarkedTextBox _vendorURLWatermarkedTextBox;
        private Controls.PreviewPicture.PreviewPicture _previewPicture;
    }
}