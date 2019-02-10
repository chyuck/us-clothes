using System;
using System.ServiceModel.Configuration;

namespace USClothesWebSite.Win.Logic.Security
{
    public class SecurityBehaviorExtension : BehaviorExtensionElement
    {
        public override Type BehaviorType
        {
            get { return typeof(SecurityEndpointBehavior); }
        }

        protected override object CreateBehavior()
        {
            return new SecurityEndpointBehavior();
        }
    }
}
