using System;
using System.Windows.Forms;

namespace USClothesWebSite.Win.Controls.ReferenceEditor
{
    public class DialogClosedEventArgs : EventArgs
    {
        public DialogClosedEventArgs(DialogResult result)
        {
            Result = result;
        }

        public DialogResult Result { get; private set; }
    }
}
