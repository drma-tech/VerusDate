using System.ComponentModel.DataAnnotations;

namespace VerusDate.Shared.Enum
{
    public enum ReportType
    {
        [Display(Name = "Desfazer o match", Description = "Apenas perdi o interesse por este perfil e quero desfazer o match")]
        NotInterested = 1,

        [Display(GroupName = "Moderado|Poderá ser exibido publicamente no perfil", Name = "Informação Errada", Description = "Denunciar algum informação errada no perfil (isso inclui informações das categorias: Básico, Bio e Lifestyle)")]
        Field = 2,

        [Display(GroupName = "Moderado|Poderá ser exibido publicamente no perfil", Name = "Curving", Description = "O 'curver' é aquela pessoa que te deixa em banho-maria; manda mensagens esporádicas, mas nunca está disposto a te ver, não convida pra sair e nem aceita convite. E, quando finalmente vocês combinam de sair, desmarca o encontro de última hora.")]
        Curving = 10,

        [Display(GroupName = "Moderado|Poderá ser exibido publicamente no perfil", Name = "Ghosting", Description = "O ghosting acontece quando a outra pessoa começa a ignorar, evitar, e também deixa de responder mensagens, não atende mais ligações e, sem aviso, desaparece sem apresentar motivos.")]
        Ghosting = 11,

        [Display(GroupName = "Moderado|Poderá ser exibido publicamente no perfil", Name = "Obligaswiping", Description = "É o que fazem essas pessoas que criam perfis em aplicativos de relacionamentos, mas, conscientemente ou não, não pretendem se encontrar e/ou se relacionar com alguém (geralmente entram para passar o tempo, aumentar o ego, etc);")]
        Obligaswiping = 12,

        [Display(GroupName = "Grave|Poderá ser banido da plataforma", Name = "Menor de Idade", Description = "Este perfil parece pertencer a alguém com menos de 18 anos (idade pode variar de acordo com as leis de cada país)")]
        Under18 = 20,

        [Display(GroupName = "Grave|Poderá ser banido da plataforma", Name = "Conteúdo Inapropriado", Description = "Conteúdo Inapropriado pode incluir: pornografia; violência; comportamento extremista; conteúdo ofensivo, como texto, fotos ou vídeos nos perfis; Conteúdo, texto ou fotos pertencentes a outra pessoa;")]
        InappropriateContent = 21,

        [Display(GroupName = "Grave|Poderá ser banido da plataforma", Name = "Comportamento Inapropriado", Description = "Comportamento Inapropriado pode incluir: Bullying online; Comentários inapropriados (racial ou sexualmente orientados); Envio de material inapropriado (adulto / ilegal / anti-social);")]
        InappropriateBehaviour = 22,

        [Display(GroupName = "Grave|Poderá ser banido da plataforma", Name = "Spam / Scam / Fake / Catfishing", Description = "Perfil com comportamento suspeito ou com intenções que violem nossos termos de uso. Exemplo: Solicitam informações pessoais sensíveis; Promovem produtos, serviços ou perfis de outras redes sociais; Solicitam dinheiro ou outros favores;")]
        SpamScamFakeCatfishing = 23
    }
}