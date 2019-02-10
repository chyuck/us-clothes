using System;
using System.ServiceModel.Configuration;

namespace USClothesWebSite.Web.Behaviors.IoC
{
    public class IoCServiceBehaviorExtension : BehaviorExtensionElement
    {
        public override Type BehaviorType
        {
            get { return typeof(IoCServiceBehavior); }
        }

        protected override object CreateBehavior()
        {
            return new IoCServiceBehavior();
        }
    }
}