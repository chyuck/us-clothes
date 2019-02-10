namespace USClothesWebSite.Win.Forms.Document
{
    partial class OrderEditForm
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
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this._orderNumberTextBox = new System.Windows.Forms.TextBox();
            this._orderDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this._customerFirstNameWatermarkedTextBox = new USClothesWebSite.Win.Controls.WatermarkedTextBox();
            this._customerLastNameWatermarkedTextBox = new USClothesWebSite.Win.Controls.WatermarkedTextBox();
            this._customerAddressWatermarkedTextBox = new USClothesWebSite.Win.Controls.WatermarkedTextBox();
            this._customerCityWatermarkedTextBox = new USClothesWebSite.Win.Controls.WatermarkedTextBox();
            this._customerCountryWatermarkedTextBox = new USClothesWebSite.Win.Controls.WatermarkedTextBox();
            this._customerPostalCodeWatermarkedTextBox = new USClothesWebSite.Win.Controls.WatermarkedTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this._customerPhoneNumberWatermarkedTextBox = new USClothesWebSite.Win.Controls.WatermarkedTextBox();
            this._customerEmailWatermarkedTextBox = new USClothesWebSite.Win.Controls.WatermarkedTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this._activeCheckBox = new System.Windows.Forms.CheckBox();
            this.label7 = new System.Windows.Forms.Label();
            this._trackingNumberTextBox = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this._parcelReferenceEditor = new USClothesWebSite.Win.Controls.ReferenceEditor.ParcelReferenceEditor();
            this.label14 = new System.Windows.Forms.Label();
            this._rublesPerDollarNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label15 = new System.Windows.Forms.Label();
            this._customerPrepaidNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label16 = new System.Windows.Forms.Label();
            this._customerPaidNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label17 = new System.Windows.Forms.Label();
            this._distributorSpentOnDeliveryNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label18 = new System.Windows.Forms.Label();
            this._commentsTextBox = new System.Windows.Forms.TextBox();
            this._trackableDtoAttributes = new USClothesWebSite.Win.Controls.TrackableDtoAttributes();
            this._totalPriceTextBox = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this._rublesPerDollarNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._customerPrepaidNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._customerPaidNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._distributorSpentOnDeliveryNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // IdTextBox
            // 
            this.IdTextBox.Location = new System.Drawing.Point(193, 68);
            this.IdTextBox.TabIndex = 2;
            // 
            // IdLabel
            // 
            this.IdLabel.Location = new System.Drawing.Point(169, 71);
            this.IdLabel.TabIndex = 1;
            // 
            // CloseButton
            // 
            this.CloseButton.Location = new System.Drawing.Point(726, 463);
            this.CloseButton.TabIndex = 43;
            // 
            // SaveButton
            // 
            this.SaveButton.Location = new System.Drawing.Point(645, 463);
            this.SaveButton.TabIndex = 42;
            // 
            // ErrorMessageTextBox
            // 
            this.ErrorMessageTextBox.Size = new System.Drawing.Size(789, 50);
            this.ErrorMessageTextBox.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(115, 97);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Дата заказа";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(290, 71);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Номер";
            // 
            // _orderNumberTextBox
            // 
            this._orderNumberTextBox.Location = new System.Drawing.Point(337, 68);
            this._orderNumberTextBox.Name = "_orderNumberTextBox";
            this._orderNumberTextBox.ReadOnly = true;
            this._orderNumberTextBox.Size = new System.Drawing.Size(140, 20);
            this._orderNumberTextBox.TabIndex = 4;
            this._orderNumberTextBox.TabStop = false;
            // 
            // _orderDateTimePicker
            // 
            this._orderDateTimePicker.Location = new System.Drawing.Point(193, 94);
            this._orderDateTimePicker.Name = "_orderDateTimePicker";
            this._orderDateTimePicker.Size = new System.Drawing.Size(161, 20);
            this._orderDateTimePicker.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(103, 123);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(84, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Имя клиента";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label9.Location = new System.Drawing.Point(346, 123);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(115, 13);
            this.label9.TabIndex = 13;
            this.label9.Text = "Фамилия клиента";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label10.Location = new System.Drawing.Point(92, 149);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(95, 13);
            this.label10.TabIndex = 15;
            this.label10.Text = "Адрес клиента";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label11.Location = new System.Drawing.Point(93, 175);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(94, 13);
            this.label11.TabIndex = 17;
            this.label11.Text = "Город клиента";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label12.Location = new System.Drawing.Point(361, 175);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(101, 13);
            this.label12.TabIndex = 19;
            this.label12.Text = "Страна клиента";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label13.Location = new System.Drawing.Point(84, 201);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(103, 13);
            this.label13.TabIndex = 21;
            this.label13.Text = "Индекс клиента";
            // 
            // _customerFirstNameWatermarkedTextBox
            // 
            this._customerFirstNameWatermarkedTextBox.Location = new System.Drawing.Point(193, 120);
            this._customerFirstNameWatermarkedTextBox.MaxLength = 50;
            this._customerFirstNameWatermarkedTextBox.Name = "_customerFirstNameWatermarkedTextBox";
            this._customerFirstNameWatermarkedTextBox.Size = new System.Drawing.Size(138, 20);
            this._customerFirstNameWatermarkedTextBox.TabIndex = 12;
            this._customerFirstNameWatermarkedTextBox.Watermark = "Например \"Ирина\"";
            // 
            // _customerLastNameWatermarkedTextBox
            // 
            this._customerLastNameWatermarkedTextBox.Location = new System.Drawing.Point(467, 120);
            this._customerLastNameWatermarkedTextBox.MaxLength = 50;
            this._customerLastNameWatermarkedTextBox.Name = "_customerLastNameWatermarkedTextBox";
            this._customerLastNameWatermarkedTextBox.Size = new System.Drawing.Size(138, 20);
            this._customerLastNameWatermarkedTextBox.TabIndex = 14;
            this._customerLastNameWatermarkedTextBox.Watermark = "Например \"Орлова\"";
            // 
            // _customerAddressWatermarkedTextBox
            // 
            this._customerAddressWatermarkedTextBox.Location = new System.Drawing.Point(193, 146);
            this._customerAddressWatermarkedTextBox.MaxLength = 100;
            this._customerAddressWatermarkedTextBox.Name = "_customerAddressWatermarkedTextBox";
            this._customerAddressWatermarkedTextBox.Size = new System.Drawing.Size(412, 20);
            this._customerAddressWatermarkedTextBox.TabIndex = 16;
            this._customerAddressWatermarkedTextBox.Watermark = "Например \"ул. Строителей, д. 23, кв. 3\"";
            // 
            // _customerCityWatermarkedTextBox
            // 
            this._customerCityWatermarkedTextBox.Location = new System.Drawing.Point(193, 172);
            this._customerCityWatermarkedTextBox.MaxLength = 50;
            this._customerCityWatermarkedTextBox.Name = "_customerCityWatermarkedTextBox";
            this._customerCityWatermarkedTextBox.Size = new System.Drawing.Size(152, 20);
            this._customerCityWatermarkedTextBox.TabIndex = 18;
            this._customerCityWatermarkedTextBox.Watermark = "Например \"Москва\"";
            // 
            // _customerCountryWatermarkedTextBox
            // 
            this._customerCountryWatermarkedTextBox.Location = new System.Drawing.Point(468, 172);
            this._customerCountryWatermarkedTextBox.MaxLength = 50;
            this._customerCountryWatermarkedTextBox.Name = "_customerCountryWatermarkedTextBox";
            this._customerCountryWatermarkedTextBox.Size = new System.Drawing.Size(138, 20);
            this._customerCountryWatermarkedTextBox.TabIndex = 20;
            this._customerCountryWatermarkedTextBox.Text = "Россия";
            this._customerCountryWatermarkedTextBox.Watermark = "Например \"Россия\"";
            // 
            // _customerPostalCodeWatermarkedTextBox
            // 
            this._customerPostalCodeWatermarkedTextBox.Location = new System.Drawing.Point(193, 198);
            this._customerPostalCodeWatermarkedTextBox.MaxLength = 20;
            this._customerPostalCodeWatermarkedTextBox.Name = "_customerPostalCodeWatermarkedTextBox";
            this._customerPostalCodeWatermarkedTextBox.Size = new System.Drawing.Size(112, 20);
            this._customerPostalCodeWatermarkedTextBox.TabIndex = 22;
            this._customerPostalCodeWatermarkedTextBox.Watermark = "Например \"230005\"";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(317, 201);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 13);
            this.label2.TabIndex = 23;
            this.label2.Text = "Телефон клиента";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(541, 201);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(98, 13);
            this.label5.TabIndex = 25;
            this.label5.Text = "Эл. почта клиента";
            // 
            // _customerPhoneNumberWatermarkedTextBox
            // 
            this._customerPhoneNumberWatermarkedTextBox.Location = new System.Drawing.Point(419, 198);
            this._customerPhoneNumberWatermarkedTextBox.MaxLength = 20;
            this._customerPhoneNumberWatermarkedTextBox.Name = "_customerPhoneNumberWatermarkedTextBox";
            this._customerPhoneNumberWatermarkedTextBox.Size = new System.Drawing.Size(110, 20);
            this._customerPhoneNumberWatermarkedTextBox.TabIndex = 24;
            this._customerPhoneNumberWatermarkedTextBox.Watermark = "";
            // 
            // _customerEmailWatermarkedTextBox
            // 
            this._customerEmailWatermarkedTextBox.Location = new System.Drawing.Point(645, 198);
            this._customerEmailWatermarkedTextBox.MaxLength = 50;
            this._customerEmailWatermarkedTextBox.Name = "_customerEmailWatermarkedTextBox";
            this._customerEmailWatermarkedTextBox.Size = new System.Drawing.Size(156, 20);
            this._customerEmailWatermarkedTextBox.TabIndex = 26;
            this._customerEmailWatermarkedTextBox.Watermark = "";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(399, 96);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(57, 13);
            this.label6.TabIndex = 9;
            this.label6.Text = "Активный";
            // 
            // _activeCheckBox
            // 
            this._activeCheckBox.AutoSize = true;
            this._activeCheckBox.Checked = true;
            this._activeCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this._activeCheckBox.Location = new System.Drawing.Point(462, 96);
            this._activeCheckBox.Name = "_activeCheckBox";
            this._activeCheckBox.Size = new System.Drawing.Size(15, 14);
            this._activeCheckBox.TabIndex = 10;
            this._activeCheckBox.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(435, 331);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(117, 13);
            this.label7.TabIndex = 39;
            this.label7.Text = "Номер отслеживания";
            // 
            // _trackingNumberTextBox
            // 
            this._trackingNumberTextBox.Location = new System.Drawing.Point(558, 328);
            this._trackingNumberTextBox.MaxLength = 20;
            this._trackingNumberTextBox.Name = "_trackingNumberTextBox";
            this._trackingNumberTextBox.Size = new System.Drawing.Size(200, 20);
            this._trackingNumberTextBox.TabIndex = 40;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(134, 331);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 13);
            this.label8.TabIndex = 37;
            this.label8.Text = "Посылка";
            // 
            // _parcelReferenceEditor
            // 
            this._parcelReferenceEditor.AutoComboBoxRefresh = true;
            this._parcelReferenceEditor.CanBeCleared = true;
            this._parcelReferenceEditor.Location = new System.Drawing.Point(193, 328);
            this._parcelReferenceEditor.Mode = USClothesWebSite.Win.Controls.ReferenceEditor.ReferenceEditorMode.ReadOnlyTextBox;
            this._parcelReferenceEditor.Name = "_parcelReferenceEditor";
            this._parcelReferenceEditor.ReadOnly = false;
            this._parcelReferenceEditor.Size = new System.Drawing.Size(230, 20);
            this._parcelReferenceEditor.TabIndex = 38;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(85, 278);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(102, 13);
            this.label14.TabIndex = 31;
            this.label14.Text = "Курс доллара (руб)";
            // 
            // _rublesPerDollarNumericUpDown
            // 
            this._rublesPerDollarNumericUpDown.DecimalPlaces = 2;
            this._rublesPerDollarNumericUpDown.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this._rublesPerDollarNumericUpDown.Location = new System.Drawing.Point(193, 276);
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
            this._rublesPerDollarNumericUpDown.Size = new System.Drawing.Size(138, 20);
            this._rublesPerDollarNumericUpDown.TabIndex = 32;
            this._rublesPerDollarNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(49, 226);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(138, 13);
            this.label15.TabIndex = 27;
            this.label15.Text = "Предоплата клиента (руб)";
            // 
            // _customerPrepaidNumericUpDown
            // 
            this._customerPrepaidNumericUpDown.DecimalPlaces = 2;
            this._customerPrepaidNumericUpDown.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this._customerPrepaidNumericUpDown.Location = new System.Drawing.Point(193, 224);
            this._customerPrepaidNumericUpDown.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this._customerPrepaidNumericUpDown.Name = "_customerPrepaidNumericUpDown";
            this._customerPrepaidNumericUpDown.Size = new System.Drawing.Size(138, 20);
            this._customerPrepaidNumericUpDown.TabIndex = 28;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(73, 252);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(114, 13);
            this.label16.TabIndex = 29;
            this.label16.Text = "Оплата клиента (руб)";
            // 
            // _customerPaidNumericUpDown
            // 
            this._customerPaidNumericUpDown.DecimalPlaces = 2;
            this._customerPaidNumericUpDown.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this._customerPaidNumericUpDown.Location = new System.Drawing.Point(193, 250);
            this._customerPaidNumericUpDown.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this._customerPaidNumericUpDown.Name = "_customerPaidNumericUpDown";
            this._customerPaidNumericUpDown.Size = new System.Drawing.Size(138, 20);
            this._customerPaidNumericUpDown.TabIndex = 30;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(13, 304);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(174, 13);
            this.label17.TabIndex = 33;
            this.label17.Text = "Расходы распространителя (руб)";
            // 
            // _distributorSpentOnDeliveryNumericUpDown
            // 
            this._distributorSpentOnDeliveryNumericUpDown.DecimalPlaces = 2;
            this._distributorSpentOnDeliveryNumericUpDown.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this._distributorSpentOnDeliveryNumericUpDown.Location = new System.Drawing.Point(193, 302);
            this._distributorSpentOnDeliveryNumericUpDown.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this._distributorSpentOnDeliveryNumericUpDown.Name = "_distributorSpentOnDeliveryNumericUpDown";
            this._distributorSpentOnDeliveryNumericUpDown.Size = new System.Drawing.Size(138, 20);
            this._distributorSpentOnDeliveryNumericUpDown.TabIndex = 34;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(348, 229);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(77, 13);
            this.label18.TabIndex = 35;
            this.label18.Text = "Комментарий";
            // 
            // _commentsTextBox
            // 
            this._commentsTextBox.Location = new System.Drawing.Point(431, 226);
            this._commentsTextBox.MaxLength = 1000;
            this._commentsTextBox.Multiline = true;
            this._commentsTextBox.Name = "_commentsTextBox";
            this._commentsTextBox.Size = new System.Drawing.Size(370, 96);
            this._commentsTextBox.TabIndex = 36;
            // 
            // _trackableDtoAttributes
            // 
            this._trackableDtoAttributes.Location = new System.Drawing.Point(135, 354);
            this._trackableDtoAttributes.Name = "_trackableDtoAttributes";
            this._trackableDtoAttributes.Size = new System.Drawing.Size(428, 98);
            this._trackableDtoAttributes.TabIndex = 41;
            // 
            // _totalPriceTextBox
            // 
            this._totalPriceTextBox.Location = new System.Drawing.Point(612, 68);
            this._totalPriceTextBox.Name = "_totalPriceTextBox";
            this._totalPriceTextBox.ReadOnly = true;
            this._totalPriceTextBox.Size = new System.Drawing.Size(166, 20);
            this._totalPriceTextBox.TabIndex = 6;
            this._totalPriceTextBox.TabStop = false;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(498, 71);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(108, 13);
            this.label19.TabIndex = 5;
            this.label19.Text = "Итоговая цена (руб)";
            // 
            // OrderEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(815, 507);
            this.Controls.Add(this._totalPriceTextBox);
            this.Controls.Add(this.label19);
            this.Controls.Add(this._trackableDtoAttributes);
            this.Controls.Add(this._customerFirstNameWatermarkedTextBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this._customerLastNameWatermarkedTextBox);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.label9);
            this.Controls.Add(this._commentsTextBox);
            this.Controls.Add(this._customerAddressWatermarkedTextBox);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.label10);
            this.Controls.Add(this._distributorSpentOnDeliveryNumericUpDown);
            this.Controls.Add(this._customerCityWatermarkedTextBox);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label11);
            this.Controls.Add(this._customerPaidNumericUpDown);
            this.Controls.Add(this._customerCountryWatermarkedTextBox);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label12);
            this.Controls.Add(this._customerPrepaidNumericUpDown);
            this.Controls.Add(this._customerPostalCodeWatermarkedTextBox);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label13);
            this.Controls.Add(this._rublesPerDollarNumericUpDown);
            this.Controls.Add(this._customerPhoneNumberWatermarkedTextBox);
            this.Controls.Add(this._parcelReferenceEditor);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label8);
            this.Controls.Add(this._customerEmailWatermarkedTextBox);
            this.Controls.Add(this.label7);
            this.Controls.Add(this._trackingNumberTextBox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this._activeCheckBox);
            this.Controls.Add(this._orderDateTimePicker);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this._orderNumberTextBox);
            this.Name = "OrderEditForm";
            this.Text = "";
            this.Controls.SetChildIndex(this.IdLabel, 0);
            this.Controls.SetChildIndex(this.IdTextBox, 0);
            this.Controls.SetChildIndex(this.SaveButton, 0);
            this.Controls.SetChildIndex(this.CloseButton, 0);
            this.Controls.SetChildIndex(this.ErrorMessageTextBox, 0);
            this.Controls.SetChildIndex(this._orderNumberTextBox, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this._orderDateTimePicker, 0);
            this.Controls.SetChildIndex(this._activeCheckBox, 0);
            this.Controls.SetChildIndex(this.label6, 0);
            this.Controls.SetChildIndex(this._trackingNumberTextBox, 0);
            this.Controls.SetChildIndex(this.label7, 0);
            this.Controls.SetChildIndex(this._customerEmailWatermarkedTextBox, 0);
            this.Controls.SetChildIndex(this.label8, 0);
            this.Controls.SetChildIndex(this.label5, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this._parcelReferenceEditor, 0);
            this.Controls.SetChildIndex(this._customerPhoneNumberWatermarkedTextBox, 0);
            this.Controls.SetChildIndex(this._rublesPerDollarNumericUpDown, 0);
            this.Controls.SetChildIndex(this.label13, 0);
            this.Controls.SetChildIndex(this.label14, 0);
            this.Controls.SetChildIndex(this._customerPostalCodeWatermarkedTextBox, 0);
            this.Controls.SetChildIndex(this._customerPrepaidNumericUpDown, 0);
            this.Controls.SetChildIndex(this.label12, 0);
            this.Controls.SetChildIndex(this.label15, 0);
            this.Controls.SetChildIndex(this._customerCountryWatermarkedTextBox, 0);
            this.Controls.SetChildIndex(this._customerPaidNumericUpDown, 0);
            this.Controls.SetChildIndex(this.label11, 0);
            this.Controls.SetChildIndex(this.label16, 0);
            this.Controls.SetChildIndex(this._customerCityWatermarkedTextBox, 0);
            this.Controls.SetChildIndex(this._distributorSpentOnDeliveryNumericUpDown, 0);
            this.Controls.SetChildIndex(this.label10, 0);
            this.Controls.SetChildIndex(this.label17, 0);
            this.Controls.SetChildIndex(this._customerAddressWatermarkedTextBox, 0);
            this.Controls.SetChildIndex(this._commentsTextBox, 0);
            this.Controls.SetChildIndex(this.label9, 0);
            this.Controls.SetChildIndex(this.label18, 0);
            this.Controls.SetChildIndex(this._customerLastNameWatermarkedTextBox, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this._customerFirstNameWatermarkedTextBox, 0);
            this.Controls.SetChildIndex(this._trackableDtoAttributes, 0);
            this.Controls.SetChildIndex(this.label19, 0);
            this.Controls.SetChildIndex(this._totalPriceTextBox, 0);
            ((System.ComponentModel.ISupportInitialize)(this._rublesPerDollarNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._customerPrepaidNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._customerPaidNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._distributorSpentOnDeliveryNumericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox _orderNumberTextBox;
        private System.Windows.Forms.DateTimePicker _orderDateTimePicker;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private Controls.WatermarkedTextBox _customerFirstNameWatermarkedTextBox;
        private Controls.WatermarkedTextBox _customerLastNameWatermarkedTextBox;
        private Controls.WatermarkedTextBox _customerAddressWatermarkedTextBox;
        private Controls.WatermarkedTextBox _customerCityWatermarkedTextBox;
        private Controls.WatermarkedTextBox _customerCountryWatermarkedTextBox;
        private Controls.WatermarkedTextBox _customerPostalCodeWatermarkedTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private Controls.WatermarkedTextBox _customerPhoneNumberWatermarkedTextBox;
        private Controls.WatermarkedTextBox _customerEmailWatermarkedTextBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox _activeCheckBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox _trackingNumberTextBox;
        private System.Windows.Forms.Label label8;
        private Controls.ReferenceEditor.ParcelReferenceEditor _parcelReferenceEditor;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.NumericUpDown _rublesPerDollarNumericUpDown;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.NumericUpDown _customerPrepaidNumericUpDown;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.NumericUpDown _customerPaidNumericUpDown;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.NumericUpDown _distributorSpentOnDeliveryNumericUpDown;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox _commentsTextBox;
        private Controls.TrackableDtoAttributes _trackableDtoAttributes;
        private System.Windows.Forms.TextBox _totalPriceTextBox;
        private System.Windows.Forms.Label label19;
    }
}