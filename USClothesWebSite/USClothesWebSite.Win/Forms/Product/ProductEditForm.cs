using System.Collections.Generic;
using System.Windows.Forms;
using USClothesWebSite.Win.Forms.Base;
using USClothesWebSite.Win.Logic.Form;
using USClothesWebSite.Win.Logic.Product;

namespace USClothesWebSite.Win.Forms.Product
{
    public partial class ProductEditForm : BaseProductEditForm
    {
        public ProductEditForm(EditFormMode mode, DTO.Product product)
            : base(mode, product)
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
                        _previewPicture,
                        _nameTextBox,
                        _subCategoryReferenceEditor,
                        _brandReferenceEditor,
                        _descriptionTextBox,
                        _vendorURLWatermarkedTextBox,
                        _activeCheckBox
                    };
            }
        }

        protected override void OnLoad()
        {
            _trackableDtoAttributes.SetControls(Mode, Dto);

            base.OnLoad();
        }

        protected override void SetDtoToControls(DTO.Product product)
        {
            _nameTextBox.Text = product.Name;
            _activeCheckBox.Checked = product.Active;
            _subCategoryReferenceEditor.Dto = product.SubCategory;
            _brandReferenceEditor.Dto = product.Brand;
            _descriptionTextBox.Text = product.Description;
            _vendorURLWatermarkedTextBox.Text = product.VendorShopURL;

            _previewPicture.SetURLs(product.PreviewPictureURL, product.FullPictureURL);
        }

        protected override void SetControlsToDto(DTO.Product product)
        {
            product.Name = _nameTextBox.Text;
            product.Active = _activeCheckBox.Checked;
            product.SubCategory = _subCategoryReferenceEditor.Dto;
            product.Brand = _brandReferenceEditor.Dto;
            product.Description = _descriptionTextBox.Text;
            product.VendorShopURL = _vendorURLWatermarkedTextBox.Text;
            
            product.PreviewPictureURL = _previewPicture.PreviewPictureURL;
            product.FullPictureURL = _previewPicture.FullPictureURL;
        }

        protected override string OnInsert(DTO.Product product)
        {
            return IoCContainer.Get<IProductService>().CreateProduct(product);
        }

        protected override string OnUpdate(DTO.Product product)
        {
            return IoCContainer.Get<IProductService>().UpdateProduct(product);
        }
    }

    public class BaseProductEditForm : BaseDtoEditForm<DTO.Product>
    {
        protected BaseProductEditForm() { }

        protected BaseProductEditForm(EditFormMode mode, DTO.Product product)
            : base(mode, product)
        {
        }
    }
}
