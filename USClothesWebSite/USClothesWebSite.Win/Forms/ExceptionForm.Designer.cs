namespace USClothesWebSite.Win.Forms
{
    partial class ExceptionForm
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
            this.CopyAndCloseButton = new System.Windows.Forms.Button();
            this.HeaderLabel = new System.Windows.Forms.Label();
            this.MessageTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // CopyAndCloseButton
            // 
            this.CopyAndCloseButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.CopyAndCloseButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.CopyAndCloseButton.Location = new System.Drawing.Point(467, 317);
            this.CopyAndCloseButton.Name = "CopyAndCloseButton";
            this.CopyAndCloseButton.Size = new System.Drawing.Size(144, 30);
            this.CopyAndCloseButton.TabIndex = 0;
            this.CopyAndCloseButton.Text = "Копировать и закрыть";
            this.CopyAndCloseButton.UseVisualStyleBackColor = true;
            this.CopyAndCloseButton.Click += new System.EventHandler(this.CopyAndCloseButton_Click);
            // 
            // HeaderLabel
            // 
            this.HeaderLabel.AutoSize = true;
            this.HeaderLabel.ForeColor = System.Drawing.Color.Red;
            this.HeaderLabel.Location = new System.Drawing.Point(12, 9);
            this.HeaderLabel.Name = "HeaderLabel";
            this.HeaderLabel.Size = new System.Drawing.Size(605, 13);
            this.HeaderLabel.TabIndex = 1;
            this.HeaderLabel.Text = "Произошла ошибка программы. Пожалуйста скопируйте и отошлите сообщение об ошибке " +
    "поставщику программы. ";
            // 
            // MessageTextBox
            // 
            this.MessageTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MessageTextBox.Location = new System.Drawing.Point(15, 34);
            this.MessageTextBox.Multiline = true;
            this.MessageTextBox.Name = "MessageTextBox";
            this.MessageTextBox.ReadOnly = true;
            this.MessageTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.MessageTextBox.Size = new System.Drawing.Size(596, 266);
            this.MessageTextBox.TabIndex = 3;
            // 
            // ExceptionForm
            // 
            this.AcceptButton = this.CopyAndCloseButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(623, 362);
            this.Controls.Add(this.MessageTextBox);
            this.Controls.Add(this.HeaderLabel);
            this.Controls.Add(this.CopyAndCloseButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ExceptionForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ошибка программы";
            this.Load += new System.EventHandler(this.ExceptionForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button CopyAndCloseButton;
        private System.Windows.Forms.Label HeaderLabel;
        private System.Windows.Forms.TextBox MessageTextBox;
    }
}