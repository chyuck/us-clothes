using System.Collections.Generic;
using System.Windows.Forms;
using USClothesWebSite.DTO;
using USClothesWebSite.Win.Forms.Base;
using USClothesWebSite.Win.Logic.Dictionary;
using USClothesWebSite.Win.Logic.Form;

namespace USClothesWebSite.Win.Forms.Dictionary
{
    public partial class SizeEditForm : BaseSizeEditForm
    {
        public SizeEditForm(EditFormMode mode, Size size)
            : base(mode, size)
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
                        _activeCheckBox,
                        _subCategoryReferenceEditor,
                        _brandReferenceEditor,
                        _heightTextBox,
                        _weightTextBox
                    };
            }
        }

        protected override void OnLoad()
        {
            _trackableDtoAttributes.SetControls(Mode, Dto);

            base.OnLoad();
        }

        protected override void SetDtoToControls(Size size)
        {
            _nameTextBox.Text = size.Name;
            _activeCheckBox.Checked = size.Active;
            _subCategoryReferenceEditor.Dto = size.SubCategory;
            _brandReferenceEditor.Dto = size.Brand;
            _heightTextBox.Text = size.Height;
            _weightTextBox.Text = size.Weight;
        }

        protected override void SetControlsToDto(Size size)
        {
            size.Name = _nameTextBox.Text;
            size.Active = _activeCheckBox.Checked;
            size.SubCategory = _subCategoryReferenceEditor.Dto;
            size.Brand = _brandReferenceEditor.Dto;
            size.Height = _heightTextBox.Text;
            size.Weight = _weightTextBox.Text;
        }

        protected override string OnInsert(Size size)
        {
            return IoCContainer.Get<IDictionaryService>().CreateSize(size);
        }

        protected override string OnUpdate(Size size)
        {
            return IoCContainer.Get<IDictionaryService>().UpdateSize(size);
        }
    }

    public class BaseSizeEditForm : BaseDtoEditForm<Size>
    {
        protected BaseSizeEditForm() { }

        protected BaseSizeEditForm(EditFormMode mode, Size size)
            : base(mode, size)
        {
        }
    }
}
