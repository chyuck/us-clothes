using System.Collections.Generic;
using System.Windows.Forms;
using USClothesWebSite.Common.Helpers;
using USClothesWebSite.DTO;
using USClothesWebSite.Win.Forms.Base;
using USClothesWebSite.Win.Logic.Form;

namespace USClothesWebSite.Win.Forms.Administration
{
    public partial class LogEditForm : BaseLogEditForm
    {
        public LogEditForm(EditFormMode mode, ActionLog actionLog)
            : base(mode, actionLog)
        {
            CheckHelper.ArgumentWithinCondition(mode == EditFormMode.View, "Form is readonly.");

            InitializeComponent();
        }

        protected override IEnumerable<Control> EditControls
        {
            get
            {
                return
                    new Control[]
                    {
                        _textTextBox,
                        _documentIdTextBox,
                        _logTypeTextBox,
                        _createDateTextBox,
                        _createUserTextBox
                    };
            }
        }

        protected override void SetDtoToControls(ActionLog actionLog)
        {
            _textTextBox.Text = actionLog.Text;
            _documentIdTextBox.Text = actionLog.DocumentId.ToString();
            _logTypeTextBox.Text = actionLog.ActionLogType.ToString();
            _createDateTextBox.Text = actionLog.CreateDate.ToLocalTime().ToString("F");
            _createUserTextBox.Text = actionLog.CreateUser;
        }
    }

    public class BaseLogEditForm : BaseDtoEditForm<ActionLog>
    {
        protected BaseLogEditForm() { }

        protected BaseLogEditForm(EditFormMode mode, ActionLog actionLog)
            : base(mode, actionLog)
        {
        }
    }
}
