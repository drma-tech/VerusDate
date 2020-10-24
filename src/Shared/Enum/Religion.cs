using System.ComponentModel.DataAnnotations;

namespace VerusDate.Shared.Enum
{
    public enum Religion
    {
        [Display(Name = "Cristianismo", Description = "Principais países: Vaticano, România, Samoa")] //2.3 billion
        Christianity = 11,

        [Display(Name = "Islamismo", Description = "Principais países: Maldivas, Mauritânia, Arábia Saudita e Turquia")] //1.9 billion
        Islam = 12,

        [Display(Name = "Ateísmo / Agnosticismo", Description = "Principais países: República Tcheca, Japão, Estônia e Dinamarca")] //1.1 billion
        Atheism_Agnosticism = 13,

        [Display(Name = "Hinduísmo", Description = "Principais países: Nepal e Índia")] //1.1 billion
        Hinduism = 14,

        [Display(Name = "Budismo", Description = "Principais países: Camboja, Tibete e Tailândia")] //506 million
        Buddhism = 15,

        [Display(Name = "Religião Tradicional Chinesa", Description = "Principais países: China")] //394 million
        Chinese = 16,

        [Display(Name = "Religiões Indígenas Primais", Description = "Principais países: Haiti, Guiné-Bissau e Camarões")] //300 million
        Folk_Religion = 17,

        [Display(Name = "Africano tradicional", Description = "Principal continente: África")] //100 million
        Traditional_African = 18,

        [Display(Name = "Sikhismo", Description = "Principais países: Índia, Reino Unido e Canadá")] //23 million
        Sikhism = 19,

        [Display(Name = "Juche", Description = "Principais países: Coreia do Norte")] //10 million
        Juche = 20,

        [Display(Name = "Espiritismo", Description = "Principais países: Cuba, Jamaica, Brasil e Suriname")] //15 million
        Spiritism = 21,

        [Display(Name = "Judaísmo", Description = "Principais países: Israel, Palestina, Mônaco e EUA")] //14 million
        Judaism = 22,

        [Display(Name = "Outro", Description = "")]
        Other = 255
    }
}