using System;
using System.Runtime.Serialization;
using USClothesWebSite.Common.Helpers.Object;
using USClothesWebSite.Common.Services.LocalizedName;
using USClothesWebSite.Common.Services.Validate.Attributes;

namespace USClothesWebSite.DTO
{
    [DataContract(IsReference = true)]
    [LocalizedName("Строка заказа", "Строки заказа")]
    public class OrderItem : IEquatable<OrderItem>, IActivatedDto, ITrackableDto, ICloneable, IDetailDto<Order, OrderItem>
    {
        [DataMember]
        [IdValidate]
        public int Id { get; set; }

        /// <summary>Цена продажи за 1 шт, руб</summary>
        /// <remarks>Продавец</remarks>
        [DataMember]
        [DecimalValidate("Цена продажи за 1 шт должна быть в диапазоне от 0,01 до 1 000 000.",
            MinValueString = "0.01", MaxValueString = "1000000")]
        public decimal Price { get; set; }

        /// <remarks>Продавец</remarks>
        [DataMember]
        [IntegerValidate("Количество должно быть в диапазоне 1 до 100 000.", MinValue = 0, MaxValue = 100000)]
        public int Quantity { get; set; }

        /// <remarks>Продавец</remarks>
        [DataMember]
        public bool Active { get; set; }

        /// <summary>Цена покупки, дол</summary>
        /// <remarks>Закупщик</remarks>
        [DataMember]
        [DecimalValidate("Цена покупки должна быть в диапазоне от 0 до 100 000.",
            MinValueString = "0", MaxValueString = "100000")]
        public decimal PurchaserPaid { get; set; }

        /// <remarks>Продавец</remarks>
        [DataMember]
        [NotNullValidate("Заказ должен быть задан.")]
        [IgnoreInClone]
        public virtual Order Order { get; set; }

        /// <remarks>Продавец</remarks>
        [DataMember]
        [NotNullValidate("Размер товара должен быть задан.")]
        public virtual ProductSize ProductSize { get; set; }

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
            return Equals(obj as OrderItem);
        }

        public override int GetHashCode()
        {
            return ObjectHelper.GetHashCode(this);
        }

        public bool Equals(OrderItem other)
        {
            return ObjectHelper.Equals(this, other);
        }

        internal OrderItem Clone(Order order)
        {
            var orderItem = ObjectHelper.Clone(this);
            orderItem.Order = order;

            return orderItem;
        }

        public object Clone()
        {
            var order = Order != null ? (Order)Order.Clone() : null;

            return Clone(order);
        }

        public Order MasterDto
        {
            get { return Order; }
        }

        /// <summary>Итоговая цена продажи, руб</summary>
        public decimal TotalPrice 
        {
            get { return Price * Quantity; }
        }
    }
}
