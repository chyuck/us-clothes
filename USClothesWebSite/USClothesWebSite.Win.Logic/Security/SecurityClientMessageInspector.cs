using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Dispatcher;

namespace USClothesWebSite.Win.Logic.Security
{
    public class SecurityClientMessageInspector : IClientMessageInspector
    {
        public void AfterReceiveReply(ref Message reply, object correlationState)
        {
        }

        public object BeforeSendRequest(ref Message request, IClientChannel channel)
        {
            var securityService = IoC.Container.Get<ISecurityService>();

            var securityData = securityService.SecurityData;

            if (securityData != null)
            {
                var header =
                    new SecurityMessageHeader
                    {
                        SecurityData = securityData
                    };

                request.Headers.Add(header);
            }

            return null;
        }
    }
}
