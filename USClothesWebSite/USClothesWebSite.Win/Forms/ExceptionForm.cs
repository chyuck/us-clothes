using System;
using System.Windows.Forms;
using USClothesWebSite.Common.Helpers;
using USClothesWebSite.Win.Logic;
using USClothesWebSite.Win.Logic.Error;

namespace USClothesWebSite.Win.Forms
{
    public partial class ExceptionForm : Form
    {
        public ExceptionForm()
        {
            InitializeComponent();
        }

        public ExceptionForm(Exception exception)
            : this()
        {
            CheckHelper.ArgumentNotNull(exception, "exception");

            Exception = exception;
        }

        public Exception Exception { get; private set; }

        private void ExceptionForm_Load(object sender, EventArgs e)
        {
            var errorService = IoC.Container.Get<IErrorService>();

            HeaderLabel.Text = errorService.GetHeader(Exception);
            MessageTextBox.Text = errorService.GetMessage(Exception);
        }

        private void CopyAndCloseButton_Click(object sender, EventArgs e)
        {
            var text = string.Format("{1}{0}{0}{2}", Environment.NewLine, HeaderLabel.Text, MessageTextBox.Text);

            Clipboard.SetText(text);
        }
    }
}
