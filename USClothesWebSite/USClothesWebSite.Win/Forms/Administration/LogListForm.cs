using System.Windows.Forms;
using USClothesWebSite.DTO;
using USClothesWebSite.Win.Forms.Base;
using USClothesWebSite.Win.Logic.Form;
using USClothesWebSite.Win.Logic.Log;

namespace USClothesWebSite.Win.Forms.Administration
{
    public partial class LogListForm : BaseLogListForm
    {
        public LogListForm(ListFormMode mode, ActionLog actionLog)
            : base(mode, actionLog)
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
                            HeaderText = "Текст", 
                            Width = 400, 
                            DefaultCellStyle = { Alignment = DataGridViewContentAlignment.MiddleLeft }
                        },
                        new DataGridViewTextBoxColumn
                        {
                            HeaderText = "ID Документа", 
                            Width = 120, 
                            DefaultCellStyle = { Alignment = DataGridViewContentAlignment.MiddleCenter }
                        },
                        new DataGridViewTextBoxColumn
                        {
                            HeaderText = "Тип лога", 
                            Width = 150, 
                            DefaultCellStyle = { Alignment = DataGridViewContentAlignment.MiddleLeft }
                        },
                        new DataGridViewTextBoxColumn
                        {
                            HeaderText = "Создан", 
                            Width = 120, 
                            DefaultCellStyle = { Alignment = DataGridViewContentAlignment.MiddleLeft }
                        },
                        new DataGridViewTextBoxColumn
                        {
                            HeaderText = "Создал", 
                            Width = 120, 
                            DefaultCellStyle = { Alignment = DataGridViewContentAlignment.MiddleLeft }
                        }
                    };
            }
        }

        protected override ActionLog[] LoadDtosByFilter(string filter)
        {
            return IoCContainer.Get<ILogService>().GetActionLogs(
                _dateDateIntervalControl.UtcFrom, _dateDateIntervalControl.UtcTo, filter);
        }

        protected override object[] GetDtoValues(ActionLog actionLog)
        {
            return
                new object[]
                {
                    actionLog.Text,
                    actionLog.DocumentId,
                    actionLog.ActionLogType.ToString(),
                    actionLog.CreateDate.ToLocalTime().ToString("G"),
                    actionLog.CreateUser
                };
        }
    }

    public class BaseLogListForm : BaseDtoListForm<ActionLog>
    {
        protected BaseLogListForm() { }

        protected BaseLogListForm(ListFormMode mode, ActionLog actionLog)
            : base(mode, actionLog)
        {
        }
    }
}
