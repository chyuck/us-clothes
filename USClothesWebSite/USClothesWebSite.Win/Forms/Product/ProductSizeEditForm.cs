using System;
using System.Collections.Generic;
using System.Windows.Forms;
using USClothesWebSite.DTO;
using USClothesWebSite.Win.Controls.ReferenceEditor;
using USClothesWebSite.Win.Forms.Base;
using USClothesWebSite.Win.Logic.Form;
using USClothesWebSite.Win.Logic.Product;

namespace USClothesWebSite.Win.Forms.Product
{
    public partial class ProductSizeEditForm : BaseProductSizeEditForm
    {
        public ProductSizeEditForm(EditFormMode mode, ProductSize productSize)
            : this(mode, productSize, null)
        {
        }

        public ProductSizeEditForm(EditFormMode mode, ProductSize productSize, DTO.Product product)
            : base(mode, productSize, product)
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
                        _productReferenceEditor,
                        _sizeReferenceEditor,
                        _priceNumericUpDown,
                        _activeCheckBox
                    };
            }
        }

        protected override ReferenceEditor<DTO.Product> MasterDtoEditor
        {
            get { return _productReferenceEditor; }
        }

        protected override void OnLoad()
        {
            _trackableDtoAttributes.SetControls(Mode, Dto);

            base.OnLoad();

            UpdateSizeReferenceEditorFilter();
        }

        protected override void SetDtoToControls(ProductSize productSize)
        {
            _activeCheckBox.Checked = productSize.Active;
            _productReferenceEditor.Dto = productSize.Product;
            _sizeReferenceEditor.Dto = productSize.Size;
            _priceNumericUpDown.Value = productSize.Price;
        }

        protected override void SetControlsToDto(ProductSize productSize)
        {
            productSize.Active = _activeCheckBox.Checked;
            productSize.Product = _productReferenceEditor.Dto;
            productSize.Size = _sizeReferenceEditor.Dto;
            productSize.Price = _priceNumericUpDown.Value;
        }

        protected override string OnInsert(ProductSize productSize)
        {
            return IoCContainer.Get<IProductService>().CreateProductSize(productSize);
        }

        protected override string OnUpdate(ProductSize productSize)
        {
            return IoCContainer.Get<IProductService>().UpdateProductSize(productSize);
        }

        private void UpdateSizeReferenceEditorFilter()
        {
            var product = _productReferenceEditor.Dto;
            if (product != null)
            {
                _sizeReferenceEditor.Filter =
                    s =>
                    s.Brand.Id == product.Brand.Id &&
                    s.SubCategory.Id == product.SubCategory.Id;
            }
            else
            {
                _sizeReferenceEditor.Filter = null;
            }
        }

        private void ProductReferenceEditor_ValueChanged(object sender, EventArgs e)
        {
            UpdateSizeReferenceEditorFilter();
        }
    }

    public class BaseProductSizeEditForm : BaseDetailEditForm<DTO.Product, ProductSize>
    {
        protected BaseProductSizeEditForm() { }

        protected BaseProductSizeEditForm(EditFormMode mode, ProductSize productSize, DTO.Product product)
            : base(mode, productSize, product)
        {
        }
    }
}
