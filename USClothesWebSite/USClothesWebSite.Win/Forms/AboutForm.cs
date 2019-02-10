using System;
using System.Diagnostics;
using System.Windows.Forms;
using USClothesWebSite.Common.Helpers;

namespace USClothesWebSite.Win.Forms
{
    public partial class AboutForm : Form
    {
        public AboutForm(Version version)
        {
            CheckHelper.ArgumentNotNull(version, "version");

            Version = version;

            InitializeComponent();
        }

        public Version Version { get; private set; }

        private void AboutForm_Load(object sender, EventArgs e)
        {
            VersionLabel.Text = Version.ToString();
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void WebsiteLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var linkLabel = (LinkLabel)sender;
            var url = string.Format("http://{0}/", linkLabel.Text);
            
            Process.Start(url);
        }

        private void EmailLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var linkLabel = (LinkLabel)sender;
            var url = string.Format("mailto:{0}", linkLabel.Text);

            Process.Start(url);
        }
    }
}
