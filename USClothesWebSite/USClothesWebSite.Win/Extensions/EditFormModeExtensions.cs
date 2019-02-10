using System;
using USClothesWebSite.Win.Logic.Form;

namespace USClothesWebSite.Win.Extensions
{
    public static class EditFormModeExtensions
    {
        public static string ToLocalizedName(this EditFormMode editFormMode)
        {
            switch (editFormMode)
            {
                case EditFormMode.Create:
                    return "Создание";

                case EditFormMode.Edit:
                    return "Редактирование";

                case EditFormMode.View:
                    return "Просмотр";

                default:
                    throw new NotSupportedException(editFormMode.ToString());
            }
        }
    }
}
