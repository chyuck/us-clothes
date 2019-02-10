using System;
using System.Collections.Generic;
using System.Windows.Forms;
using USClothesWebSite.Common.Helpers;
using USClothesWebSite.Common.Services.Time;
using USClothesWebSite.DTO;
using USClothesWebSite.Win.Controls.ReferenceEditor;
using USClothesWebSite.Win.Forms.Base;
using USClothesWebSite.Win.Helpers;
using USClothesWebSite.Win.Logic.Administration;
using USClothesWebSite.Win.Logic.Document;
using USClothesWebSite.Win.Logic.Extensions;
using USClothesWebSite.Win.Logic.Form;
using USClothesWebSite.Win.Logic.Security;

namespace USClothesWebSite.Win.Forms.Document
{
    public partial class OrderEditForm : BaseOrderEditForm
    {
        public OrderEditForm(EditFormMode mode, Order order)
            : this(mode, order, null)
        {
        }

        public OrderEditForm(EditFormMode mode, Order order, Parcel parcel)
            : base(mode, order, parcel)
        {
            InitializeComponent();
        }

        private ISecurityService SecurityService
        {
            get { return IoCContainer.Get<ISecurityService>(); }
        }

        private ITimeService TimeService
        {
            get { return IoCContainer.Get<ITimeService>(); }
        }

        protected override ReferenceEditor<Parcel> MasterDtoEditor
        {
            get { return _parcelReferenceEditor; }
        }

        protected override IEnumerable<Control> EditControls
        {
            get
            {
                return
                    new Control[]
                    {
                        _totalPriceTextBox,
                        _orderDateTimePicker,
                        _activeCheckBox,
                        _customerFirstNameWatermarkedTextBox,
                        _customerLastNameWatermarkedTextBox,
                        _customerAddressWatermarkedTextBox,
                        _customerCityWatermarkedTextBox,
                        _customerCountryWatermarkedTextBox,
                        _customerPostalCodeWatermarkedTextBox,
                        _customerPhoneNumberWatermarkedTextBox,
                        _customerEmailWatermarkedTextBox,
                        _customerPrepaidNumericUpDown,
                        _customerPaidNumericUpDown,
                        _rublesPerDollarNumericUpDown,
                        _distributorSpentOnDeliveryNumericUpDown,
                        _commentsTextBox,
                        _parcelReferenceEditor,
                        _trackingNumberTextBox
                    };
            }
        }

