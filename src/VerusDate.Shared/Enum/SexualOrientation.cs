using VerusDate.Shared.Core;

namespace VerusDate.Shared.Enum
{
    /// <summary>
    /// https://www.india.com/lifestyle/there-are-at-least-15-types-of-sexual-orientations-how-many-do-you-know-2205005/
    /// https://www.healthline.com/health/different-types-of-sexuality
    /// </summary>
    public enum SexualOrientation
    {
        [Custom(Name = "Heterosexual_Name", Description = "Heterosexual_Description", ResourceType = typeof(Resources.Enum.SexualOrientation))]
        Heterosexual = 1,

        [Custom(Name = "Homosexual_Name", Description = "Homosexual_Description", ResourceType = typeof(Resources.Enum.SexualOrientation))]
        Homosexual = 2,

        [Custom(Name = "Bisexual_Name", Description = "Bisexual_Description", ResourceType = typeof(Resources.Enum.SexualOrientation))]
        Bisexual = 3,

        [Custom(Name = "Pansexual_Name", Description = "Pansexual_Description", ResourceType = typeof(Resources.Enum.SexualOrientation))]
        Pansexual = 4,

        [Custom(Name = "Asexual_Name", Description = "Asexual_Description", ResourceType = typeof(Resources.Enum.SexualOrientation))]
        Asexual = 5,

        [Custom(Name = "Demisexual_Name", Description = "Demisexual_Description", ResourceType = typeof(Resources.Enum.SexualOrientation))]
        Demisexual = 6,

        [Custom(Name = "Sapiosexual_Name", Description = "Sapiosexual_Description", ResourceType = typeof(Resources.Enum.SexualOrientation))]
        Sapiosexual = 7,

        [Custom(Name = "Polysexual_Name", Description = "Polysexual_Description", ResourceType = typeof(Resources.Enum.SexualOrientation))]
        Polysexual = 8,

        [Custom(Name = "Graysexual_Name", Description = "Graysexual_Description", ResourceType = typeof(Resources.Enum.SexualOrientation))]
        Graysexual = 9,

        [Custom(Name = "Androgynsexual_Name", Description = "Androgynsexual_Description", ResourceType = typeof(Resources.Enum.SexualOrientation))]
        Androgynsexual = 10,

        [Custom(Name = "Androsexual_Name", Description = "Androsexual_Description", ResourceType = typeof(Resources.Enum.SexualOrientation))]
        Androsexual = 11,

        [Custom(Name = "Gynosexual_Name", Description = "Gynosexual_Description", ResourceType = typeof(Resources.Enum.SexualOrientation))]
        Gynosexual = 12,

        [Custom(Name = "Pomosexual_Name", Description = "Pomosexual_Description", ResourceType = typeof(Resources.Enum.SexualOrientation))]
        Pomosexual = 13,

        [Custom(Name = "Skoliosexual_Name", Description = "Skoliosexual_Description", ResourceType = typeof(Resources.Enum.SexualOrientation))]
        Skoliosexual = 14,

        [Custom(Name = "Autosexual_Name", Description = "Autosexual_Description", ResourceType = typeof(Resources.Enum.SexualOrientation))]
        Autosexual = 15,
    }

    public enum SexualOrientationOld
    {
        [Custom(Name = "Heteressexual", Description = "A pessoa que gosta do sexo oposto")]
        Heteressexual = 1,

        [Custom(Name = "Homossexual", Description = "A pessoa que gosta do mesmo sexo (gays, lésbicas, etc)")]
        Homossexual = 2,

        [Custom(Name = "Bissexual", Description = "A pessoa que gosta de ambos os sexos")]
        Bissexual = 3,

        [Custom(Name = "Assexual", Description = "A pessoa que não sente atração por sexo algum")]
        Assexual = 4,

        [Custom(Name = "Panssexual", Description = "A pessoa que sente atração por alguém (independente do sexo e gênero)")]
        Panssexual = 5,

        [Custom(Name = "Polissexual", Description = "A pessoa que sente atração por vários generos diferentes - sem nenhum específico")]
        Polissexual = 6,

        [Custom(Name = "Demissexual", Description = "A pessoa que sente atração por outra pessoa apenas quando existe um laço ou vínculo muito forte")]
        Demissexual = 7,

        [Custom(Name = "Sapiossexual", Description = "A pessoa que sente atração pela inteligencia de alguém (independente da orientação sexual e identidade de genero)")]
        Sapiossexual = 8,

        //menossexual = atração por mulher menstruada (contrario = antiaemosexaul)
        //graysexual = zona cinzenta entre a sexualidade e assexualidade (atração sexual esporádica)
        //quoisexual = a pessoa não entende oq é atração sexual. ou se entende, não se aplica a ela
        //pomosexual = prefere ou não consegue definir a orientação sexual
        //Solossexual = não sente atração por terceiros, independente de sexo e genero (apenas por si mesmo)
        //Lithsexual = sente atração por outra pessoa, mas não a necessidade de ser correspondido
        [Custom(Name = "Outra", Description = "menossexual, graysexual, quoisexual, pomosexual, solossexual, lithsexual, etc")]
        Other = 99
    }
}