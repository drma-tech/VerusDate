using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using VerusDate.Shared.Helper;

namespace VerusDate.Web.Shared
{
    public partial class CustomField
    {
        [Parameter] public string Value { get; set; }
        [Parameter] public EventCallback<string> ValueChanged { get; set; }
        [Parameter] public EventCallback ButtomClicked { get; set; }
        [Parameter] public object ButtomCssIcon { get; set; }
        [Parameter] public string ButtomTitle { get; set; }
        [Parameter] public bool Required { get; set; }

        private async Task SetValue(string value)
        {
            if (Value != value)
            {
                Value = value;
                await ValueChanged.InvokeAsync(value);
            }
        }

        [Parameter] public int Rows { get; set; }

        public static Dictionary<string, object> GetAttributes(Expression<Func<string>> expression, bool isMultiple = false, bool disabled = false)
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
    }
}