using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace VerusDate.Web.Shared.Field
{
    public partial class FieldText
    {
        [Parameter] public string Value { get; set; }
        [Parameter] public EventCallback<string> ValueChanged { get; set; }
        [Parameter] public int Rows { get; set; } = 0;

        [Parameter] public string CssIcon { get; set; }
        [Parameter] public bool Required { get; set; }

        [Parameter] public EventCallback ButtomClicked { get; set; }
        [Parameter] public object ButtomCssIcon { get; set; }
        [Parameter] public string ButtomTitle { get; set; }

        private string Description => GetDescription();

        protected async Task SetValue(string value)
        {
            if (Disabled) return;

            if (Value != value)
            {
                Value = value;
                await ValueChanged.InvokeAsync(value);
            }
        }

        protected override Dictionary<string, object> GetAttributes(string customStyle)
        {
            var result = base.GetAttributes(customStyle);

            if (Rows > 0)
            {
                result.Add("rows", Rows);
            }

            return result;
        }
    }
}