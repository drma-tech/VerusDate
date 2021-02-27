using System.ComponentModel.DataAnnotations;

namespace VerusDate.Shared.Enum
{
    //https://www.musicgenreslist.com/
    public enum MusicGenre
    {
        [Display(Name = "Blues", Description = "O blues incorporou espirituais, canções de trabalho, gritos de campo, gritos, cantos e baladas narrativas simples rimadas.")]
        Blues = 1,

        [Display(Name = "Caribenha e Influenciadas", Description = "Alguns dos estilos que ganharam grande popularidade fora do Caribe incluem bachata, merenque, palo, mombo, denbo, baithak gana, bouyon, cadence-lypso, calypso, chutney, chutney-soca, compas, dancehall, jing ping, parang, pichakaree, punta, ragga, reggae, reggaeton, salsa, soca e zouk.")]
        CaribbeanCaribbeanInfluenced = 2,

        [Display(Name = "Clássica", Description = "Avant-Garde, Barroco, Coral, Concerto, Ópera, Orquestral, Romântica, Música de Casamento")]
        Classical = 3,

        [Display(Name = "Comédia", Description = "Novidade, Música de paródia, Comédia stand-up, Vaudeville")]
        Comedy = 4,

        [Display(Name = "Country", Description = "A música country geralmente consiste em baladas e melodias de dança com formas geralmente simples, letras folclóricas e harmonias, principalmente acompanhadas por instrumentos de cordas, como banjos, violões elétricos e acústicos, guitarras de aço (como pedal steels e dobros) e violinos, bem como gaitas .")]
        Country = 5,

        [Display(Name = "Easy Listening", Description = "Plano de fundo, Bop, elevador, móveis, sala, meio da estrada, balanço")]
        EasyListening = 6,

        [Display(Name = "Eletrônica", Description = "Música eletrônica é aquela que emprega instrumentos musicais eletrônicos, instrumentos digitais ou tecnologia musical baseada em circuitos. (Disco, House, Techno, Videogame)")]
        ElectronicHouse = 7,

        [Display(Name = "Tradicional / Popular", Description = "A música folclórica tradicional foi definida de várias maneiras: como música transmitida oralmente, música com compositores desconhecidos ou música executada por costume durante um longo período de tempo.")]
        Folk = 8,

        [Display(Name = "Hip-Hop / Rap", Description = "Consiste em uma música rítmica estilizada que comumente acompanha o rap, uma fala rítmica e rimada que é cantada.")]
        HipHopRap = 9,

        [Display(Name = "Jazz", Description = "O jazz é caracterizado por notas suaves e azuis, acordes complexos, vocais de chamada e resposta, polirritmos e improvisação.")]
        Jazz = 10,

        [Display(Name = "Latina / Brasileira", Description = "Alternativo & Rock Latino, Tango, Baladas y Boleros, Bossa Nova, Brazilian (Brega, Forró, Frevo, Maracatu, MPB, Pagode, Samba)")]
        LatinBrazilian = 11,

        [Display(Name = "Pop", Description = "Os fatores de identificação geralmente incluem refrões e ganchos repetidos, canções curtas a médias escritas em um formato básico (geralmente a estrutura verso-refrão) e ritmos ou andamentos que podem ser dançados facilmente. Grande parte da música pop também empresta elementos de outros estilos, como rock, urbano, dance, latino e country.")]
        Pop = 12,

        [Display(Name = "R&B / Soul", Description = "Combina elementos da música gospel afro-americana, ritmo, blues e jazz.")]
        RBSoul = 13,

        [Display(Name = "Rock", Description = "É baseado em instrumentos amplificados, especialmente a guitarra e o baixo elétricos, e é caracterizado por uma linha de baixo forte e ritmos impulsionadores. É tipicamente executado por grupos de rock e, embora a música de dança rápida seja a forma básica, as músicas mais lentas no estilo de balada também são uma parte popular do repertório.")]
        Rock = 14,

        [Display(Name = "Música Religiosa", Description = "É qualquer tipo de música executada ou composta para uso religioso ou por influência religiosa.")]
        ReligiousMusic = 15,

        [Display(Name = "Música Popular Africana", Description = "A maioria dos gêneros contemporâneos de música popular africana baseia-se na polinização cruzada com a música popular ocidental. Muitos gêneros de música popular como blues, jazz, afrobeats, salsa, zouk e rumba derivam em graus variados das tradições musicais da África, levadas para as Américas por africanos escravizados.")]
        AfricanMusic = 16,

        [Display(Name = "Música Asiática", Description = "Chinês (C-Pop), Hong Kong, Taiwanês, Japonês (Enka, J-pop), Coreano (K-pop), Sul da Ásia, Sudeste Asiático, Malaia, Indonésio, Tailandês, Filipino, Laosiano, Vietnamita")]
        AsianMusic = 17
    }
}