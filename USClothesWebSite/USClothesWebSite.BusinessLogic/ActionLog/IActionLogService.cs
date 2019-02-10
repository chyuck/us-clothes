using System;

namespace USClothesWebSite.BusinessLogic.ActionLog
{
    public interface IActionLogService
    {
        DTO.ActionLogType UserCreatedType { get; }
        DTO.ActionLogType UserChangedType { get; }
        DTO.ActionLogType UserChangedPasswordType { get; }
        DTO.ActionLogType PasswordWasResetedForUserType { get; }

        DTO.ActionLog[] GetActionLogs(DateTime startDate, DateTime endDate, string filter);

        void CreateActionLog(DTO.ActionLog createdActionLog);
    }
}
