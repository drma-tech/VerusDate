using System;

namespace VerusDate.Shared.Core
{
    /// <summary>
    /// Sensitive data will only be displayed after the match
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class SensitiveDataAttribute : Attribute
    {
    }
}