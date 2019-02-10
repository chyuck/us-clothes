namespace USClothesWebSite.Win.Controls
{
    partial class TrackableDtoAttributes
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
            this._changeDateTextBox = new System.Windows.Forms.TextBox();
            this._createDateTextBox = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this._changeUserTextBox = new System.Windows.Forms.TextBox();
            this._createUserTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // _changeDateTextBox
            // 
            this._changeDateTextBox.Location = new System.Drawing.Point(59, 52);
            this._changeDateTextBox.Name = "_changeDateTextBox";
            this._changeDateTextBox.ReadOnly = true;
            this._changeDateTextBox.Size = new System.Drawing.Size(247, 20);
            this._changeDateTextBox.TabIndex = 5;
            this._changeDateTextBox.TabStop = false;
            // 
            // _createDateTextBox
            // 
            this._createDateTextBox.Location = new System.Drawing.Point(59, 0);
            this._createDateTextBox.Name = "_createDateTextBox";
            this._createDateTextBox.ReadOnly = true;
            this._createDateTextBox.Size = new System.Drawing.Size(247, 20);
            this._createDateTextBox.TabIndex = 1;
            this._createDateTextBox.TabStop = false;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(0, 81);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(53, 13);
            this.label9.TabIndex = 6;
            this.label9.Text = "Изменил";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(0, 55);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 13);
            this.label8.TabIndex = 4;
            this.label8.Text = "Изменен";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(9, 29);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(44, 13);
            this.label7.TabIndex = 2;
            this.label7.Text = "Создал";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 3);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(44, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "Создан";
            // 
            // _changeUserTextBox
            // 
            this._changeUserTextBox.Location = new System.Drawing.Point(59, 78);
            this._changeUserTextBox.Name = "_changeUserTextBox";
            this._changeUserTextBox.ReadOnly = true;
            this._changeUserTextBox.Size = new System.Drawing.Size(369, 20);
            this._changeUserTextBox.TabIndex = 7;
            this._changeUserTextBox.TabStop = false;
            // 
            // _createUserTextBox
            // 
            this._createUserTextBox.Location = new System.Drawing.Point(59, 26);
            this._createUserTextBox.Name = "_createUserTextBox";
            this._createUserTextBox.ReadOnly = true;
            this._createUserTextBox.Size = new System.Drawing.Size(369, 20);
            this._createUserTextBox.TabIndex = 3;
            this._createUserTextBox.TabStop = false;
            // 
            // TrackableAttributes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this._changeDateTextBox);
            this.Controls.Add(this._createDateTextBox);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this._changeUserTextBox);
            this.Controls.Add(this._createUserTextBox);
            this.Name = "TrackableDtoAttributes";
            this.Size = new System.Drawing.Size(428, 98);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox _changeDateTextBox;
        private System.Windows.Forms.TextBox _createDateTextBox;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox _changeUserTextBox;
        private System.Windows.Forms.TextBox _createUserTextBox;
    }
}
