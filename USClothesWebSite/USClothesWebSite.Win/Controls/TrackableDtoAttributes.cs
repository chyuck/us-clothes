using System;
using System.Windows.Forms;
using USClothesWebSite.Common.Helpers;
using USClothesWebSite.Common.Services.Time;
using USClothesWebSite.DTO;
using USClothesWebSite.Win.Logic;
using USClothesWebSite.Win.Logic.Form;
using USClothesWebSite.Win.Logic.Security;

namespace USClothesWebSite.Win.Controls
{
    public partial class TrackableDtoAttributes : UserControl
    {
        public TrackableDtoAttributes()
        {
            InitializeComponent();
        }

        private string GetCurrentUserFullName()
        {
            var securityService = IoC.Container.Get<ISecurityService>();
            CheckHelper.WithinCondition(securityService.IsLoggedIn, "securityService.IsLoggedIn");
            
            return securityService.CurrentUser.ToString();
        }

        private string GetLocalTime()
        {
            var timeService = IoC.Container.Get<ITimeService>();

            return timeService.LocalNow.ToString("F");
        }

        public void SetControls(EditFormMode mode, ITrackableDto dto)
        {
            CheckHelper.ArgumentWithinCondition(
                mode == EditFormMode.Create
                ||
                dto != null && dto.Id > 0 && mode != EditFormMode.Create,
                "Invalid usage");

            switch (mode)
            {
                case EditFormMode.Create:
                    {
                        var currentUserFullName = GetCurrentUserFullName();
                        var localNow = GetLocalTime();
                        
                        _createUserTextBox.Text = currentUserFullName;
                        _createDateTextBox.Text = localNow;
                        _changeUserTextBox.Text = currentUserFullName;
                        _changeDateTextBox.Text = localNow;
                    }
                    break;

                case EditFormMode.Edit:
                    {
                        var currentUserFullName = GetCurrentUserFullName();
                        var localNow = GetLocalTime();

                        _createUserTextBox.Text = dto.CreateUser;
                        _createDateTextBox.Text = dto.CreateDate.ToLocalTime().ToString("F");
                        _changeUserTextBox.Text = currentUserFullName;
                        _changeDateTextBox.Text = localNow;
                    }
                    break;

                case EditFormMode.View:
                    _createUserTextBox.Text = dto.CreateUser;
                    _createDateTextBox.Text = dto.CreateDate.ToLocalTime().ToString("F");
                    _changeUserTextBox.Text = dto.ChangeUser;
                    _changeDateTextBox.Text = dto.ChangeDate.ToLocalTime().ToString("F");
                    break;

                default:
                    throw new NotSupportedException(mode.ToString());
            }
        }
    }
}
