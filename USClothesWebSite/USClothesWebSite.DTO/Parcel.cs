using System;
using System.Linq;
using System.Runtime.Serialization;
using USClothesWebSite.Common.Helpers.Object;
using USClothesWebSite.Common.Services.LocalizedName;
using USClothesWebSite.Common.Services.Validate.Attributes;

namespace USClothesWebSite.DTO
{
    [DataContract(IsReference = true)]
    [LocalizedName("Посылка", "Посылки")]
    public class Parcel : IEquatable<Parcel>, ITrackableDto, ICloneable, IMasterDto<Parcel, Order>
    {
        [DataMember]
        [IdValidate]
        public int Id { get; set; }

        /// <remarks>Закупщик</remarks>
        [DataMember]
        [StringValidate("Номер отслеживания должен иметь длину не более 20 символов.",
            CanBeNull = true, CanBeEmpty = true, MaxLength = 20)]
        public string TrackingNumber { get; set; }

        /// <remarks>Закупщик</remarks>
        [DataMember]
        public DateTime? SentDate { get; set; }

        /// <remarks>Закупщик</remarks>
        [DataMember]
        [StringValidate("Комментарий должен иметь длину не более 1000 символов.",
            CanBeNull = true, CanBeEmpty = true, MaxLength = 1000)]
        public string Comments { get; set; }

        /// <remarks>Закупщик</remarks>
        [DataMember]
        [DecimalValidate("Курс доллара должен быть в диапазоне от 0,01 до 1 000 000.",
            MinValueString = "0.01", MaxValueString = "1000000")]
        public decimal RublesPerDollar { get; set; }

        /// <summary>Цена отправки, дол</summary>
        /// <remarks>Закупщик</remarks>
        [DataMember]
        [DecimalValidate("Цена отправки должна быть в диапазоне от 0 до 1 000 000.",
            MinValueString = "0", MaxValueString = "1000000")]
        public decimal PurchaserSpentOnDelivery { get; set; }

        /// <remarks>Распространитель</remarks>
        [DataMember]
        public DateTime? ReceivedDate { get; set; }

        /// <remarks>Закупщик</remarks>
        [DataMember]
        public User Distributor { get; set; }

        [DataMember]
        [IgnoreInEquals]
        [IgnoreInGetHashCode]
        [IgnoreInClone]
        public Order[] Orders { get; set; }

        [DataMember]
        [IgnoreInEquals]
        [IgnoreInGetHashCode]
        public int CreateUserId { get; set; }

        [DataMember]
        [IgnoreInEquals]
        [IgnoreInGetHashCode]
        public DateTime CreateDate { get; set; }

        [DataMember]
        [IgnoreInEquals]
        [IgnoreInGetHashCode]
        public string CreateUser { get; set; }

        [DataMember]
        [IgnoreInEquals]
        [IgnoreInGetHashCode]
        public DateTime ChangeDate { get; set; }

        [DataMember]
        [IgnoreInEquals]
        [IgnoreInGetHashCode]
        public string ChangeUser { get; set; }

        public override bool Equals(object obj)
        {
            return Equals(obj as Parcel);
        }

        public override int GetHashCode()
        {
            return ObjectHelper.GetHashCode(this);
        }

        public bool Equals(Parcel other)
        {
            return ObjectHelper.Equals(this, other);
        }

        public object Clone()
        {
            var parcel = ObjectHelper.Clone(this);

            if (Orders != null)
                parcel.Orders =
                    Orders
                        .Select(o => o.Clone(parcel))
                        .ToArray();

            return parcel;
        }

        public override string ToString()
        {
            return GetParcelName(Id);
        }

        public Order[] DetailDtos
        {
            get { return Orders; }
        }

        public string ParcelNumber
        {
            get { return GetParcelNumber(Id); }
        }

        public static string GetParcelName(int id)
        {
            return id > 0 ? string.Format("Посылка №{0}", GetParcelNumber(id)) : string.Empty;
        }

        public static string GetParcelNumber(int id)
        {
            return id > 0 ? id.ToString("0000") : string.Empty;
        }

        /// <summary>Итоговая цена продажи, руб</summary>
        public decimal TotalPrice
        {
            get
            {
                if (Orders == null || !Orders.Any())
                    return 0;

                return Orders.Sum(oi => oi.TotalPrice);
            }
        }
    }
}
