using Microsoft.AspNetCore.Components;
using System.Linq.Expressions;
using VerusDate.Shared.Helper;
using VerusDate.Web.Core;

namespace VerusDate.Web.Shared
{
    public enum FieldType
    {
        TextEdit,
        TextEditButtom,
        Date,
        MemoEdit,
        Select,
        SelectMultiple
    }

    public class BaseCustomField<TValue, TClass> : ComponenteCore<TClass> where TClass : class
    {
        [Parameter] public FieldType Type { get; set; }
        [Parameter] public object CssIcon { get; set; }
        [Parameter] public bool Disabled { get; set; }
        [Parameter] public Expression<Func<TValue>> For { get; set; }

        public string Label => " " + AttributeHelper.GetName(For);

        protected void PrivateData()
        {
            Toast.ShowWarning("", "Esta informação não será compartilhada no seu perfil e em nenhum tipo de busca dentro da plataforma");
        }
    }
}