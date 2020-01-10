using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Resources;

namespace Workflow.Base.Infrastructure.Utilities
{
    public static class EnumExtensions
    {
        public static T ToEnum<T>(this string value)
        {
            return (T)Enum.Parse(typeof(T), value);
        }

        public static T? ToEnumOrNull<T>(this string value) where T : struct
        {
            if (value == null)
            {
                return null;
            }

            return (T)Enum.Parse(typeof(T), value);
        }

        public static bool Contains<T>(string value)
        {
            if (typeof(T).BaseType != typeof(Enum))
            {
                throw new InvalidCastException();
            }

            return Enum.GetValues(typeof(T)).Cast<T>().Select(v => v.ToString()).Contains(value);
        }

        public static IList<T> ToList<T>()
        {
            if (typeof(T).BaseType != typeof(Enum))
            {
                throw new InvalidCastException();
            }

            return Enum.GetValues(typeof(T)).Cast<T>().ToList();
        }

        public static string DisplayName<T>(T value)
        {
            var fieldInfo = value.GetType().GetField(value.ToString());

            if (fieldInfo == null)
            {
                return null;
            }

            var attributes = (DisplayAttribute[])fieldInfo.GetCustomAttributes(typeof(DisplayAttribute), false);

            if (attributes.Length > 0)
            {
                return attributes.First().Name;
            }

            return value.ToString();
        }
    }
}
