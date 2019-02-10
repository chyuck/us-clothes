using System;
using System.Windows.Forms;
using USClothesWebSite.Common.Helpers;

namespace USClothesWebSite.Win.Controls.PreviewPicture
{
    public partial class FullPictureViewForm : Form
    {
        private readonly string _pictureURL;

        public FullPictureViewForm(string pictureURL)
        {
            InitializeComponent();

            CheckHelper.ArgumentNotNullAndNotWhiteSpace(pictureURL, "pictureURL");

            _pictureURL = pictureURL;
        }

        private void FullPictureViewForm_Load(object sender, EventArgs e)
        {
            _pictureBox.ImageLocation = _pictureURL;
        }

        private void CopyURLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(_pictureURL);
        }
    }
}
