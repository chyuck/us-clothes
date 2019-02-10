using System;
using System.Runtime.Serialization;
using USClothesWebSite.Common.Helpers.Object;
using USClothesWebSite.Common.Services.LocalizedName;
using USClothesWebSite.Common.Services.Validate.Attributes;

namespace USClothesWebSite.DTO
{
    [DataContract(IsReference = true)]
    [LocalizedName("Лог", "Логи")]
    public class ActionLog : IDto, IEquatable<ActionLog>, ICloneable
    {
        [DataMember]
        [IdValidate]
        public int Id { get; set; }

        [DataMember]
        [NotNullValidate("Не задан текст.")]
        public string Text { get; set; }

        [DataMember]
        [IntegerValidate("Не задано Id документа.", MinValue = 1)]
        public int DocumentId { get; set; }

        [DataMember]
        [NotNullValidate("Не задан тип лога.")]
        public ActionLogType ActionLogType { get; set; }

        [DataMember]
        public DateTime CreateDate { get; set; }

        [DataMember]
        public string CreateUser { get; set; }
        
        public override bool Equals(object obj)
        {
            return Equals(obj as ActionLog);
        }

        public override int GetHashCode()
        {
            return ObjectHelper.GetHashCode(this);
        }

        public bool Equals(ActionLog other)
        {
            return ObjectHelper.Equals(this, other);
        }

        public object Clone()
        {
            return ObjectHelper.Clone(this);
        }
    }
}
