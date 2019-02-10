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
    public partial class CategoryMasterDetailForm : BaseCategoryMasterDetailForm
    {
        public CategoryMasterDetailForm(ListFormMode mode, Category category)
            : base(mode, category)
        {
            InitializeComponent();
        }

        protected override DataGridViewColumn[] DtoMasterColumns
        {
            get
            {
                var columns =
                    new DataGridViewColumn[]
                    {
                        new DataGridViewTextBoxColumn
                        {
                            HeaderText = "Название", 
                            Width = 200, 
                            DefaultCellStyle = { Alignment = DataGridViewContentAlignment.MiddleLeft }
                        },
                        new DataGridViewTextBoxColumn
                        {
                            HeaderText = "Активный", 
                            Width = 70, 
                            DefaultCellStyle = { Alignment = DataGridViewContentAlignment.MiddleCenter }
                        }
                    };

                return
                    columns
                        .Concat(TrackableDtoListFormHelper.Columns)
                        .ToArray();
            }
        }

        protected override DataGridViewColumn[] DtoDetailColumns
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

        protected override Category[] LoadMasterDtosByFilter(string filter)
        {
            return IoCContainer.Get<IDictionaryService>().GetCategories(filter);
        }

        protected override object[] GetMasterDtoValues(Category category)
        {
            var values =
                new object[]
                {
                    category.Name,
                    category.Active.ToYesNo()
                };

            return
                values
                    .Concat(TrackableDtoListFormHelper.GetValues(category))
                    .ToArray();
        }

        protected override SubCategory[] LoadDetailDtosByFilter(string filter, Category category)
        {
            return IoCContainer.Get<IDictionaryService>().GetSubCategories(filter, category);
        }

        protected override object[] GetDetailDtoValues(SubCategory subCategory)
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

    public class BaseCategoryMasterDetailForm : BaseDtoMasterDetailForm<Category, SubCategory>
    {
        protected BaseCategoryMasterDetailForm() { }

        protected BaseCategoryMasterDetailForm(ListFormMode mode, Category category)
            : base(mode, category)
        {
        }
    }
}
