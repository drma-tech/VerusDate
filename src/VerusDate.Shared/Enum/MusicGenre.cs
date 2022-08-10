using VerusDate.Shared.Core;

namespace VerusDate.Shared.Enum
{
    /// <summary>
    /// https://www.omarimc.com/complete-music-genre-list/
    /// </summary>
    public enum MusicGenre
    {
        [Custom(Name = "Pop_Name", Description = "Pop_Description", ResourceType = typeof(Resources.Enum.MusicGenre))]
        Pop = 1,

        [Custom(Name = "Rock_Name", Description = "Rock_Description", ResourceType = typeof(Resources.Enum.MusicGenre))]
        Rock = 2,

        [Custom(Name = "HipHopRap_Name", Description = "HipHopRap_Description", ResourceType = typeof(Resources.Enum.MusicGenre))]
        HipHopRap = 3,

        [Custom(Name = "RB_Name", Description = "RB_Description", ResourceType = typeof(Resources.Enum.MusicGenre))]
        RB = 4,

        [Custom(Name = "Reggae_Name", Description = "Reggae_Description", ResourceType = typeof(Resources.Enum.MusicGenre))]
        Reggae = 5,

        [Custom(Name = "Country_Name", Description = "Country_Description", ResourceType = typeof(Resources.Enum.MusicGenre))]
        Country = 6,

        [Custom(Name = "Folk_Name", Description = "Folk_Description", ResourceType = typeof(Resources.Enum.MusicGenre))]
        Folk = 7,

        [Custom(Name = "Jazz_Name", Description = "Jazz_Description", ResourceType = typeof(Resources.Enum.MusicGenre))]
        Jazz = 8,

        [Custom(Name = "Classical_Name", Description = "Classical_Description", ResourceType = typeof(Resources.Enum.MusicGenre))]
        Classical = 9,

        [Custom(Name = "Blues_Name", Description = "Blues_Description", ResourceType = typeof(Resources.Enum.MusicGenre))]
        Blues = 10,

        [Custom(Name = "Electronic_Name", Description = "Electronic_Description", ResourceType = typeof(Resources.Enum.MusicGenre))]
        Electronic = 11,

        [Custom(Name = "Childrens_Name", Description = "Childrens_Description", ResourceType = typeof(Resources.Enum.MusicGenre))]
        Childrens = 12,

        [Custom(Name = "Christian_Name", Description = "Christian_Description", ResourceType = typeof(Resources.Enum.MusicGenre))]
        Christian = 13,

        [Custom(Name = "Latino_Name", Description = "Latino_Description", ResourceType = typeof(Resources.Enum.MusicGenre))]
        Latino = 14,

        [Custom(Name = "Alternative_Name", Description = "Alternative_Description", ResourceType = typeof(Resources.Enum.MusicGenre))]
        Alternative = 15,

        [Custom(Name = "NewAge_Name", Description = "NewAge_Description", ResourceType = typeof(Resources.Enum.MusicGenre))]
        NewAge = 16
    }

    //https://www.musicgenreslist.com/
    public enum MusicGenreOld
    {
        //POPULAR - 1

        [Custom(Group = "Popular", Name = "Comédia", Description = "Novidade, Música de paródia, Comédia stand-up, Vaudeville")]
        Comedy = 12,

        [Custom(Group = "Popular", Name = "Country / Bluegrass", Description = "A música country geralmente consiste em baladas e melodias de dança com formas geralmente simples, letras folclóricas e harmonias, principalmente acompanhadas por instrumentos de cordas, como banjos, violões elétricos e acústicos, guitarras de aço (como pedal steels e dobros) e violinos, bem como gaitas .")]
        CountryBluegrass = 13,

        [Custom(Group = "Popular", Name = "Easy Listening", Description = "Plano de fundo, Bop, elevador, móveis, sala, meio da estrada, balanço")]
        EasyListening = 14,

        [Custom(Group = "Popular", Name = "Dance / Electronic / House", Description = "Música eletrônica é aquela que emprega instrumentos musicais eletrônicos, instrumentos digitais ou tecnologia musical baseada em circuitos. (Disco, House, Techno, Videogame)")]
        DanceElectronicHouse = 15,

