using System.ComponentModel.DataAnnotations;

namespace VerusDate.Shared.Enum
{
    public enum SexualOrientation
    {
        [Display(Name = "Heteressexual", Description = "A pessoa que gosta do sexo oposto")]
        Heteressexual = 1,

        [Display(Name = "Homossexual", Description = "A pessoa que gosta do mesmo sexo (gays, lésbicas, etc)")]
        Homossexual = 2,

        [Display(Name = "Bissexual", Description = "A pessoa que gosta de ambos os sexos")]
        Bissexual = 3,

        [Display(Name = "Assexual", Description = "A pessoa que não sente atração por sexo algum")]
        Assexual = 4,

        [Display(Name = "Panssexual", Description = "A pessoa que sente atração por alguém (independente do sexo e gênero)")]
        Panssexual = 5,

        [Display(Name = "Polissexual", Description = "A pessoa que sente atração por vários generos diferentes - sem nenhum específico")]
        Polissexual = 6,

        [Display(Name = "Demissexual", Description = "A pessoa que sente atração por outra pessoa apenas quando existe um laço ou vínculo muito forte")]
        Demissexual = 7,

        [Display(Name = "Sapiossexual", Description = "A pessoa que sente atração pela inteligencia de alguém (independente da orientação sexual e identidade de genero)")]
        Sapiossexual = 8,

        //menossexual = atração por mulher menstruada (contrario = antiaemosexaul)
        //graysexual = zona cinzenta entre a sexualidade e assexualidade (atração sexual esporádica)
        //quoisexual = a pessoa não entende oq é atração sexual. ou se entende, não se aplica a ela
        //pomosexual = prefere ou não consegue definir a orientação sexual
        //Solossexual = não sente atração por terceiros, independente de sexo e genero (apenas por si mesmo)
        //Lithsexual = sente atração por outra pessoa, mas não a necessidade de ser correspondido
        [Display(Name = "Outra", Description = "menossexual, graysexual, quoisexual, pomosexual, solossexual, lithsexual, etc")]
        Other = 255
    }
}