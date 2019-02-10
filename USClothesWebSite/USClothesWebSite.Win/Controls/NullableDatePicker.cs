using System;
using System.Windows.Forms;
using USClothesWebSite.Common.Services.Time;
using USClothesWebSite.Win.Logic;

namespace USClothesWebSite.Win.Controls
{
    public class NullableDatePicker : DateTimePicker
    {
        public NullableDatePicker()
        {
            ShowCheckBox = true;
            Checked = false;
            UpdateControl();
        }

        private static ITimeService TimeService
        {
            get { return IoC.Container.Get<ITimeService>(); }
        }

        public bool HasValue { get; private set; }

        public DateTime? UtcValue
        {
            get { return HasValue ? TimeService.ToUtc(Value) : (DateTime?)null; }
            set
            {
                Checked = value.HasValue;

                if (value.HasValue)
                    Value = TimeService.ToLocal(value.Value);
            }
        }

        protected override void OnValueChanged(EventArgs eventargs)
        {
            HasValue = Checked;
            UpdateControl();

            base.OnValueChanged(eventargs);
        }

        private void UpdateControl()
        {
            if (Checked)
                Format = DateTimePickerFormat.Long;
            else
            {
                Format = DateTimePickerFormat.Custom;
                CustomFormat = " ";
            }
        }
    }
}
