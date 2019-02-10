namespace USClothesWebSite.Win.Forms.Dictionary
{
    partial class SubCategoryEditForm
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
            this.label2 = new System.Windows.Forms.Label();
            this._categoryReferenceEditor = new USClothesWebSite.Win.Controls.ReferenceEditor.CategoryReferenceEditor();
            this.SuspendLayout();
            // 
            // IdTextBox
            // 
            this.IdTextBox.Location = new System.Drawing.Point(80, 75);
            this.IdTextBox.TabIndex = 2;
            // 
            // IdLabel
            // 
            this.IdLabel.Location = new System.Drawing.Point(56, 78);
            this.IdLabel.TabIndex = 1;
            // 
            // CloseButton
            // 
            this.CloseButton.Location = new System.Drawing.Point(376, 291);
            this.CloseButton.TabIndex = 11;
            // 
            // SaveButton
            // 
            this.SaveButton.Location = new System.Drawing.Point(295, 291);
            this.SaveButton.TabIndex = 10;
            // 
            // ErrorMessageTextBox
            // 
            this.ErrorMessageTextBox.Location = new System.Drawing.Point(17, 12);
            this.ErrorMessageTextBox.Size = new System.Drawing.Size(432, 50);
            this.ErrorMessageTextBox.TabIndex = 0;
            // 
            // _trackableDtoAttributes
            // 
            this._trackableDtoAttributes.Location = new System.Drawing.Point(21, 173);
            this._trackableDtoAttributes.Name = "_trackableDtoAttributes";
            this._trackableDtoAttributes.Size = new System.Drawing.Size(428, 98);
            this._trackableDtoAttributes.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(17, 127);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(57, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "Активный";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(9, 104);
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
            this._activeCheckBox.Location = new System.Drawing.Point(80, 127);
            this._activeCheckBox.Name = "_activeCheckBox";
            this._activeCheckBox.Size = new System.Drawing.Size(15, 14);
            this._activeCheckBox.TabIndex = 6;
            this._activeCheckBox.UseVisualStyleBackColor = true;
            // 
            // _nameTextBox
            // 
            this._nameTextBox.Location = new System.Drawing.Point(80, 101);
            this._nameTextBox.MaxLength = 50;
            this._nameTextBox.Name = "_nameTextBox";
            this._nameTextBox.Size = new System.Drawing.Size(369, 20);
            this._nameTextBox.TabIndex = 4;
            this._nameTextBox.Watermark = "Например \"Мальчики от 0 до 2 лет\"";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(5, 150);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Категория";
            // 
            // _categoryReferenceEditor
            // 
            this._categoryReferenceEditor.AutoComboBoxRefresh = true;
            this._categoryReferenceEditor.CanBeCleared = true;
            this._categoryReferenceEditor.Location = new System.Drawing.Point(80, 146);
            this._categoryReferenceEditor.Mode = USClothesWebSite.Win.Controls.ReferenceEditor.ReferenceEditorMode.ComboBox;
            this._categoryReferenceEditor.Name = "_categoryReferenceEditor";
            this._categoryReferenceEditor.ReadOnly = false;
            this._categoryReferenceEditor.Size = new System.Drawing.Size(369, 21);
            this._categoryReferenceEditor.TabIndex = 8;
            // 
            // SubCategoryEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(461, 333);
            this.Controls.Add(this._categoryReferenceEditor);
            this.Controls.Add(this.label2);
            this.Controls.Add(this._trackableDtoAttributes);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label1);
            this.Controls.Add(this._activeCheckBox);
            this.Controls.Add(this._nameTextBox);
            this.Name = "SubCategoryEditForm";
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
            this.Controls.SetChildIndex(this._categoryReferenceEditor, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Controls.TrackableDtoAttributes _trackableDtoAttributes;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox _activeCheckBox;
        private Controls.WatermarkedTextBox _nameTextBox;
        private System.Windows.Forms.Label label2;
        private Controls.ReferenceEditor.CategoryReferenceEditor _categoryReferenceEditor;
    }
}