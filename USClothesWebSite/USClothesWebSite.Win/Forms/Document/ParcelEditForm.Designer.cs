namespace USClothesWebSite.Win.Forms.Document
{
    partial class ParcelEditForm
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
            this._parcelNumberTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this._trackingNumberTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this._distributorReferenceEditor = new USClothesWebSite.Win.Controls.ReferenceEditor.UserReferenceEditor();
            this.label6 = new System.Windows.Forms.Label();
            this._purchaserSpentOnDeliveryNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this._rublesPerDollarNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this._commentsTextBox = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this._trackableDtoAttributes = new USClothesWebSite.Win.Controls.TrackableDtoAttributes();
            this._sentDatePicker = new USClothesWebSite.Win.Controls.NullableDatePicker();
            this._receivedDatePicker = new USClothesWebSite.Win.Controls.NullableDatePicker();
            this._totalPriceTextBox = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this._purchaserSpentOnDeliveryNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._rublesPerDollarNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // IdTextBox
            // 
            this.IdTextBox.Location = new System.Drawing.Point(135, 66);
            this.IdTextBox.TabIndex = 2;
            // 
            // IdLabel
            // 
            this.IdLabel.Location = new System.Drawing.Point(111, 69);
            this.IdLabel.TabIndex = 1;
            // 
            // CloseButton
            // 
            this.CloseButton.Location = new System.Drawing.Point(430, 506);
            this.CloseButton.TabIndex = 24;
            // 
            // SaveButton
            // 
            this.SaveButton.Location = new System.Drawing.Point(349, 506);
            this.SaveButton.TabIndex = 23;
            // 
            // ErrorMessageTextBox
            // 
            this.ErrorMessageTextBox.Location = new System.Drawing.Point(12, 10);
            this.ErrorMessageTextBox.Size = new System.Drawing.Size(493, 50);
            this.ErrorMessageTextBox.TabIndex = 0;
            // 
            // _parcelNumberTextBox
            // 
            this._parcelNumberTextBox.Location = new System.Drawing.Point(135, 92);
            this._parcelNumberTextBox.Name = "_parcelNumberTextBox";
            this._parcelNumberTextBox.ReadOnly = true;
            this._parcelNumberTextBox.Size = new System.Drawing.Size(140, 20);
            this._parcelNumberTextBox.TabIndex = 4;
            this._parcelNumberTextBox.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(88, 95);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Номер";
            // 
            // _trackingNumberTextBox
            // 
            this._trackingNumberTextBox.Location = new System.Drawing.Point(135, 144);
            this._trackingNumberTextBox.MaxLength = 20;
            this._trackingNumberTextBox.Name = "_trackingNumberTextBox";
            this._trackingNumberTextBox.Size = new System.Drawing.Size(196, 20);
            this._trackingNumberTextBox.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 147);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(117, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Номер отслеживания";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(46, 173);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Дата отправки";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(44, 199);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(85, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Дата прибытия";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(27, 224);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(102, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "Распространитель";
            // 
            // _distributorReferenceEditor
            // 
            this._distributorReferenceEditor.AutoComboBoxRefresh = true;
            this._distributorReferenceEditor.CanBeCleared = true;
            this._distributorReferenceEditor.Location = new System.Drawing.Point(135, 221);
            this._distributorReferenceEditor.Mode = USClothesWebSite.Win.Controls.ReferenceEditor.ReferenceEditorMode.ComboBox;
            this._distributorReferenceEditor.Name = "_distributorReferenceEditor";
            this._distributorReferenceEditor.ReadOnly = false;
            this._distributorReferenceEditor.Size = new System.Drawing.Size(342, 21);
            this._distributorReferenceEditor.TabIndex = 14;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(31, 250);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(98, 13);
            this.label6.TabIndex = 16;
            this.label6.Text = "Цена отправки ($)";
            // 
            // _purchaserSpentOnDeliveryNumericUpDown
            // 
            this._purchaserSpentOnDeliveryNumericUpDown.DecimalPlaces = 2;
            this._purchaserSpentOnDeliveryNumericUpDown.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this._purchaserSpentOnDeliveryNumericUpDown.Location = new System.Drawing.Point(135, 248);
            this._purchaserSpentOnDeliveryNumericUpDown.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this._purchaserSpentOnDeliveryNumericUpDown.Name = "_purchaserSpentOnDeliveryNumericUpDown";
            this._purchaserSpentOnDeliveryNumericUpDown.Size = new System.Drawing.Size(140, 20);
            this._purchaserSpentOnDeliveryNumericUpDown.TabIndex = 17;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(27, 276);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(102, 13);
            this.label7.TabIndex = 18;
            this.label7.Text = "Курс доллара (руб)";
            // 
            // _rublesPerDollarNumericUpDown
            // 
            this._rublesPerDollarNumericUpDown.DecimalPlaces = 2;
            this._rublesPerDollarNumericUpDown.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this._rublesPerDollarNumericUpDown.Location = new System.Drawing.Point(135, 274);
            this._rublesPerDollarNumericUpDown.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this._rublesPerDollarNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this._rublesPerDollarNumericUpDown.Name = "_rublesPerDollarNumericUpDown";
            this._rublesPerDollarNumericUpDown.Size = new System.Drawing.Size(140, 20);
            this._rublesPerDollarNumericUpDown.TabIndex = 19;
            this._rublesPerDollarNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            // 
            // _commentsTextBox
            // 
            this._commentsTextBox.Location = new System.Drawing.Point(135, 300);
            this._commentsTextBox.MaxLength = 1000;
            this._commentsTextBox.Multiline = true;
            this._commentsTextBox.Name = "_commentsTextBox";
            this._commentsTextBox.Size = new System.Drawing.Size(370, 79);
            this._commentsTextBox.TabIndex = 21;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(52, 303);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(77, 13);
            this.label8.TabIndex = 20;
            this.label8.Text = "Комментарий";
            // 
            // _trackableDtoAttributes
            // 
            this._trackableDtoAttributes.Location = new System.Drawing.Point(77, 385);
            this._trackableDtoAttributes.Name = "_trackableDtoAttributes";
            this._trackableDtoAttributes.Size = new System.Drawing.Size(428, 98);
            this._trackableDtoAttributes.TabIndex = 22;
            // 
            // _sentDatePicker
            // 
            this._sentDatePicker.Checked = false;
            this._sentDatePicker.CustomFormat = " ";
            this._sentDatePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this._sentDatePicker.Location = new System.Drawing.Point(135, 170);
            this._sentDatePicker.Name = "_sentDatePicker";
            this._sentDatePicker.ShowCheckBox = true;
            this._sentDatePicker.Size = new System.Drawing.Size(196, 20);
            this._sentDatePicker.TabIndex = 10;
            this._sentDatePicker.UtcValue = null;
            // 
            // _receivedDatePicker
            // 
            this._receivedDatePicker.Checked = false;
            this._receivedDatePicker.CustomFormat = " ";
            this._receivedDatePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this._receivedDatePicker.Location = new System.Drawing.Point(135, 196);
            this._receivedDatePicker.Name = "_receivedDatePicker";
            this._receivedDatePicker.ShowCheckBox = true;
            this._receivedDatePicker.Size = new System.Drawing.Size(196, 20);
            this._receivedDatePicker.TabIndex = 12;
            this._receivedDatePicker.UtcValue = null;
            // 
            // _totalPriceTextBox
            // 
            this._totalPriceTextBox.Location = new System.Drawing.Point(135, 118);
            this._totalPriceTextBox.Name = "_totalPriceTextBox";
            this._totalPriceTextBox.ReadOnly = true;
            this._totalPriceTextBox.Size = new System.Drawing.Size(166, 20);
            this._totalPriceTextBox.TabIndex = 6;
            this._totalPriceTextBox.TabStop = false;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(21, 121);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(108, 13);
            this.label19.TabIndex = 5;
            this.label19.Text = "Итоговая цена (руб)";
            // 
            // ParcelEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(520, 548);
            this.Controls.Add(this._totalPriceTextBox);
            this.Controls.Add(this.label19);
            this.Controls.Add(this._receivedDatePicker);
            this.Controls.Add(this._sentDatePicker);
            this.Controls.Add(this._trackableDtoAttributes);
            this.Controls.Add(this.label8);
            this.Controls.Add(this._commentsTextBox);
            this.Controls.Add(this.label7);
            this.Controls.Add(this._rublesPerDollarNumericUpDown);
            this.Controls.Add(this.label6);
            this.Controls.Add(this._purchaserSpentOnDeliveryNumericUpDown);
            this.Controls.Add(this._distributorReferenceEditor);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this._trackingNumberTextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this._parcelNumberTextBox);
            this.Name = "ParcelEditForm";
            this.Text = "";
            this.Controls.SetChildIndex(this.IdLabel, 0);
            this.Controls.SetChildIndex(this.IdTextBox, 0);
            this.Controls.SetChildIndex(this.SaveButton, 0);
            this.Controls.SetChildIndex(this.CloseButton, 0);
            this.Controls.SetChildIndex(this.ErrorMessageTextBox, 0);
            this.Controls.SetChildIndex(this._parcelNumberTextBox, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this._trackingNumberTextBox, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.label5, 0);
            this.Controls.SetChildIndex(this._distributorReferenceEditor, 0);
            this.Controls.SetChildIndex(this._purchaserSpentOnDeliveryNumericUpDown, 0);
            this.Controls.SetChildIndex(this.label6, 0);
            this.Controls.SetChildIndex(this._rublesPerDollarNumericUpDown, 0);
            this.Controls.SetChildIndex(this.label7, 0);
            this.Controls.SetChildIndex(this._commentsTextBox, 0);
            this.Controls.SetChildIndex(this.label8, 0);
            this.Controls.SetChildIndex(this._trackableDtoAttributes, 0);
            this.Controls.SetChildIndex(this._sentDatePicker, 0);
            this.Controls.SetChildIndex(this._receivedDatePicker, 0);
            this.Controls.SetChildIndex(this.label19, 0);
            this.Controls.SetChildIndex(this._totalPriceTextBox, 0);
            ((System.ComponentModel.ISupportInitialize)(this._purchaserSpentOnDeliveryNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._rublesPerDollarNumericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox _parcelNumberTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox _trackingNumberTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private Controls.ReferenceEditor.UserReferenceEditor _distributorReferenceEditor;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown _purchaserSpentOnDeliveryNumericUpDown;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown _rublesPerDollarNumericUpDown;
        private System.Windows.Forms.TextBox _commentsTextBox;
        private System.Windows.Forms.Label label8;
        private Controls.TrackableDtoAttributes _trackableDtoAttributes;
        private Controls.NullableDatePicker _sentDatePicker;
        private Controls.NullableDatePicker _receivedDatePicker;
        private System.Windows.Forms.TextBox _totalPriceTextBox;
        private System.Windows.Forms.Label label19;
    }
}