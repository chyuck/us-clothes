namespace USClothesWebSite.Win.Forms.Report
{
    partial class ParcelReportEditForm
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
            this._parcelNameTextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this._receivedDatePicker = new USClothesWebSite.Win.Controls.NullableDatePicker();
            this._sentDatePicker = new USClothesWebSite.Win.Controls.NullableDatePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this._distributorTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this._purchaserPaidNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this._purchaserSpentOnDeliveryNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this._distributorSpentOnDeliveryNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this._totalPaidNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label9 = new System.Windows.Forms.Label();
            this._customersPrepaidNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label10 = new System.Windows.Forms.Label();
            this._customersPaidNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label11 = new System.Windows.Forms.Label();
            this._totalCustomersPaidNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label12 = new System.Windows.Forms.Label();
            this._expectedTotalCustomerPaidNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label13 = new System.Windows.Forms.Label();
            this._totalProfitNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label14 = new System.Windows.Forms.Label();
            this._expectedTotalProfitNumericUpDown = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this._purchaserPaidNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._purchaserSpentOnDeliveryNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._distributorSpentOnDeliveryNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._totalPaidNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._customersPrepaidNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._customersPaidNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._totalCustomersPaidNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._expectedTotalCustomerPaidNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._totalProfitNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._expectedTotalProfitNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // IdTextBox
            // 
            this.IdTextBox.Location = new System.Drawing.Point(188, 10);
            this.IdTextBox.TabIndex = 1;
            // 
            // IdLabel
            // 
            this.IdLabel.Location = new System.Drawing.Point(164, 13);
            this.IdLabel.TabIndex = 0;
            // 
            // CloseButton
            // 
            this.CloseButton.Location = new System.Drawing.Point(347, 410);
            this.CloseButton.TabIndex = 31;
            // 
            // SaveButton
            // 
            this.SaveButton.Location = new System.Drawing.Point(266, 410);
            this.SaveButton.TabIndex = 30;
            // 
            // ErrorMessageTextBox
            // 
            this.ErrorMessageTextBox.Location = new System.Drawing.Point(24, 469);
            this.ErrorMessageTextBox.Size = new System.Drawing.Size(43, 21);
            // 
            // _parcelNameTextBox
            // 
            this._parcelNameTextBox.Location = new System.Drawing.Point(188, 36);
            this._parcelNameTextBox.Name = "_parcelNameTextBox";
            this._parcelNameTextBox.Size = new System.Drawing.Size(196, 20);
            this._parcelNameTextBox.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(129, 39);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "Посылка";
            // 
            // _receivedDatePicker
            // 
            this._receivedDatePicker.Checked = false;
            this._receivedDatePicker.CustomFormat = " ";
            this._receivedDatePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this._receivedDatePicker.Location = new System.Drawing.Point(188, 88);
            this._receivedDatePicker.Name = "_receivedDatePicker";
            this._receivedDatePicker.ShowCheckBox = true;
            this._receivedDatePicker.Size = new System.Drawing.Size(196, 20);
            this._receivedDatePicker.TabIndex = 7;
            this._receivedDatePicker.UtcValue = null;
            // 
            // _sentDatePicker
            // 
            this._sentDatePicker.Checked = false;
            this._sentDatePicker.CustomFormat = " ";
            this._sentDatePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this._sentDatePicker.Location = new System.Drawing.Point(188, 62);
            this._sentDatePicker.Name = "_sentDatePicker";
            this._sentDatePicker.ShowCheckBox = true;
            this._sentDatePicker.Size = new System.Drawing.Size(196, 20);
            this._sentDatePicker.TabIndex = 5;
            this._sentDatePicker.UtcValue = null;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(97, 91);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(85, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Дата прибытия";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(99, 65);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Дата отправки";
            // 
            // _distributorTextBox
            // 
            this._distributorTextBox.Location = new System.Drawing.Point(188, 114);
            this._distributorTextBox.Name = "_distributorTextBox";
            this._distributorTextBox.Size = new System.Drawing.Size(234, 20);
            this._distributorTextBox.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(80, 117);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Распространитель";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(90, 142);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(92, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Цена покупки ($)";
            // 
            // _purchaserPaidNumericUpDown
            // 
            this._purchaserPaidNumericUpDown.DecimalPlaces = 2;
            this._purchaserPaidNumericUpDown.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this._purchaserPaidNumericUpDown.Location = new System.Drawing.Point(188, 140);
            this._purchaserPaidNumericUpDown.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this._purchaserPaidNumericUpDown.Minimum = new decimal(new int[] {
            1000000,
            0,
            0,
            -2147483648});
            this._purchaserPaidNumericUpDown.Name = "_purchaserPaidNumericUpDown";
            this._purchaserPaidNumericUpDown.Size = new System.Drawing.Size(140, 20);
            this._purchaserPaidNumericUpDown.TabIndex = 11;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(84, 168);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Цена отправки ($)";
            // 
            // _purchaserSpentOnDeliveryNumericUpDown
            // 
            this._purchaserSpentOnDeliveryNumericUpDown.DecimalPlaces = 2;
            this._purchaserSpentOnDeliveryNumericUpDown.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this._purchaserSpentOnDeliveryNumericUpDown.Location = new System.Drawing.Point(188, 166);
            this._purchaserSpentOnDeliveryNumericUpDown.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this._purchaserSpentOnDeliveryNumericUpDown.Minimum = new decimal(new int[] {
            1000000,
            0,
            0,
            -2147483648});
            this._purchaserSpentOnDeliveryNumericUpDown.Name = "_purchaserSpentOnDeliveryNumericUpDown";
            this._purchaserSpentOnDeliveryNumericUpDown.Size = new System.Drawing.Size(140, 20);
            this._purchaserSpentOnDeliveryNumericUpDown.TabIndex = 13;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(19, 194);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(163, 13);
            this.label7.TabIndex = 14;
            this.label7.Text = "Расходы распространителя ($)";
            // 
            // _distributorSpentOnDeliveryNumericUpDown
            // 
            this._distributorSpentOnDeliveryNumericUpDown.DecimalPlaces = 2;
            this._distributorSpentOnDeliveryNumericUpDown.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this._distributorSpentOnDeliveryNumericUpDown.Location = new System.Drawing.Point(188, 192);
            this._distributorSpentOnDeliveryNumericUpDown.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this._distributorSpentOnDeliveryNumericUpDown.Minimum = new decimal(new int[] {
            1000000,
            0,
            0,
            -2147483648});
            this._distributorSpentOnDeliveryNumericUpDown.Name = "_distributorSpentOnDeliveryNumericUpDown";
            this._distributorSpentOnDeliveryNumericUpDown.Size = new System.Drawing.Size(140, 20);
            this._distributorSpentOnDeliveryNumericUpDown.TabIndex = 15;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(80, 220);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(102, 13);
            this.label8.TabIndex = 16;
            this.label8.Text = "Итого расходов ($)";
            // 
            // _totalPaidNumericUpDown
            // 
            this._totalPaidNumericUpDown.DecimalPlaces = 2;
            this._totalPaidNumericUpDown.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this._totalPaidNumericUpDown.Location = new System.Drawing.Point(188, 218);
            this._totalPaidNumericUpDown.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this._totalPaidNumericUpDown.Minimum = new decimal(new int[] {
            1000000,
            0,
            0,
            -2147483648});
            this._totalPaidNumericUpDown.Name = "_totalPaidNumericUpDown";
            this._totalPaidNumericUpDown.Size = new System.Drawing.Size(140, 20);
            this._totalPaidNumericUpDown.TabIndex = 17;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(49, 246);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(133, 13);
            this.label9.TabIndex = 18;
            this.label9.Text = "Предоплата клиентов ($)";
            // 
            // _customersPrepaidNumericUpDown
            // 
            this._customersPrepaidNumericUpDown.DecimalPlaces = 2;
            this._customersPrepaidNumericUpDown.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this._customersPrepaidNumericUpDown.Location = new System.Drawing.Point(188, 244);
            this._customersPrepaidNumericUpDown.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this._customersPrepaidNumericUpDown.Minimum = new decimal(new int[] {
            1000000,
            0,
            0,
            -2147483648});
            this._customersPrepaidNumericUpDown.Name = "_customersPrepaidNumericUpDown";
            this._customersPrepaidNumericUpDown.Size = new System.Drawing.Size(140, 20);
            this._customersPrepaidNumericUpDown.TabIndex = 19;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(73, 272);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(109, 13);
            this.label10.TabIndex = 20;
            this.label10.Text = "Оплата клиентов ($)";
            // 
            // _customersPaidNumericUpDown
            // 
            this._customersPaidNumericUpDown.DecimalPlaces = 2;
            this._customersPaidNumericUpDown.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this._customersPaidNumericUpDown.Location = new System.Drawing.Point(188, 270);
            this._customersPaidNumericUpDown.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this._customersPaidNumericUpDown.Minimum = new decimal(new int[] {
            1000000,
            0,
            0,
            -2147483648});
            this._customersPaidNumericUpDown.Name = "_customersPaidNumericUpDown";
            this._customersPaidNumericUpDown.Size = new System.Drawing.Size(140, 20);
            this._customersPaidNumericUpDown.TabIndex = 21;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(42, 298);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(140, 13);
            this.label11.TabIndex = 22;
            this.label11.Text = "Итого оплата клиентов ($)";
            // 
            // _totalCustomersPaidNumericUpDown
            // 
            this._totalCustomersPaidNumericUpDown.DecimalPlaces = 2;
            this._totalCustomersPaidNumericUpDown.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this._totalCustomersPaidNumericUpDown.Location = new System.Drawing.Point(188, 296);
            this._totalCustomersPaidNumericUpDown.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this._totalCustomersPaidNumericUpDown.Minimum = new decimal(new int[] {
            1000000,
            0,
            0,
            -2147483648});
            this._totalCustomersPaidNumericUpDown.Name = "_totalCustomersPaidNumericUpDown";
            this._totalCustomersPaidNumericUpDown.Size = new System.Drawing.Size(140, 20);
            this._totalCustomersPaidNumericUpDown.TabIndex = 23;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(12, 324);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(170, 13);
            this.label12.TabIndex = 24;
            this.label12.Text = "Ожидаемая оплата клиентов ($)";
            // 
            // _expectedTotalCustomerPaidNumericUpDown
            // 
            this._expectedTotalCustomerPaidNumericUpDown.DecimalPlaces = 2;
            this._expectedTotalCustomerPaidNumericUpDown.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this._expectedTotalCustomerPaidNumericUpDown.Location = new System.Drawing.Point(188, 322);
            this._expectedTotalCustomerPaidNumericUpDown.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this._expectedTotalCustomerPaidNumericUpDown.Minimum = new decimal(new int[] {
            1000000,
            0,
            0,
            -2147483648});
            this._expectedTotalCustomerPaidNumericUpDown.Name = "_expectedTotalCustomerPaidNumericUpDown";
            this._expectedTotalCustomerPaidNumericUpDown.Size = new System.Drawing.Size(140, 20);
            this._expectedTotalCustomerPaidNumericUpDown.TabIndex = 25;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(128, 350);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(54, 13);
            this.label13.TabIndex = 26;
            this.label13.Text = "Доход ($)";
            // 
            // _totalProfitNumericUpDown
            // 
            this._totalProfitNumericUpDown.DecimalPlaces = 2;
            this._totalProfitNumericUpDown.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this._totalProfitNumericUpDown.Location = new System.Drawing.Point(188, 348);
            this._totalProfitNumericUpDown.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this._totalProfitNumericUpDown.Minimum = new decimal(new int[] {
            1000000,
            0,
            0,
            -2147483648});
            this._totalProfitNumericUpDown.Name = "_totalProfitNumericUpDown";
            this._totalProfitNumericUpDown.Size = new System.Drawing.Size(140, 20);
            this._totalProfitNumericUpDown.TabIndex = 27;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(66, 376);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(116, 13);
            this.label14.TabIndex = 28;
            this.label14.Text = "Ожидаемый доход ($)";
            // 
            // _expectedTotalProfitNumericUpDown
            // 
            this._expectedTotalProfitNumericUpDown.DecimalPlaces = 2;
            this._expectedTotalProfitNumericUpDown.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this._expectedTotalProfitNumericUpDown.Location = new System.Drawing.Point(188, 374);
            this._expectedTotalProfitNumericUpDown.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this._expectedTotalProfitNumericUpDown.Minimum = new decimal(new int[] {
            1000000,
            0,
            0,
            -2147483648});
            this._expectedTotalProfitNumericUpDown.Name = "_expectedTotalProfitNumericUpDown";
            this._expectedTotalProfitNumericUpDown.Size = new System.Drawing.Size(140, 20);
            this._expectedTotalProfitNumericUpDown.TabIndex = 29;
            // 
            // ParcelReportEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(434, 451);
            this.Controls.Add(this.label14);
            this.Controls.Add(this._expectedTotalProfitNumericUpDown);
            this.Controls.Add(this.label13);
            this.Controls.Add(this._totalProfitNumericUpDown);
            this.Controls.Add(this.label12);
            this.Controls.Add(this._expectedTotalCustomerPaidNumericUpDown);
            this.Controls.Add(this.label11);
            this.Controls.Add(this._totalCustomersPaidNumericUpDown);
            this.Controls.Add(this.label10);
            this.Controls.Add(this._customersPaidNumericUpDown);
            this.Controls.Add(this.label9);
            this.Controls.Add(this._customersPrepaidNumericUpDown);
            this.Controls.Add(this.label8);
            this.Controls.Add(this._totalPaidNumericUpDown);
            this.Controls.Add(this.label7);
            this.Controls.Add(this._distributorSpentOnDeliveryNumericUpDown);
            this.Controls.Add(this.label2);
            this.Controls.Add(this._purchaserSpentOnDeliveryNumericUpDown);
            this.Controls.Add(this.label6);
            this.Controls.Add(this._purchaserPaidNumericUpDown);
            this.Controls.Add(this._distributorTextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this._receivedDatePicker);
            this.Controls.Add(this._sentDatePicker);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this._parcelNameTextBox);
            this.Controls.Add(this.label5);
            this.Name = "ParcelReportEditForm";
            this.Text = "";
            this.Controls.SetChildIndex(this.IdLabel, 0);
            this.Controls.SetChildIndex(this.IdTextBox, 0);
            this.Controls.SetChildIndex(this.SaveButton, 0);
            this.Controls.SetChildIndex(this.CloseButton, 0);
            this.Controls.SetChildIndex(this.ErrorMessageTextBox, 0);
            this.Controls.SetChildIndex(this.label5, 0);
            this.Controls.SetChildIndex(this._parcelNameTextBox, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this._sentDatePicker, 0);
            this.Controls.SetChildIndex(this._receivedDatePicker, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this._distributorTextBox, 0);
            this.Controls.SetChildIndex(this._purchaserPaidNumericUpDown, 0);
            this.Controls.SetChildIndex(this.label6, 0);
            this.Controls.SetChildIndex(this._purchaserSpentOnDeliveryNumericUpDown, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this._distributorSpentOnDeliveryNumericUpDown, 0);
            this.Controls.SetChildIndex(this.label7, 0);
            this.Controls.SetChildIndex(this._totalPaidNumericUpDown, 0);
            this.Controls.SetChildIndex(this.label8, 0);
            this.Controls.SetChildIndex(this._customersPrepaidNumericUpDown, 0);
            this.Controls.SetChildIndex(this.label9, 0);
            this.Controls.SetChildIndex(this._customersPaidNumericUpDown, 0);
            this.Controls.SetChildIndex(this.label10, 0);
            this.Controls.SetChildIndex(this._totalCustomersPaidNumericUpDown, 0);
            this.Controls.SetChildIndex(this.label11, 0);
            this.Controls.SetChildIndex(this._expectedTotalCustomerPaidNumericUpDown, 0);
            this.Controls.SetChildIndex(this.label12, 0);
            this.Controls.SetChildIndex(this._totalProfitNumericUpDown, 0);
            this.Controls.SetChildIndex(this.label13, 0);
            this.Controls.SetChildIndex(this._expectedTotalProfitNumericUpDown, 0);
            this.Controls.SetChildIndex(this.label14, 0);
            ((System.ComponentModel.ISupportInitialize)(this._purchaserPaidNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._purchaserSpentOnDeliveryNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._distributorSpentOnDeliveryNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._totalPaidNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._customersPrepaidNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._customersPaidNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._totalCustomersPaidNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._expectedTotalCustomerPaidNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._totalProfitNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._expectedTotalProfitNumericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox _parcelNameTextBox;
        private System.Windows.Forms.Label label5;
        private Controls.NullableDatePicker _receivedDatePicker;
        private Controls.NullableDatePicker _sentDatePicker;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox _distributorTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown _purchaserPaidNumericUpDown;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown _purchaserSpentOnDeliveryNumericUpDown;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown _distributorSpentOnDeliveryNumericUpDown;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericUpDown _totalPaidNumericUpDown;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.NumericUpDown _customersPrepaidNumericUpDown;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.NumericUpDown _customersPaidNumericUpDown;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.NumericUpDown _totalCustomersPaidNumericUpDown;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.NumericUpDown _expectedTotalCustomerPaidNumericUpDown;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.NumericUpDown _totalProfitNumericUpDown;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.NumericUpDown _expectedTotalProfitNumericUpDown;
    }
}