using Blazorise;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using VerusDate.Shared.Helper;

namespace VerusDate.Web.Shared
{
    public enum LabelSize
    {
        Short,
        Normal,
        Big
    }

    public partial class CustomFieldSelect<TValue, TEnum> where TEnum : struct, Enum, IConvertible
    {
        #region CustomSelect

        [Parameter] public TValue SelectedValue { get; set; }
        [Parameter] public EventCallback<TValue> SelectedValueChanged { get; set; }

        #endregion CustomSelect

        #region CustomSelectMultiple

        [Parameter] public IReadOnlyList<TEnum> SelectedValues { get; set; }
        [Parameter] public EventCallback<IReadOnlyList<TEnum>> SelectedValuesChanged { get; set; }

        #endregion CustomSelectMultiple

        [Parameter] public bool ShowGroup { get; set; } = false;
        [Parameter] public bool ShowSwitch { get; set; } = false;
        [Parameter] public bool ShowHelper { get; set; } = true;
        [Parameter] public string HelpLink { get; set; }
        [Parameter] public bool Required { get; set; } = false;
        [Parameter] public LabelSize LabelSize { get; set; } = LabelSize.Normal;

        private modal.ProfileDataHelp<TValue> dataHelp;
        private modal.ProfileDataSelect<TValue, TEnum> dataSelect;

        private async Task SetValues(IReadOnlyList<TEnum> value)
        {
            SelectedValues = value;
            await SelectedValuesChanged.InvokeAsync(SelectedValues);
        }

        public static Dictionary<string, object> GetAttributes(Expression<Func<TValue>> expression, bool isMultiple = false, bool disabled = false, string customStyle = "")
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
                dic.Add("style", "background-color: #e9ecef; opacity: 1;" + customStyle);
            }
            else
            {
                if (!string.IsNullOrEmpty(customStyle))
                {
                    dic.Add("style", customStyle);
                }
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

        private IFluentColumn GetLabelSize()
        {
            return LabelSize switch
            {
                LabelSize.Short => ColumnSize.IsFull.OnWidescreen.Is3.OnFullHD,
                LabelSize.Normal => ColumnSize.IsFull.OnWidescreen.Is4.OnFullHD,
                LabelSize.Big => ColumnSize.IsFull.OnWidescreen.Is5.OnFullHD,
                _ => ColumnSize.IsFull.OnWidescreen.Is4.OnFullHD,
            };
        }

        private IFluentColumn GetBodySize()
        {
            return LabelSize switch
            {
                LabelSize.Short => ColumnSize.IsFull.OnWidescreen.Is9.OnFullHD,
                LabelSize.Normal => ColumnSize.IsFull.OnWidescreen.Is8.OnFullHD,
                LabelSize.Big => ColumnSize.IsFull.OnWidescreen.Is7.OnFullHD,
                _ => ColumnSize.IsFull.OnWidescreen.Is8.OnFullHD,
            };
        }
    }
}