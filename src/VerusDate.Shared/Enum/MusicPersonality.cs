using VerusDate.Shared.Core;

namespace VerusDate.Shared.Enum
{
    //https://www.youtube.com/watch?v=pRwLmwrMuQk
    public enum MusicPersonality
    {
        [Custom(Name = "Clássica / Ópera", Description = "São normalmente mais introvertidos, mas também estão à vontade consigo mesmos e com o mundo ao seu redor. Eles são criativos e têm um bom senso de auto-estima.")]
        ClassicalOpera = 1, //- Unfortunately, nowadays people almost never listen to classical music. But if you're one of those rare people who genuinely love it more than any other music genre, you're exceptionally smart and confident.

        [Custom(Name = "Jazz / Blues / Soul", Description = "Consideradas mais extrovertidas e com alta auto-estima. Eles também tendem a ser muito criativos, inteligentes e à vontade.")]
        JazzBluesSoul = 2, //- If you can't live without jazz or blues, you're intelligent, charming, and traditional. Jazz lovers enjoy the simplest things and put their main focus on relationships.

        [Custom(Name = "Musicais / Pop / Romântica", Description = "Tendem a ser extrovertidos, honestos e convencionais. Embora os amantes da música pop sejam trabalhadores e tenham autoestima elevada, os pesquisadores sugerem que tendem a ser menos criativos e mais inquietos.")]
        MusicalsPopRomantic = 3, //- If you're a huge fan of pop music, you're probably extroverted, hardworking, and pretty honest. You love to meet new people and get into new and exciting adventures and ideas.

        [Custom(Name = "Sertanejo / Popular", Description = "São tipicamente trabalhadores, convencionais e extrovertidos. Embora as canções country sejam frequentemente centradas no coração partido, as pessoas que gravitam em torno desse gênero tendem a ser emocionalmente estáveis. Eles também tendem a ser mais conservadores e ter uma classificação inferior no traço de abertura à experiência.")]
        CountryWesternFolk = 4, //- Country music has tons of dedicated fans all over the world. If you're one of them, you're laid-back, friendly, and responsible. Even though country songs often describe going through a roller coaster of emotions, most country lovers rarely go through mood swings and are very emotionally stable.

        [Custom(Name = "Punk / Rock Alternativo / Indie", Description = "São tipicamente introvertidos, intelectuais e criativos. De acordo com os pesquisadores, eles também tendem a ser menos trabalhadores e menos gentis. Passividade, ansiedade e baixa auto-estima são outras características comuns da personalidade.")]
        PunkAlternativeRockIndie = 5, //- Indie lovers are certainly the most creative of all the music genre types. They know how to think outside of the box and find simple but innovative solutions in a heartbeat. This makes them powerful leaders and masters of brainstorming.

        //[Custom(Name = "Samba / Latino / Swing", Description = "")]
        //SambaLatinoSwing = 6,

        [Custom(Name = "Rap / Hip Hop / Reggae", Description = "Apesar do estereótipo de que os amantes destes gêneros são mais agressivos ou violentos, os pesquisadores, na verdade, não encontraram essa ligação. Os fãs de rap tendem a ter alta autoestima e geralmente são extrovertidos.")]
        RapHipHopReggae = 7, //- If your playlist mostly consists of rap and hip-hop music, you're probably highly extroverted and outgoing. Rap lovers are often the life of the party as they have outstanding social skills and can find common ground with both extroverts and introverts.

        [Custom(Name = "Dança / Eletrônica / Techno", Description = "Costumam ser extrovertidas e assertivas. Eles também tendem a ter uma classificação elevada no traço de abertura à experiência, um dos cinco principais traços de personalidade. Pessoas que preferem música eletrônica acelerada também tendem a ter uma classificação baixa em gentileza.")]
        DanceElectronicTechno = 8, //- If you can't stop listening to electronic music, you're probably a social butterfly who has strong opinions and rarely compromises. Electronic music lovers are often big fans of going to concerts and music festivals.

        [Custom(Name = "Rock / Heavy Metal", Description = "Apesar da imagem às vezes agressiva que o rock e o heavy metal projetam, costumam ser bastante gentis. Tendem a ser criativos, mas costumam ser introvertidos e podem sofrer de baixa autoestima.")]
        RockHeavyMetal = 9, //- If rock ’n' roll is your kind of music, you're extremely creative and intuitive. Rock lovers see the world as a platform of endless possibilities and are interested in mastering many things at once.

        //[Custom(Name = "Militar / Religioso", Description = "")]
        //MilitaryReligious = 10
    }
}