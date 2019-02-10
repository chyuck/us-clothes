using System.ServiceModel;
using DepIC;

namespace USClothesWebSite.Web.Behaviors.IoC
{
    public class IoCOperationContext : IExtension<OperationContext>
    {
        public IReadOnlyContainer Container { get; set; }

        public static IoCOperationContext Current
        {
            get
            {
                return OperationContext.Current.Extensions.Find<IoCOperationContext>();
            }
        }

        public void Attach(OperationContext owner)
        {
        }

        public void Detach(OperationContext owner)
        {
        }
    }
}