using VerusDate.Shared.Core;

namespace VerusDate.Shared.Enum
{
    public enum Change
    {
        [Custom(Name = "Estou disposto(a) a me mudar", Description = "Caso esteja disposto(a) a se mudar se houver necessidade (apenas dentro da região selecionada)")]
        OpenToChange = 1,

        [Custom(Name = "Não estou disposto(a) a me mudar", Description = "Caso não esteja com disposição para mudanças. Mesmo assim, ainda terá sugestões de perfis fora da sua região selecionada (caso essa pessoa esteja disposta a se mudar para a sua região)")]
        NoChange = 2,
    }
}