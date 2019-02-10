namespace USClothesWebSite.Win.Controls.PreviewPicture
{
    partial class PreviewPicture
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
            this._loadButton = new System.Windows.Forms.Button();
            this._pictureBox = new System.Windows.Forms.PictureBox();
            this._openImageDialog = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this._pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // _loadButton
            // 
            this._loadButton.Location = new System.Drawing.Point(0, 131);
            this._loadButton.Name = "_loadButton";
            this._loadButton.Size = new System.Drawing.Size(128, 23);
            this._loadButton.TabIndex = 0;
            this._loadButton.Text = "Загрузить";
            this._loadButton.UseVisualStyleBackColor = true;
            this._loadButton.Click += new System.EventHandler(this.LoadButton_Click);
            // 
            // _pictureBox
            // 
            this._pictureBox.BackColor = System.Drawing.SystemColors.Window;
            this._pictureBox.Location = new System.Drawing.Point(0, 0);
            this._pictureBox.Margin = new System.Windows.Forms.Padding(0);
            this._pictureBox.Name = "_pictureBox";
            this._pictureBox.Size = new System.Drawing.Size(128, 128);
            this._pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this._pictureBox.TabIndex = 22;
            this._pictureBox.TabStop = false;
            this._pictureBox.DoubleClick += new System.EventHandler(this.PictureBox_DoubleClick);
            // 
            // _openImageDialog
            // 
            this._openImageDialog.Filter = "Фотографии (*.jpg)|*.jpg";
            this._openImageDialog.Title = "Загрузить фотографию";
            // 
            // PreviewPicture
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this._loadButton);
            this.Controls.Add(this._pictureBox);
            this.Name = "PreviewPicture";
            this.Size = new System.Drawing.Size(128, 156);
            ((System.ComponentModel.ISupportInitialize)(this._pictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox _pictureBox;
        private System.Windows.Forms.Button _loadButton;
        private System.Windows.Forms.OpenFileDialog _openImageDialog;
    }
}
