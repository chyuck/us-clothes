namespace USClothesWebSite.Win.Forms.Administration
{
    partial class SettingsEditForm
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
            this.label1 = new System.Windows.Forms.Label();
            this._rublesPerDollarNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this._trackableDtoAttributes = new USClothesWebSite.Win.Controls.TrackableDtoAttributes();
            ((System.ComponentModel.ISupportInitialize)(this._rublesPerDollarNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // IdTextBox
            // 
            this.IdTextBox.Location = new System.Drawing.Point(120, 54);
            this.IdTextBox.TabIndex = 2;
            this.IdTextBox.Visible = false;
            // 
            // IdLabel
            // 
            this.IdLabel.Location = new System.Drawing.Point(96, 57);
            this.IdLabel.TabIndex = 1;
            this.IdLabel.Visible = false;
            // 
            // CloseButton
            // 
            this.CloseButton.Location = new System.Drawing.Point(414, 221);
            this.CloseButton.TabIndex = 7;
            // 
            // SaveButton
            // 
            this.SaveButton.Location = new System.Drawing.Point(333, 221);
            this.SaveButton.TabIndex = 6;
            // 
            // ErrorMessageTextBox
            // 
            this.ErrorMessageTextBox.Location = new System.Drawing.Point(12, 14);
            this.ErrorMessageTextBox.Size = new System.Drawing.Size(477, 50);
            this.ErrorMessageTextBox.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 82);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Курс доллара (руб)";
            // 
            // _rublesPerDollarNumericUpDown
            // 
            this._rublesPerDollarNumericUpDown.DecimalPlaces = 2;
            this._rublesPerDollarNumericUpDown.Location = new System.Drawing.Point(120, 80);
            this._rublesPerDollarNumericUpDown.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this._rublesPerDollarNumericUpDown.Name = "_rublesPerDollarNumericUpDown";
            this._rublesPerDollarNumericUpDown.Size = new System.Drawing.Size(166, 20);
            this._rublesPerDollarNumericUpDown.TabIndex = 4;
            // 
            // _trackableDtoAttributes
            // 
            this._trackableDtoAttributes.Location = new System.Drawing.Point(61, 106);
            this._trackableDtoAttributes.Name = "_trackableDtoAttributes";
            this._trackableDtoAttributes.Size = new System.Drawing.Size(428, 98);
            this._trackableDtoAttributes.TabIndex = 5;
            // 
            // SettingsEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(503, 264);
            this.Controls.Add(this._trackableDtoAttributes);
            this.Controls.Add(this.label1);
            this.Controls.Add(this._rublesPerDollarNumericUpDown);
            this.Name = "SettingsEditForm";
            this.Text = "";
            this.Controls.SetChildIndex(this.IdLabel, 0);
            this.Controls.SetChildIndex(this.IdTextBox, 0);
            this.Controls.SetChildIndex(this.SaveButton, 0);
            this.Controls.SetChildIndex(this.CloseButton, 0);
            this.Controls.SetChildIndex(this.ErrorMessageTextBox, 0);
            this.Controls.SetChildIndex(this._rublesPerDollarNumericUpDown, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this._trackableDtoAttributes, 0);
            ((System.ComponentModel.ISupportInitialize)(this._rublesPerDollarNumericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown _rublesPerDollarNumericUpDown;
        private Controls.TrackableDtoAttributes _trackableDtoAttributes;
    }
}