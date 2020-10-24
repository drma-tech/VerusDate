using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;
using System.Reflection;

namespace VerusDate.Shared.Helper
{
    public static class AttributeHelper
    {
        public static Dictionary<string, object> GetAttributes(Expression<Func<object>> expression, bool showDescription = false, bool showPrompt = false, bool isMultiple = false,
            bool disabled = false)
        {
            var dic = new Dictionary<string, object>() { { "class", "form-control" } };

            if (isMultiple)
            {
                dic.Add("rows", 6);
            }

            if (showDescription)
            {
                dic.Add("title", GetDescription(expression)); //tooltip
            }

            if (showPrompt)
            {
                dic.Add("placeholder", GetPrompt(expression)); //componente body
            }

            if (disabled)
            {
                dic.Add("disabled", "disabled");
            }

            return dic;
        }

        public static string GetName(Expression<Func<object>> expression)
        {
            if (expression == null) return null;

            return GetDisplayAttribute(expression)?.Name;
        }

        public static string GetNameOf(Expression<Func<object>> expression)
        {
            if (expression == null) return null;

            var body = expression.Body as MemberExpression;
            if (body != null)
            {
                return ((MemberExpression)expression.Body).Member.Name;
            }
            else
            {
                var op = ((UnaryExpression)expression.Body).Operand;
                return ((MemberExpression)op).Member.Name;
            }
        }

        public static string GetDescription(Expression<Func<object>> expression)
        {
            return GetDisplayAttribute(expression)?.Description;
        }

        public static string GetPrompt(Expression<Func<object>> expression)
        {
            return GetDisplayAttribute(expression)?.Prompt;
        }

        private static DisplayAttribute GetDisplayAttribute(Expression<Func<object>> expression)
        {
            var body = expression.Body as MemberExpression;
            if (body != null)
            {
                return ((MemberExpression)expression.Body).Member.GetCustomAttribute(typeof(DisplayAttribute)) as DisplayAttribute;
            }
            else
            {
                var op = ((UnaryExpression)expression.Body).Operand;
                return ((MemberExpression)op).Member.GetCustomAttribute(typeof(DisplayAttribute)) as DisplayAttribute;
            }
        }
    }
}