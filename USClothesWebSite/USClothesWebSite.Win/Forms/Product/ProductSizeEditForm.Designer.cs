namespace USClothesWebSite.Win.Forms.Product
{
    partial class ProductSizeEditForm
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
            this._productReferenceEditor = new USClothesWebSite.Win.Controls.ReferenceEditor.ProductReferenceEditor();
            this._sizeReferenceEditor = new USClothesWebSite.Win.Controls.ReferenceEditor.SizeReferenceEditor();
            this._priceNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this._activeCheckBox = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this._trackableDtoAttributes = new USClothesWebSite.Win.Controls.TrackableDtoAttributes();
            ((System.ComponentModel.ISupportInitialize)(this._priceNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // IdTextBox
            // 
            this.IdTextBox.Location = new System.Drawing.Point(81, 72);
            this.IdTextBox.TabIndex = 2;
            // 
            // IdLabel
            // 
            this.IdLabel.Location = new System.Drawing.Point(57, 75);
            this.IdLabel.TabIndex = 1;
            // 
            // CloseButton
            // 
            this.CloseButton.Location = new System.Drawing.Point(374, 311);
            this.CloseButton.TabIndex = 13;
            // 
            // SaveButton
            // 
            this.SaveButton.Location = new System.Drawing.Point(293, 311);
            this.SaveButton.TabIndex = 12;
            // 
            // ErrorMessageTextBox
            // 
            this.ErrorMessageTextBox.Location = new System.Drawing.Point(16, 12);
            this.ErrorMessageTextBox.Size = new System.Drawing.Size(433, 50);
            this.ErrorMessageTextBox.TabIndex = 0;
            // 
            // _productReferenceEditor
            // 
            this._productReferenceEditor.AutoComboBoxRefresh = true;
            this._productReferenceEditor.CanBeCleared = true;
            this._productReferenceEditor.Location = new System.Drawing.Point(81, 98);
            this._productReferenceEditor.Mode = USClothesWebSite.Win.Controls.ReferenceEditor.ReferenceEditorMode.ReadOnlyTextBox;
            this._productReferenceEditor.Name = "_productReferenceEditor";
            this._productReferenceEditor.ReadOnly = false;
            this._productReferenceEditor.Size = new System.Drawing.Size(368, 20);
            this._productReferenceEditor.TabIndex = 4;
            this._productReferenceEditor.ValueChanged += new System.EventHandler(this.ProductReferenceEditor_ValueChanged);
            // 
            // _sizeReferenceEditor
            // 
            this._sizeReferenceEditor.AutoComboBoxRefresh = true;
            this._sizeReferenceEditor.CanBeCleared = true;
            this._sizeReferenceEditor.Location = new System.Drawing.Point(81, 123);
            this._sizeReferenceEditor.Mode = USClothesWebSite.Win.Controls.ReferenceEditor.ReferenceEditorMode.ComboBox;
            this._sizeReferenceEditor.Name = "_sizeReferenceEditor";
            this._sizeReferenceEditor.ReadOnly = false;
            this._sizeReferenceEditor.Size = new System.Drawing.Size(368, 21);
            this._sizeReferenceEditor.TabIndex = 6;
            // 
            // _priceNumericUpDown
            // 
            this._priceNumericUpDown.DecimalPlaces = 2;
            this._priceNumericUpDown.Location = new System.Drawing.Point(81, 150);
            this._priceNumericUpDown.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this._priceNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this._priceNumericUpDown.Name = "_priceNumericUpDown";
            this._priceNumericUpDown.Size = new System.Drawing.Size(166, 20);
            this._priceNumericUpDown.TabIndex = 8;
            this._priceNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(18, 176);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(57, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Активный";
            // 
            // _activeCheckBox
            // 
            this._activeCheckBox.AutoSize = true;
            this._activeCheckBox.Checked = true;
            this._activeCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this._activeCheckBox.Location = new System.Drawing.Point(81, 176);
            this._activeCheckBox.Name = "_activeCheckBox";
            this._activeCheckBox.Size = new System.Drawing.Size(15, 14);
            this._activeCheckBox.TabIndex = 10;
            this._activeCheckBox.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(6, 152);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Цена (руб)";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(32, 101);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Товар";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(23, 127);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Размер";
            // 
            // _trackableDtoAttributes
            // 
            this._trackableDtoAttributes.Location = new System.Drawing.Point(21, 196);
            this._trackableDtoAttributes.Name = "_trackableDtoAttributes";
            this._trackableDtoAttributes.Size = new System.Drawing.Size(428, 98);
            this._trackableDtoAttributes.TabIndex = 11;
            // 
            // ProductSizeEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(457, 353);
            this.Controls.Add(this._trackableDtoAttributes);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this._activeCheckBox);
            this.Controls.Add(this._priceNumericUpDown);
            this.Controls.Add(this._sizeReferenceEditor);
            this.Controls.Add(this._productReferenceEditor);
            this.Name = "ProductSizeEditForm";
            this.Text = "";
            this.Controls.SetChildIndex(this.IdLabel, 0);
            this.Controls.SetChildIndex(this.IdTextBox, 0);
            this.Controls.SetChildIndex(this.SaveButton, 0);
            this.Controls.SetChildIndex(this.CloseButton, 0);
            this.Controls.SetChildIndex(this.ErrorMessageTextBox, 0);
            this.Controls.SetChildIndex(this._productReferenceEditor, 0);
            this.Controls.SetChildIndex(this._sizeReferenceEditor, 0);
            this.Controls.SetChildIndex(this._priceNumericUpDown, 0);
            this.Controls.SetChildIndex(this._activeCheckBox, 0);
            this.Controls.SetChildIndex(this.label5, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this._trackableDtoAttributes, 0);
            ((System.ComponentModel.ISupportInitialize)(this._priceNumericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Controls.ReferenceEditor.ProductReferenceEditor _productReferenceEditor;
        private Controls.ReferenceEditor.SizeReferenceEditor _sizeReferenceEditor;
        private System.Windows.Forms.NumericUpDown _priceNumericUpDown;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox _activeCheckBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private Controls.TrackableDtoAttributes _trackableDtoAttributes;
    }
}