        protected override void CustomizeControls()
        {
            var isCurrentUserSeller = SecurityService.IsCurrentUserSeller;
            var isCurrentUserPurchaser = SecurityService.IsCurrentUserPurchaser;
            var isCurrentUserDistributor = SecurityService.IsCurrentUserDistributor;

            switch (Mode)
            {
                case EditFormMode.View:
                    base.CustomizeControls();
                    break;

                case EditFormMode.Create:
                    CheckHelper.WithinCondition(isCurrentUserSeller, "Only seller can create order.");

                    var createFormModeForPurchaser = isCurrentUserPurchaser ? EditFormMode.Create : EditFormMode.View;

                    ControlCustomizeHelper.CustomizeControl(_orderDateTimePicker, EditFormMode.Create);
                    ControlCustomizeHelper.CustomizeControl(_activeCheckBox, EditFormMode.Create);
                    ControlCustomizeHelper.CustomizeControl(_customerFirstNameWatermarkedTextBox, EditFormMode.Create);
                    ControlCustomizeHelper.CustomizeControl(_customerLastNameWatermarkedTextBox, EditFormMode.Create);
                    ControlCustomizeHelper.CustomizeControl(_customerAddressWatermarkedTextBox, EditFormMode.Create);
                    ControlCustomizeHelper.CustomizeControl(_customerCityWatermarkedTextBox, EditFormMode.Create);
                    ControlCustomizeHelper.CustomizeControl(_customerCountryWatermarkedTextBox, EditFormMode.Create);
                    ControlCustomizeHelper.CustomizeControl(_customerPostalCodeWatermarkedTextBox, EditFormMode.Create);
                    ControlCustomizeHelper.CustomizeControl(_customerPhoneNumberWatermarkedTextBox, EditFormMode.Create);
                    ControlCustomizeHelper.CustomizeControl(_customerEmailWatermarkedTextBox, EditFormMode.Create);
                    ControlCustomizeHelper.CustomizeControl(_customerPrepaidNumericUpDown, EditFormMode.Create);
                    ControlCustomizeHelper.CustomizeControl(_customerPaidNumericUpDown, EditFormMode.Create);
                    ControlCustomizeHelper.CustomizeControl(_rublesPerDollarNumericUpDown, EditFormMode.Create);
                    ControlCustomizeHelper.CustomizeControl(_distributorSpentOnDeliveryNumericUpDown, EditFormMode.View);
                    ControlCustomizeHelper.CustomizeControl(_commentsTextBox, EditFormMode.Create);
                    ControlCustomizeHelper.CustomizeControl(_parcelReferenceEditor, createFormModeForPurchaser);
                    ControlCustomizeHelper.CustomizeControl(_trackingNumberTextBox, EditFormMode.View);
                    break;

                case EditFormMode.Edit:
                    CheckHelper.WithinCondition(
                        isCurrentUserPurchaser || isCurrentUserDistributor || isCurrentUserSeller, 
                        "Only purchaser, distributor and seller can change order.");

                    var editFormModeForPurchaser = isCurrentUserPurchaser ? EditFormMode.Edit : EditFormMode.View;
                    var editFormModeForDistributor = Dto.IsCurrentUserDistributorForOrder() ? EditFormMode.Edit : EditFormMode.View;
                    var editFormModeForSeller = Dto.IsCurrentUserSellerForOrder() ? EditFormMode.Edit : EditFormMode.View;

                    ControlCustomizeHelper.CustomizeControl(_orderDateTimePicker, editFormModeForSeller);
                    ControlCustomizeHelper.CustomizeControl(_activeCheckBox, editFormModeForSeller);
                    ControlCustomizeHelper.CustomizeControl(_customerFirstNameWatermarkedTextBox, editFormModeForSeller);
                    ControlCustomizeHelper.CustomizeControl(_customerLastNameWatermarkedTextBox, editFormModeForSeller);
                    ControlCustomizeHelper.CustomizeControl(_customerAddressWatermarkedTextBox, editFormModeForSeller);
                    ControlCustomizeHelper.CustomizeControl(_customerCityWatermarkedTextBox, editFormModeForSeller);
                    ControlCustomizeHelper.CustomizeControl(_customerCountryWatermarkedTextBox, editFormModeForSeller);
                    ControlCustomizeHelper.CustomizeControl(_customerPostalCodeWatermarkedTextBox, editFormModeForSeller);
                    ControlCustomizeHelper.CustomizeControl(_customerPhoneNumberWatermarkedTextBox, editFormModeForSeller);
                    ControlCustomizeHelper.CustomizeControl(_customerEmailWatermarkedTextBox, editFormModeForSeller);
                    ControlCustomizeHelper.CustomizeControl(_customerPrepaidNumericUpDown, editFormModeForSeller);
                    ControlCustomizeHelper.CustomizeControl(_customerPaidNumericUpDown, editFormModeForSeller);
                    ControlCustomizeHelper.CustomizeControl(_rublesPerDollarNumericUpDown, editFormModeForSeller);
                    ControlCustomizeHelper.CustomizeControl(_distributorSpentOnDeliveryNumericUpDown, editFormModeForDistributor);
                    ControlCustomizeHelper.CustomizeControl(_commentsTextBox, editFormModeForSeller);
                    ControlCustomizeHelper.CustomizeControl(_parcelReferenceEditor, editFormModeForPurchaser);
                    ControlCustomizeHelper.CustomizeControl(_trackingNumberTextBox, editFormModeForDistributor);
                    break;

                default:
                    throw new NotSupportedException(Mode.ToString());
            }
        }

