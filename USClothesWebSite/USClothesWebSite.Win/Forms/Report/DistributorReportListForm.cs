using System.Windows.Forms;
using USClothesWebSite.DTO;
using USClothesWebSite.Win.Forms.Base;
using USClothesWebSite.Win.Logic.Form;
using USClothesWebSite.Win.Logic.Report;

namespace USClothesWebSite.Win.Forms.Report
{
    public partial class DistributorReportListForm : BaseDistributorReportListForm
    {
        public DistributorReportListForm(ListFormMode mode, DistributorReportItem distributorReportItem)
            : base(mode, distributorReportItem)
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
                            HeaderText = "Распространитель", 
                            Width = 120, 
                            DefaultCellStyle = { Alignment = DataGridViewContentAlignment.MiddleLeft }
                        },
                        new DataGridViewTextBoxColumn
                        {
                            HeaderText = "Траты распространителя", 
                            Width = 170, 
                            DefaultCellStyle = { Alignment = DataGridViewContentAlignment.MiddleRight, Format = "$#0.00" }
                        },
                        new DataGridViewTextBoxColumn
                        {
                            HeaderText = "Приход распространителя", 
                            Width = 170, 
                            DefaultCellStyle = { Alignment = DataGridViewContentAlignment.MiddleRight, Format = "$#0.00" }
                        },
                        new DataGridViewTextBoxColumn
                        {
                            HeaderText = "Баланс распространителя", 
                            Width = 170, 
                            DefaultCellStyle = { Alignment = DataGridViewContentAlignment.MiddleRight, Format = "$#0.00" }
                        },
                        new DataGridViewTextBoxColumn
                        {
                            HeaderText = "Траты закупщика", 
                            Width = 130, 
                            DefaultCellStyle = { Alignment = DataGridViewContentAlignment.MiddleRight, Format = "$#0.00" }
                        },
                        new DataGridViewTextBoxColumn
                        {
                            HeaderText = "Приход закупщика", 
                            Width = 130, 
                            DefaultCellStyle = { Alignment = DataGridViewContentAlignment.MiddleRight, Format = "$#0.00" }
                        },
                        new DataGridViewTextBoxColumn
                        {
                            HeaderText = "Баланс закупщика", 
                            Width = 130, 
                            DefaultCellStyle = { Alignment = DataGridViewContentAlignment.MiddleRight, Format = "$#0.00" }
                        },
                        new DataGridViewTextBoxColumn
                        {
                            HeaderText = "Итоговый баланс", 
                            Width = 130, 
                            DefaultCellStyle = { Alignment = DataGridViewContentAlignment.MiddleRight, Format = "$#0.00" }
                        }
                    };
            }
        }

        protected override DistributorReportItem[] LoadDtosByFilter(string filter)
        {
            return IoCContainer.Get<IReportService>().GenerateDistributorsReport();
        }

        protected override object[] GetDtoValues(DistributorReportItem distributorReportItem)
        {
            return
                new object[]
                {
                    distributorReportItem.DistributorName,
                    distributorReportItem.DistributorSpent,
                    distributorReportItem.DistributorReceived,
                    distributorReportItem.DistributorBalance,
                    distributorReportItem.PurchaserSpent,
                    distributorReportItem.PurchaserReceived,
                    distributorReportItem.PurchaserBalance,
                    distributorReportItem.TotalBalance
                };
        }
    }

    public class BaseDistributorReportListForm : BaseDtoListForm<DistributorReportItem>
    {
        protected BaseDistributorReportListForm() { }

        protected BaseDistributorReportListForm(ListFormMode mode, DistributorReportItem distributorReportItem)
            : base(mode, distributorReportItem)
        {
        }
    }
}
