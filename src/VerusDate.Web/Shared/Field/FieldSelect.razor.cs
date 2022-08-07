using Microsoft.AspNetCore.Components;
using System.Linq.Expressions;
using VerusDate.Shared.Helper;
using VerusDate.Shared.Core;

namespace VerusDate.Web.Shared.Field
{
    public partial class FieldSelect<TValue, TEnum> where TEnum : struct, Enum, IConvertible
    {
        [Parameter] public string CssIcon { get; set; }
        [Parameter] public bool Required { get; set; } = false;
        [Parameter] public bool Multiple { get; set; } = false;
        [Parameter] public bool ShowGroup { get; set; } = false;
        [Parameter] public bool ShowSwitch { get; set; } = false;
        [Parameter] public bool ShowHelper { get; set; } = true;
        [Parameter] public string HelpLink { get; set; }

        [Parameter] public EventCallback ButtomClicked { get; set; }
        [Parameter] public object ButtomCssIcon { get; set; }
        [Parameter] public string ButtomTitle { get; set; }

        [Parameter] public TValue SelectedValue { get; set; }
        [Parameter] public EventCallback<TValue> SelectedValueChanged { get; set; }

        [Parameter] public IReadOnlyList<TEnum> SelectedValues { get; set; }
        [Parameter] public EventCallback<IReadOnlyList<TEnum>> SelectedValuesChanged { get; set; }

        private string Description => For.GetCustomAttribute().Description;

        private modal.ProfileDataHelp<TValue, TEnum> dataHelp;
        private modal.ProfileDataSelect<TValue, TEnum> dataSelect;

        [Parameter] public Func<EnumObject, object> Order { get; set; } = o => o.Value;

        protected async Task SetValue(TValue value)
        {
            if (Disabled) return;

            if (!SelectedValue.Equals(value))
            {
                SelectedValue = value;
                await SelectedValueChanged.InvokeAsync(value);
            }
        }

        protected void UpdateDataHelp(Expression<Func<TValue>> For)
        {
            dataHelp.ChangeContent(For);
            dataHelp.ShowModal();
        }

        protected void UpdateDataSelect(Expression<Func<TValue>> For)
        {
            dataSelect.ChangeContent(For);
            dataSelect.ShowModal();
        }
    }
}