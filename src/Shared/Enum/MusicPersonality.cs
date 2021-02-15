using System.ComponentModel.DataAnnotations;

namespace VerusDate.Shared.Enum
{
    public enum MusicPersonality
    {
        [Display(Name = "Pop", Description = "Fans of the top 40 pop hits tend to be extroverted, honest, and conventional. While pop music lovers are hardworking and have high self-esteem, researchers suggest that they tend to be less creative and more uneasy.")]
        Pop = 1,

        [Display(Name = "Rap / Hip Hop", Description = "In spite of the stereotype that rap lovers are more aggressive or violent, researchers have actually found no such link. Rap fans do tend to have high self-esteem and are usually outgoing.")]
        RapHipHop = 2,

        [Display(Name = "Country / Western", Description = "Country music fans are typically hardworking, conventional, and outgoing. While country songs are often centered on heartbreak, people who gravitate towards this genre tend to be very emotionally stable. They also tend to be more conservative and rank lower on the trait of openness to experience.")]
        CountryWestern = 3,

        [Display(Name = "Rock / Heavy Metal", Description = "Despite the sometimes aggressive image that rock and heavy metal music project, researchers found that fans of this style of music are usually quite gentle. They tend to be creative, but are often introverted and may suffer from low self-esteem.")]
        RockHeavyMetal = 4,

        [Display(Name = "Indie Music", Description = "Fans of the indie genre are typically introverted, intellectual, and creative. According to researchers, they also tend to be less hardworking and less gentle. Passivity, anxiousness, and low self-esteem are other common personality characteristics.")]
        IndieMusic = 5,

        [Display(Name = "Dance", Description = "According to researchers, people who prefer dance music are usually outgoing and assertive. They also tend to rank high on the trait of openness to experience, one of the five major personality traits. People who prefer fast-paced electronic music also tend to rank low on gentleness.")]
        Dance = 6,

        [Display(Name = "Classical Music", Description = "Classical music lovers are typically more introverted but are also at ease with themselves and the world around them. They are creative and have a good sense of self-esteem.")]
        ClassicalMusic = 7,

        [Display(Name = "Jazz / Blues / Soul", Description = "People who enjoy jazz, blues, or soul music were found to be more extroverted with high self-esteem. They also tend to be very creative, intelligent, and at ease.")]
        Jazz = 8,
    }
}