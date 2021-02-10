using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using VerusDate.Shared.Helper;

namespace VerusDate.Web.Shared
{
    public partial class CustomFieldSelect<TValue, TEnum> where TEnum : struct, Enum, IConvertible
    {
        [Parameter] public TValue SelectedValue { get; set; }
        [Parameter] public EventCallback<TValue> SelectedValueChanged { get; set; }

        [Parameter] public IReadOnlyList<TEnum> SelectedValues { get; set; }
        [Parameter] public EventCallback<IReadOnlyList<TEnum>> SelectedValuesChanged { get; set; }

        [Parameter] public bool DisableHelp { get; set; }
        [Parameter] public string HelpLink { get; set; }

        private modal.ProfileDataHelp<TValue> dataHelp;
        private modal.ProfileDataSelect<TValue, TEnum> dataSelect;

        private async Task SetValue(TValue value)
        {
            SelectedValue = value;
            await SelectedValueChanged.InvokeAsync(SelectedValue);
        }

        private async Task SetValues(IReadOnlyList<TEnum> value)
        {
            SelectedValues = value;
            await SelectedValuesChanged.InvokeAsync(SelectedValues);
        }

        public static Dictionary<string, object> GetAttributes(Expression<Func<TValue>> expression, bool isMultiple = false, bool disabled = false)
        {
            var dic = new Dictionary<string, object>() { { "class", "form-control" } };

            if (isMultiple)
            {
                dic.Add("rows", 7);
            }

            dic.Add("placeholder", AttributeHelper.GetPrompt(expression)); //componente body

            if (disabled)
            {
                dic.Add("disabled", "disabled");
            }

            return dic;
        }

        protected void UpdateDataHelp(Expression<Func<TValue>> For, Type TypeEnum)
        {
            dataHelp.ChangeContent(For, TypeEnum);
            dataHelp.ShowModal();
        }

        protected void UpdateDataSelect(Expression<Func<TValue>> For, Type TypeEnum)
        {
            dataSelect.ChangeContent(For, TypeEnum);
            dataSelect.ShowModal();
        }
    }
}