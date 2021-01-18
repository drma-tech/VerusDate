using Microsoft.AspNetCore.Components;
using System;
using System.Linq.Expressions;
using VerusDate.Shared.Helper;

namespace VerusDate.Web.Shared
{
    public enum FieldType
    {
        TextEdit,
        TextEditButtom,
        MemoEdit,
        Select,
        SelectMultiple
    }

    public class BaseCustomField<TValue> : ComponentBase
    {
        [Parameter] public FieldType Type { get; set; }
        [Parameter] public object CssIcon { get; set; }
        [Parameter] public bool Disabled { get; set; }
        [Parameter] public Expression<Func<TValue>> For { get; set; }

        public string Label => " " + AttributeHelper.GetName(For);
    }
}