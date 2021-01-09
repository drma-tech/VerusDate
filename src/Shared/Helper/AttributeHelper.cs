using System;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;
using System.Reflection;

namespace VerusDate.Shared.Helper
{
    public static class AttributeHelper
    {
        public static string GetDescription<T>(Expression<Func<T>> expression)
        {
            return GetDisplayAttribute(expression)?.Description;
        }

        public static string GetName<T>(Expression<Func<T>> expression)
        {
            if (expression == null) return null;

            return GetDisplayAttribute(expression)?.Name;
        }

        public static string GetNameOf<T>(Expression<Func<T>> expression)
        {
            if (expression == null) return null;

            if (expression.Body is MemberExpression body)
            {
                return body.Member.Name;
            }
            else
            {
                var op = ((UnaryExpression)expression.Body).Operand;
                return ((MemberExpression)op).Member.Name;
            }
        }

        public static string GetPrompt<T>(Expression<Func<T>> expression)
        {
            return GetDisplayAttribute(expression)?.Prompt;
        }

        private static DisplayAttribute GetDisplayAttribute<T>(Expression<Func<T>> expression)
        {
            if (expression.Body is MemberExpression body)
            {
                return body.Member.GetCustomAttribute(typeof(DisplayAttribute)) as DisplayAttribute;
            }
            else
            {
                var op = ((UnaryExpression)expression.Body).Operand;
                return ((MemberExpression)op).Member.GetCustomAttribute(typeof(DisplayAttribute)) as DisplayAttribute;
            }
        }
    }
}