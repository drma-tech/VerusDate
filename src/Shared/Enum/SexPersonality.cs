using System.ComponentModel.DataAnnotations;

namespace VerusDate.Shared.Enum
{
    public enum SexPersonality
    {
        [Display(Name = "Descompressora", Description = "A que vê o sexo como uma forma de descontração, um tubo de escape para momentos em que se sente tensa, estressada ou chateada.")]
        Decompresser = 1,

        [Display(Name = "Exploradora", Description = "A turista sexual: curiosa e ávida por aprender coisas novas. Gosta de ir além da sua zona de conforto e não leva o sexo demasiado a sério.")]
        Explorer = 2,

        [Display(Name = "Comerciante Justo", Description = "A que dá extrema importância à equação dar-receber, de modo que esta seja equilibrada. Gosta de saber que ambos estão atentos quanto às necessidades um do outro e dispostos a trabalhar em equipa.")]
        FairTrader = 3,

        [Display(Name = "Dadora", Description = "A que dá mais do que recebe e está em sintonia com as experiências e necessidades do seu parceiro. Pessoa para quem é importante saber que consegue fazer o outro sentir-se bem.")]
        Giver = 4,

        [Display(Name = "Guardiã", Description = "A que enfatiza a segurança mais do que tudo. Esta característica é típica de quem tenha sofrido algum tipo de trauma ou simplesmente precise do elo de confiança com o seu parceiro nos momentos de intimidade.")]
        Guardian = 5,

        [Display(Name = "Apaixonada", Description = "A que crê que a interação sexual deve trazer experiências intensas, quase animalescas, e que é preciso estar em sintonia total com a energia do seu parceiro.")]
        PassionPursuer = 6,

        [Display(Name = "Prazerosa", Description = "A que encara o prazer físico como único objetivo, considerando o sexo um dos prazeres mais simples da vida. Gosta de contacto físico abundante, mas não sente necessidade da componente emocional para o fazer.")]
        PleasureSeeker = 7,

        [Display(Name = "Prioritária", Description = "A que valoriza muito a vida sexual de ambos e está disposta a fazer sacrifícios para manter uma rotina, sem desculpas.")]
        Prioritizer = 8,

        [Display(Name = "Romântica", Description = "A cujo sexo baseia-se numa conexão profunda entre os dois, sendo comum manter contacto visual com o parceiro ou dizer-lhe que o ama durante a relação sexual.")]
        Romantic = 9,

        [Display(Name = "Espiritualista", Description = "A cujo sexo é mais do que aquilo que se passa no corpo, devendo ser uma experiência quase transcendente, uma comunhão de almas e não apenas de corpos.")]
        Spiritualist = 10,

        [Display(Name = "Aventureira", Description = "A que encara o ato sexual como algo entusiasmante, quase interdito. Trata-se do tipo de pessoa que precisa do elemento tabu, quer isto signifique experimentar algo inusitado ou satisfazer um fetiche.")]
        ThrillSeeker = 11
    }
}