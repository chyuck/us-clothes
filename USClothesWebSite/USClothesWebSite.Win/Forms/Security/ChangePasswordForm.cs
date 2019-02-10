using USClothesWebSite.Win.Forms.Base;
using USClothesWebSite.Win.Logic;
using USClothesWebSite.Win.Logic.Security;

namespace USClothesWebSite.Win.Forms.Security
{
    public partial class ChangePasswordForm : BaseEditForm
    {
        public ChangePasswordForm()
        {
            InitializeComponent();
        }

        protected override string InitialMessage
        {
            get { return @"Введите ""Новый пароль"" и ""Подтверждение пароля"" и нажмите ""Сохранить"""; }
        }

        protected override string OnSave()
        {
            var newPassword = _newPasswordMaskedTextBox.Text;
            var passwordConfirmation = _passwordConfirmationMaskedTextBox.Text;

            var errorMessage = IoCContainer.Get<ISecurityService>().ChangePassword(newPassword, passwordConfirmation);
            if (!string.IsNullOrEmpty(errorMessage))
                return errorMessage;

            return null;
        }
    }
}
