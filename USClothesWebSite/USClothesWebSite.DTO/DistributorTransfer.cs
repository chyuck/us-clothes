﻿using System;
using System.Runtime.Serialization;
using USClothesWebSite.Common.Helpers.Object;
using USClothesWebSite.Common.Services.LocalizedName;
using USClothesWebSite.Common.Services.Validate.Attributes;

namespace USClothesWebSite.DTO
{
    [DataContract(IsReference = true)]
    [LocalizedName("Перевод распространителя", "Переводы распространителей")]
    public class DistributorTransfer : IEquatable<DistributorTransfer>, IActivatedDto, ITrackableDto, ICloneable
    {
        [DataMember]
        [IdValidate]
        public int Id { get; set; }

        [DataMember]
        public DateTime Date { get; set; }

        /// <remarks>руб</remarks>
        [DataMember]
        [DecimalValidate("Сумма перевода должна быть в диапазоне от 0 до 1 000 000.",
            MinValueString = "0", MaxValueString = "1000000")]
        public decimal Amount { get; set; }

        [DataMember]
        [DecimalValidate("Курс доллара должен быть в диапазоне от 0,01 до 1 000 000.",
            MinValueString = "0.01", MaxValueString = "1000000")]
        public decimal RublesPerDollar { get; set; }
        
        [DataMember]
        [IgnoreInEquals]
        [IgnoreInGetHashCode]
        public string CreateUser { get; set; }

        [DataMember]
        [IgnoreInEquals]
        [IgnoreInGetHashCode]
        public DateTime CreateDate { get; set; }


        [DataMember]
        [IgnoreInEquals]
        [IgnoreInGetHashCode]
        public DateTime ChangeDate { get; set; }

        [DataMember]
        [IgnoreInEquals]
        [IgnoreInGetHashCode]
        public string ChangeUser { get; set; }

        [DataMember]
        public bool Active { get; set; }

        public override bool Equals(object obj)
        {
            return Equals(obj as DistributorTransfer);
        }

        public override int GetHashCode()
        {
            return ObjectHelper.GetHashCode(this);
        }

        public bool Equals(DistributorTransfer other)
        {
            return ObjectHelper.Equals(this, other);
        }

        public object Clone()
        {
            return ObjectHelper.Clone(this);
        }
    }
}
