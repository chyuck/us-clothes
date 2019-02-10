using System.Collections.Generic;
using System.Windows.Forms;
using USClothesWebSite.Common.Helpers;
using USClothesWebSite.DTO;
using USClothesWebSite.Win.Forms.Base;
using USClothesWebSite.Win.Logic.Form;

namespace USClothesWebSite.Win.Forms.Report
{
    public partial class ParcelReportEditForm : BaseParcelReportEditForm
    {
        public ParcelReportEditForm(EditFormMode mode, ParcelReportItem parcelReportItem)
            : base(mode, parcelReportItem)
        {
            CheckHelper.ArgumentWithinCondition(mode == EditFormMode.View, "Form is readonly.");

            InitializeComponent();
        }

        protected override IEnumerable<Control> EditControls
        {
            get
            {
                return
                    new Control[]
                    {
                        _parcelNameTextBox,
                        _sentDatePicker,
                        _receivedDatePicker,
                        _distributorTextBox,
                        _purchaserPaidNumericUpDown,
                        _purchaserSpentOnDeliveryNumericUpDown,
                        _distributorSpentOnDeliveryNumericUpDown,
                        _totalPaidNumericUpDown,
                        _customersPrepaidNumericUpDown,
                        _customersPaidNumericUpDown,
                        _totalCustomersPaidNumericUpDown,
                        _expectedTotalCustomerPaidNumericUpDown,
                        _totalProfitNumericUpDown,
                        _expectedTotalProfitNumericUpDown
                    };
            }
        }

        protected override void SetDtoToControls(ParcelReportItem parcelReportItem)
        {
            _parcelNameTextBox.Text = parcelReportItem.ParcelName;
            _sentDatePicker.UtcValue = parcelReportItem.SentDate;
            _receivedDatePicker.UtcValue = parcelReportItem.ReceivedDate;
            _distributorTextBox.Text = parcelReportItem.DistributorName;
            _purchaserPaidNumericUpDown.Value = parcelReportItem.PurchaserPaid;
            _purchaserSpentOnDeliveryNumericUpDown.Value = parcelReportItem.PurchaserSpentOnDelivery;
            _distributorSpentOnDeliveryNumericUpDown.Value = parcelReportItem.DistributorSpentOnDelivery;
            _totalPaidNumericUpDown.Value = parcelReportItem.TotalPaid;
            _customersPrepaidNumericUpDown.Value = parcelReportItem.CustomersPrepaid;
            _customersPaidNumericUpDown.Value = parcelReportItem.CustomersPaid;
            _totalCustomersPaidNumericUpDown.Value = parcelReportItem.TotalCustomersPaid;
            _expectedTotalCustomerPaidNumericUpDown.Value = parcelReportItem.ExpectedTotalCustomerPaid;
            _totalProfitNumericUpDown.Value = parcelReportItem.TotalProfit;
            _expectedTotalProfitNumericUpDown.Value = parcelReportItem.ExpectedTotalProfit;
        }
    }

    public class BaseParcelReportEditForm : BaseDtoEditForm<ParcelReportItem>
    {
        protected BaseParcelReportEditForm() { }

        protected BaseParcelReportEditForm(EditFormMode mode, ParcelReportItem parcelReportItem)
            : base(mode, parcelReportItem)
        {
        }
    }
}