        protected override void OnLoad()
        {
            _orderNumberTextBox.Text = Dto != null ? Dto.OrderNumber : string.Empty;
            _trackableDtoAttributes.SetControls(Mode, Dto);

            var totalPrice = Dto != null ? Dto.TotalPrice : 0;
            _totalPriceTextBox.Text = totalPrice.ToString("#0.00");

            if (Mode == EditFormMode.Create)
                _rublesPerDollarNumericUpDown.Value =
                    IoCContainer.Get<IAdministrationService>().Settings.RublesPerDollar;

            base.OnLoad();
        }

        protected override void SetDtoToControls(Order order)
        {
            _orderDateTimePicker.Value = TimeService.ToLocal(order.OrderDate);
            _activeCheckBox.Checked = order.Active;
            _customerFirstNameWatermarkedTextBox.Text = order.CustomerFirstName;
            _customerLastNameWatermarkedTextBox.Text = order.CustomerLastName;
            _customerAddressWatermarkedTextBox.Text = order.CustomerAddress;
            _customerCityWatermarkedTextBox.Text = order.CustomerCity;
            _customerCountryWatermarkedTextBox.Text = order.CustomerCountry;
            _customerPostalCodeWatermarkedTextBox.Text = order.CustomerPostalCode;
            _customerPhoneNumberWatermarkedTextBox.Text = order.CustomerPhoneNumber;
            _customerEmailWatermarkedTextBox.Text = order.CustomerEmail;
            _customerPrepaidNumericUpDown.Value = order.CustomerPrepaid;
            _customerPaidNumericUpDown.Value = order.CustomerPaid;
            _rublesPerDollarNumericUpDown.Value = order.RublesPerDollar;
            _distributorSpentOnDeliveryNumericUpDown.Value = order.DistributorSpentOnDelivery;
            _commentsTextBox.Text = order.Comments;
            _parcelReferenceEditor.Dto = order.Parcel;
            _trackingNumberTextBox.Text = order.TrackingNumber;
        }

        protected override void SetControlsToDto(Order order)
        {
            order.OrderDate = TimeService.ToUtc(_orderDateTimePicker.Value);
            order.Active = _activeCheckBox.Checked;
            order.CustomerFirstName = _customerFirstNameWatermarkedTextBox.Text;
            order.CustomerLastName = _customerLastNameWatermarkedTextBox.Text;
            order.CustomerAddress = _customerAddressWatermarkedTextBox.Text;
            order.CustomerCity = _customerCityWatermarkedTextBox.Text;
            order.CustomerCountry = _customerCountryWatermarkedTextBox.Text;
            order.CustomerPostalCode = _customerPostalCodeWatermarkedTextBox.Text;
            order.CustomerPhoneNumber = _customerPhoneNumberWatermarkedTextBox.Text;
            order.CustomerEmail = _customerEmailWatermarkedTextBox.Text;
            order.CustomerPrepaid = _customerPrepaidNumericUpDown.Value;
            order.CustomerPaid = _customerPaidNumericUpDown.Value;
            order.RublesPerDollar = _rublesPerDollarNumericUpDown.Value;
            order.Comments = _commentsTextBox.Text;
            order.Parcel = _parcelReferenceEditor.Dto;
            order.DistributorSpentOnDelivery = _distributorSpentOnDeliveryNumericUpDown.Value;
            order.TrackingNumber = _trackingNumberTextBox.Text;
        }

        protected override string OnInsert(Order order)
        {
            return IoCContainer.Get<IDocumentService>().CreateOrder(order);
        }

        protected override string OnUpdate(Order order)
        {
            return IoCContainer.Get<IDocumentService>().UpdateOrder(order);
        }
    }

    public class BaseOrderEditForm : BaseDetailEditForm<Parcel, Order>
    {
        protected BaseOrderEditForm() { }

        protected BaseOrderEditForm(EditFormMode mode, Order order, Parcel parcel)
            : base(mode, order, parcel)
        {
        }
    }
}
