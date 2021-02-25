using System.ComponentModel.DataAnnotations;

namespace VerusDate.Shared.Enum
{
    public enum MyersBriggsTypeIndicator
    {
        [Display(GroupName = "Analistas", Name = "Arquiteto (INTJ)", Description = "Pessoas com o tipo de personalidade do Arquiteto (INTJ) abordam o romance da maneira como abordam a maioria dos desafios: estrategicamente, com objetivos bem definidos e um plano para alcançá-los. Em um mundo puramente racional, essa abordagem seria infalível. Infelizmente, ele ignora fatores importantes que os Arquitetos às vezes descartam - como a imprevisibilidade da natureza humana e do afeto. (Combinam com ENTP e ENFP)")]
        INTJ = 11,

        [Display(GroupName = "Analistas", Name = "Lógico (INTP)", Description = "Quando se trata de relacionamentos românticos, os lógicos têm uma mistura interessante de características que costumam surpreender agradavelmente seus parceiros. Pessoas com esse tipo de personalidade estão sempre cheias de ideias, mas têm poucas oportunidades de explorar suas noções mais românticas. Como acontece com qualquer uma de suas teorias, os lógicos adoram compartilhar com os outros e, ao finalmente conhecer alguém onde pensamentos românticos são apropriados, eles se mostram excitados, entusiasmados e até brincalhões, flertando com jogos de palavras e jogos intelectuais. (Combinam com ENTJ e ENFJ)")]
        INTP = 12,

        [Display(GroupName = "Analistas", Name = "Comandante (ENTJ)", Description = "Como em outras áreas de suas vidas, os comandantes abordam o namoro e os relacionamentos com um conjunto de metas e um plano para alcançá-los, e agem assim com energia e entusiasmo impressionantes. Pessoas com o tipo de personalidade de Comandante querem vencer e, com prazer, assumirão papéis de liderança nos relacionamentos desde o início, assumindo responsabilidade pessoal por como as coisas vão bem e trabalhando ativamente para garantir uma experiência mutuamente gratificante. Relacionamentos românticos são um negócio sério, e os comandantes estão nisso por muito tempo. (Combinam com INTP e INFP)")]
        ENTJ = 13,

        [Display(GroupName = "Analistas", Name = "Inovador (ENTP)", Description = "Se há uma coisa em que os Inovadores são bons, é apresentar um fluxo interminável de inovações e ideias para manter as coisas avançando, e isso é evidente em seus relacionamentos românticos também. Para as pessoas com o tipo de personalidade Inovador, o crescimento é a chave, e mesmo antes de encontrarem um parceiro de namoro, elas imaginam todas as maneiras pelas quais podem experimentar coisas novas juntos, para crescer em conjunto. Este pode ser um processo opressor se seu parceiro não corresponder, mas quando os Inovadores encontrarem alguém que compartilhe seu amor pela exploração intelectual, tome cuidado. (Combinam com INTJ e INFJ)")]
        ENTP = 14,

        [Display(GroupName = "Diplomatas", Name = "Advogado (INFJ)", Description = "Os advogados (INFJs) tendem a levar a sério o processo de encontrar um parceiro romântico. Pessoas com este tipo de personalidade procuram profundidade e significado em seus relacionamentos, preferindo não se contentar com uma união que seja baseada em algo menos do que o amor verdadeiro. Pode levar algum tempo para que os advogados encontrem um parceiro compatível. Algumas pessoas podem pensar que os defensores são muito exigentes e é verdade que essas personalidades podem ter expectativas irrealistas. Alguns defensores podem defender um parceiro ou relacionamento 'perfeito' que, em última análise, não existe. (Combinam com ENFP, ENTP, INTJ e INFJ)")]
        INFJ = 21,

        [Display(GroupName = "Diplomatas", Name = "Mediador (INFP)", Description = "Mediadores (INFPs) são sonhadores e idealistas, especialmente quando se trata de romance. O conceito de amor verdadeiro ressoa com eles, e é improvável que sejam felizes em um relacionamento baseado em nada menos. Pessoas com esse tipo de personalidade podem sonhar acordadas com o relacionamento perfeito, imaginando como seria compartilhar seu eu mais íntimo com outra pessoa. (Combinam com ENFJ e ENTJ)")]
        INFP = 22,

        [Display(GroupName = "Diplomatas", Name = "Protagonista (ENFJ)", Description = "Pessoas que compartilham o tipo de personalidade de Protagonista se sentem mais em casa quando estão em um relacionamento, e poucos tipos estão mais ansiosos para estabelecer um compromisso amoroso com o parceiro escolhido. Os protagonistas levam o namoro e os relacionamentos a sério, selecionando parceiros com um olhar voltado para o longo prazo, em vez da abordagem mais casual que pode ser esperada de alguns tipos do grupo Explorador. Não há alegria maior para os Protagonistas do que ajudar ao longo dos objetivos de alguém de quem gostam, e o entrelaçamento de vidas que um relacionamento sério representa é a oportunidade perfeita para fazer exatamente isso. (Combinam com INFP e INTP)")]
        ENFJ = 23,

        [Display(GroupName = "Diplomatas", Name = "Ativista (ENFP)", Description = "Quando se trata de relacionamentos, dificilmente há alguém por perto que está mais animado do que os ativistas para compartilhar com seus parceiros a abundância de ideias e experiências reveladoras que a vida tem a oferecer. Para pessoas com o tipo de personalidade de Ativista, os relacionamentos são um processo alegre de exploração e imaginação mútuas, uma chance de se conectar com outra alma. Os ativistas levam seus relacionamentos a sério e são conhecidos por sua devoção desinibida e inabalável às pessoas a quem comprometeram seus corações. (Combinam com INFJ e INTJ)")]
        ENFP = 24,

