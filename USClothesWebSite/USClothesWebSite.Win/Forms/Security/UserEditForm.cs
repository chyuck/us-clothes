using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using USClothesWebSite.Common.Extensions;
using USClothesWebSite.Common.Helpers;
using USClothesWebSite.DTO;
using USClothesWebSite.Win.Forms.Base;
using USClothesWebSite.Win.Logic.Extensions;
using USClothesWebSite.Win.Logic.Form;
using USClothesWebSite.Win.Logic.Menu;
using USClothesWebSite.Win.Logic.Security;

namespace USClothesWebSite.Win.Forms.Security
{
    public partial class UserEditForm : BaseUserEditForm
    {
        private Role[] _availableRoles;

        public UserEditForm(EditFormMode mode, User user)
            : base(mode, user)
        {
            InitializeComponent();
        }

        protected override IEnumerable<Control> EditControls
        {
            get
            {
                return
                    new Control[]
                        {
                            _firstNameTextBox,
                            _lastNameTextBox,
                            _emailTextBox,
                            _loginTextBox,
                            _activeCheckBox,
                            _rolesCheckedListBox
                        };
            }
        }

        protected override void OnLoad()
        {
            _availableRoles = IoCContainer.Get<ISecurityService>().AvailableRoles;

            _rolesCheckedListBox.Items.Clear();
            _availableRoles.ForEach(r => _rolesCheckedListBox.Items.Add(r.Name));

            _trackableDtoAttributes.SetControls(Mode, Dto);
            
            base.OnLoad();
        }

        private void SetRolesToControl(Role[] roles)
        {
            CheckHelper.ArgumentNotNull(roles, "roles");

            foreach (var availableRole in _availableRoles)
            {
                var role = availableRole;

                var index = _availableRoles.IndexOfElement(r => r.Name == role.Name);
                var isChecked = roles.Contains(role);

                _rolesCheckedListBox.SetItemCheckState(index, isChecked.ToCheckState());
            }
        }

        protected override void SetDtoToControls(User user)
        {
            _firstNameTextBox.Text = user.FirstName;
            _lastNameTextBox.Text = user.LastName;
            _emailTextBox.Text = user.Email;
            _loginTextBox.Text = user.Login;
            _activeCheckBox.Checked = user.Active;

            SetRolesToControl(user.Roles);
        }

        private void SetControlToRoles(User user)
        {
            CheckHelper.ArgumentNotNull(user, "user");

            var roles = new List<Role>();

            foreach (string checkedItemText in _rolesCheckedListBox.CheckedItems)
            {
                var role = _availableRoles.Single(r => r.Name == checkedItemText);
                roles.Add(role);
            }

            user.Roles = roles.ToArray();
        }

        protected override void SetControlsToDto(User user)
        {
            user.FirstName = _firstNameTextBox.Text;
            user.LastName = _lastNameTextBox.Text;
            user.Email = _emailTextBox.Text;
            user.Login = _loginTextBox.Text;
            user.Active = _activeCheckBox.Checked;

            SetControlToRoles(user);
        }

        protected override string OnInsert(User user)
        {
            return IoCContainer.Get<ISecurityService>().CreateUser(user);
        }

        protected override string OnUpdate(User user)
        {
            return IoCContainer.Get<ISecurityService>().UpdateUser(user);
        }

        protected override void OnClose()
        {
            base.OnClose();

            if (DialogResult == DialogResult.OK)
                IoCContainer.Get<IMenuService>().SetUpMenu();

            _availableRoles = null;
        }
    }

    public class BaseUserEditForm : BaseDtoEditForm<User>
    {
        protected BaseUserEditForm() { }

        protected BaseUserEditForm(EditFormMode mode, User user)
            : base(mode, user)
        {
        }
    }
}
