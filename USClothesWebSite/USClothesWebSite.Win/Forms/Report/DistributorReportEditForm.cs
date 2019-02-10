using System.Collections.Generic;
using System.Windows.Forms;
using USClothesWebSite.Common.Helpers;
using USClothesWebSite.DTO;
using USClothesWebSite.Win.Forms.Base;
using USClothesWebSite.Win.Logic.Form;

namespace USClothesWebSite.Win.Forms.Report
{
    public partial class DistributorReportEditForm : BaseDistributorReportEditForm
    {
        public DistributorReportEditForm(EditFormMode mode, DistributorReportItem distributorReportItem)
            : base(mode, distributorReportItem)
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
                        _distributorNameTextBox,
                        _distributorSpentNumericUpDown,
                        _distributorReceivedNumericUpDown,
                        _distributorBalanceNumericUpDown,
                        _purchaserSpentNumericUpDown,
                        _purchaserReceivedNumericUpDown,
                        _purchaserBalanceNumericUpDown,
                        _totalBalanceNumericUpDown
                    };
            }
        }

        protected override void SetDtoToControls(DistributorReportItem distributorReportItem)
        {
            _distributorNameTextBox.Text = distributorReportItem.DistributorName;
            _distributorSpentNumericUpDown.Value = distributorReportItem.DistributorSpent;
            _distributorReceivedNumericUpDown.Value = distributorReportItem.DistributorReceived;
            _distributorBalanceNumericUpDown.Value = distributorReportItem.DistributorBalance;
            _purchaserSpentNumericUpDown.Value = distributorReportItem.PurchaserSpent;
            _purchaserReceivedNumericUpDown.Value = distributorReportItem.PurchaserReceived;
            _purchaserBalanceNumericUpDown.Value = distributorReportItem.PurchaserBalance;
            _totalBalanceNumericUpDown.Value = distributorReportItem.TotalBalance;
        }
    }

    public class BaseDistributorReportEditForm : BaseDtoEditForm<DistributorReportItem>
    {
        protected BaseDistributorReportEditForm() { }

        protected BaseDistributorReportEditForm(EditFormMode mode, DistributorReportItem distributorReportItem)
            : base(mode, distributorReportItem)
        {
        }
    }
}