        [Display(GroupName = "Sentinelas", Name = "Logístico (ISTJ)", Description = "Os logísticos são totalmente confiáveis e essa característica é claramente expressa quando se trata de seus relacionamentos românticos. Muitas vezes representando o epítome dos valores familiares, as pessoas com o tipo de personalidade da Logística sentem-se à vontade com, e muitas vezes até encorajam, os papéis domésticos e de gênero tradicionais, e procuram uma estrutura familiar guiada por expectativas claras e honestidade. Embora sua natureza reservada muitas vezes torne os logísticos de namoro um desafio, eles são parceiros verdadeiramente dedicados, dispostos a dedicar muito pensamento e energia para garantir relacionamentos estáveis e mutuamente satisfatórios. (Combinam com ESTP e ESFP)")]
        ISTJ = 31,

        [Display(GroupName = "Sentinelas", Name = "Defensor (ISFJ)", Description = "Quando se trata de relacionamentos românticos, a bondade dos Defensores se transforma em uma alegria que só é encontrada em cuidar de sua família e casa, em estar lá para apoio emocional e prático sempre que necessário. O lar é onde o coração está para as pessoas com o tipo de personalidade Defensor, e em nenhuma outra área de suas vidas elas se esforçam com tanta dedicação para criar a harmonia e a beleza que desejam ver no mundo. (Combinam com ESFP e ESTP)")]
        ISFJ = 32,

        [Display(GroupName = "Sentinelas", Name = "Executivo (ESTJ)", Description = "Os executivos são bastante únicos no sentido de que seus relacionamentos não mudam realmente à medida que progridem da fase de namoro para relacionamentos mais estáveis e de longo prazo e ainda mais para o casamento. Por valorizarem tanto a honestidade e a franqueza, as pessoas com personalidade executiva tendem a ser claras sobre quem são, como são e quais são seus objetivos desde o início, e devem seguir essas afirmações a longo prazo. Contanto que seu parceiro seja capaz de acreditar em sua palavra e seguir o exemplo, eles tendem a ser relacionamentos extremamente estáveis. (Combinam com ISTP e ISFP)")]
        ESTJ = 33,

        [Display(GroupName = "Sentinelas", Name = "Cônsul (ESFJ)", Description = "Valorizando a validação social e um senso de pertencimento tão altamente, os relacionamentos românticos têm um nível especial de importância para os cônsules. Nenhum outro tipo de relacionamento fornece às pessoas com o tipo de personalidade Cônsul o mesmo nível de apoio e devoção, e os sentimentos de segurança e estabilidade que acompanham relacionamentos românticos fortes são extremamente calorosos. (Combinam com ISFP e ISTP)")]
        ESFJ = 34,

        [Display(GroupName = "Exploradores", Name = "Virtuoso (ISTP)", Description = "Quando se trata de relacionamentos românticos com Virtuosos, é um pouco como pregar gelatina em uma árvore. Namorar personalidades Virtuoso é um tango, complexo e interessante, com alternância de frieza e desapego, e paixão, espontaneidade e prazer do momento. Nada pode ser forçado nos relacionamentos do Virtuoso, mas, desde que recebam o espaço de que precisam para serem eles mesmos, eles terão prazer em desfrutar do conforto de um parceiro estável por toda a vida. (Combinam com ESFJ e ESTJ)")]
        ISTP = 41,

        [Display(GroupName = "Exploradores", Name = "Aventureiro (ISFP)", Description = "Os aventureiros são bastante misteriosos e difíceis de conhecer. Embora sejam indivíduos muito emocionais, eles guardam esse núcleo sensível com cuidado, preferindo ouvir do que expressar. Pessoas com o tipo de personalidade Aventureiro se concentram em seus parceiros, com pouco interesse em ditar o clima de uma situação com seus próprios sentimentos. Embora isso às vezes possa ser frustrante, se eles forem aceitos pelo que são, os Aventureiros demonstram ser parceiros calorosos e entusiasmados. (Combinam com ESTJ e ESFJ)")]
        ISFP = 42,

        [Display(GroupName = "Exploradores", Name = "Empresário (ESTP)", Description = "Quando se trata de relacionamentos românticos, dificilmente se pode dizer que as pessoas com o tipo de personalidade Empreendedor estão morrendo de saudades do dia do casamento. A vida é divertida e cheia de surpresas (algo que os empreendedores têm uma habilidade especial em entregar), e eles gostam de tudo aqui e agora. Os empreendedores podem não perder muito tempo planejando “algum dia”, mas seu entusiasmo e imprevisibilidade os tornam parceiros de namoro emocionantes. (Combinam com ISTJ e ISFJ)")]
        ESTP = 43,

        [Display(GroupName = "Exploradores", Name = "Animador (ESFP)", Description = "Animadores são pessoas sociáveis, amantes da diversão e de espírito livre, que vivem a vida no momento e extraem cada pedacinho de emoção de tudo. Naturalmente, eles não poupam nada desse frescor e energia no namoro. Para pessoas com o tipo de personalidade de Animador, os relacionamentos não são sobre construir lentamente as bases para o futuro ou planejar uma vida - eles são coisas borbulhantes e imprevisíveis para serem desfrutadas enquanto houver prazer a ser desfrutado. (Combinam com ISTJ e ISFJ)")]
        ESFP = 44
    }
}