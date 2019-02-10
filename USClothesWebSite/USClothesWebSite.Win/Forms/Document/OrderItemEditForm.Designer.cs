namespace USClothesWebSite.Win.Forms.Document
{
    partial class OrderItemEditForm
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
            this._orderReferenceEditor = new USClothesWebSite.Win.Controls.ReferenceEditor.OrderReferenceEditor();
            this.label1 = new System.Windows.Forms.Label();
            this._productSizeReferenceEditor = new USClothesWebSite.Win.Controls.ReferenceEditor.ProductSizeReferenceEditor();
            this.label2 = new System.Windows.Forms.Label();
            this._quantityNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this._priceNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this._trackableDtoAttributes = new USClothesWebSite.Win.Controls.TrackableDtoAttributes();
            this.label5 = new System.Windows.Forms.Label();
            this._activeCheckBox = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this._totalPriceTextBox = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this._purchaserPaidNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this._previewPicture = new USClothesWebSite.Win.Controls.PreviewPicture.PreviewPicture();
            ((System.ComponentModel.ISupportInitialize)(this._quantityNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._priceNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._purchaserPaidNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // IdTextBox
            // 
            this.IdTextBox.Location = new System.Drawing.Point(300, 69);
            this.IdTextBox.TabIndex = 2;
            // 
            // IdLabel
            // 
            this.IdLabel.Location = new System.Drawing.Point(276, 72);
            this.IdLabel.TabIndex = 1;
            // 
            // CloseButton
            // 
            this.CloseButton.Location = new System.Drawing.Point(591, 387);
            this.CloseButton.TabIndex = 19;
            // 
            // SaveButton
            // 
            this.SaveButton.Location = new System.Drawing.Point(510, 387);
            this.SaveButton.TabIndex = 18;
            // 
            // ErrorMessageTextBox
            // 
            this.ErrorMessageTextBox.Size = new System.Drawing.Size(704, 50);
            this.ErrorMessageTextBox.TabIndex = 0;
            // 
            // _orderReferenceEditor
            // 
            this._orderReferenceEditor.AutoComboBoxRefresh = true;
            this._orderReferenceEditor.CanBeCleared = true;
            this._orderReferenceEditor.Location = new System.Drawing.Point(300, 95);
            this._orderReferenceEditor.Mode = USClothesWebSite.Win.Controls.ReferenceEditor.ReferenceEditorMode.ReadOnlyTextBox;
            this._orderReferenceEditor.Name = "_orderReferenceEditor";
            this._orderReferenceEditor.ReadOnly = false;
            this._orderReferenceEditor.Size = new System.Drawing.Size(366, 20);
            this._orderReferenceEditor.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(251, 98);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Заказ";
            // 
            // _productSizeReferenceEditor
            // 
            this._productSizeReferenceEditor.AutoComboBoxRefresh = true;
            this._productSizeReferenceEditor.CanBeCleared = true;
            this._productSizeReferenceEditor.Location = new System.Drawing.Point(300, 121);
            this._productSizeReferenceEditor.Mode = USClothesWebSite.Win.Controls.ReferenceEditor.ReferenceEditorMode.ReadOnlyTextBox;
            this._productSizeReferenceEditor.Name = "_productSizeReferenceEditor";
            this._productSizeReferenceEditor.ReadOnly = false;
            this._productSizeReferenceEditor.Size = new System.Drawing.Size(366, 20);
            this._productSizeReferenceEditor.TabIndex = 6;
            this._productSizeReferenceEditor.ValueChanged += new System.EventHandler(this.ProductSizeReferenceEditor_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(197, 124);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Размер товара";
            // 
            // _quantityNumericUpDown
            // 
            this._quantityNumericUpDown.Location = new System.Drawing.Point(300, 147);
            this._quantityNumericUpDown.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this._quantityNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this._quantityNumericUpDown.Name = "_quantityNumericUpDown";
            this._quantityNumericUpDown.Size = new System.Drawing.Size(120, 20);
            this._quantityNumericUpDown.TabIndex = 8;
            this._quantityNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this._quantityNumericUpDown.ValueChanged += new System.EventHandler(this.ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(218, 149);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Количество";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(225, 175);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Цена (руб)";
            // 
            // _priceNumericUpDown
            // 
            this._priceNumericUpDown.DecimalPlaces = 2;
            this._priceNumericUpDown.Location = new System.Drawing.Point(300, 173);
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
            this._priceNumericUpDown.TabIndex = 10;
            this._priceNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this._priceNumericUpDown.ValueChanged += new System.EventHandler(this.ValueChanged);
            // 
            // _trackableDtoAttributes
            // 
            this._trackableDtoAttributes.Location = new System.Drawing.Point(238, 271);
            this._trackableDtoAttributes.Name = "_trackableDtoAttributes";
            this._trackableDtoAttributes.Size = new System.Drawing.Size(428, 98);
            this._trackableDtoAttributes.TabIndex = 17;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(237, 225);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(57, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "Активный";
            // 
            // _activeCheckBox
            // 
            this._activeCheckBox.AutoSize = true;
            this._activeCheckBox.Checked = true;
            this._activeCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this._activeCheckBox.Location = new System.Drawing.Point(300, 225);
            this._activeCheckBox.Name = "_activeCheckBox";
            this._activeCheckBox.Size = new System.Drawing.Size(15, 14);
            this._activeCheckBox.TabIndex = 14;
            this._activeCheckBox.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(186, 202);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(108, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Итоговая цена (руб)";
            // 
            // _totalPriceTextBox
            // 
            this._totalPriceTextBox.Location = new System.Drawing.Point(300, 199);
            this._totalPriceTextBox.Name = "_totalPriceTextBox";
            this._totalPriceTextBox.ReadOnly = true;
            this._totalPriceTextBox.Size = new System.Drawing.Size(166, 20);
            this._totalPriceTextBox.TabIndex = 12;
            this._totalPriceTextBox.TabStop = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(202, 247);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(92, 13);
            this.label7.TabIndex = 15;
            this.label7.Text = "Цена покупки ($)";
            // 
            // _purchaserPaidNumericUpDown
            // 
            this._purchaserPaidNumericUpDown.DecimalPlaces = 2;
            this._purchaserPaidNumericUpDown.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this._purchaserPaidNumericUpDown.Location = new System.Drawing.Point(300, 245);
            this._purchaserPaidNumericUpDown.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this._purchaserPaidNumericUpDown.Name = "_purchaserPaidNumericUpDown";
            this._purchaserPaidNumericUpDown.Size = new System.Drawing.Size(166, 20);
            this._purchaserPaidNumericUpDown.TabIndex = 16;
            // 
            // _previewPicture
            // 
            this._previewPicture.Enabled = false;
            this._previewPicture.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this._previewPicture.Location = new System.Drawing.Point(12, 69);
            this._previewPicture.Name = "_previewPicture";
            this._previewPicture.Size = new System.Drawing.Size(150, 155);
            this._previewPicture.TabIndex = 20;
            // 
            // OrderItemEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(680, 429);
            this.Controls.Add(this._previewPicture);
            this.Controls.Add(this.label7);
            this.Controls.Add(this._purchaserPaidNumericUpDown);
            this.Controls.Add(this._totalPriceTextBox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this._trackableDtoAttributes);
            this.Controls.Add(this.label5);
            this.Controls.Add(this._activeCheckBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this._priceNumericUpDown);
            this.Controls.Add(this.label3);
            this.Controls.Add(this._quantityNumericUpDown);
            this.Controls.Add(this.label2);
            this.Controls.Add(this._productSizeReferenceEditor);
            this.Controls.Add(this.label1);
            this.Controls.Add(this._orderReferenceEditor);
            this.Name = "OrderItemEditForm";
            this.Text = "";
            this.Controls.SetChildIndex(this.IdLabel, 0);
            this.Controls.SetChildIndex(this.IdTextBox, 0);
            this.Controls.SetChildIndex(this.SaveButton, 0);
            this.Controls.SetChildIndex(this.CloseButton, 0);
            this.Controls.SetChildIndex(this.ErrorMessageTextBox, 0);
            this.Controls.SetChildIndex(this._orderReferenceEditor, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this._productSizeReferenceEditor, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this._quantityNumericUpDown, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this._priceNumericUpDown, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this._activeCheckBox, 0);
            this.Controls.SetChildIndex(this.label5, 0);
            this.Controls.SetChildIndex(this._trackableDtoAttributes, 0);
            this.Controls.SetChildIndex(this.label6, 0);
            this.Controls.SetChildIndex(this._totalPriceTextBox, 0);
            this.Controls.SetChildIndex(this._purchaserPaidNumericUpDown, 0);
            this.Controls.SetChildIndex(this.label7, 0);
            this.Controls.SetChildIndex(this._previewPicture, 0);
            ((System.ComponentModel.ISupportInitialize)(this._quantityNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._priceNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._purchaserPaidNumericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Controls.ReferenceEditor.OrderReferenceEditor _orderReferenceEditor;
        private System.Windows.Forms.Label label1;
        private Controls.ReferenceEditor.ProductSizeReferenceEditor _productSizeReferenceEditor;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown _quantityNumericUpDown;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown _priceNumericUpDown;
        private Controls.TrackableDtoAttributes _trackableDtoAttributes;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox _activeCheckBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox _totalPriceTextBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown _purchaserPaidNumericUpDown;
        private Controls.PreviewPicture.PreviewPicture _previewPicture;
    }
}