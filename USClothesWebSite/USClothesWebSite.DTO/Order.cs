using System;
using System.Linq;
using System.Runtime.Serialization;
using USClothesWebSite.Common.Helpers.Object;
using USClothesWebSite.Common.Services.LocalizedName;
using USClothesWebSite.Common.Services.Validate.Attributes;

namespace USClothesWebSite.DTO
{
    [DataContract(IsReference = true)]
    [LocalizedName("Заказ", "Заказы")]
    public class Order : IEquatable<Order>, IActivatedDto, ITrackableDto, ICloneable, IMasterDto<Order, OrderItem>, IDetailDto<Parcel, Order>
    {
        [DataMember]
        [IdValidate]
        public int Id { get; set; }

        /// <remarks>Продавец</remarks>
        [DataMember]
        public DateTime OrderDate { get; set; }

        /// <remarks>Продавец</remarks>
        [DataMember]
        [StringValidate("Имя клиента должно иметь длину от 1 до 50 символов.",
            CanBeNull = false, CanBeEmpty = false, MinLength = 1, MaxLength = 50)]
        public string CustomerFirstName { get; set; }

        /// <remarks>Продавец</remarks>
        [DataMember]
        [StringValidate("Фамилия клиента должно иметь длину от 1 до 50 символов.",
            CanBeNull = false, CanBeEmpty = false, MinLength = 1, MaxLength = 50)]
        public string CustomerLastName { get; set; }

        /// <remarks>Продавец</remarks>
        [DataMember]
        [StringValidate("Адрес клиента должен иметь длину от 1 до 100 символов.",
            CanBeNull = false, CanBeEmpty = false, MinLength = 1, MaxLength = 100)]
        public string CustomerAddress { get; set; }

        /// <remarks>Продавец</remarks>
        [DataMember]
        [StringValidate("Город клиента должен иметь длину от 1 до 50 символов.",
            CanBeNull = false, CanBeEmpty = false, MinLength = 1, MaxLength = 50)]
        public string CustomerCity { get; set; }

        /// <remarks>Продавец</remarks>
        [DataMember]
        [StringValidate("Страна клиента должна иметь длину от 1 до 50 символов.",
            CanBeNull = false, CanBeEmpty = false, MinLength = 1, MaxLength = 50)]
        public string CustomerCountry { get; set; }

        /// <remarks>Продавец</remarks>
        [DataMember]
        [StringValidate("Индекс клиента должен иметь длину от 1 до 20 символов.",
            CanBeNull = false, CanBeEmpty = false, MinLength = 1, MaxLength = 20)]
        public string CustomerPostalCode { get; set; }

        /// <remarks>Продавец</remarks>
        [DataMember]
        [StringValidate("Телефон клиента должен иметь длину от 1 до 20 символов.",
            CanBeNull = true, CanBeEmpty = true, MinLength = 1, MaxLength = 20)]
        public string CustomerPhoneNumber { get; set; }

        /// <remarks>Продавец</remarks>
        [DataMember]
        [EmailValidate("Неправильный формат электронной почты клиента.", CanBeNull = true, CanBeEmpty = true)]
        public string CustomerEmail { get; set; }

        /// <remarks>Продавец</remarks>
        [DataMember]
        public bool Active { get; set; }

        /// <remarks>Продавец</remarks>
        [DataMember]
        [StringValidate("Комментарий должен иметь длину не более 1000 символов.",
            CanBeNull = true, CanBeEmpty = true, MaxLength = 1000)]
        public string Comments { get; set; }

        /// <remarks>Продавец</remarks>
        [DataMember]
        [DecimalValidate("Курс доллара должен быть в диапазоне от 0,01 до 1 000 000.",
            MinValueString = "0.01", MaxValueString = "1000000")]
        public decimal RublesPerDollar { get; set; }

        /// <summary>Предоплата клиента, руб</summary>
        /// <remarks>Продавец</remarks>
        [DataMember]
        [DecimalValidate("Предоплата клиента должна быть в диапазоне от 0 до 1 000 000.",
            MinValueString = "0", MaxValueString = "1000000")]
        public decimal CustomerPrepaid { get; set; }

        /// <summary>Расходы распространителя, руб</summary>
        /// <remarks>Распространитель</remarks>
        [DataMember]
        [DecimalValidate("Расходы распространителя должны быть в диапазоне от 0 до 1 000 000.",
            MinValueString = "0", MaxValueString = "1000000")]
        public decimal DistributorSpentOnDelivery { get; set; }

        /// <summary>Оплата клиента, руб</summary>
        /// <remarks>Продавец</remarks>
        [DataMember]
        [DecimalValidate("Оплата клиента должна быть в диапазоне от 0 до 1 000 000.",
            MinValueString = "0", MaxValueString = "1000000")]
        public decimal CustomerPaid { get; set; }

        /// <remarks>Распространитель</remarks>
        [DataMember]
        [StringValidate("Номер отслеживания должен иметь длину не более 20 символов.",
            CanBeNull = true, CanBeEmpty = true, MaxLength = 20)]
        public string TrackingNumber { get; set; }

        /// <remarks>Закупщик</remarks>
        [DataMember]
        [IgnoreInClone]
        public Parcel Parcel { get; set; }

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

        [DataMember]
        [IgnoreInEquals]
        [IgnoreInGetHashCode]
        [IgnoreInClone]
        public OrderItem[] OrderItems { get; set; }

        public override bool Equals(object obj)
        {
            return Equals(obj as Order);
        }

        public override int GetHashCode()
        {
            return ObjectHelper.GetHashCode(this);
        }

        public bool Equals(Order other)
        {
            return ObjectHelper.Equals(this, other);
        }

        internal Order Clone(Parcel parcel)
        {
            var order = ObjectHelper.Clone(this);
            order.Parcel = parcel;

            if (OrderItems != null)
                order.OrderItems =
                    OrderItems
                        .Select(oi => oi.Clone(order))
                        .ToArray();

            return order;
        }

        public object Clone()
        {
            var parcel = Parcel != null ? (Parcel)Parcel.Clone() : null;

            return Clone(parcel);
        }

        public override string ToString()
        {
            return Id > 0 ? string.Format("Заказ №{0}", OrderNumber) : string.Empty;
        }

        public OrderItem[] DetailDtos
        {
            get { return OrderItems; }
        }

        public Parcel MasterDto
        {
            get { return Parcel; }
        }

        public string OrderNumber 
        {
            get { return Id > 0 ? Id.ToString("000000") : string.Empty; }
        }

        /// <summary>Итоговая цена продажи, руб</summary>
        public decimal TotalPrice
        {
            get
            {
                if (OrderItems == null || !OrderItems.Any())
                    return 0;

                return OrderItems.Sum(oi => oi.TotalPrice);
            }
        }
    }
}
