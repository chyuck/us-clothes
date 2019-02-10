namespace USClothesWebSite.Win.Controls
{
    partial class FilterControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this._clearFilterButton = new System.Windows.Forms.Button();
            this._filterWatermarkedTextBox = new USClothesWebSite.Win.Controls.WatermarkedTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // _clearFilterButton
            // 
            this._clearFilterButton.BackColor = System.Drawing.SystemColors.Window;
            this._clearFilterButton.FlatAppearance.BorderColor = System.Drawing.SystemColors.Window;
            this._clearFilterButton.FlatAppearance.BorderSize = 0;
            this._clearFilterButton.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Window;
            this._clearFilterButton.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Window;
            this._clearFilterButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._clearFilterButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this._clearFilterButton.Image = global::USClothesWebSite.Win.Properties.Resources.delete_12x12;
            this._clearFilterButton.Location = new System.Drawing.Point(220, 3);
            this._clearFilterButton.Margin = new System.Windows.Forms.Padding(0);
            this._clearFilterButton.Name = "_clearFilterButton";
            this._clearFilterButton.Size = new System.Drawing.Size(14, 14);
            this._clearFilterButton.TabIndex = 2;
            this._clearFilterButton.TabStop = false;
            this._clearFilterButton.UseVisualStyleBackColor = false;
            this._clearFilterButton.Click += new System.EventHandler(this.ClearFilterButton_Click);
            // 
            // _filterWatermarkedTextBox
            // 
            this._filterWatermarkedTextBox.Location = new System.Drawing.Point(59, 0);
            this._filterWatermarkedTextBox.MaxLength = 20;
            this._filterWatermarkedTextBox.Name = "_filterWatermarkedTextBox";
            this._filterWatermarkedTextBox.Size = new System.Drawing.Size(189, 20);
            this._filterWatermarkedTextBox.TabIndex = 1;
            this._filterWatermarkedTextBox.Watermark = "Введите фильтр";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Фильтр";
            // 
            // FilterControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this._clearFilterButton);
            this.Controls.Add(this._filterWatermarkedTextBox);
            this.Controls.Add(this.label1);
            this.MaximumSize = new System.Drawing.Size(241, 20);
            this.MinimumSize = new System.Drawing.Size(241, 20);
            this.Name = "FilterControl";
            this.Size = new System.Drawing.Size(241, 20);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button _clearFilterButton;
        private WatermarkedTextBox _filterWatermarkedTextBox;
        private System.Windows.Forms.Label label1;

    }
}
