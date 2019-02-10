using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using USClothesWebSite.Common.Helpers;
using USClothesWebSite.DTO;
using USClothesWebSite.Win.Forms.Base;
using USClothesWebSite.Win.Helpers;
using USClothesWebSite.Win.Logic.Administration;
using USClothesWebSite.Win.Logic.Document;
using USClothesWebSite.Win.Logic.Extensions;
using USClothesWebSite.Win.Logic.Form;
using USClothesWebSite.Win.Logic.Security;

namespace USClothesWebSite.Win.Forms.Document
{
    public partial class ParcelEditForm : BaseParcelEditForm
    {
        public ParcelEditForm(EditFormMode mode, Parcel parcel)
            : base(mode, parcel)
        {
            InitializeComponent();
        }

        private ISecurityService SecurityService
        {
            get { return IoCContainer.Get<ISecurityService>(); }
        }

        protected override IEnumerable<Control> EditControls
        {
            get
            {
                return
                    new Control[]
                    {
                        _totalPriceTextBox,
                        _trackingNumberTextBox,
                        _sentDatePicker,
                        _receivedDatePicker,
                        _distributorReferenceEditor,
                        _purchaserSpentOnDeliveryNumericUpDown,
                        _rublesPerDollarNumericUpDown,
                        _commentsTextBox
                    };
            }
        }

        protected override void CustomizeControls()
        {
            var isCurrentUserPurchaser = SecurityService.IsCurrentUserPurchaser;
            var isCurrentUserDistributor = SecurityService.IsCurrentUserDistributor;

            switch (Mode)
            {
                case EditFormMode.View:
                    base.CustomizeControls();
                    break;

                case EditFormMode.Create:
                    CheckHelper.WithinCondition(isCurrentUserPurchaser, "Only purchaser can create parcel.");

                    ControlCustomizeHelper.CustomizeControl(_trackingNumberTextBox, EditFormMode.Create);
                    ControlCustomizeHelper.CustomizeControl(_sentDatePicker, EditFormMode.Create);
                    ControlCustomizeHelper.CustomizeControl(_receivedDatePicker, EditFormMode.View);
                    ControlCustomizeHelper.CustomizeControl(_distributorReferenceEditor, EditFormMode.Create);
                    ControlCustomizeHelper.CustomizeControl(_purchaserSpentOnDeliveryNumericUpDown, EditFormMode.Create);
                    ControlCustomizeHelper.CustomizeControl(_rublesPerDollarNumericUpDown, EditFormMode.Create);
                    ControlCustomizeHelper.CustomizeControl(_commentsTextBox, EditFormMode.Create);
                    break;

                case EditFormMode.Edit:
                    CheckHelper.WithinCondition(isCurrentUserPurchaser || isCurrentUserDistributor, "Only purchaser and distributor can change parcel.");

                    var editFormModeForPurchaser = isCurrentUserPurchaser ? EditFormMode.Edit : EditFormMode.View;
                    var editFormModeForDistributor = Dto.IsCurrentUserDistributorForParcel() ? EditFormMode.Edit : EditFormMode.View;

                    ControlCustomizeHelper.CustomizeControl(_trackingNumberTextBox, editFormModeForPurchaser);
                    ControlCustomizeHelper.CustomizeControl(_sentDatePicker, editFormModeForPurchaser);
                    ControlCustomizeHelper.CustomizeControl(_receivedDatePicker, editFormModeForDistributor);
                    ControlCustomizeHelper.CustomizeControl(_distributorReferenceEditor, editFormModeForPurchaser);
                    ControlCustomizeHelper.CustomizeControl(_purchaserSpentOnDeliveryNumericUpDown, editFormModeForPurchaser);
                    ControlCustomizeHelper.CustomizeControl(_rublesPerDollarNumericUpDown, editFormModeForPurchaser);
                    ControlCustomizeHelper.CustomizeControl(_commentsTextBox, editFormModeForPurchaser);
                    break;

                default:
                    throw new NotSupportedException(Mode.ToString());
            }
        }

        protected override void OnLoad()
        {
            _parcelNumberTextBox.Text = Dto != null ? Dto.ParcelNumber : string.Empty;
            _trackableDtoAttributes.SetControls(Mode, Dto);

            var totalPrice = Dto != null ? Dto.TotalPrice : 0;
            _totalPriceTextBox.Text = totalPrice.ToString("#0.00");
            
            _distributorReferenceEditor.Filter = u => u.Roles.Any(r => r.Name == Role.DISTRIBUTOR_ROLE_NAME);

            if (Mode == EditFormMode.Create)
                _rublesPerDollarNumericUpDown.Value =
                    IoCContainer.Get<IAdministrationService>().Settings.RublesPerDollar;

            base.OnLoad();
        }

        protected override void SetDtoToControls(Parcel parcel)
        {
            _trackingNumberTextBox.Text = parcel.TrackingNumber;
            _sentDatePicker.UtcValue = parcel.SentDate;
            _receivedDatePicker.UtcValue = parcel.ReceivedDate;
            _distributorReferenceEditor.Dto = parcel.Distributor;
            _purchaserSpentOnDeliveryNumericUpDown.Value = parcel.PurchaserSpentOnDelivery;
            _rublesPerDollarNumericUpDown.Value = parcel.RublesPerDollar;
            _commentsTextBox.Text = parcel.Comments;
        }

        protected override void SetControlsToDto(Parcel parcel)
        {
            parcel.ReceivedDate = _receivedDatePicker.UtcValue;
            parcel.TrackingNumber = _trackingNumberTextBox.Text;
            parcel.SentDate = _sentDatePicker.UtcValue;
            parcel.Distributor = _distributorReferenceEditor.Dto;
            parcel.PurchaserSpentOnDelivery = _purchaserSpentOnDeliveryNumericUpDown.Value;
            parcel.RublesPerDollar = _rublesPerDollarNumericUpDown.Value;
            parcel.Comments = _commentsTextBox.Text;
        }

        protected override string OnInsert(Parcel parcel)
        {
            return IoCContainer.Get<IDocumentService>().CreateParcel(parcel);
        }

        protected override string OnUpdate(Parcel parcel)
        {
            return IoCContainer.Get<IDocumentService>().UpdateParcel(parcel);
        }
    }

    public class BaseParcelEditForm : BaseDtoEditForm<Parcel>
    {
        protected BaseParcelEditForm() { }

        protected BaseParcelEditForm(EditFormMode mode, Parcel parcel)
            : base(mode, parcel)
        {
        }
    }
}
