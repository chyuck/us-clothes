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
    public partial class DistributorTransferListForm : BaseDistributorTransferListForm
    {
        public DistributorTransferListForm(ListFormMode mode, DistributorTransfer distributorTransfer)
            : base(mode, distributorTransfer)
        {
            InitializeComponent();
        }

        private ISecurityService SecurityService
        {
            get { return IoCContainer.Get<ISecurityService>(); }
        }

        protected override void OnLoad()
        {
            base.OnLoad();

            _distributorReferenceEditor.Filter = u => u.Roles.Any(r => r.Name == Role.DISTRIBUTOR_ROLE_NAME);

            var isCurrentUserPurchaser = SecurityService.IsCurrentUserPurchaser;
            _distributorLabel.Visible = isCurrentUserPurchaser;
            _distributorReferenceEditor.Visible = isCurrentUserPurchaser;

            var isCurrentUserDistributor = SecurityService.IsCurrentUserDistributor;
            CreateButton.Enabled = isCurrentUserDistributor;
            EditButton.Enabled = isCurrentUserDistributor;
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
                            HeaderText = "Дата перевода", 
                            Width = 120, 
                            DefaultCellStyle = { Alignment = DataGridViewContentAlignment.MiddleLeft }
                        },
                        new DataGridViewTextBoxColumn
                        {
                            HeaderText = "Сумма", 
                            Width = 120, 
                            DefaultCellStyle = { Alignment = DataGridViewContentAlignment.MiddleRight, Format = "#0.00 руб" }
                        },
                        new DataGridViewTextBoxColumn
                        {
                            HeaderText = "Курс доллара", 
                            Width = 120, 
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

        protected override DistributorTransfer[] LoadDtosByFilter(string filter)
        {
            return IoCContainer.Get<IDocumentService>().GetDistributorTransfers(_distributorReferenceEditor.Dto);
        }

        protected override object[] GetDtoValues(DistributorTransfer distributorTransfer)
        {
            var values =
                new object[]
                {
                    distributorTransfer.Date.ToString("d"),
                    distributorTransfer.Amount,
                    distributorTransfer.RublesPerDollar,
                    distributorTransfer.Active.ToYesNo()
                };

            return
                values
                    .Concat(TrackableDtoListFormHelper.GetValues(distributorTransfer))
                    .ToArray();
        }
    }

    public class BaseDistributorTransferListForm : BaseDtoListForm<DistributorTransfer>
    {
        protected BaseDistributorTransferListForm() { }

        protected BaseDistributorTransferListForm(ListFormMode mode, DistributorTransfer distributorTransfer)
            : base(mode, distributorTransfer)
        {
        }
    }
}
