namespace USClothesWebSite.Win.Forms.Dictionary
{
    partial class SizeListForm
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
            this._copyButton = new System.Windows.Forms.Button();
            this.ActionButtonPanel.SuspendLayout();
            this.ButtonPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // ButtonPanel
            // 
            this.ButtonPanel.Controls.Add(this._copyButton);
            this.ButtonPanel.Controls.SetChildIndex(this.CreateButton, 0);
            this.ButtonPanel.Controls.SetChildIndex(this.EditButton, 0);
            this.ButtonPanel.Controls.SetChildIndex(this.RefreshButton, 0);
            this.ButtonPanel.Controls.SetChildIndex(this.FilterControl, 0);
            this.ButtonPanel.Controls.SetChildIndex(this._copyButton, 0);
            // 
            // RefreshButton
            // 
            this.RefreshButton.Location = new System.Drawing.Point(578, 5);
            this.RefreshButton.TabIndex = 4;
            // 
            // FilterControl
            // 
            this.FilterControl.Location = new System.Drawing.Point(331, 7);
            this.FilterControl.TabIndex = 3;
            // 
            // _copyButton
            // 
            this._copyButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._copyButton.Image = global::USClothesWebSite.Win.Properties.Resources.CopyHS;
            this._copyButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this._copyButton.Location = new System.Drawing.Point(210, 5);
            this._copyButton.Name = "_copyButton";
            this._copyButton.Size = new System.Drawing.Size(96, 23);
            this._copyButton.TabIndex = 2;
            this._copyButton.TabStop = false;
            this._copyButton.Text = "Копировать";
            this._copyButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this._copyButton.UseVisualStyleBackColor = true;
            this._copyButton.Click += new System.EventHandler(this.СopyButton_Click);
            // 
            // SizeListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 362);
            this.Name = "SizeListForm";
            this.ActionButtonPanel.ResumeLayout(false);
            this.ButtonPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button _copyButton;
    }
}