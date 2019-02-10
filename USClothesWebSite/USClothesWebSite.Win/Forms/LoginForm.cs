using System.Windows.Forms;
using USClothesWebSite.Win.Forms.Base;
using USClothesWebSite.Win.Logic;
using USClothesWebSite.Win.Logic.Security;
using USClothesWebSite.Win.Properties;

namespace USClothesWebSite.Win.Forms
{
    public partial class LoginForm : BaseEditForm
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        protected override string InitialMessage
        {
            get { return @"Введите ""Логин"" и ""Пароль"" и нажмите ""Войти"""; }
        }

        protected override string SavingMessage
        {
            get { return "Выполняется вход..."; }
        }

        protected override void OnLoad()
        {
            base.OnLoad();

            _loginTextBox.Text = Settings.Default.LoginForm_Login;

            if (!string.IsNullOrWhiteSpace(_loginTextBox.Text))
                ActiveControl = _passwordMaskedTextBox;
        }

        protected override string OnSave()
        {
            var login = _loginTextBox.Text;
            var password = _passwordMaskedTextBox.Text;

            var errorMessage = IoC.Container.Get<ISecurityService>().Login(login, password);
            if (!string.IsNullOrEmpty(errorMessage))
                return errorMessage;

            return null;
        }

        protected override void OnClose()
        {
            if (DialogResult == DialogResult.OK)
            {
                Settings.Default.LoginForm_Login = _loginTextBox.Text;
                Settings.Default.Save();
            }
        }
    }
}
