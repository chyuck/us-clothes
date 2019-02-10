using System;
using System.Runtime.Serialization;
using USClothesWebSite.Common.Helpers.Object;
using USClothesWebSite.Common.Services.LocalizedName;

namespace USClothesWebSite.DTO
{
    [DataContract(IsReference = true)]
    [LocalizedName("Отчет по посылке", "Отчет по посылкам")]
    public class ParcelReportItem : IEquatable<ParcelReportItem>, IDto, ICloneable
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string ParcelName { get; set; }

        [DataMember]
        public DateTime? SentDate { get; set; }

        [DataMember]
        public DateTime? ReceivedDate { get; set; }

        [DataMember]
        public string DistributorName { get; set; }

        [DataMember]
        public decimal PurchaserPaid { get; set; }

        [DataMember]
        public decimal PurchaserSpentOnDelivery { get; set; }

        [DataMember]
        public decimal DistributorSpentOnDelivery { get; set; }

        [DataMember]
        public decimal TotalPaid { get; set; }

        [DataMember]
        public decimal CustomersPrepaid { get; set; }

        [DataMember]
        public decimal CustomersPaid { get; set; }

        [DataMember]
        public decimal TotalCustomersPaid { get; set; }

        [DataMember]
        public decimal ExpectedTotalCustomerPaid { get; set; }

        [DataMember]
        public decimal TotalProfit { get; set; }

        [DataMember]
        public decimal ExpectedTotalProfit { get; set; }

        public override bool Equals(object obj)
        {
            return Equals(obj as ParcelReportItem);
        }

        public override int GetHashCode()
        {
            return ObjectHelper.GetHashCode(this);
        }

        public bool Equals(ParcelReportItem other)
        {
            return ObjectHelper.Equals(this, other);
        }

        public object Clone()
        {
            return ObjectHelper.Clone(this);
        }
    }
}
