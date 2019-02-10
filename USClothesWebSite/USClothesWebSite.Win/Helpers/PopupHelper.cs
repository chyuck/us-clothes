using System.Windows.Forms;
using USClothesWebSite.Common.Helpers;

namespace USClothesWebSite.Win.Helpers
{
    public static class PopupHelper
    {
        public static void ShowError(IWin32Window owner, string message, string caption = null)
        {
            CheckHelper.ArgumentNotNull(owner, "owner");
            CheckHelper.ArgumentNotNullAndNotWhiteSpace(message, "message");

            MessageBox.Show(owner, message, caption ?? "Ошибка",
                MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
        }

        public static void ShowInfo(IWin32Window owner, string message, string caption = null)
        {
            CheckHelper.ArgumentNotNull(owner, "owner");
            CheckHelper.ArgumentNotNullAndNotWhiteSpace(message, "message");

            MessageBox.Show(owner, message, caption ?? "Информация",
                MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
        }

        public static bool ShowYesNoDialog(IWin32Window owner, string message, string caption = null)
        {
            CheckHelper.ArgumentNotNull(owner, "owner");
            CheckHelper.ArgumentNotNullAndNotWhiteSpace(message, "message");

            var dialogResult =
                MessageBox.Show(owner, message, caption ?? "Вопрос",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            return dialogResult == DialogResult.Yes;
        }
    }
}
