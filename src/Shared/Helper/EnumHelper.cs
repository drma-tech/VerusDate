using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace VerusDate.Shared.Helper
{
    public class EnumList
    {
        public int Value { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }

    public static class EnumHelper
    {
        public static T[] GetArray<T>() where T : struct, IConvertible
        {
            return System.Enum.GetValues(typeof(T)).Cast<T>().ToArray();
        }

        public static List<EnumList> GetList(Type enumType)
        {
            if (enumType == null) throw new ArgumentNullException(nameof(enumType));

            if (!enumType.IsEnum) throw new ArgumentException("Type must be an enum type.");

            var items = System.Enum.GetValues(enumType);

            var output = new List<EnumList>();
            foreach (object val in items)
            {
                output.Add(new EnumList()
                {
                    Value = (int)val,
                    Name = GetName((System.Enum)val),
                    Description = GetDescription((System.Enum)val),
                });
            }

            return output;
        }

        public static string GetName(this System.Enum value)
        {
            if (value == null) return null;

            var fieldInfo = value.GetType().GetField(value.ToString());

            if (fieldInfo == null) return null;

            return ((DisplayAttribute[])fieldInfo.GetCustomAttributes(typeof(DisplayAttribute), false))[0].Name;
        }

        public static string GetDescription(this System.Enum value)
        {
            if (value == null) return null;

            var fieldInfo = value.GetType().GetField(value.ToString());

            if (fieldInfo == null) return null;

            return ((DisplayAttribute[])fieldInfo.GetCustomAttributes(typeof(DisplayAttribute), false))[0].Description;
        }
    }
}