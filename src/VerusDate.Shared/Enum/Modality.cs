using VerusDate.Shared.Core;

namespace VerusDate.Shared.Enum
{
    public enum Modality
    {
        [Custom(Name = "Matchmaker", Description = "Você está em busca do seu parceiro ideal (durar a vida toda)? Com nosso exclusivo e avançado sistema de compatibilidade, garantimos uma taxa de sucesso maior que qualquer outro sistema/site/app no mundo.")]
        Matchmaker = 1,

        [Custom(Name = "Relationship Analysis", Description = "Você já está em um relacionamento sério, noivado ou casamento e quer saber o quanto vocês são compatíveis? Quais os pontos fracos que precisam trabalhar para fortalecer a relação? Saiba tudo disso e muito mais.")]
        RelationshipAnalysis = 2
    }
}