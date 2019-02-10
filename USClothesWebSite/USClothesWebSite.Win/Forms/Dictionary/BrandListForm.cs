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
    public partial class BrandListForm : BaseBrandListForm
    {
        public BrandListForm(ListFormMode mode, Brand brand)
            : base(mode, brand)
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

        protected override Brand[] LoadDtosByFilter(string filter)
        {
            return IoCContainer.Get<IDictionaryService>().GetBrands(filter);
        }

        protected override object[] GetDtoValues(Brand brand)
        {
            var values =
                new object[]
                {
                    brand.Name,
                    brand.Active.ToYesNo()
                };

            return
                values
                    .Concat(TrackableDtoListFormHelper.GetValues(brand))
                    .ToArray();
        }
    }

    public class BaseBrandListForm : BaseDtoListForm<Brand>
    {
        protected BaseBrandListForm() { }

        protected BaseBrandListForm(ListFormMode mode, Brand brand)
            : base(mode, brand)
        {
        }
    }
}
