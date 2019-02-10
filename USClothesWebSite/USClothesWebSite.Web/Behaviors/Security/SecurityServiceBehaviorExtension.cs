using System;
using System.ServiceModel.Configuration;

namespace USClothesWebSite.Web.Behaviors.Security
{
    public class SecurityServiceBehaviorExtension : BehaviorExtensionElement
    {
        public override Type BehaviorType
        {
            get { return typeof(SecurityServiceBehavior); }
        }

        protected override object CreateBehavior()
        {
            return new SecurityServiceBehavior();
        }
    }
}