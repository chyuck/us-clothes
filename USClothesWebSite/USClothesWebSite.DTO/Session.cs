using System;
using USClothesWebSite.Common.Helpers.Object;

namespace USClothesWebSite.DTO
{
    public class Session : IEquatable<Session>, IDto, ICloneable
    {
        public int Id { get; set; }
        public string Key { get; set; }
        public DateTime CreateDate { get; set; }

        public override bool Equals(object obj)
        {
            return Equals(obj as Session);
        }

        public override int GetHashCode()
        {
            return ObjectHelper.GetHashCode(this);
        }

        public bool Equals(Session other)
        {
            return ObjectHelper.Equals(this, other);
        }

        public object Clone()
        {
            return ObjectHelper.Clone(this);
        }
    }
}
