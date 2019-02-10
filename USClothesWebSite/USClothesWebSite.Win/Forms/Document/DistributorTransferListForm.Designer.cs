namespace USClothesWebSite.Win.Forms.Document
{
    partial class DistributorTransferListForm
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
            this._distributorReferenceEditor = new USClothesWebSite.Win.Controls.ReferenceEditor.UserReferenceEditor();
            this._distributorLabel = new System.Windows.Forms.Label();
            this.ActionButtonPanel.SuspendLayout();
            this.ButtonPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // ButtonPanel
            // 
            this.ButtonPanel.Controls.Add(this._distributorLabel);
            this.ButtonPanel.Controls.Add(this._distributorReferenceEditor);
            this.ButtonPanel.Controls.SetChildIndex(this.CreateButton, 0);
            this.ButtonPanel.Controls.SetChildIndex(this.EditButton, 0);
            this.ButtonPanel.Controls.SetChildIndex(this.RefreshButton, 0);
            this.ButtonPanel.Controls.SetChildIndex(this.FilterControl, 0);
            this.ButtonPanel.Controls.SetChildIndex(this._distributorReferenceEditor, 0);
            this.ButtonPanel.Controls.SetChildIndex(this._distributorLabel, 0);
            // 
            // RefreshButton
            // 
            this.RefreshButton.Location = new System.Drawing.Point(210, 5);
            this.RefreshButton.TabIndex = 2;
            // 
            // FilterControl
            // 
            this.FilterControl.Location = new System.Drawing.Point(721, 6);
            this.FilterControl.Visible = false;
            // 
            // _distributorReferenceEditor
            // 
            this._distributorReferenceEditor.AutoComboBoxRefresh = true;
            this._distributorReferenceEditor.CanBeCleared = true;
            this._distributorReferenceEditor.Location = new System.Drawing.Point(423, 6);
            this._distributorReferenceEditor.Mode = USClothesWebSite.Win.Controls.ReferenceEditor.ReferenceEditorMode.ComboBox;
            this._distributorReferenceEditor.Name = "_distributorReferenceEditor";
            this._distributorReferenceEditor.ReadOnly = false;
            this._distributorReferenceEditor.Size = new System.Drawing.Size(222, 21);
            this._distributorReferenceEditor.TabIndex = 4;
            // 
            // _distributorLabel
            // 
            this._distributorLabel.AutoSize = true;
            this._distributorLabel.Location = new System.Drawing.Point(315, 10);
            this._distributorLabel.Name = "_distributorLabel";
            this._distributorLabel.Size = new System.Drawing.Size(102, 13);
            this._distributorLabel.TabIndex = 3;
            this._distributorLabel.Text = "Распространитель";
            // 
            // DistributorTransferListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 362);
            this.Name = "DistributorTransferListForm";
            this.ActionButtonPanel.ResumeLayout(false);
            this.ButtonPanel.ResumeLayout(false);
            this.ButtonPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.ReferenceEditor.UserReferenceEditor _distributorReferenceEditor;
        private System.Windows.Forms.Label _distributorLabel;
    }
}