namespace USClothesWebSite.Win.Controls.PreviewPicture
{
    partial class FullPictureViewForm
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
            this.components = new System.ComponentModel.Container();
            this._pictureBox = new System.Windows.Forms.PictureBox();
            this._contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this._copyURLToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this._pictureBox)).BeginInit();
            this._contextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // _pictureBox
            // 
            this._pictureBox.ContextMenuStrip = this._contextMenuStrip;
            this._pictureBox.Location = new System.Drawing.Point(2, 2);
            this._pictureBox.Name = "_pictureBox";
            this._pictureBox.Size = new System.Drawing.Size(480, 480);
            this._pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this._pictureBox.TabIndex = 0;
            this._pictureBox.TabStop = false;
            // 
            // _contextMenuStrip
            // 
            this._contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._copyURLToolStripMenuItem});
            this._contextMenuStrip.Name = "_contextMenuStrip";
            this._contextMenuStrip.Size = new System.Drawing.Size(183, 48);
            // 
            // _copyURLToolStripMenuItem
            // 
            this._copyURLToolStripMenuItem.Name = "_copyURLToolStripMenuItem";
            this._copyURLToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this._copyURLToolStripMenuItem.Text = "Копировать ссылку";
            this._copyURLToolStripMenuItem.Click += new System.EventHandler(this.CopyURLToolStripMenuItem_Click);
            // 
            // FullPictureViewForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 484);
            this.Controls.Add(this._pictureBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FullPictureViewForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Load += new System.EventHandler(this.FullPictureViewForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this._pictureBox)).EndInit();
            this._contextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox _pictureBox;
        private System.Windows.Forms.ContextMenuStrip _contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem _copyURLToolStripMenuItem;
    }
}