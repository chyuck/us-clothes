using System;
using System.Linq;
using System.Windows.Forms;
using USClothesWebSite.DTO;
using USClothesWebSite.Win.Forms.Base;
using USClothesWebSite.Win.Helpers;
using USClothesWebSite.Win.Logic.Document;
using USClothesWebSite.Win.Logic.Extensions;
using USClothesWebSite.Win.Logic.Form;
using USClothesWebSite.Win.Logic.Security;

namespace USClothesWebSite.Win.Forms.Document
{
    public partial class OrderMasterDetailForm : BaseOrderMasterDetailForm
    {
        public OrderMasterDetailForm(ListFormMode mode, Order order)
            : this(mode, order, null)
        {
        }

        public OrderMasterDetailForm(ListFormMode mode, Order order, Func<Order, bool> filter)
            : base(mode, order, filter)
        {
            InitializeComponent();
        }

        private ISecurityService SecurityService
        {
            get { return IoCContainer.Get<ISecurityService>(); }
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
                            HeaderText = "Номер", 
                            Width = 50, 
                            DefaultCellStyle = { Alignment = DataGridViewContentAlignment.MiddleLeft }
                        },
                        new DataGridViewTextBoxColumn
                        {
                            HeaderText = "Дата заказа", 
                            Width = 100, 
                            DefaultCellStyle = { Alignment = DataGridViewContentAlignment.MiddleLeft }
                        },
                        new DataGridViewTextBoxColumn
                        {
                            HeaderText = "Итоговая цена", 
                            Width = 110, 
                            DefaultCellStyle = { Alignment = DataGridViewContentAlignment.MiddleRight, Format = "#0.00 руб" }
                        },
                        new DataGridViewTextBoxColumn
                        {
                            HeaderText = "Имя клиента", 
                            Width = 100, 
                            DefaultCellStyle = { Alignment = DataGridViewContentAlignment.MiddleLeft }
                        },
                        new DataGridViewTextBoxColumn
                        {
                            HeaderText = "Фамилия клиента", 
                            Width = 125, 
                            DefaultCellStyle = { Alignment = DataGridViewContentAlignment.MiddleLeft }
                        },
                        new DataGridViewTextBoxColumn
                        {
                            HeaderText = "Адрес клиента", 
                            Width = 140, 
                            DefaultCellStyle = { Alignment = DataGridViewContentAlignment.MiddleLeft }
                        },
                        new DataGridViewTextBoxColumn
                        {
                            HeaderText = "Город клиента", 
                            Width = 110, 
                            DefaultCellStyle = { Alignment = DataGridViewContentAlignment.MiddleLeft }
                        },
                        new DataGridViewTextBoxColumn
                        {
                            HeaderText = "Страна клиента", 
                            Width = 120, 
                            DefaultCellStyle = { Alignment = DataGridViewContentAlignment.MiddleLeft }
                        },
                        new DataGridViewTextBoxColumn
                        {
                            HeaderText = "Индекс клиента", 
                            Width = 120, 
                            DefaultCellStyle = { Alignment = DataGridViewContentAlignment.MiddleLeft }
                        },
                        new DataGridViewTextBoxColumn
                        {
                            HeaderText = "Телефон клиента", 
                            Width = 125, 
                            DefaultCellStyle = { Alignment = DataGridViewContentAlignment.MiddleLeft }
                        },
                        new DataGridViewTextBoxColumn
                        {
                            HeaderText = "Эл. почта клиента", 
                            Width = 125, 
                            DefaultCellStyle = { Alignment = DataGridViewContentAlignment.MiddleLeft }
                        },
                        new DataGridViewTextBoxColumn
                        {
                            HeaderText = "Номер отслеживания", 
                            Width = 150, 
                            DefaultCellStyle = { Alignment = DataGridViewContentAlignment.MiddleLeft }
                        },
                        new DataGridViewTextBoxColumn
                        {
                            HeaderText = "Посылка", 
                            Width = 100, 
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
                            HeaderText = "Предоплата клиента", 
                            Width = 140, 
                            DefaultCellStyle = { Alignment = DataGridViewContentAlignment.MiddleRight, Format = "#0.00 руб" }
                        },
                        new DataGridViewTextBoxColumn
                        {
                            HeaderText = "Оплата клиента", 
                            Width = 120, 
                            DefaultCellStyle = { Alignment = DataGridViewContentAlignment.MiddleRight, Format = "#0.00 руб" }
                        },
                        new DataGridViewTextBoxColumn
                        {
                            HeaderText = "Расходы распространителя", 
                            Width = 175, 
                            DefaultCellStyle = { Alignment = DataGridViewContentAlignment.MiddleRight, Format = "#0.00 руб" }
                        },
                        new DataGridViewTextBoxColumn
                        {
                            HeaderText = "Курс доллара", 
                            Width = 105, 
                            DefaultCellStyle = { Alignment = DataGridViewContentAlignment.MiddleRight, Format = "#0.00 руб" }
                        },
                        new DataGridViewTextBoxColumn
                        {
                            HeaderText = "Комментарий", 
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

        protected override DataGridViewColumn[] DtoDetailColumns
        {
            get
            {
                var columns =
                    new DataGridViewColumn[]
                    {
                        new DataGridViewTextBoxColumn
                        {
                            HeaderText = "Заказ", 
                            Width = 100, 
                            DefaultCellStyle = { Alignment = DataGridViewContentAlignment.MiddleLeft }
                        },
                        new DataGridViewTextBoxColumn
                        {
                            HeaderText = "Товар", 
                            Width = 150, 
                            DefaultCellStyle = { Alignment = DataGridViewContentAlignment.MiddleLeft }
                        },
                        new DataGridViewTextBoxColumn
                        {
                            HeaderText = "Размер", 
                            Width = 150, 
                            DefaultCellStyle = { Alignment = DataGridViewContentAlignment.MiddleLeft }
                        },
                        new DataGridViewTextBoxColumn
                        {
                            HeaderText = "Количество", 
                            Width = 85, 
                            DefaultCellStyle = { Alignment = DataGridViewContentAlignment.MiddleRight, Format = "#0" }
                        },
                        new DataGridViewTextBoxColumn
                        {
                            HeaderText = "Цена", 
                            Width = 80, 
                            DefaultCellStyle = { Alignment = DataGridViewContentAlignment.MiddleRight, Format = "#0.00 руб" }
                        },
                        new DataGridViewTextBoxColumn
                        {
                            HeaderText = "Итоговая цена", 
                            Width = 110, 
                            DefaultCellStyle = { Alignment = DataGridViewContentAlignment.MiddleRight, Format = "#0.00 руб" }
                        },
                        new DataGridViewTextBoxColumn
                        {
                            HeaderText = "Активный", 
                            Width = 70, 
                            DefaultCellStyle = { Alignment = DataGridViewContentAlignment.MiddleCenter }
                        },
                        new DataGridViewTextBoxColumn
                        {
                            HeaderText = "Цена покупки", 
                            Width = 100, 
                            DefaultCellStyle = { Alignment = DataGridViewContentAlignment.MiddleRight, Format = "$#0.00" }
                        }
                    };

                return
                    columns
                        .Concat(TrackableDtoListFormHelper.Columns)
                        .ToArray();
            }
        }

        protected override Order[] LoadMasterDtosByFilter(string filter)
        {
            return
                IoCContainer.Get<IDocumentService>()
                    .GetOrders(_dateDateIntervalControl.UtcFrom, _dateDateIntervalControl.UtcTo, filter);
        }

        protected override object[] GetMasterDtoValues(Order order)
        {
            var values =
                new object[]
                {
                    order.OrderNumber,
                    order.OrderDate.ToString("d"),
                    order.TotalPrice,
                    order.CustomerFirstName,
                    order.CustomerLastName,
                    order.CustomerAddress,
                    order.CustomerCity,
                    order.CustomerCountry,
                    order.CustomerPostalCode,
                    order.CustomerPhoneNumber,
                    order.CustomerEmail,
                    order.TrackingNumber,
                    order.Parcel != null ? order.Parcel.ToString() : string.Empty,
                    order.Active.ToYesNo(),
                    order.CustomerPrepaid,
                    order.CustomerPaid,
                    order.DistributorSpentOnDelivery,
                    order.RublesPerDollar,
                    order.Comments ?? string.Empty
                };

            return
                values
                    .Concat(TrackableDtoListFormHelper.GetValues(order))
                    .ToArray();
        }

        protected override OrderItem[] LoadDetailDtosByFilter(string filter, Order order)
        {
            return IoCContainer.Get<IDocumentService>().GetOrderItems(order);
        }

        protected override object[] GetDetailDtoValues(OrderItem orderItem)
        {
            var values =
                new object[]
                {
                    orderItem.Order.ToString(),
                    orderItem.ProductSize.Product.ToString(),
                    orderItem.ProductSize.Size.ToString(),
                    orderItem.Quantity,
                    orderItem.Price,
                    orderItem.TotalPrice,
                    orderItem.Active.ToYesNo(),
                    orderItem.PurchaserPaid
                };

            return
                values
                    .Concat(TrackableDtoListFormHelper.GetValues(orderItem))
                    .ToArray();
        }

        protected override void OnMasterSelect()
        {
            base.OnMasterSelect();

            var order = GetSelectedMasterDto();
            
            if (order != null)
            {
                MasterEditButton.Enabled =
                    SecurityService.IsCurrentUserPurchaser ||
                    order.IsCurrentUserDistributorForOrder() ||
                    order.IsCurrentUserSellerForOrder();
                DetailCreateButton.Enabled = order.IsCurrentUserSellerForOrder();
            }
        }

        protected override void OnDetailSelect()
        {
            base.OnDetailSelect();
            
            var orderItem = GetSelectedDetailDto();
            if (orderItem != null)
            {
                DetailEditButton.Enabled =
                    SecurityService.IsCurrentUserPurchaser || orderItem.IsCurrentUserSellerForOrderItem();
            }
        }

        protected override void OnLoad()
        {
            base.OnLoad();

            if (Dto != null && Mode == ListFormMode.List)
            {
                var createDate = Dto.CreateDate;

                _dateDateIntervalControl.UtcFrom = createDate.AddMonths(-1);
            }

            MasterCreateButton.Enabled = SecurityService.IsCurrentUserSeller;
        }
    }
    
    public class BaseOrderMasterDetailForm : BaseDtoMasterDetailForm<Order, OrderItem>
    {
        protected BaseOrderMasterDetailForm() { }

        protected BaseOrderMasterDetailForm(ListFormMode mode, Order order)
            : base(mode, order)
        {
        }

        protected BaseOrderMasterDetailForm(ListFormMode mode, Order order, Func<Order, bool> filter)
            : base(mode, order, filter)
        {
        }
    }
}
