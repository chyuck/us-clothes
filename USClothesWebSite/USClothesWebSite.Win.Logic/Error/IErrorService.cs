using System;

namespace USClothesWebSite.Win.Logic.Error
{
    public interface IErrorService
    {
        string GetHeader(Exception exception);

        string GetMessage(Exception exception);
    }
}
