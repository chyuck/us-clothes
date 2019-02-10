namespace USClothesWebSite.Win.Forms.Administration
{
    partial class LogEditForm
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
            this._textTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this._documentIdTextBox = new System.Windows.Forms.TextBox();
            this._logTypeTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this._createDateTextBox = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this._createUserTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // IdTextBox
            // 
            this.IdTextBox.Location = new System.Drawing.Point(92, 9);
            this.IdTextBox.TabIndex = 1;
            // 
            // IdLabel
            // 
            this.IdLabel.Location = new System.Drawing.Point(68, 12);
            this.IdLabel.TabIndex = 0;
            // 
            // CloseButton
            // 
            this.CloseButton.Location = new System.Drawing.Point(386, 313);
            this.CloseButton.TabIndex = 13;
            // 
            // SaveButton
            // 
            this.SaveButton.Location = new System.Drawing.Point(305, 313);
            this.SaveButton.TabIndex = 12;
            this.SaveButton.Visible = false;
            // 
            // ErrorMessageTextBox
            // 
            this.ErrorMessageTextBox.Location = new System.Drawing.Point(12, 360);
            this.ErrorMessageTextBox.Size = new System.Drawing.Size(10, 10);
            this.ErrorMessageTextBox.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(49, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Текст";
            // 
            // _textTextBox
            // 
            this._textTextBox.Location = new System.Drawing.Point(92, 34);
            this._textTextBox.Multiline = true;
            this._textTextBox.Name = "_textTextBox";
            this._textTextBox.ReadOnly = true;
            this._textTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this._textTextBox.Size = new System.Drawing.Size(369, 147);
            this._textTextBox.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 190);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "ID документа";
            // 
            // _documentIdTextBox
            // 
            this._documentIdTextBox.Location = new System.Drawing.Point(92, 187);
            this._documentIdTextBox.Name = "_documentIdTextBox";
            this._documentIdTextBox.ReadOnly = true;
            this._documentIdTextBox.Size = new System.Drawing.Size(80, 20);
            this._documentIdTextBox.TabIndex = 5;
            // 
            // _logTypeTextBox
            // 
            this._logTypeTextBox.Location = new System.Drawing.Point(92, 213);
            this._logTypeTextBox.Name = "_logTypeTextBox";
            this._logTypeTextBox.ReadOnly = true;
            this._logTypeTextBox.Size = new System.Drawing.Size(369, 20);
            this._logTypeTextBox.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(34, 216);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Тип лога";
            // 
            // _createDateTextBox
            // 
            this._createDateTextBox.Location = new System.Drawing.Point(92, 239);
            this._createDateTextBox.Name = "_createDateTextBox";
            this._createDateTextBox.ReadOnly = true;
            this._createDateTextBox.Size = new System.Drawing.Size(247, 20);
            this._createDateTextBox.TabIndex = 9;
            this._createDateTextBox.TabStop = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(42, 268);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(44, 13);
            this.label7.TabIndex = 10;
            this.label7.Text = "Создал";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(42, 242);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(44, 13);
            this.label6.TabIndex = 8;
            this.label6.Text = "Создан";
            // 
            // _createUserTextBox
            // 
            this._createUserTextBox.Location = new System.Drawing.Point(92, 265);
            this._createUserTextBox.Name = "_createUserTextBox";
            this._createUserTextBox.ReadOnly = true;
            this._createUserTextBox.Size = new System.Drawing.Size(369, 20);
            this._createUserTextBox.TabIndex = 11;
            this._createUserTextBox.TabStop = false;
            // 
            // LogEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(473, 354);
            this.Controls.Add(this._createDateTextBox);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this._createUserTextBox);
            this.Controls.Add(this._logTypeTextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this._documentIdTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this._textTextBox);
            this.Controls.Add(this.label1);
            this.Name = "LogEditForm";
            this.Text = "";
            this.Controls.SetChildIndex(this.IdLabel, 0);
            this.Controls.SetChildIndex(this.IdTextBox, 0);
            this.Controls.SetChildIndex(this.SaveButton, 0);
            this.Controls.SetChildIndex(this.CloseButton, 0);
            this.Controls.SetChildIndex(this.ErrorMessageTextBox, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this._textTextBox, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this._documentIdTextBox, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this._logTypeTextBox, 0);
            this.Controls.SetChildIndex(this._createUserTextBox, 0);
            this.Controls.SetChildIndex(this.label6, 0);
            this.Controls.SetChildIndex(this.label7, 0);
            this.Controls.SetChildIndex(this._createDateTextBox, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox _textTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox _documentIdTextBox;
        private System.Windows.Forms.TextBox _logTypeTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox _createDateTextBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox _createUserTextBox;
    }
}