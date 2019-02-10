using System.Collections.Generic;
using System.Windows.Forms;
using USClothesWebSite.DTO;
using USClothesWebSite.Win.Forms.Base;
using USClothesWebSite.Win.Logic.Dictionary;
using USClothesWebSite.Win.Logic.Form;

namespace USClothesWebSite.Win.Forms.Dictionary
{
    public partial class CategoryEditForm : BaseCategoryEditForm
    {
        public CategoryEditForm(EditFormMode mode, Category category)
            : base(mode, category)
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

        protected override void SetDtoToControls(Category category)
        {
            _nameTextBox.Text = category.Name;
            _activeCheckBox.Checked = category.Active;
        }

        protected override void SetControlsToDto(Category category)
        {
            category.Name = _nameTextBox.Text;
            category.Active = _activeCheckBox.Checked;
        }

        protected override string OnInsert(Category category)
        {
            return IoCContainer.Get<IDictionaryService>().CreateCategory(category);
        }

        protected override string OnUpdate(Category category)
        {
            return IoCContainer.Get<IDictionaryService>().UpdateCategory(category);
        }
    }

    public class BaseCategoryEditForm : BaseDtoEditForm<Category>
    {
        protected BaseCategoryEditForm() { }

        protected BaseCategoryEditForm(EditFormMode mode, Category category)
            : base(mode, category)
        {
        }
    }
}
