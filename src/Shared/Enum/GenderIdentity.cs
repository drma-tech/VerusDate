using System.ComponentModel.DataAnnotations;

namespace VerusDate.Shared.Enum
{
    public enum GenderIdentity
    {
        [Display(GroupName = "Binário", Name = "Cisgênero", Description = "Cisgênero é o indivíduo que se identifica com o sexo biológico com o qual nasceu, também conhecido como 'cis'")]
        Cisgender = 1,

        [Display(GroupName = "Não-Binário", Name = "Transgênero", Description = "O (a) transexual pode ser homem ou mulher que se identifica com o sexo biológico oposto, também conhecido como 'trans'")]
        Transgender = 2,

        [Display(GroupName = "Não-Binário", Name = "Transexual", Description = "Semelhante ao transgênero, porém recorre ao uso de cirurgia para troca de sexo")]
        Transexuais = 3,

        [Display(GroupName = "Não-Binário", Name = "Travesti", Description = "Semelhante ao transgênero, e recorre a cirurgias parciais de troca de sexo. ex: prótese de seios")]
        Travestis = 4,

        [Display(GroupName = "Não-Binário", Name = "Intergênero", Description = "não se identifica nem como homem nem como mulher")]
        Intergenero = 5,

        [Display(GroupName = "Não-Binário", Name = "Andrógeno", Description = "se identifica tanto como homem quanto mulher")]
        Androgenos = 6,

        [Display(GroupName = "Não-Binário", Name = "Intersexual", Description = "genitalia indefinida ou com ambos genitais")]
        Intersexual = 7,

        //bigeneros = que tem duas identidades de genero
        //demigenero = conexão parcial com um determinado genêro
        //genero fluido = identificação varia atraves do tempo --GENDER FLUID
        //agenero = não se identifica como nenhum genero
        [Display(GroupName = "Não-Binário", Name = "Outro", Description = "bigêneros, demigênero, genero fluído, agênero")]
        Other = 99
    }
}