using VerusDate.Shared.Core;

namespace VerusDate.Shared.Enum
{
    /// <summary>
    /// https://www.masterclass.com/articles/gender-identity-guide
    /// </summary>
    public enum GenderIdentity
    {
        [Custom(Name = "Agender_Name", Description = "Agender_Description", ResourceType = typeof(Resources.Enum.GenderIdentity))]
        Agender = 1,

        [Custom(Name = "Androgyne_Name", Description = "Androgyne_Description", ResourceType = typeof(Resources.Enum.GenderIdentity))]
        Androgyne = 2,

        [Custom(Name = "Bigender_Name", Description = "Bigender_Description", ResourceType = typeof(Resources.Enum.GenderIdentity))]
        Bigender = 3,

        [Custom(Name = "Cisgender_Name", Description = "Cisgender_Description", ResourceType = typeof(Resources.Enum.GenderIdentity))]
        Cisgender = 4,

        [Custom(Name = "Genderfluid_Name", Description = "Genderfluid_Description", ResourceType = typeof(Resources.Enum.GenderIdentity))]
        Genderfluid = 5,

        [Custom(Name = "GenderNonconforming_Name", Description = "GenderNonconforming_Description", ResourceType = typeof(Resources.Enum.GenderIdentity))]
        GenderNonconforming = 6,

        [Custom(Name = "Genderqueer_Name", Description = "Genderqueer_Description", ResourceType = typeof(Resources.Enum.GenderIdentity))]
        Genderqueer = 7,

        [Custom(Name = "Intergender_Name", Description = "Intergender_Description", ResourceType = typeof(Resources.Enum.GenderIdentity))]
        Intergender = 8,

        [Custom(Name = "Intersex_Name", Description = "Intersex_Description", ResourceType = typeof(Resources.Enum.GenderIdentity))]
        Intersex = 9,

        [Custom(Name = "Omnigender_Name", Description = "Omnigender_Description", ResourceType = typeof(Resources.Enum.GenderIdentity))]
        Omnigender = 10,

        [Custom(Name = "NonBinary_Name", Description = "NonBinary_Description", ResourceType = typeof(Resources.Enum.GenderIdentity))]
        NonBinary = 11,

        [Custom(Name = "Questioning_Name", Description = "Questioning_Description", ResourceType = typeof(Resources.Enum.GenderIdentity))]
        Questioning = 12,

        [Custom(Name = "Transgender_Name", Description = "Transgender_Description", ResourceType = typeof(Resources.Enum.GenderIdentity))]
        Transgender = 13,

        [Custom(Name = "Transsexual_Name", Description = "Transsexual_Description", ResourceType = typeof(Resources.Enum.GenderIdentity))]
        Transsexual = 14,

        [Custom(Name = "TwoSpirit_Name", Description = "TwoSpirit_Description", ResourceType = typeof(Resources.Enum.GenderIdentity))]
        TwoSpirit = 15,
    }

    public enum GenderIdentityOld
    {
        [Custom(Group = "Binário", Name = "Cisgênero", Description = "Cisgênero é o indivíduo que se identifica com o sexo biológico com o qual nasceu, também conhecido como 'cis'")]
        Cisgender = 1,

        [Custom(Group = "Não-Binário", Name = "Transgênero", Description = "O (a) transexual pode ser homem ou mulher que se identifica com o sexo biológico oposto, também conhecido como 'trans'")]
        Transgender = 2,

        [Custom(Group = "Não-Binário", Name = "Transexual", Description = "Semelhante ao transgênero, porém recorre ao uso de cirurgia para troca de sexo")]
        Transexuais = 3,

        [Custom(Group = "Não-Binário", Name = "Travesti", Description = "Semelhante ao transgênero, e recorre a cirurgias parciais de troca de sexo. ex: prótese de seios")]
        Travestis = 4,

        [Custom(Group = "Não-Binário", Name = "Intergênero", Description = "não se identifica nem como homem nem como mulher")]
        Intergenero = 5,

        [Custom(Group = "Não-Binário", Name = "Andrógeno", Description = "se identifica tanto como homem quanto mulher")]
        Androgenos = 6,

        [Custom(Group = "Não-Binário", Name = "Intersexual", Description = "genitalia indefinida ou com ambos genitais")]
        Intersexual = 7,

        //bigeneros = que tem duas identidades de genero
        //demigenero = conexão parcial com um determinado genêro
        //genero fluido = identificação varia atraves do tempo --GENDER FLUID
        //agenero = não se identifica como nenhum genero
        [Custom(Group = "Não-Binário", Name = "Outro", Description = "bigêneros, demigênero, genero fluído, agênero")]
        Other = 99
    }
}