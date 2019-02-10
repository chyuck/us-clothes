using System;
using System.ComponentModel;
using System.Windows.Forms;
using USClothesWebSite.Common.Extensions;
using USClothesWebSite.Common.Services.Time;
using USClothesWebSite.Win.Logic;

namespace USClothesWebSite.Win.Controls
{
    public partial class DateIntervalControl : UserControl
    {
        public DateIntervalControl()
        {
            InitializeComponent();

            var localNow = TimeService.LocalNow.Date;
            _fromDateTimePicker.Value = localNow.AddMonths(-1);
            _toDateTimePicker.Value = localNow;
        }

        private ITimeService TimeService
        {
            get { return IoC.Container.Get<ITimeService>(); }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public DateTime UtcFrom
        {
            get { return TimeService.ToUtc(_fromDateTimePicker.Value.Date); }
            set { _fromDateTimePicker.Value = TimeService.ToLocal(value).Date; }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public DateTime UtcTo
        {
            get { return TimeService.ToUtc(_toDateTimePicker.Value.ToEndOfDay()); }
            set { _toDateTimePicker.Value = TimeService.ToLocal(value).Date; }
        }

        private void FromDateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            if (_fromDateTimePicker.Value > _toDateTimePicker.Value)
                _fromDateTimePicker.Value = _toDateTimePicker.Value;
        }

        private void ToDateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            if (_fromDateTimePicker.Value > _toDateTimePicker.Value)
                _toDateTimePicker.Value = _fromDateTimePicker.Value;
        }
    }
}
