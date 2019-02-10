using System;
using System.ServiceModel.Configuration;

namespace USClothesWebSite.Web.Behaviors.Error
{
    public class ErrorServiceBehaviorExtension : BehaviorExtensionElement
    {
        public override Type BehaviorType
        {
            get { return typeof(ErrorServiceBehavior); }
        }

        protected override object CreateBehavior()
        {
            return new ErrorServiceBehavior();
        }
    }
}