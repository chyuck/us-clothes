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
    public partial class ProductMasterDetailForm : BaseProductMasterDetailForm
    {
        public ProductMasterDetailForm(ListFormMode mode, DTO.Product product)
            : base(mode, product)
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
                            Width = 120, 
                            DefaultCellStyle = { Alignment = DataGridViewContentAlignment.MiddleLeft }
                        },
                        new DataGridViewTextBoxColumn
                        {
                            HeaderText = "Подкатегория", 
                            Width = 120, 
                            DefaultCellStyle = { Alignment = DataGridViewContentAlignment.MiddleLeft }
                        },
                        new DataGridViewTextBoxColumn
                        {
                            HeaderText = "Бренд", 
                            Width = 120, 
                            DefaultCellStyle = { Alignment = DataGridViewContentAlignment.MiddleLeft }
                        },
                        new DataGridViewTextBoxColumn
                        {
                            HeaderText = "Описание", 
                            Width = 120, 
                            DefaultCellStyle = { Alignment = DataGridViewContentAlignment.MiddleLeft }
                        },
                        new DataGridViewTextBoxColumn
                        {
                            HeaderText = "Ссылка на сайт", 
                            Width = 120, 
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
        
        protected override DTO.Product[] LoadMasterDtosByFilter(string filter)
        {
            return 
                IoCContainer.Get<IProductService>()
                    .GetProducts(_dateDateIntervalControl.UtcFrom, _dateDateIntervalControl.UtcTo, filter);
        }

        protected override object[] GetMasterDtoValues(DTO.Product product)
        {
            var values =
                new object[]
                {
                    product.Name,
                    product.SubCategory.ToString(),
                    product.Brand.ToString(),
                    product.Description,
                    product.VendorShopURL,
                    product.Active.ToYesNo()
                };

            return
                values
                    .Concat(TrackableDtoListFormHelper.GetValues(product))
                    .ToArray();
        }

        protected override ProductSize[] LoadDetailDtosByFilter(string filter, DTO.Product product)
        {
            return IoCContainer.Get<IProductService>().GetProductSizes(product, filter);
        }

        protected override object[] GetDetailDtoValues(ProductSize productSize)
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

    public class BaseProductMasterDetailForm : BaseDtoMasterDetailForm<DTO.Product, ProductSize>
    {
        protected BaseProductMasterDetailForm() { }

        protected BaseProductMasterDetailForm(ListFormMode mode, DTO.Product product)
            : base(mode, product)
        {
        }
    }
}
