namespace USClothesWebSite.Win.Controls.ReferenceEditor
{
    partial class ReferenceEditor
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
                OnDispose();
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
            this._selectButton = new System.Windows.Forms.Button();
            this._descriptionComboBox = new System.Windows.Forms.ComboBox();
            this._descriptionTextBox = new System.Windows.Forms.TextBox();
            this._clearButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // _selectButton
            // 
            this._selectButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._selectButton.Location = new System.Drawing.Point(275, 0);
            this._selectButton.Name = "_selectButton";
            this._selectButton.Size = new System.Drawing.Size(24, 20);
            this._selectButton.TabIndex = 1;
            this._selectButton.Text = "...";
            this._selectButton.UseVisualStyleBackColor = true;
            this._selectButton.Click += new System.EventHandler(this.SelectButton_Click);
            // 
            // _descriptionComboBox
            // 
            this._descriptionComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._descriptionComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._descriptionComboBox.FormattingEnabled = true;
            this._descriptionComboBox.Location = new System.Drawing.Point(0, 0);
            this._descriptionComboBox.Name = "_descriptionComboBox";
            this._descriptionComboBox.Size = new System.Drawing.Size(269, 21);
            this._descriptionComboBox.TabIndex = 0;
            this._descriptionComboBox.Visible = false;
            this._descriptionComboBox.SelectedIndexChanged += new System.EventHandler(this.DescriptionComboBox_SelectedIndexChanged);
            // 
            // _descriptionTextBox
            // 
            this._descriptionTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._descriptionTextBox.Location = new System.Drawing.Point(0, 0);
            this._descriptionTextBox.Name = "_descriptionTextBox";
            this._descriptionTextBox.ReadOnly = true;
            this._descriptionTextBox.Size = new System.Drawing.Size(269, 20);
            this._descriptionTextBox.TabIndex = 0;
            // 
            // _clearButton
            // 
            this._clearButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._clearButton.Location = new System.Drawing.Point(305, 0);
            this._clearButton.Name = "_clearButton";
            this._clearButton.Size = new System.Drawing.Size(24, 20);
            this._clearButton.TabIndex = 2;
            this._clearButton.Text = "X";
            this._clearButton.UseVisualStyleBackColor = true;
            this._clearButton.Click += new System.EventHandler(this.ClearButton_Click);
            // 
            // ReferenceEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this._clearButton);
            this.Controls.Add(this._selectButton);
            this.Controls.Add(this._descriptionTextBox);
            this.Controls.Add(this._descriptionComboBox);
            this.Name = "ReferenceEditor";
            this.Size = new System.Drawing.Size(333, 21);
            this.Load += new System.EventHandler(this.ReferenceEditor_Load);
            this.ParentChanged += new System.EventHandler(this.ReferenceEditor_ParentChanged);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button _selectButton;
        private System.Windows.Forms.ComboBox _descriptionComboBox;
        private System.Windows.Forms.TextBox _descriptionTextBox;
        private System.Windows.Forms.Button _clearButton;


    }
}
