using System.Linq;
using System.Windows.Forms;
using USClothesWebSite.DTO;
using USClothesWebSite.Win.Forms.Base;
using USClothesWebSite.Win.Helpers;
using USClothesWebSite.Win.Logic.Dictionary;
using USClothesWebSite.Win.Logic.Extensions;
using USClothesWebSite.Win.Logic.Form;

namespace USClothesWebSite.Win.Forms.Dictionary
{
    public partial class SubCategoryListForm : BaseSubCategoryListForm
    {
        public SubCategoryListForm(ListFormMode mode, SubCategory subCategory)
            : base(mode, subCategory)
        {
            InitializeComponent();
        }

        protected override DataGridViewColumn[] DtoColumns
        {
            get
            {
                var columns =
                    new DataGridViewColumn[]
                    {
                        new DataGridViewTextBoxColumn
                        {
                            HeaderText = "Название", 
                            Width = 150, 
                            DefaultCellStyle = { Alignment = DataGridViewContentAlignment.MiddleLeft }
                        },
                        new DataGridViewTextBoxColumn
                        {
                            HeaderText = "Активный", 
                            Width = 70, 
                            DefaultCellStyle = { Alignment = DataGridViewContentAlignment.MiddleCenter }
                        },
                        new DataGridViewTextBoxColumn
                        {
                            HeaderText = "Категория", 
                            Width = 150, 
                            DefaultCellStyle = { Alignment = DataGridViewContentAlignment.MiddleLeft }
                        }
                    };

                return
                    columns
                        .Concat(TrackableDtoListFormHelper.Columns)
                        .ToArray();
            }
        }

        protected override SubCategory[] LoadDtosByFilter(string filter)
        {
            return IoCContainer.Get<IDictionaryService>().GetSubCategories(filter);
        }

        protected override object[] GetDtoValues(SubCategory subCategory)
        {
            var values =
                new object[]
                {
                    subCategory.Name,
                    subCategory.Active.ToYesNo(),
                    subCategory.Category.ToString()
                };

            return
                values
                    .Concat(TrackableDtoListFormHelper.GetValues(subCategory))
                    .ToArray();
        }
    }

    public class BaseSubCategoryListForm : BaseDtoListForm<SubCategory>
    {
        protected BaseSubCategoryListForm() { }

        protected BaseSubCategoryListForm(ListFormMode mode, SubCategory subCategory)
            : base(mode, subCategory)
        {
        }
    }
}
