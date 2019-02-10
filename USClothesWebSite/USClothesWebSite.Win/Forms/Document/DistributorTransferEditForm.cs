using System.Collections.Generic;
using System.Windows.Forms;
using USClothesWebSite.DTO;
using USClothesWebSite.Win.Forms.Base;
using USClothesWebSite.Win.Logic.Administration;
using USClothesWebSite.Win.Logic.Document;
using USClothesWebSite.Win.Logic.Form;

namespace USClothesWebSite.Win.Forms.Document
{
    public partial class DistributorTransferEditForm : BaseDistributorTransferEditForm
    {
        public DistributorTransferEditForm(EditFormMode mode, DistributorTransfer distributorTransfer)
            : base(mode, distributorTransfer)
        {
            InitializeComponent();
        }

        protected override IEnumerable<Control> EditControls
        {
            get
            {
                return
                    new Control[]
                    {
                        _dateTimePicker,
                        _amountNumericUpDown,
                        _rublesPerDollarNumericUpDown,
                        _activeCheckBox
                    };
            }
        }

        protected override void OnLoad()
        {
            _trackableDtoAttributes.SetControls(Mode, Dto);

            if (Mode == EditFormMode.Create)
                _rublesPerDollarNumericUpDown.Value =
                    IoCContainer.Get<IAdministrationService>().Settings.RublesPerDollar;

            base.OnLoad();
        }

        protected override void SetDtoToControls(DistributorTransfer distributorTransfer)
        {
            _dateTimePicker.Value = distributorTransfer.Date;
            _amountNumericUpDown.Value = distributorTransfer.Amount;
            _rublesPerDollarNumericUpDown.Value = distributorTransfer.RublesPerDollar;
            _activeCheckBox.Checked = distributorTransfer.Active;
        }

        protected override void SetControlsToDto(DistributorTransfer distributorTransfer)
        {
            distributorTransfer.Date = _dateTimePicker.Value;
            distributorTransfer.Amount = _amountNumericUpDown.Value;
            distributorTransfer.RublesPerDollar = _rublesPerDollarNumericUpDown.Value;
            distributorTransfer.Active = _activeCheckBox.Checked;
        }

        protected override string OnInsert(DistributorTransfer distributorTransfer)
        {
            return IoCContainer.Get<IDocumentService>().CreateDistributorTransfer(distributorTransfer);
        }

        protected override string OnUpdate(DistributorTransfer distributorTransfer)
        {
            return IoCContainer.Get<IDocumentService>().UpdateDistributorTransfer(distributorTransfer);
        }
    }

    public class BaseDistributorTransferEditForm : BaseDtoEditForm<DistributorTransfer>
    {
        protected BaseDistributorTransferEditForm() { }

        protected BaseDistributorTransferEditForm(EditFormMode mode, DistributorTransfer distributorTransfer)
            : base(mode, distributorTransfer)
        {
        }
    }
}
