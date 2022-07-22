﻿using VerusDate.Shared.Core;

namespace VerusDate.Shared.Enum
{
    //https://www.studiobinder.com/blog/movie-genres-list/
    public enum MovieGenre
    {
        [Custom(Name = "Ação", Description = "Os filmes do gênero de ação são definidos pelo risco e pelo desafio. Incluindo cenas de luta, acrobacias, perseguições de carro e perigo geral. (Derramamento de sangue heróico, ação militar, espionagem, wuxia, desastre, aventura, super-herói)")]
        Action = 1,

        [Custom(Name = "Animação", Description = "O gênero da animação é definido por objetos inanimados sendo manipulados para parecerem vivos. (Tradicional, Stop Motion, Claymation, Cutout, Imagens Geradas por Computador - CGI, Puppetry, Live-Action)")]
        Animation = 2,

        //[Custom(Name = "Biopics (Biographical Film)", Description = "At their core, biopics dramatize real people and real events with varying degrees of verisimilitude. ")]
        //Biopics = 3,

        [Custom(Name = "Comédia", Description = "O gênero da comédia é definido por eventos que pretendem fazer alguém rir, não importa se a história é macabra, engraçada ou boba. (Comédia de ação, Dark Comedy, Comédia romântica, Buddy Comedy, Road Comedy, Comédia pastelão, paródia, sátira, sitcom, Sketch Comedy, Mockumentary, pegadinha)")]
        Comedy = 4,

        [Custom(Name = "Crime", Description = "O gênero crime lida com ambos os lados do sistema de justiça criminal, mas não se concentra em questões legislativas ou processos civis e ações judiciais. (Caper, Heist, Gangster, Policial, Detetive, Tribunal, Processual)")]
        Crime = 5,

        [Custom(Name = "Drama", Description = "O gênero dramático é definido pelo conflito e muitas vezes olha para a realidade ao invés do sensacionalismo. (Melodrama, Drama Adolescente, Drama Filosófico, Drama Médico, Drama Jurídico, Drama Político, Drama Antropológico, Drama Religioso, Docudrama)")]
        Drama = 6,

        [Custom(Name = "Experimental", Description = "O gênero experimental é frequentemente definido pela ideia de que a obra de arte e entretenimento não se enquadra em um gênero ou subgênero particular, e é concebida como tal. (Surrealista, Absurdo)")]
        Experimental = 7,

        [Custom(Name = "Fantasia", Description = "O gênero de fantasia é definido tanto pelas circunstâncias quanto pelo cenário dentro de um universo ficcional com um conjunto irreal de leis naturais. (Fantasia contemporânea, Fantasia urbana, Fantasia negra, Fantasia elevada, Mito)")]
        Fantasy = 8,

        [Custom(Name = "Histórico / Fatos Reais", Description = "O gênero histórico pode ser dividido em duas seções. Um trata de representações precisas de relatos históricos, que podem incluir biografias, autobiografias e memórias. A outra seção é composta por filmes de ficção que são colocados dentro de uma representação precisa de um cenário histórico. (Evento histórico, biografia, épico histórico, ficção histórica, peça de época, história alternativa)")]
        Historical = 9,

        [Custom(Name = "Terror", Description = "O gênero de terror é centrado na descrição de eventos aterrorizantes ou macabros por uma questão de entretenimento. (Fantasma, Monstro, Lobisomem, Vampiro, Oculto, Slasher, Splatter, Filmagem encontrada, Zumbi)")]
        Horror = 10,

        [Custom(Name = "Musical", Description = "Os musicais podem incorporar qualquer outro gênero, mas incorporam personagens que cantam canções e executam números de dança.")]
        Musical = 11,

        [Custom(Name = "Romance", Description = "O gênero romance é definido por relacionamentos íntimos. (Drama romance, suspense romance, romance de época)")]
        Romance = 12,

        [Custom(Name = "Ficção científica", Description = "Os filmes de ficção científica são definidos por uma mistura de especulação e ciência. (Pós-apocalíptico, Utópico, Distópico, Cyberpunk, Steampunk, Tech Noir, Space Opera, Contemporâneo, Militar)")]
        ScienceFiction = 13,

        [Custom(Name = "Suspense", Description = "Uma história de suspense é principalmente sobre o propósito emocional, que é provocar emoções fortes, lidando principalmente com a geração de suspense e ansiedade. (Psicológico, Mistério, Techno, Film Noir)")]
        Thriller = 14,

        [Custom(Name = "Guerra", Description = "Os filmes do gênero guerra giram em torno de conflitos de grande escala entre forças opostas dentro de um universo que compartilha as mesmas leis naturais que o nosso.")]
        War = 15,

        [Custom(Name = "Faroeste", Description = "Faroeste são definidos por sua configuração e período de tempo. A história precisa se passar no oeste americano, que começa no extremo leste do Missouri e se estende até o oceano Pacífico. (Western épico, Empire Western, Marshal Western, Outlaw Western, Revenge Western, Revisionist Western, Spaghetti Western)")]
        Western = 16
    }
}