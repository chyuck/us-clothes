using System;
using USClothesWebSite.Common.Helpers;

namespace USClothesWebSite.Common.Services.Validate
{
    public sealed class ValidationError : IEquatable<ValidationError>
    {
        public ValidationError(string key, string message)
        {
            CheckHelper.ArgumentNotNullAndNotWhiteSpace(key, "key");
            CheckHelper.ArgumentNotNullAndNotWhiteSpace(message, "message");

            Key = key;
            Message = message;
        }

        public string Key { get; private set; }
        public string Message { get; private set; }

        public override bool Equals(object obj)
        {
            return Equals(obj as ValidationError);
        }

        public override int GetHashCode()
        {
            return 
                Key.GetHashCode() ^ 
                Message.GetHashCode();
        }

        public bool Equals(ValidationError other)
        {
            if (other == null)
                return false;

            if (ReferenceEquals(this, other))
                return true;

            return
                other.Key == Key &&
                other.Message == Message;
        }
    }
}
