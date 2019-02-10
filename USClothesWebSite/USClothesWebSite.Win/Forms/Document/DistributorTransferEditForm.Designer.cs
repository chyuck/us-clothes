namespace USClothesWebSite.Win.Forms.Document
{
    partial class DistributorTransferEditForm
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
            this._dateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this._amountNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label14 = new System.Windows.Forms.Label();
            this._rublesPerDollarNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this._activeCheckBox = new System.Windows.Forms.CheckBox();
            this._trackableDtoAttributes = new USClothesWebSite.Win.Controls.TrackableDtoAttributes();
            ((System.ComponentModel.ISupportInitialize)(this._amountNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._rublesPerDollarNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // IdTextBox
            // 
            this.IdTextBox.Location = new System.Drawing.Point(121, 68);
            this.IdTextBox.TabIndex = 2;
            // 
            // IdLabel
            // 
            this.IdLabel.Location = new System.Drawing.Point(97, 71);
            this.IdLabel.TabIndex = 1;
            // 
            // CloseButton
            // 
            this.CloseButton.Location = new System.Drawing.Point(414, 314);
            this.CloseButton.TabIndex = 13;
            // 
            // SaveButton
            // 
            this.SaveButton.Location = new System.Drawing.Point(333, 314);
            this.SaveButton.TabIndex = 12;
            // 
            // ErrorMessageTextBox
            // 
            this.ErrorMessageTextBox.Size = new System.Drawing.Size(477, 50);
            this.ErrorMessageTextBox.TabIndex = 0;
            // 
            // _dateTimePicker
            // 
            this._dateTimePicker.Location = new System.Drawing.Point(121, 94);
            this._dateTimePicker.Name = "_dateTimePicker";
            this._dateTimePicker.Size = new System.Drawing.Size(161, 20);
            this._dateTimePicker.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(31, 96);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Дата перевода";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label15.Location = new System.Drawing.Point(37, 122);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(78, 13);
            this.label15.TabIndex = 5;
            this.label15.Text = "Сумма (руб)";
            // 
            // _amountNumericUpDown
            // 
            this._amountNumericUpDown.DecimalPlaces = 2;
            this._amountNumericUpDown.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this._amountNumericUpDown.Location = new System.Drawing.Point(121, 120);
            this._amountNumericUpDown.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this._amountNumericUpDown.Name = "_amountNumericUpDown";
            this._amountNumericUpDown.Size = new System.Drawing.Size(161, 20);
            this._amountNumericUpDown.TabIndex = 6;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(13, 148);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(102, 13);
            this.label14.TabIndex = 7;
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
            this._rublesPerDollarNumericUpDown.Location = new System.Drawing.Point(121, 146);
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
            this._rublesPerDollarNumericUpDown.Size = new System.Drawing.Size(161, 20);
            this._rublesPerDollarNumericUpDown.TabIndex = 8;
            this._rublesPerDollarNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(58, 172);
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
            this._activeCheckBox.Location = new System.Drawing.Point(121, 172);
            this._activeCheckBox.Name = "_activeCheckBox";
            this._activeCheckBox.Size = new System.Drawing.Size(15, 14);
            this._activeCheckBox.TabIndex = 10;
            this._activeCheckBox.UseVisualStyleBackColor = true;
            // 
            // _trackableDtoAttributes
            // 
            this._trackableDtoAttributes.Location = new System.Drawing.Point(61, 192);
            this._trackableDtoAttributes.Name = "_trackableDtoAttributes";
            this._trackableDtoAttributes.Size = new System.Drawing.Size(428, 98);
            this._trackableDtoAttributes.TabIndex = 11;
            // 
            // DistributorTransferEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(505, 360);
            this.Controls.Add(this._trackableDtoAttributes);
            this.Controls.Add(this.label15);
            this.Controls.Add(this._amountNumericUpDown);
            this.Controls.Add(this.label14);
            this.Controls.Add(this._rublesPerDollarNumericUpDown);
            this.Controls.Add(this.label6);
            this.Controls.Add(this._activeCheckBox);
            this.Controls.Add(this._dateTimePicker);
            this.Controls.Add(this.label3);
            this.Name = "DistributorTransferEditForm";
            this.Text = "";
            this.Controls.SetChildIndex(this.IdLabel, 0);
            this.Controls.SetChildIndex(this.IdTextBox, 0);
            this.Controls.SetChildIndex(this.SaveButton, 0);
            this.Controls.SetChildIndex(this.CloseButton, 0);
            this.Controls.SetChildIndex(this.ErrorMessageTextBox, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this._dateTimePicker, 0);
            this.Controls.SetChildIndex(this._activeCheckBox, 0);
            this.Controls.SetChildIndex(this.label6, 0);
            this.Controls.SetChildIndex(this._rublesPerDollarNumericUpDown, 0);
            this.Controls.SetChildIndex(this.label14, 0);
            this.Controls.SetChildIndex(this._amountNumericUpDown, 0);
            this.Controls.SetChildIndex(this.label15, 0);
            this.Controls.SetChildIndex(this._trackableDtoAttributes, 0);
            ((System.ComponentModel.ISupportInitialize)(this._amountNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._rublesPerDollarNumericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker _dateTimePicker;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.NumericUpDown _amountNumericUpDown;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.NumericUpDown _rublesPerDollarNumericUpDown;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox _activeCheckBox;
        private Controls.TrackableDtoAttributes _trackableDtoAttributes;
    }
}