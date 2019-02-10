using System.Windows.Forms;
using USClothesWebSite.Common.Helpers;
using USClothesWebSite.Win.Controls.PreviewPicture;
using USClothesWebSite.Win.Controls.ReferenceEditor;
using USClothesWebSite.Win.Logic.Form;

namespace USClothesWebSite.Win.Helpers
{
    public static class ControlCustomizeHelper
    {
        public static void CustomizeControl(TextBox textBox, EditFormMode mode)
        {
            CheckHelper.ArgumentNotNull(textBox, "textBox");

            textBox.ReadOnly = mode == EditFormMode.View;
        }

        public static void CustomizeControl(NumericUpDown numericUpDown, EditFormMode mode)
        {
            CheckHelper.ArgumentNotNull(numericUpDown, "numericUpDown");

            numericUpDown.ReadOnly = mode == EditFormMode.View;
            numericUpDown.Increment = mode == EditFormMode.View ? 0 : 1;
        }

        public static void CustomizeControl(DateTimePicker dateTimePicker, EditFormMode mode)
        {
            CheckHelper.ArgumentNotNull(dateTimePicker, "dateTimePicker");

            dateTimePicker.Enabled = mode != EditFormMode.View;
        }

        public static void CustomizeControl(Button button, EditFormMode mode)
        {
            CheckHelper.ArgumentNotNull(button, "button");

            button.Enabled = mode != EditFormMode.View;
        }

        public static void CustomizeControl(CheckBox checkBox, EditFormMode mode)
        {
            CheckHelper.ArgumentNotNull(checkBox, "checkBox");

            checkBox.Enabled = mode != EditFormMode.View;
        }

        public static void CustomizeControl(CheckedListBox checkedListBox, EditFormMode mode)
        {
            CheckHelper.ArgumentNotNull(checkedListBox, "checkedListBox");

            checkedListBox.Enabled = mode != EditFormMode.View;
        }

        public static void CustomizeControl(ReferenceEditor referenceEditor, EditFormMode mode)
        {
            CheckHelper.ArgumentNotNull(referenceEditor, "referenceEditor");

            referenceEditor.ReadOnly = mode == EditFormMode.View;
        }

        public static void CustomizeControl(PreviewPicture previewPicture, EditFormMode mode)
        {
            CheckHelper.ArgumentNotNull(previewPicture, "previewPicture");

            previewPicture.Enabled = mode != EditFormMode.View;
        }
    }
}
