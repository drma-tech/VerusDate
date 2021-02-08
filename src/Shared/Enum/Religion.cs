using System.ComponentModel.DataAnnotations;

namespace VerusDate.Shared.Enum
{
    public enum Religion
    {
        //2.4 bilhões
        [Display(Name = "Cristianismo", Description = "É uma religião abraâmica monoteísta centrada na vida e nos ensinamentos de Jesus de Nazaré, tais como são apresentados no Novo Testamento. A fé cristã acredita essencialmente em Jesus como o Cristo, Filho de Deus, Salvador e Senhor.")]
        Christianity = 11,

        //1.8 bilhões
        [Display(Name = "Islamismo", Description = "É uma religião abraâmica monoteísta articulada pelo Alcorão, um texto considerado pelos seus seguidores como a palavra literal de Deus, e pelos ensinamentos e exemplos normativos de Maomé, considerado pelos fiéis como o último profeta de Deus.")]
        Islam = 12,

        //1.1 bilhões
        [Display(Name = "Sem religião", Description = "Irreligião (também referida como incredulidade, ausência de religião ou pessoas sem religião) é a ausência, indiferença ou não prática de uma religião. (Agnósticos, Ateus, Deístas)")]
        Irreligion = 13,

        //1.2 bilhões
        [Display(Name = "Hinduísmo", Description = "O hinduísmo engloba o bramanismo, isto é, a crença na 'Alma Universal', Brâman; num sentido mais específico, o termo se refere ao mundo cultural e religioso, ordenado por castas, da Índia pós-budista.")]
        Hinduism = 14,

        //0.5 bilhões
        [Display(Name = "Budismo", Description = "Filosofia ou religião não teísta que surgiu originalmente na Índia por volta do século VI A.C. e abrange diversas tradições, crenças e práticas baseadas nos ensinamentos, o Darma, de Siddhartha Gautama, intitulado de Buddha.")]
        Buddhism = 15,

        //0.4 bilhões
        [Display(Name = "Religião étnica", Description = "Religião étnica ou religião indígena é um termo que pode incluir religiões civis oficialmente sancionadas e organizadas com um clero organizado, mas que são caracterizadas pelo fato de que seus adeptos em geral são definidos por uma etnia em comum e a conversão, essencialmente, equivale a uma assimilação cultural para o povo em questão.")]
        Folk_Religion = 16,

        [Display(Name = "Outra religião ", Description = "Xintoísmo, Sikhismo, Espiritismo, Judaísmo, Wicca e Neopaganismo, etc.")]
        Other = 255
    }
}