using System.Collections.Generic;
using System.Windows.Forms;
using USClothesWebSite.DTO;
using USClothesWebSite.Win.Controls.ReferenceEditor;
using USClothesWebSite.Win.Forms.Base;
using USClothesWebSite.Win.Logic.Dictionary;
using USClothesWebSite.Win.Logic.Form;

namespace USClothesWebSite.Win.Forms.Dictionary
{
    public partial class SubCategoryEditForm : BaseSubCategoryEditForm
    {
        public SubCategoryEditForm(EditFormMode mode, SubCategory subCategory)
            : this(mode, subCategory, null)
        {
        }

        public SubCategoryEditForm(EditFormMode mode, SubCategory subCategory, Category category)
            : base(mode, subCategory, category)
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
                        _categoryReferenceEditor
                    };
            }
        }

        protected override ReferenceEditor<Category> MasterDtoEditor
        {
            get { return _categoryReferenceEditor; }
        }

        protected override void OnLoad()
        {
            _trackableDtoAttributes.SetControls(Mode, Dto);

            base.OnLoad();
        }

        protected override void SetDtoToControls(SubCategory subCategory)
        {
            _nameTextBox.Text = subCategory.Name;
            _activeCheckBox.Checked = subCategory.Active;
            _categoryReferenceEditor.Dto = subCategory.Category;
        }

        protected override void SetControlsToDto(SubCategory subCategory)
        {
            subCategory.Name = _nameTextBox.Text;
            subCategory.Active = _activeCheckBox.Checked;
            subCategory.Category = _categoryReferenceEditor.Dto;
        }

        protected override string OnInsert(SubCategory subCategory)
        {
            return IoCContainer.Get<IDictionaryService>().CreateSubCategory(subCategory);
        }

        protected override string OnUpdate(SubCategory subCategory)
        {
            return IoCContainer.Get<IDictionaryService>().UpdateSubCategory(subCategory);
        }
    }

    public class BaseSubCategoryEditForm : BaseDetailEditForm<Category, SubCategory>
    {
        protected BaseSubCategoryEditForm() { }

        protected BaseSubCategoryEditForm(EditFormMode mode, SubCategory subCategory, Category category)
            : base(mode, subCategory, category)
        {
        }
    }
}
