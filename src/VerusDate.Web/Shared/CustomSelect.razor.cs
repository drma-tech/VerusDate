using Microsoft.AspNetCore.Components;
using System;

namespace VerusDate.Web.Shared
{
    public partial class CustomSelect<TValue, TEnum> where TEnum : struct, Enum, IConvertible
    {
        [Parameter] public TValue SelectedValue { get; set; }
        [Parameter] public EventCallback<TValue> SelectedValueChanged { get; set; }
        [Parameter] public bool ShowGroup { get; set; }
    }
}