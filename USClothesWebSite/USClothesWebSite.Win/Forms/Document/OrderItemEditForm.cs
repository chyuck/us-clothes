using System;
using System.Collections.Generic;
using System.Windows.Forms;
using USClothesWebSite.Common.Helpers;
using USClothesWebSite.DTO;
using USClothesWebSite.Win.Controls.ReferenceEditor;
using USClothesWebSite.Win.Forms.Base;
using USClothesWebSite.Win.Helpers;
using USClothesWebSite.Win.Logic.Document;
using USClothesWebSite.Win.Logic.Extensions;
using USClothesWebSite.Win.Logic.Form;
using USClothesWebSite.Win.Logic.Security;

namespace USClothesWebSite.Win.Forms.Document
{
    public partial class OrderItemEditForm : BaseOrderItemEditForm
    {
        public OrderItemEditForm(EditFormMode mode, OrderItem orderItem)
            : this(mode, orderItem, null)
        {
        }

        public OrderItemEditForm(EditFormMode mode, OrderItem orderItem, Order order)
            : base(mode, orderItem, order)
        {
            InitializeComponent();
        }

        private ISecurityService SecurityService
        {
            get { return IoCContainer.Get<ISecurityService>(); }
        }

        protected override ReferenceEditor<Order> MasterDtoEditor
        {
            get { return _orderReferenceEditor; }
        }

        protected override IEnumerable<Control> EditControls
        {
            get
            {
                return
                    new Control[]
                    {
                        _orderReferenceEditor,
                        _productSizeReferenceEditor,
                        _quantityNumericUpDown,
                        _priceNumericUpDown,
                        _totalPriceTextBox,
                        _activeCheckBox,
                        _purchaserPaidNumericUpDown
                    };
            }
        }

        protected override void CustomizeControls()
        {
            var isCurrentUserSeller = SecurityService.IsCurrentUserSeller;
            var isCurrentUserPurchaser = SecurityService.IsCurrentUserPurchaser;

            switch (Mode)
            {
                case EditFormMode.View:
                    base.CustomizeControls();
                    break;

                case EditFormMode.Create:
                    CheckHelper.WithinCondition(isCurrentUserSeller, "Only seller can create order item.");

                    ControlCustomizeHelper.CustomizeControl(_orderReferenceEditor, EditFormMode.Create);
                    ControlCustomizeHelper.CustomizeControl(_productSizeReferenceEditor, EditFormMode.Create);
                    ControlCustomizeHelper.CustomizeControl(_quantityNumericUpDown, EditFormMode.Create);
                    ControlCustomizeHelper.CustomizeControl(_priceNumericUpDown, EditFormMode.Create);
                    ControlCustomizeHelper.CustomizeControl(_activeCheckBox, EditFormMode.Create);
                    ControlCustomizeHelper.CustomizeControl(_purchaserPaidNumericUpDown,
                        isCurrentUserPurchaser ? EditFormMode.Create : EditFormMode.View);
                    break;

                case EditFormMode.Edit:
                    CheckHelper.WithinCondition(
                        isCurrentUserPurchaser || isCurrentUserSeller,
                        "Only purchaser and seller can change order item.");

                    var editFormModeForPurchaser = isCurrentUserPurchaser ? EditFormMode.Edit : EditFormMode.View;
                    var editFormModeForSeller = Dto.IsCurrentUserSellerForOrderItem() ? EditFormMode.Edit : EditFormMode.View;

                    ControlCustomizeHelper.CustomizeControl(_orderReferenceEditor, editFormModeForSeller);
                    ControlCustomizeHelper.CustomizeControl(_productSizeReferenceEditor, editFormModeForSeller);
                    ControlCustomizeHelper.CustomizeControl(_quantityNumericUpDown, editFormModeForSeller);
                    ControlCustomizeHelper.CustomizeControl(_priceNumericUpDown, editFormModeForSeller);
                    ControlCustomizeHelper.CustomizeControl(_activeCheckBox, editFormModeForSeller);
                    ControlCustomizeHelper.CustomizeControl(_purchaserPaidNumericUpDown, editFormModeForPurchaser);
                    break;

                default:
                    throw new NotSupportedException(Mode.ToString());
            }
        }

        protected override void OnLoad()
        {
            _trackableDtoAttributes.SetControls(Mode, Dto);
            ValueChanged(this, EventArgs.Empty);
            _orderReferenceEditor.Filter = o => o.IsCurrentUserSellerForOrder();

            base.OnLoad();
        }

        protected override void SetDtoToControls(OrderItem orderItem)
        {
            _orderReferenceEditor.Dto = orderItem.Order;
            _productSizeReferenceEditor.Dto = orderItem.ProductSize;
            _quantityNumericUpDown.Value = orderItem.Quantity;
            _priceNumericUpDown.Value = orderItem.Price;
            _activeCheckBox.Checked = orderItem.Active;
            _purchaserPaidNumericUpDown.Value = orderItem.PurchaserPaid;
        }

        protected override void SetControlsToDto(OrderItem orderItem)
        {
            orderItem.Order = _orderReferenceEditor.Dto;
            orderItem.ProductSize = _productSizeReferenceEditor.Dto;
            orderItem.Quantity = (int)_quantityNumericUpDown.Value;
            orderItem.Price = _priceNumericUpDown.Value;
            orderItem.Active = _activeCheckBox.Checked;
        }

        protected override string OnInsert(OrderItem orderItem)
        {
            return IoCContainer.Get<IDocumentService>().CreateOrderItem(orderItem);
        }

        protected override string OnUpdate(OrderItem orderItem)
        {
            return IoCContainer.Get<IDocumentService>().UpdateOrderItem(orderItem);
        }

        private void ValueChanged(object sender, EventArgs e)
        {
            var quantity = (int)_quantityNumericUpDown.Value;
            var price = _priceNumericUpDown.Value;

            var totalPrice = price * quantity;

            _totalPriceTextBox.Text = totalPrice.ToString("#0.00");
        }

        private void ProductSizeReferenceEditor_ValueChanged(object sender, EventArgs e)
        {
            var productSize = _productSizeReferenceEditor.Dto;
            
            if (productSize != null)
                _priceNumericUpDown.Value = productSize.Price;

            UpdatePicture(productSize);
        }

        private void UpdatePicture(ProductSize productSize)
        {
            if (productSize == null || productSize.Product == null)
            {
                _previewPicture.Clear();
                return;
            }

            var product = productSize.Product;

            _previewPicture.SetURLs(product.PreviewPictureURL, product.FullPictureURL);
        }
    }

    public class BaseOrderItemEditForm : BaseDetailEditForm<Order, OrderItem>
    {
        protected BaseOrderItemEditForm() { }

        protected BaseOrderItemEditForm(EditFormMode mode, OrderItem orderItem, Order order)
            : base(mode, orderItem, order)
        {
        }
    }
}
