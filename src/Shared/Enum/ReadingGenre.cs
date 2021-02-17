using System.ComponentModel.DataAnnotations;

namespace VerusDate.Shared.Enum
{
    public enum ReadingGenre
    {
        [Display(Name = "Gêneros de ficção", Description = "A ficção geralmente é uma forma narrativa, em qualquer meio, consistindo em pessoas, eventos ou lugares que são imaginários, em outras palavras, não baseados estritamente na história ou fato.")]
        FictionGenres = 1,

        [Display(Name = "Biografia", Description = "Uma narrativa da vida de uma pessoa; quando o autor também é o assunto principal, esta é uma autobiografia ou memória")]
        Biography = 2,

        [Display(Name = "Histórias em quadrinhos", Description = "Uma revista que apresenta uma história serializada na forma de uma história em quadrinhos, normalmente apresentando as aventuras de um super-herói.")]
        Comics = 3,

        [Display(Name = "Ensaio", Description = "Uma curta composição literária que reflete a perspectiva ou ponto de vista do autor")]
        Essay = 4,

        [Display(Name = "Jornalismo", Description = "Reportagem de notícias e eventos atuais")]
        Journalism = 5,

        [Display(Name = "Memórias", Description = "História factual que enfoca uma relação significativa entre o escritor e uma pessoa, lugar ou objeto; lê como um pequeno romance")]
        Memoir = 6,

        [Display(Name = "Não-ficção narrativa / Narrativa pessoal", Description = "Informações factuais sobre um evento significativo apresentado em um formato que conta uma história")]
        NarrativeNonfictionPersonalNarrative = 7,

        [Display(Name = "Referência", Description = "Como um dicionário, dicionário de sinônimos, enciclopédia, almanaque ou atlas")]
        Reference = 8,

        [Display(Name = "Auto Ajuda", Description = "Informações com o intuito de instruir os leitores na solução de problemas pessoais")]
        SelfHelp = 9,

        [Display(Name = "Artigo Científico", Description = "Relatório de estudo científico, inclusive nas disciplinas sociais, naturais ou outras disciplinas acadêmicas")]
        ScientificArticle = 10,

        [Display(Name = "Livro Didático / Técnico", Description = "Descrição factual confiável e detalhada de uma coisa")]
        Textbook = 11
    }
}