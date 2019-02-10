using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Dispatcher;

namespace USClothesWebSite.Web.Behaviors.IoC
{
    public class IoCServiceMessageInspector : IDispatchMessageInspector
    {
        public object AfterReceiveRequest(ref Message request, IClientChannel channel, InstanceContext instanceContext)
        {
            var context = new IoCOperationContext();

            OperationContext.Current.Extensions.Add(context);

            context.Container = BusinessLogic.IoCFactory.CreateContainer();

            return null;
        }

        public void BeforeSendReply(ref Message reply, object correlationState)
        {
            OperationContext.Current.Extensions.Remove(IoCOperationContext.Current);
        }
    }
}