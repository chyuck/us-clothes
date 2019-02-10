using System.Windows.Forms;
using USClothesWebSite.DTO;
using USClothesWebSite.Win.Forms.Base;
using USClothesWebSite.Win.Logic.Form;
using USClothesWebSite.Win.Logic.Report;

namespace USClothesWebSite.Win.Forms.Report
{
    public partial class ParcelReportListForm : BaseParcelReportListForm
    {
        public ParcelReportListForm(ListFormMode mode, ParcelReportItem parcelReportItem)
            : base(mode, parcelReportItem)
        {
            InitializeComponent();
        }

        protected override DataGridViewColumn[] DtoColumns
        {
            get
            {
                return
                    new DataGridViewColumn[]
                    {
                        new DataGridViewTextBoxColumn
                        {
                            HeaderText = "Посылка", 
                            Width = 120, 
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
                            HeaderText = "Цена покупки", 
                            Width = 110, 
                            DefaultCellStyle = { Alignment = DataGridViewContentAlignment.MiddleRight, Format = "$#0.00" }
                        },
                        new DataGridViewTextBoxColumn
                        {
                            HeaderText = "Цена отправки", 
                            Width = 110, 
                            DefaultCellStyle = { Alignment = DataGridViewContentAlignment.MiddleRight, Format = "$#0.00" }
                        },
                        new DataGridViewTextBoxColumn
                        {
                            HeaderText = "Расходы распространителя", 
                            Width = 175, 
                            DefaultCellStyle = { Alignment = DataGridViewContentAlignment.MiddleRight, Format = "$#0.00" }
                        },
                        new DataGridViewTextBoxColumn
                        {
                            HeaderText = "Итого расходов", 
                            Width = 120, 
                            DefaultCellStyle = { Alignment = DataGridViewContentAlignment.MiddleRight, Format = "$#0.00" }
                        },
                        new DataGridViewTextBoxColumn
                        {
                            HeaderText = "Предоплата клиентов", 
                            Width = 150, 
                            DefaultCellStyle = { Alignment = DataGridViewContentAlignment.MiddleRight, Format = "$#0.00" }
                        },
                        new DataGridViewTextBoxColumn
                        {
                            HeaderText = "Оплата клиентов", 
                            Width = 120, 
                            DefaultCellStyle = { Alignment = DataGridViewContentAlignment.MiddleRight, Format = "$#0.00" }
                        },
                        new DataGridViewTextBoxColumn
                        {
                            HeaderText = "Итого оплата клиентов", 
                            Width = 150, 
                            DefaultCellStyle = { Alignment = DataGridViewContentAlignment.MiddleRight, Format = "$#0.00" }
                        },
                        new DataGridViewTextBoxColumn
                        {
                            HeaderText = "Ожидаемая оплата клиентов", 
                            Width = 180, 
                            DefaultCellStyle = { Alignment = DataGridViewContentAlignment.MiddleRight, Format = "$#0.00" }
                        },
                        new DataGridViewTextBoxColumn
                        {
                            HeaderText = "Доход", 
                            Width = 80, 
                            DefaultCellStyle = { Alignment = DataGridViewContentAlignment.MiddleRight, Format = "$#0.00" }
                        },
                        new DataGridViewTextBoxColumn
                        {
                            HeaderText = "Ожидаемый доход", 
                            Width = 130, 
                            DefaultCellStyle = { Alignment = DataGridViewContentAlignment.MiddleRight, Format = "$#0.00" }
                        }
                    };
            }
        }

        protected override ParcelReportItem[] LoadDtosByFilter(string filter)
        {
            return IoCContainer.Get<IReportService>().GenerateParcelsReport();
        }

        protected override object[] GetDtoValues(ParcelReportItem parcelReportItem)
        {
            return
                new object[]
                {
                    parcelReportItem.ParcelName,
                    parcelReportItem.SentDate.HasValue ? parcelReportItem.SentDate.Value.ToString("d") : string.Empty,
                    parcelReportItem.ReceivedDate.HasValue ? parcelReportItem.ReceivedDate.Value.ToString("d") : string.Empty,
                    parcelReportItem.DistributorName,
                    parcelReportItem.PurchaserPaid,
                    parcelReportItem.PurchaserSpentOnDelivery,
                    parcelReportItem.DistributorSpentOnDelivery,
                    parcelReportItem.TotalPaid,
                    parcelReportItem.CustomersPrepaid,
                    parcelReportItem.CustomersPaid,
                    parcelReportItem.TotalCustomersPaid,
                    parcelReportItem.ExpectedTotalCustomerPaid,
                    parcelReportItem.TotalProfit,
                    parcelReportItem.ExpectedTotalProfit
                };
        }
    }

    public class BaseParcelReportListForm : BaseDtoListForm<ParcelReportItem>
    {
        protected BaseParcelReportListForm() { }

        protected BaseParcelReportListForm(ListFormMode mode, ParcelReportItem parcelReportItem)
            : base(mode, parcelReportItem)
        {
        }
    }
}
