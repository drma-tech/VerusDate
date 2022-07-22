using VerusDate.Shared.Core;

namespace VerusDate.Shared.Enum
{
    public enum TicketType
    {
        [Custom(Name = "Erro")]
        Bug = 1,

        [Custom(Name = "Sugestão de Melhoria")]
        FeatureRequest = 2
    }
}