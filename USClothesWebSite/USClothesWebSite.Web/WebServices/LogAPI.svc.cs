using System;
using USClothesWebSite.BusinessLogic.ActionLog;

namespace USClothesWebSite.Web.WebServices
{
    public class LogAPI : BaseAPI, ILogAPI
    {
        public DTO.ActionLog[] GetActionLogs(DateTime startDate, DateTime endDate, string filter)
        {
            return Container.Get<IActionLogService>().GetActionLogs(startDate, endDate, filter);
        }
    }
}
