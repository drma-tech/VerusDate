using VerusDate.Shared.Core;

namespace VerusDate.Shared.Enum
{
    //https://en.wikipedia.org/wiki/List_of_television_formats_and_genres#Genres
    public enum TVGenre
    {
        [Custom(Name = "Programa de culinária", Description = "Um programa de televisão que apresenta a apresentação de comida em um estúdio de televisão de cozinha.")]
        CookingShow = 1,

        [Custom(Name = "Documentário", Description = "Um longa-metragem ou quase longa-metragem que retrata um evento ou pessoa do mundo real, contado em estilo jornalístico.")]
        Documentary = 2,

        [Custom(Name = "Game Shows", Description = "Em programas de jogos, equipes de competidores ou participantes chamados da plateia tentam resolver quebra-cabeças ou responder a perguntas triviais, com prêmios concedidos se ganharem.")]
        GameShows = 3,

        [Custom(Name = "Programa de notícias", Description = "A programação de notícias inclui noticiários noturnos locais, transmissões nacionais diurnas em redes a cabo e programação semanal que geralmente vai ao ar às sextas-feiras ou fins de semana.")]
        NewsProgramm = 5,

        [Custom(Name = "Religioso", Description = "Produzido por organizações religiosas, geralmente com uma mensagem religiosa. Pode incluir serviços religiosos, programas de entrevistas / variedades e filmes dramáticos.")]
        Religious = 6,

        [Custom(Name = "Reality TV", Description = "Reality TV tende a enfatizar as pessoas comuns em vez das grandes estrelas. Alguns reality shows são competições, enquanto outros afirmam mostrar fatias da vida real.")]
        RealityTV = 7,

        [Custom(Name = "Esportes", Description = "Ao contrário de muitos outros formatos, os esportes são frequentemente transmitidos ao vivo, trazendo uma sensação de imediatismo e urgência à experiência de visualização.")]
        Sports = 8,

        [Custom(Name = "Programas de entrevistas", Description = "Os programas de entrevistas ou programas de bate-papo são programas de televisão baseados em discussões entre apresentadores.")]
        TalkShows = 9,

        [Custom(Name = "Novela", Description = "uma série dramática de televisão ou rádio que lida tipicamente com acontecimentos diários na vida do mesmo grupo de personagens.")]
        Telenovela = 10,

        [Custom(Name = "Programas de variedades", Description = "Shows de variedades destacam o talento de seus convidados. Os programas de variedades incluem atos musicais, dança, apresentações de comédia stand-up e esquetes cômicos.")]
        VarietyShows = 11
    }
}