using VerusDate.Shared.Core;

namespace VerusDate.Shared.Enum
{
    public enum Region
    {
        [Custom(Name = "Toda a Cidade")]
        City = 1,

        [Custom(Name = "Todo o Estado")]
        State = 2,

        [Custom(Name = "Todo o País")]
        Country = 3,

        [Custom(Name = "Qualquer lugar do mundo")]
        World = 4
    }
}