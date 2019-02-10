using System.Linq;
using System.Windows.Forms;
using USClothesWebSite.DTO;
using USClothesWebSite.Win.Forms.Base;
using USClothesWebSite.Win.Helpers;
using USClothesWebSite.Win.Logic.Extensions;
using USClothesWebSite.Win.Logic.Form;
using USClothesWebSite.Win.Logic.Product;

namespace USClothesWebSite.Win.Forms.Product
{
    public partial class ProductSizeListForm : BaseProductSizeListForm
    {
        public ProductSizeListForm(ListFormMode mode, ProductSize productSize)
            : base(mode, productSize)
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
                            HeaderText = "Товар", 
                            Width = 120, 
                            DefaultCellStyle = { Alignment = DataGridViewContentAlignment.MiddleLeft }
                        },
                        new DataGridViewTextBoxColumn
                        {
                            HeaderText = "Размер", 
                            Width = 120, 
                            DefaultCellStyle = { Alignment = DataGridViewContentAlignment.MiddleLeft }
                        },
                        new DataGridViewTextBoxColumn
                        {
                            HeaderText = "Цена (руб)", 
                            Width = 100, 
                            DefaultCellStyle = { Alignment = DataGridViewContentAlignment.MiddleRight, Format = "#0.00 руб" }
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

        protected override ProductSize[] LoadDtosByFilter(string filter)
        {
            return IoCContainer.Get<IProductService>().GetProductSizes(filter);
        }

        protected override object[] GetDtoValues(ProductSize productSize)
        {
            var values =
                   new object[]
                {
                    productSize.Product.ToString(),
                    productSize.Size.ToString(),
                    productSize.Price,
                    productSize.Active.ToYesNo()
                };

            return
                values
                    .Concat(TrackableDtoListFormHelper.GetValues(productSize))
                    .ToArray();
        }
    }

    public class BaseProductSizeListForm : BaseDtoListForm<ProductSize>
    {
        protected BaseProductSizeListForm() { }

        protected BaseProductSizeListForm(ListFormMode mode, ProductSize productSize)
            : base(mode, productSize)
        {
        }
    }
}
