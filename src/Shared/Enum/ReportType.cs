using System.ComponentModel.DataAnnotations;

namespace VerusDate.Shared.Enum
{
    public enum ReportType
    {
        [Display(Name = "Conteúdo Inapropriado", Description = "Conteúdo Inapropriado pode incluir: pornografia; violência; comportamento extremista; conteúdo ofensivo, como texto, fotos ou vídeos nos perfis; Conteúdo, texto ou fotos pertencentes a outra pessoa;")]
        InappropriateContent = 2,

        [Display(Name = "Comportamento Inapropriado", Description = "Comportamento Inapropriado pode incluir: Bullying online; Comentários inapropriados (racial ou sexualmente orientados); Envio de material inapropriado (adulto / ilegal / anti-social);")]
        InappropriateBehaviour = 3,

        [Display(Name = "Spam / Scam / Fake", Description = "Perfil com comportamento suspeito ou com intenções que violem nossos termos de uso. Exemplo: Solicitam informações pessoais sensíveis; Promovem produtos, serviços ou perfis de outras redes sociais; Solicitam dinheiro ou outros favores;")]
        SpamOrScam = 4,

        [Display(Name = "Menor de Idade", Description = "Este perfil parece pertencer a alguém com menos de 18 anos (idade pode variar de acordo com as leis de cada país)")]
        Under18 = 5,

        [Display(Name = "Não interessado", Description = "Apenas não me interessei por este perfil")]
        NotInterested = 99
    }
}