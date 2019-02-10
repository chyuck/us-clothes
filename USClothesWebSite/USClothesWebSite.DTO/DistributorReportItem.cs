using System;
using System.Runtime.Serialization;
using USClothesWebSite.Common.Helpers.Object;
using USClothesWebSite.Common.Services.LocalizedName;

namespace USClothesWebSite.DTO
{
    [DataContract(IsReference = true)]
    [LocalizedName("Отчет по распространителю", "Отчет по распространителям")]
    public class DistributorReportItem : IEquatable<DistributorReportItem>, IDto, ICloneable
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string DistributorName { get; set; }

        [DataMember]
        public decimal DistributorSpent { get; set; }

        [DataMember]
        public decimal DistributorReceived { get; set; }

        [DataMember]
        public decimal DistributorBalance { get; set; }

        [DataMember]
        public decimal PurchaserSpent { get; set; }

        [DataMember]
        public decimal PurchaserReceived { get; set; }

        [DataMember]
        public decimal PurchaserBalance { get; set; }

        [DataMember]
        public decimal TotalBalance { get; set; }
        
        public override bool Equals(object obj)
        {
            return Equals(obj as DistributorReportItem);
        }

        public override int GetHashCode()
        {
            return ObjectHelper.GetHashCode(this);
        }

        public bool Equals(DistributorReportItem other)
        {
            return ObjectHelper.Equals(this, other);
        }

        public object Clone()
        {
            return ObjectHelper.Clone(this);
        }
    }
}
