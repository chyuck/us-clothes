using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Dispatcher;
using System.Xml;
using USClothesWebSite.BusinessLogic.Security;
using USClothesWebSite.Common.Helpers;
using USClothesWebSite.DTO;
using USClothesWebSite.Web.Behaviors.IoC;

namespace USClothesWebSite.Web.Behaviors.Security
{
    public class SecurityServiceMessageInspector : IDispatchMessageInspector
    {
        public object AfterReceiveRequest(ref Message request, IClientChannel channel, InstanceContext instanceContext)
        {
            var headerPosition = request.Headers.FindHeader(SecurityData.HEADER_NAME, SecurityData.HEADER_NAMESPACE);
            
            if (headerPosition >= 0)
            {
                var xmlNodes = request.Headers.GetHeader<XmlNode[]>(headerPosition);
                var data = xmlNodes[0].InnerText;

                var securityData = SerializeHelper.Deserialize<SecurityData>(data);

                var operationContext = IoCOperationContext.Current;
                CheckHelper.NotNull(operationContext, "operationContext");

                var container = operationContext.Container;
                CheckHelper.NotNull(container, "container");

                container.Get<ISecurityService>().LogIn(securityData);
            }

            return null;
        }

        public void BeforeSendReply(ref Message reply, object correlationState)
        {
        }
    }
}