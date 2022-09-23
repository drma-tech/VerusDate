using System;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;
using System.Reflection;
using System.Resources;
using VerusDate.Shared.Core;

namespace VerusDate.Shared.Core
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
    public class CustomAttribute : Attribute
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Group { get; set; }
        public string Prompt { get; set; }
        public string FieldInfo { get; set; }

        /// <summary>
        /// format: Title 1|Description 1|Title 2|Description 2
        /// </summary>
        public string Tips { get; set; }

        /// <summary>
        /// Translations resource file
        /// </summary>
        public Type ResourceType { get; set; }
    }

    public static class CustomAttributeHelper
    {
        public static string GetName(this System.Enum value, bool translate = true)
        {
            return value.GetCustomAttribute(translate)?.Name;
        }

        public static CustomAttribute GetCustomAttribute(this System.Enum value, bool translate = true)
        {
            var fieldInfo = value.GetType().GetField(value.ToString());

            if (fieldInfo == null) return default;

            return fieldInfo.GetCustomAttribute(translate);
        }

        public static CustomAttribute GetCustomAttribute<T>(this Expression<Func<T>> expression, bool translate = true)
        {
            if (expression == null) return null;

            if (expression.Body is MemberExpression body)
            {
                return body.Member.GetCustomAttribute(translate);
            }
            else
            {
                var op = ((UnaryExpression)expression.Body).Operand;
                return ((MemberExpression)op).Member.GetCustomAttribute(translate);
            }
        }

        public static CustomAttribute GetCustomAttribute(this MemberInfo mi, bool translate = true)
        {
            if (mi.GetCustomAttribute(typeof(CustomAttribute)) is not CustomAttribute attr) throw new ValidationException("attr null");

            if (translate && attr.ResourceType != null) //translations
            {
                var rm = new ResourceManager(attr.ResourceType.FullName ?? "", attr.ResourceType.Assembly);

                if (!string.IsNullOrEmpty(attr.Name)) attr.Name = rm.GetString(attr.Name) ?? attr.Name + " (incomplete translation)";
                if (!string.IsNullOrEmpty(attr.Description)) attr.Description = rm.GetString(attr.Description) ?? attr.Description + " (incomplete translation)";
                if (!string.IsNullOrEmpty(attr.Group)) attr.Group = rm.GetString(attr.Group);
                if (!string.IsNullOrEmpty(attr.Prompt)) attr.Prompt = rm.GetString(attr.Prompt).Replace(@"\n", Environment.NewLine);
                if (!string.IsNullOrEmpty(attr.FieldInfo)) attr.FieldInfo = rm.GetString(attr.FieldInfo)?.Replace(@"\n", Environment.NewLine) ?? attr.FieldInfo.Replace(@"\n", Environment.NewLine) + " (incomplete translation)";
                if (!string.IsNullOrEmpty(attr.Tips)) attr.Tips = rm.GetString(attr.Tips) ?? attr.Tips + " (incomplete translation)";
            }

            return attr;
        }
    }
}