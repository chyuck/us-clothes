using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace USClothesWebSite.Common.Helpers.Object
{
    public static class ObjectHelper
    {
        private static IEnumerable<PropertyInfo> GetProperties<T>()
            where T : class
        {
            const BindingFlags BINDING_ATTR =
                BindingFlags.Instance |
                BindingFlags.Public;

            return 
                typeof(T)
                    .GetProperties(BINDING_ATTR)
                    .Where(p => 
                        p.CanRead && 
                        p.CanWrite && 
                        !typeof(Array).IsAssignableFrom(p.PropertyType));
        }

        public static int GetHashCode<T>(T obj)
            where T : class
        {
            CheckHelper.ArgumentNotNull(obj, "obj");

            var properties = GetProperties<T>();
            
            int hashCode = 0;

            foreach (var property in properties)
            {
                if (property.GetCustomAttribute<IgnoreInGetHashCodeAttribute>() != null)
                    continue;

                var value = property.GetValue(obj, null);

                if (value == null)
                    continue;

                hashCode |= value.GetHashCode();
            }

            return hashCode;
        }

        public static bool Equals<T>(T obj1, T obj2)
            where T : class
        {
            // Same object or both are nulls
            if (ReferenceEquals(obj1, obj2))
                return true;

            // One is null
            if (obj1 == null || obj2 == null)
                return false;

            var properties = GetProperties<T>();

            var equals = true;

            foreach (var property in properties)
            {
                if (property.GetCustomAttribute<IgnoreInEqualsAttribute>() != null)
                    continue;

                var value1 = property.GetValue(obj1, null);
                var value2 = property.GetValue(obj2, null);

                equals &= object.Equals(value1, value2);

                if (!equals)
                    break;
            }

            return equals;
        }

        public static T Clone<T>(T obj)
            where T : class, new()
        {
            CheckHelper.ArgumentNotNull(obj, "obj");

            var properties = GetProperties<T>();

            var clone = new T();

            foreach (var property in properties)
            {
                if (property.GetCustomAttribute<IgnoreInCloneAttribute>() != null)
                    continue;

                var value = property.GetValue(obj, null);

                if (value == null)
                {
                    property.SetValue(clone, null);
                    continue;
                }

                var clonable = value as ICloneable;
                if (clonable == null)
                {
                    property.SetValue(clone, value);
                    continue;
                }

                property.SetValue(clone, clonable.Clone());
            }

            return clone;
        }
    }
}
