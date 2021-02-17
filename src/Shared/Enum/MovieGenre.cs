using System.ComponentModel.DataAnnotations;

namespace VerusDate.Shared.Enum
{
    //https://www.studiobinder.com/blog/movie-genres-list/
    public enum MovieGenre
    {
        [Display(Name = "Açao", Description = "Os filmes do gênero de ação são definidos pelo risco e pelo desafio. Incluindo cenas de luta, acrobacias, perseguições de carro e perigo geral. (Derramamento de sangue heróico, ação militar, espionagem, wuxia, desastre, aventura, super-herói)")]
        Action,

        [Display(Name = "Animação", Description = "O gênero da animação é definido por objetos inanimados sendo manipulados para parecerem vivos. (Tradicional, Stop Motion, Claymation, Cutout, Imagens Geradas por Computador - CGI, Puppetry, Live-Action)")]
        Animation,

        //[Display(Name = "Biopics (Biographical Film)", Description = "At their core, biopics dramatize real people and real events with varying degrees of verisimilitude. ")]
        //Biopics,

        [Display(Name = "Comédia", Description = "O gênero da comédia é definido por eventos que pretendem fazer alguém rir, não importa se a história é macabra, engraçada ou boba. (Comédia de ação, Dark Comedy, Comédia romântica, Buddy Comedy, Road Comedy, Comédia pastelão, paródia, sátira, sitcom, Sketch Comedy, Mockumentary, pegadinha)")]
        Comedy,

        [Display(Name = "Crime", Description = "O gênero crime lida com ambos os lados do sistema de justiça criminal, mas não se concentra em questões legislativas ou processos civis e ações judiciais. (Caper, Heist, Gangster, Policial, Detetive, Tribunal, Processual)")]
        Crime,

        [Display(Name = "Drama", Description = "O gênero dramático é definido pelo conflito e muitas vezes olha para a realidade ao invés do sensacionalismo. (Melodrama, Drama Adolescente, Drama Filosófico, Drama Médico, Drama Jurídico, Drama Político, Drama Antropológico, Drama Religioso, Docudrama)")]
        Drama,

        [Display(Name = "Experimental", Description = "O gênero experimental é frequentemente definido pela ideia de que a obra de arte e entretenimento não se enquadra em um gênero ou subgênero particular, e é concebida como tal. (Surrealista, Absurdo)")]
        Experimental,

        [Display(Name = "Fantasia", Description = "O gênero de fantasia é definido tanto pelas circunstâncias quanto pelo cenário dentro de um universo ficcional com um conjunto irreal de leis naturais. (Fantasia contemporânea, Fantasia urbana, Fantasia negra, Fantasia elevada, Mito)")]
        Fantasy,

        [Display(Name = "Histórico / Fatos Reais", Description = "O gênero histórico pode ser dividido em duas seções. Um trata de representações precisas de relatos históricos, que podem incluir biografias, autobiografias e memórias. A outra seção é composta por filmes de ficção que são colocados dentro de uma representação precisa de um cenário histórico. (Evento histórico, biografia, épico histórico, ficção histórica, peça de época, história alternativa)")]
        Historical,

        [Display(Name = "Terror", Description = "O gênero de terror é centrado na descrição de eventos aterrorizantes ou macabros por uma questão de entretenimento. (Fantasma, Monstro, Lobisomem, Vampiro, Oculto, Slasher, Splatter, Filmagem encontrada, Zumbi)")]
        Horror,

        [Display(Name = "Musical", Description = "Os musicais podem incorporar qualquer outro gênero, mas incorporam personagens que cantam canções e executam números de dança.")]
        Musical,

        [Display(Name = "Romance", Description = "O gênero romance é definido por relacionamentos íntimos. (Drama romance, suspense romance, romance de época)")]
        Romance,

        [Display(Name = "Ficção científica", Description = "Os filmes de ficção científica são definidos por uma mistura de especulação e ciência. (Pós-apocalíptico, Utópico, Distópico, Cyberpunk, Steampunk, Tech Noir, Space Opera, Contemporâneo, Militar)")]
        ScienceFiction,

        [Display(Name = "Suspense", Description = "Uma história de suspense é principalmente sobre o propósito emocional, que é provocar emoções fortes, lidando principalmente com a geração de suspense e ansiedade. (Psicológico, Mistério, Techno, Film Noir)")]
        Thriller,

        [Display(Name = "Guerra", Description = "Os filmes do gênero guerra giram em torno de conflitos de grande escala entre forças opostas dentro de um universo que compartilha as mesmas leis naturais que o nosso.")]
        War,

        [Display(Name = "Faroeste", Description = "Faroeste são definidos por sua configuração e período de tempo. A história precisa se passar no oeste americano, que começa no extremo leste do Missouri e se estende até o oceano Pacífico. (Western épico, Empire Western, Marshal Western, Outlaw Western, Revenge Western, Revisionist Western, Spaghetti Western)")]
        Western
    }
}