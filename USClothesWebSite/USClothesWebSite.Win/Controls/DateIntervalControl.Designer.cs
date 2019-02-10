namespace USClothesWebSite.Win.Controls
{
    partial class DateIntervalControl
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
            this.label1 = new System.Windows.Forms.Label();
            this._fromDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this._toDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(13, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "с";
            // 
            // _fromDateTimePicker
            // 
            this._fromDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this._fromDateTimePicker.Location = new System.Drawing.Point(22, 0);
            this._fromDateTimePicker.Name = "_fromDateTimePicker";
            this._fromDateTimePicker.Size = new System.Drawing.Size(93, 20);
            this._fromDateTimePicker.TabIndex = 1;
            this._fromDateTimePicker.ValueChanged += new System.EventHandler(this.FromDateTimePicker_ValueChanged);
            // 
            // _toDateTimePicker
            // 
            this._toDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this._toDateTimePicker.Location = new System.Drawing.Point(146, 0);
            this._toDateTimePicker.Name = "_toDateTimePicker";
            this._toDateTimePicker.Size = new System.Drawing.Size(93, 20);
            this._toDateTimePicker.TabIndex = 3;
            this._toDateTimePicker.ValueChanged += new System.EventHandler(this.ToDateTimePicker_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(124, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(19, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "по";
            // 
            // DateIntervalControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this._toDateTimePicker);
            this.Controls.Add(this.label2);
            this.Controls.Add(this._fromDateTimePicker);
            this.Controls.Add(this.label1);
            this.Name = "DateIntervalControl";
            this.Size = new System.Drawing.Size(240, 20);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker _fromDateTimePicker;
        private System.Windows.Forms.DateTimePicker _toDateTimePicker;
        private System.Windows.Forms.Label label2;
    }
}