        [Custom(Group = "Popular", Name = "Hip-Hop / Rap / Trap", Description = "Consiste em uma música rítmica estilizada que comumente acompanha o rap, uma fala rítmica e rimada que é cantada.")]
        HipHopRapTrap = 16,

        [Custom(Group = "Popular", Name = "Pop", Description = "Os fatores de identificação geralmente incluem refrões e ganchos repetidos, canções curtas a médias escritas em um formato básico (geralmente a estrutura verso-refrão) e ritmos ou andamentos que podem ser dançados facilmente. Grande parte da música pop também empresta elementos de outros estilos, como rock, urbano, dance, latino e country.")]
        Pop = 18,

        [Custom(Group = "Popular", Name = "R&B / Soul / Blues / Jazz", Description = "Combina elementos da música gospel afro-americana, ritmo, blues e jazz.")]
        RBSoulBluesJazz = 19,

        [Custom(Group = "Popular", Name = "Rock / Metal / Punk", Description = "É baseado em instrumentos amplificados, especialmente a guitarra e o baixo elétricos, e é caracterizado por uma linha de baixo forte e ritmos impulsionadores. É tipicamente executado por grupos de rock e, embora a música de dança rápida seja a forma básica, as músicas mais lentas no estilo de balada também são uma parte popular do repertório.")]
        RockMetalPunk = 110,

        [Custom(Group = "Popular", Name = "Singer / Songwriter", Description = "É baseado em instrumentos amplificados, especialmente a guitarra e o baixo elétricos, e é caracterizado por uma linha de baixo forte e ritmos impulsionadores. É tipicamente executado por grupos de rock e, embora a música de dança rápida seja a forma básica, as músicas mais lentas no estilo de balada também são uma parte popular do repertório.")]
        SingerSongwriter = 111,

        //REGIONAL - 2

        [Custom(Group = "Regional", Name = "Música Popular Africana", Description = "A maioria dos gêneros contemporâneos de música popular africana baseia-se na polinização cruzada com a música popular ocidental. Muitos gêneros de música popular como blues, jazz, afrobeats, salsa, zouk e rumba derivam em graus variados das tradições musicais da África, levadas para as Américas por africanos escravizados.")]
        AfricanMusic = 21,

        [Custom(Group = "Regional", Name = "Música Asiática", Description = "Chinês (C-Pop), Hong Kong, Taiwanês, Japonês (Enka, J-pop), Coreano (K-pop), Sul da Ásia, Sudeste Asiático, Malaia, Indonésio, Tailandês, Filipino, Laosiano, Vietnamita")]
        AsianMusic = 22,

        [Custom(Group = "Regional", Name = "Caribenha e Influenciadas", Description = "Alguns dos estilos que ganharam grande popularidade fora do Caribe incluem bachata, merenque, palo, mombo, denbo, baithak gana, bouyon, cadence-lypso, calypso, chutney, chutney-soca, compas, dancehall, jing ping, parang, pichakaree, punta, ragga, reggae, reggaeton, salsa, soca e zouk.")]
        CaribbeanCaribbeanInfluenced = 23,

        [Custom(Group = "Regional", Name = "Latina / Brasileira", Description = "Alternativo & Rock Latino, Tango, Baladas y Boleros, Bossa Nova, Brazilian (Brega, Forró, Frevo, Maracatu, MPB, Pagode, Samba)")]
        LatinBrazilian = 24,

        //OTHERS - 3

        [Custom(Group = "Other", Name = "Clássica / Contemporary", Description = "Avant-Garde, Barroco, Coral, Concerto, Ópera, Orquestral, Romântica, Música de Casamento")]
        ClassicalContemporary = 31,

        [Custom(Group = "Other", Name = "Música Religiosa / Cristian / Gospel", Description = "É qualquer tipo de música executada ou composta para uso religioso ou por influência religiosa.")]
        ReligiousMusicCristianGospel = 32,

        [Custom(Group = "Other", Name = "Tradicional / Popular", Description = "A música folclórica tradicional foi definida de várias maneiras: como música transmitida oralmente, música com compositores desconhecidos ou música executada por costume durante um longo período de tempo.")]
        Folk = 33
    }
}