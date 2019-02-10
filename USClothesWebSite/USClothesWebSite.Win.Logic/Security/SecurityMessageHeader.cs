using System.ServiceModel.Channels;
using System.Xml;
using USClothesWebSite.Common.Helpers;
using USClothesWebSite.Common.Services.Serialize;
using USClothesWebSite.DTO;

namespace USClothesWebSite.Win.Logic.Security
{
    public class SecurityMessageHeader : MessageHeader
    {
        public override string Name
        {
            get { return SecurityData.HEADER_NAME; }
        }

        public override string Namespace
        {
            get { return SecurityData.HEADER_NAMESPACE; }
        }

        public SecurityData SecurityData { get; set; }

        protected override void OnWriteHeaderContents(XmlDictionaryWriter writer, MessageVersion messageVersion)
        {
            CheckHelper.NotNull(SecurityData, "SecurityData");

            var serializeService = IoC.Container.Get<ISerializeService>();
            var data = serializeService.Serialize(SecurityData);

            writer.WriteElementString(SecurityData.HEADER_NAME, data);
        }
    }
}
