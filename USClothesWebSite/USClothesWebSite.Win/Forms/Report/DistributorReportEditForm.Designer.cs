namespace USClothesWebSite.Win.Forms.Report
{
    partial class DistributorReportEditForm
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
            this.label5 = new System.Windows.Forms.Label();
            this._distributorNameTextBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this._distributorSpentNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this._distributorReceivedNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this._distributorBalanceNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this._purchaserSpentNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this._purchaserReceivedNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this._purchaserBalanceNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this._totalBalanceNumericUpDown = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this._distributorSpentNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._distributorReceivedNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._distributorBalanceNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._purchaserSpentNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._purchaserReceivedNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._purchaserBalanceNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._totalBalanceNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // IdTextBox
            // 
            this.IdTextBox.Location = new System.Drawing.Point(174, 12);
            this.IdTextBox.TabIndex = 1;
            // 
            // IdLabel
            // 
            this.IdLabel.Location = new System.Drawing.Point(150, 15);
            this.IdLabel.TabIndex = 0;
            // 
            // CloseButton
            // 
            this.CloseButton.Location = new System.Drawing.Point(333, 262);
            this.CloseButton.TabIndex = 19;
            // 
            // SaveButton
            // 
            this.SaveButton.Location = new System.Drawing.Point(252, 262);
            this.SaveButton.TabIndex = 18;
            this.SaveButton.Visible = false;
            // 
            // ErrorMessageTextBox
            // 
            this.ErrorMessageTextBox.Location = new System.Drawing.Point(0, 365);
            this.ErrorMessageTextBox.Size = new System.Drawing.Size(41, 18);
            this.ErrorMessageTextBox.Visible = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(66, 41);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(102, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "Распространитель";
            // 
            // _distributorNameTextBox
            // 
            this._distributorNameTextBox.Location = new System.Drawing.Point(174, 38);
            this._distributorNameTextBox.Name = "_distributorNameTextBox";
            this._distributorNameTextBox.Size = new System.Drawing.Size(234, 20);
            this._distributorNameTextBox.TabIndex = 3;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(17, 66);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(151, 13);
            this.label6.TabIndex = 4;
            this.label6.Text = "Траты распространителя ($)";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 92);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(156, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Приход распространителя ($)";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 118);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(156, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Баланс распространителя ($)";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(50, 196);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(118, 13);
            this.label3.TabIndex = 14;
            this.label3.Text = "Баланс закупщика ($)";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(50, 170);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(118, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Приход закупщика ($)";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(55, 144);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(113, 13);
            this.label7.TabIndex = 10;
            this.label7.Text = "Траты закупщика ($)";
            // 
            // _distributorSpentNumericUpDown
            // 
            this._distributorSpentNumericUpDown.DecimalPlaces = 2;
            this._distributorSpentNumericUpDown.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this._distributorSpentNumericUpDown.Location = new System.Drawing.Point(174, 64);
            this._distributorSpentNumericUpDown.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this._distributorSpentNumericUpDown.Minimum = new decimal(new int[] {
            1000000,
            0,
            0,
            -2147483648});
            this._distributorSpentNumericUpDown.Name = "_distributorSpentNumericUpDown";
            this._distributorSpentNumericUpDown.Size = new System.Drawing.Size(140, 20);
            this._distributorSpentNumericUpDown.TabIndex = 5;
            // 
            // _distributorReceivedNumericUpDown
            // 
            this._distributorReceivedNumericUpDown.DecimalPlaces = 2;
            this._distributorReceivedNumericUpDown.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this._distributorReceivedNumericUpDown.Location = new System.Drawing.Point(174, 90);
            this._distributorReceivedNumericUpDown.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this._distributorReceivedNumericUpDown.Minimum = new decimal(new int[] {
            1000000,
            0,
            0,
            -2147483648});
            this._distributorReceivedNumericUpDown.Name = "_distributorReceivedNumericUpDown";
            this._distributorReceivedNumericUpDown.Size = new System.Drawing.Size(140, 20);
            this._distributorReceivedNumericUpDown.TabIndex = 7;
            // 
            // _distributorBalanceNumericUpDown
            // 
            this._distributorBalanceNumericUpDown.DecimalPlaces = 2;
            this._distributorBalanceNumericUpDown.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this._distributorBalanceNumericUpDown.Location = new System.Drawing.Point(174, 116);
            this._distributorBalanceNumericUpDown.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this._distributorBalanceNumericUpDown.Minimum = new decimal(new int[] {
            1000000,
            0,
            0,
            -2147483648});
            this._distributorBalanceNumericUpDown.Name = "_distributorBalanceNumericUpDown";
            this._distributorBalanceNumericUpDown.Size = new System.Drawing.Size(140, 20);
            this._distributorBalanceNumericUpDown.TabIndex = 9;
            // 
            // _purchaserSpentNumericUpDown
            // 
            this._purchaserSpentNumericUpDown.DecimalPlaces = 2;
            this._purchaserSpentNumericUpDown.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this._purchaserSpentNumericUpDown.Location = new System.Drawing.Point(174, 142);
            this._purchaserSpentNumericUpDown.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this._purchaserSpentNumericUpDown.Minimum = new decimal(new int[] {
            1000000,
            0,
            0,
            -2147483648});
            this._purchaserSpentNumericUpDown.Name = "_purchaserSpentNumericUpDown";
            this._purchaserSpentNumericUpDown.Size = new System.Drawing.Size(140, 20);
            this._purchaserSpentNumericUpDown.TabIndex = 11;
            // 
            // _purchaserReceivedNumericUpDown
            // 
            this._purchaserReceivedNumericUpDown.DecimalPlaces = 2;
            this._purchaserReceivedNumericUpDown.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this._purchaserReceivedNumericUpDown.Location = new System.Drawing.Point(174, 168);
            this._purchaserReceivedNumericUpDown.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this._purchaserReceivedNumericUpDown.Minimum = new decimal(new int[] {
            1000000,
            0,
            0,
            -2147483648});
            this._purchaserReceivedNumericUpDown.Name = "_purchaserReceivedNumericUpDown";
            this._purchaserReceivedNumericUpDown.Size = new System.Drawing.Size(140, 20);
            this._purchaserReceivedNumericUpDown.TabIndex = 13;
            // 
            // _purchaserBalanceNumericUpDown
            // 
            this._purchaserBalanceNumericUpDown.DecimalPlaces = 2;
            this._purchaserBalanceNumericUpDown.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this._purchaserBalanceNumericUpDown.Location = new System.Drawing.Point(174, 194);
            this._purchaserBalanceNumericUpDown.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this._purchaserBalanceNumericUpDown.Minimum = new decimal(new int[] {
            1000000,
            0,
            0,
            -2147483648});
            this._purchaserBalanceNumericUpDown.Name = "_purchaserBalanceNumericUpDown";
            this._purchaserBalanceNumericUpDown.Size = new System.Drawing.Size(140, 20);
            this._purchaserBalanceNumericUpDown.TabIndex = 15;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(57, 222);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(111, 13);
            this.label8.TabIndex = 16;
            this.label8.Text = "Итоговый баланс ($)";
            // 
            // _totalBalanceNumericUpDown
            // 
            this._totalBalanceNumericUpDown.DecimalPlaces = 2;
            this._totalBalanceNumericUpDown.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this._totalBalanceNumericUpDown.Location = new System.Drawing.Point(174, 220);
            this._totalBalanceNumericUpDown.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this._totalBalanceNumericUpDown.Minimum = new decimal(new int[] {
            1000000,
            0,
            0,
            -2147483648});
            this._totalBalanceNumericUpDown.Name = "_totalBalanceNumericUpDown";
            this._totalBalanceNumericUpDown.Size = new System.Drawing.Size(140, 20);
            this._totalBalanceNumericUpDown.TabIndex = 17;
            // 
            // DistributorReportEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(420, 304);
            this.Controls.Add(this.label8);
            this.Controls.Add(this._totalBalanceNumericUpDown);
            this.Controls.Add(this.label3);
            this.Controls.Add(this._purchaserBalanceNumericUpDown);
            this.Controls.Add(this.label4);
            this.Controls.Add(this._purchaserReceivedNumericUpDown);
            this.Controls.Add(this.label7);
            this.Controls.Add(this._purchaserSpentNumericUpDown);
            this.Controls.Add(this.label2);
            this.Controls.Add(this._distributorBalanceNumericUpDown);
            this.Controls.Add(this.label1);
            this.Controls.Add(this._distributorReceivedNumericUpDown);
            this.Controls.Add(this.label6);
            this.Controls.Add(this._distributorSpentNumericUpDown);
            this.Controls.Add(this._distributorNameTextBox);
            this.Controls.Add(this.label5);
            this.Name = "DistributorReportEditForm";
            this.Text = "";
            this.Controls.SetChildIndex(this.label5, 0);
            this.Controls.SetChildIndex(this._distributorNameTextBox, 0);
            this.Controls.SetChildIndex(this._distributorSpentNumericUpDown, 0);
            this.Controls.SetChildIndex(this.label6, 0);
            this.Controls.SetChildIndex(this._distributorReceivedNumericUpDown, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this._distributorBalanceNumericUpDown, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this._purchaserSpentNumericUpDown, 0);
            this.Controls.SetChildIndex(this.label7, 0);
            this.Controls.SetChildIndex(this._purchaserReceivedNumericUpDown, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this._purchaserBalanceNumericUpDown, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.IdLabel, 0);
            this.Controls.SetChildIndex(this.IdTextBox, 0);
            this.Controls.SetChildIndex(this.SaveButton, 0);
            this.Controls.SetChildIndex(this.CloseButton, 0);
            this.Controls.SetChildIndex(this.ErrorMessageTextBox, 0);
            this.Controls.SetChildIndex(this._totalBalanceNumericUpDown, 0);
            this.Controls.SetChildIndex(this.label8, 0);
            ((System.ComponentModel.ISupportInitialize)(this._distributorSpentNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._distributorReceivedNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._distributorBalanceNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._purchaserSpentNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._purchaserReceivedNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._purchaserBalanceNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._totalBalanceNumericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox _distributorNameTextBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown _distributorSpentNumericUpDown;
        private System.Windows.Forms.NumericUpDown _distributorReceivedNumericUpDown;
        private System.Windows.Forms.NumericUpDown _distributorBalanceNumericUpDown;
        private System.Windows.Forms.NumericUpDown _purchaserSpentNumericUpDown;
        private System.Windows.Forms.NumericUpDown _purchaserReceivedNumericUpDown;
        private System.Windows.Forms.NumericUpDown _purchaserBalanceNumericUpDown;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericUpDown _totalBalanceNumericUpDown;
    }
}