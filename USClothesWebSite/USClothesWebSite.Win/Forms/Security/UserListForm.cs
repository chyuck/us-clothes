using System;
using System.Linq;
using System.Windows.Forms;
using USClothesWebSite.DTO;
using USClothesWebSite.Win.Forms.Base;
using USClothesWebSite.Win.Helpers;
using USClothesWebSite.Win.Logic.Extensions;
using USClothesWebSite.Win.Logic.Form;
using USClothesWebSite.Win.Logic.Security;

namespace USClothesWebSite.Win.Forms.Security
{
    public partial class UserListForm : BaseUserListForm
    {
        public UserListForm(ListFormMode mode, User user)
            : this(mode, user, null)
        {
            
        }

        public UserListForm(ListFormMode mode, User user, Func<User, bool> filter)
            : base(mode, user, filter)
        {
            InitializeComponent();
        }

        protected override void OnLoad()
        {
            base.OnLoad();

            var isCurrentUserAdministrator = IoCContainer.Get<ISecurityService>().IsCurrentUserAdministrator;

            CreateButton.Enabled = isCurrentUserAdministrator;
            EditButton.Enabled = isCurrentUserAdministrator;
            _resetPasswordButton.Visible = isCurrentUserAdministrator;
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
                            HeaderText = "Имя", 
                            Width = 100, 
                            DefaultCellStyle = { Alignment = DataGridViewContentAlignment.MiddleLeft }
                        },
                        new DataGridViewTextBoxColumn
                        {
                            HeaderText = "Фамилия", 
                            Width = 100, 
                            DefaultCellStyle = { Alignment = DataGridViewContentAlignment.MiddleLeft }
                        },
                        new DataGridViewTextBoxColumn
                        {
                            HeaderText = "Электронная почта", 
                            Width = 150, 
                            DefaultCellStyle = { Alignment = DataGridViewContentAlignment.MiddleLeft }
                        },
                        new DataGridViewTextBoxColumn
                        {
                            HeaderText = "Логин", 
                            Width = 100, 
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

        protected override User[] LoadDtosByFilter(string filter)
        {
            return IoCContainer.Get<ISecurityService>().GetUsers(filter);
        }

        protected override object[] GetDtoValues(User user)
        {
            var values =
                new object[]
                {
                    user.FirstName,
                    user.LastName,
                    user.Email,
                    user.Login,
                    user.Active.ToYesNo()
                };

            return
                values
                    .Concat(TrackableDtoListFormHelper.GetValues(user))
                    .ToArray();
        }

        private void ResetPasswordButton_Click(object sender, EventArgs e)
        {
            const string POPUP_CAPTION = "Сброс пароля";

            var selectedDto = GetSelectedDto();
            if (selectedDto == null)
                return;

            var message = string.Format(@"Сбросить пароль для пользователя ""{0}""?", selectedDto);
            if (!PopupHelper.ShowYesNoDialog(this, message, POPUP_CAPTION))
                return;

            var errorMessage = IoCContainer.Get<ISecurityService>().ResetPassword(selectedDto);

            if (!string.IsNullOrEmpty(errorMessage))
            {
                PopupHelper.ShowError(this, errorMessage, POPUP_CAPTION);
                return;
            }

            var infoMessage = 
                string.Format(
                    @"Пароль для пользователя ""{0}"" сброшен. Письмо с новым паролем отправлено на электронную почту пользователя.",
                    selectedDto);
            PopupHelper.ShowInfo(this, infoMessage, POPUP_CAPTION);
        }
    }

    public class BaseUserListForm : BaseDtoListForm<User>
    {
        protected BaseUserListForm() { }

        protected BaseUserListForm(ListFormMode mode, User user)
            : base(mode, user)
        {
        }

        protected BaseUserListForm(ListFormMode mode, User user, Func<User, bool> filter)
            : base(mode, user, filter)
        {
        }
    }
}
