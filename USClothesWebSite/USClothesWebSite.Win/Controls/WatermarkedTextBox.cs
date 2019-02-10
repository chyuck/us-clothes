using System;
using System.Windows.Forms;

namespace USClothesWebSite.Win.Controls
{
    public class WatermarkedTextBox : TextBox
    {
        public string Watermark
        {
            get
            {
                return _watermark;
            }
            set
            {
                _watermark = value;
                UpdateWatermark();
            }
        }
        private string _watermark;

        private void UpdateWatermark()
        {
            if (IsHandleCreated && _watermark != null)
            {
                NativeMethods.SendMessageW(Handle, NativeMethods.EM_SETWATERMARKBANNER, (IntPtr)1, _watermark);
            }
        }

        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);

            UpdateWatermark();
        }
    }
}
