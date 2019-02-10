using System.Collections.Generic;
using System.Windows.Forms;
using USClothesWebSite.DTO;
using USClothesWebSite.Win.Forms.Base;
using USClothesWebSite.Win.Logic.Dictionary;
using USClothesWebSite.Win.Logic.Form;

namespace USClothesWebSite.Win.Forms.Dictionary
{
    public partial class BrandEditForm : BaseBrandEditForm
    {
        public BrandEditForm(EditFormMode mode, Brand brand)
            : base(mode, brand)
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
                        _nameTextBox,
                        _activeCheckBox
                    };
            }
        }

        protected override void OnLoad()
        {
            _trackableDtoAttributes.SetControls(Mode, Dto);

            base.OnLoad();
        }

        protected override void SetDtoToControls(Brand brand)
        {
            _nameTextBox.Text = brand.Name;
            _activeCheckBox.Checked = brand.Active;
        }

        protected override void SetControlsToDto(Brand brand)
        {
            brand.Name = _nameTextBox.Text;
            brand.Active = _activeCheckBox.Checked;
        }

        protected override string OnInsert(Brand brand)
        {
            return IoCContainer.Get<IDictionaryService>().CreateBrand(brand);
        }

        protected override string OnUpdate(Brand brand)
        {
            return IoCContainer.Get<IDictionaryService>().UpdateBrand(brand);
        }
    }

    public class BaseBrandEditForm : BaseDtoEditForm<Brand>
    {
        protected BaseBrandEditForm() { }

        protected BaseBrandEditForm(EditFormMode mode, Brand brand)
            : base(mode, brand)
        {
        }
    }
}
