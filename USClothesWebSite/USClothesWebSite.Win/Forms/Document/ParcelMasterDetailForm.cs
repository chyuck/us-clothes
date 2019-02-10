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
    public partial class ParcelMasterDetailForm : BaseParcelMasterDetailForm
    {
        public ParcelMasterDetailForm(ListFormMode mode, Parcel parcel)
            : base(mode, parcel)
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
                            HeaderText = "Итоговая цена", 
                            Width = 110, 
                            DefaultCellStyle = { Alignment = DataGridViewContentAlignment.MiddleRight, Format = "#0.00 руб" }
                        },
                        new DataGridViewTextBoxColumn
                        {
                            HeaderText = "Номер отслеживания", 
                            Width = 140, 
                            DefaultCellStyle = { Alignment = DataGridViewContentAlignment.MiddleLeft }
                        },
                        new DataGridViewTextBoxColumn
                        {
                            HeaderText = "Дата отправки", 
                            Width = 110, 
                            DefaultCellStyle = { Alignment = DataGridViewContentAlignment.MiddleLeft }
                        },
                        new DataGridViewTextBoxColumn
                        {
                            HeaderText = "Дата прибытия", 
                            Width = 110, 
                            DefaultCellStyle = { Alignment = DataGridViewContentAlignment.MiddleLeft }
                        },
                        new DataGridViewTextBoxColumn
                        {
                            HeaderText = "Распространитель", 
                            Width = 120, 
                            DefaultCellStyle = { Alignment = DataGridViewContentAlignment.MiddleLeft }
                        },
                        new DataGridViewTextBoxColumn
                        {
                            HeaderText = "Цена отправки", 
                            Width = 110, 
                            DefaultCellStyle = { Alignment = DataGridViewContentAlignment.MiddleRight, Format = "$#0.00" }
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

        protected override Parcel[] LoadMasterDtosByFilter(string filter)
        {
            return 
                IoCContainer.Get<IDocumentService>()
                    .GetParcels(_dateDateIntervalControl.UtcFrom, _dateDateIntervalControl.UtcTo, filter);
        }

        protected override object[] GetMasterDtoValues(Parcel parcel)
        {
            var values =
                new object[]
                {
                    parcel.ParcelNumber,
                    parcel.TotalPrice,
                    parcel.TrackingNumber,
                    parcel.SentDate.HasValue ? parcel.SentDate.Value.ToString("d") : string.Empty,
                    parcel.ReceivedDate.HasValue ? parcel.ReceivedDate.Value.ToString("d") : string.Empty,
                    parcel.Distributor != null ? parcel.Distributor.ToString() : string.Empty,
                    parcel.PurchaserSpentOnDelivery,
                    parcel.RublesPerDollar,
                    parcel.Comments ?? string.Empty
                };

            return
                values
                    .Concat(TrackableDtoListFormHelper.GetValues(parcel))
                    .ToArray();
        }

        protected override Order[] LoadDetailDtosByFilter(string filter, Parcel parcel)
        {
            return IoCContainer.Get<IDocumentService>().GetOrders(parcel, filter);
        }

        protected override void OnLoad()
        {
            base.OnLoad();

            MasterCreateButton.Enabled = SecurityService.IsCurrentUserPurchaser;
            DetailAddButton.Enabled = false;
            GoButton.Enabled = false;
        }

        protected override object[] GetDetailDtoValues(Order order)
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

        protected override void OnMasterSelect()
        {
            base.OnMasterSelect();

            var parcel = GetSelectedMasterDto();

            DetailAddButton.Enabled = parcel != null && SecurityService.IsCurrentUserPurchaser;

            if (parcel != null)
            {
                MasterEditButton.Enabled = SecurityService.IsCurrentUserPurchaser || parcel.IsCurrentUserDistributorForParcel();
                DetailCreateButton.Enabled = SecurityService.IsCurrentUserSeller;
            }
        }

        protected override void OnDetailSelect()
        {
            base.OnDetailSelect();

            var order = GetSelectedDetailDto();

            GoButton.Enabled = order != null && Mode == ListFormMode.List;

            if (order != null)
            {
                DetailEditButton.Enabled = 
                    SecurityService.IsCurrentUserPurchaser || 
                    order.IsCurrentUserDistributorForOrder() || 
                    order.IsCurrentUserSellerForOrder();
            }
        }

        private void DetailAddButton_Click(object sender, EventArgs e)
        {
            var parcel = GetSelectedMasterDto();
            if (parcel != null)
            {
                var formService = IoCContainer.Get<IFormService>();

                var orderListForm = formService.CreateDtoListForm<Order>(ListFormMode.Choose, filter: o => o.Parcel == null);
                orderListForm.StartPosition = FormStartPosition.CenterParent;

                if (orderListForm.ShowDialog(ParentForm) == DialogResult.OK)
                {
                    var order = orderListForm.Dto;
                    order.Parcel = parcel;

                    var documentService = IoCContainer.Get<IDocumentService>();
                    documentService.UpdateOrder(order);

                    MasterRefreshButton.PerformClick();
                }
            }
        }

        private void GoButton_Click(object sender, EventArgs e)
        {
            var order = GetSelectedDetailDto();

            if (order != null)
            {
                var form = IoCContainer.Get<IFormService>().CreateDtoListForm<Order>(ListFormMode.List, order);
            
                form.MdiParent = MdiParent;
                form.Show();
            }
        }
    }

    public class BaseParcelMasterDetailForm : BaseDtoMasterDetailForm<Parcel, Order>
    {
        protected BaseParcelMasterDetailForm() { }

        protected BaseParcelMasterDetailForm(ListFormMode mode, Parcel parcel)
            : base(mode, parcel)
        {
        }
    }
}
