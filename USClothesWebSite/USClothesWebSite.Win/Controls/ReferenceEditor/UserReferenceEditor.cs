using System.Linq;
using USClothesWebSite.DTO;
using USClothesWebSite.Win.Logic.Security;

namespace USClothesWebSite.Win.Controls.ReferenceEditor
{
    public class UserReferenceEditor : ReferenceEditor<User>
    {
        protected override User[] GetDtos()
        {
            var securityService = IoCContainer.Get<ISecurityService>();
            var users = securityService.GetUsers(null);

            return users.OrderBy(b => b.ToString()).ToArray();
        }
    }
}
