using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using VerusDate.Shared.Core;
using VerusDate.Shared.Enum;
using VerusDate.Shared.Helper;
using static VerusDate.Shared.Helper.ImageHelper;

namespace VerusDate.Shared.Model
{
    public class ProfileModel : CosmosBase
    {
        public ProfileModel() : base(CosmosType.Profile)
        {
        }

        public DateTime? DtTopList { get; set; } = DateTime.UtcNow;
        public DateTime? DtLastLogin { get; set; } = DateTime.UtcNow;

        #region BASIC

        [Custom(Name = "Modality_Name", ResourceType = typeof(Resources.Model.ProfileBasicModel))]
        public Modality? Modality { get; set; }

        [Custom(Name = "NickName_Name", Prompt = "NickName_Prompt", ResourceType = typeof(Resources.Model.ProfileBasicModel))]
        public string NickName { get; set; }

        [Custom(Name = "Description_Name", Prompt = "Description_Prompt", ResourceType = typeof(Resources.Model.ProfileBasicModel))]
        public string Description { get; set; }

        [Custom(Name = "Location_Name", Prompt = "Location_Prompt", Description = "Location_Description", ResourceType = typeof(Resources.Model.ProfileBasicModel))]
        public string Location { get; set; }

        //They say that good communication is the key to any long-lasting and successful relationship. It is absolutely essential for two people to share their feelings with each other, express their thoughts, and, perhaps most importantly, listen attentively to one another. Unfortunately, in today’s fast-paced and hectic world, many couples don’t find the time to sit down and have a meaningful conversation with one another. Phone calls and texts have replaced personal chats between two people.A lack of proper communication is one of the main reasons why many relationships don’t last for as long as they should. Keeping all this in mind, is it really a good idea for you to date a person who does not speak the same language as you?
        [Custom(Name = "Languages_Name", Description = "Languages_Description", FieldInfo = "Dizem que uma boa comunicação é a chave para qualquer relacionamento duradouro e bem-sucedido. É absolutamente essencial que duas pessoas compartilhem seus sentimentos, expressem seus pensamentos e, talvez o mais importante, ouçam atentamente uma à outra. Infelizmente, no mundo acelerado e agitado de hoje, muitos casais não encontram tempo para sentar e ter uma conversa significativa um com o outro. Telefonemas e mensagens de texto substituíram os bate-papos pessoais entre duas pessoas. A falta de comunicação adequada é uma das principais razões pelas quais muitos relacionamentos não duram tanto quanto deveriam. Tendo tudo isso em mente, é realmente uma boa ideia você namorar uma pessoa que não fala a mesma língua que você?", ResourceType = typeof(Resources.Model.ProfileBasicModel))]
        public IReadOnlyList<Language> Languages { get; set; } = Array.Empty<Language>();

        [Custom(Name = "CurrentSituation_Name", ResourceType = typeof(Resources.Model.ProfileBasicModel))]
        public CurrentSituation? CurrentSituation { get; set; }

        //According to Sydney-based psychotherapist and couples counselor Annie Gurton, being honest and clear about what you're looking for in a relationship is for the benefit of both of you. And for the best chance at success, she believes the two of you should have the same intentions. "It's all about making a match," she explains. "Some people want a casual relationship, maybe with other partners or maybe without any talk of commitment, and they are best with someone who thinks the same way and not with someone looking for long-term commitment."
        [Custom(Name = "Intentions_Name", Description = "Intentions_Description", FieldInfo = "De acordo com a psicoterapeuta e conselheira de casais de Sydney, Annie Gurton, ser honesto e claro sobre o que você está procurando em um relacionamento é para o benefício de ambos. E para a melhor chance de sucesso, ela acredita que vocês dois devem ter as mesmas intenções. \"É tudo uma questão de fazer um jogo\", explica ela. \"Algumas pessoas querem um relacionamento casual, talvez com outros parceiros ou talvez sem qualquer conversa de compromisso, e eles são melhores com alguém que pensa da mesma maneira e não com alguém que procura um compromisso de longo prazo.\"", ResourceType = typeof(Resources.Model.ProfileBasicModel))]
        public IReadOnlyList<Intentions> Intentions { get; set; } = Array.Empty<Intentions>();

        [Custom(Name = "BiologicalSex_Name", ResourceType = typeof(Resources.Model.ProfileBasicModel))]
        public BiologicalSex? BiologicalSex { get; set; }

        //Gender identity is each person’s internal and individual experience of gender. It is their sense of being a woman, a man, both, neither, or anywhere along the gender spectrum. A person’s gender identity may be the same as or different from their birth-assigned sex. Gender identity is fundamentally different from a person’s sexual orientation.
        [Custom(Name = "GenderIdentity_Name", Description = "GenderIdentity_Description", ResourceType = typeof(Resources.Model.ProfileBasicModel))]
        public GenderIdentity? GenderIdentity { get; set; }

        //Sexual orientation is a term used to refer to a person's pattern of emotional, romantic, and sexual attraction to people of a particular gender (male or female). Sexuality is an important part of who we are as humans. Beyond the ability to reproduce, sexuality also defines how we see ourselves and how we physically relate to others. Sexual orientation involves a person's feelings and sense of identity; it’s not necessarily something that’s noticeable to others. People may or may not act on the attractions they feel.
        [Custom(Name = "SexualOrientation_Name", Description = "SexualOrientation_Description", ResourceType = typeof(Resources.Model.ProfileBasicModel))]
        public SexualOrientation? SexualOrientation { get; set; }

        #endregion BASIC

        #region BIO

        //It is very rewarding to love someone who is different from you in terms of race, culture, identity, religion, and more. When we are open with each other, we can broaden each other's perspectives, approach the world in different ways, and even find that there is a connection in our differences. Unfortunately, interracial couples can still experience difficulties at times by virtue of the fact that racism exists in our society on a deep level. Ideally, love should have no bounds in this regard. However, in reality, other people may harbor negativity or judgment about an interracial couple. Partners in an interracial marriage must take on these issues together while maintaining empathy and support for each other's experiences.
        [Custom(Name = "RaceCategory_Name", Description = "RaceCategory_Description", FieldInfo = "É muito gratificante amar alguém que é diferente de você em termos de raça, cultura, identidade, religião e muito mais. Quando estamos abertos uns com os outros, podemos ampliar as perspectivas uns dos outros, abordar o mundo de maneiras diferentes e até descobrir que há uma conexão em nossas diferenças. Infelizmente, os casais inter-raciais ainda podem enfrentar dificuldades às vezes em virtude do fato de que o racismo existe em nossa sociedade em um nível profundo. Idealmente, o amor não deve ter limites a esse respeito. No entanto, na realidade, outras pessoas podem abrigar negatividade ou julgamento sobre um casal interracial. Os parceiros em um casamento inter-racial devem enfrentar essas questões juntos, mantendo empatia e apoio às experiências um do outro.", ResourceType = typeof(Resources.Model.ProfileBioModel))]
        public RaceCategory? RaceCategory { get; set; }

        [Custom(Name = "BodyMass_Name", ResourceType = typeof(Resources.Model.ProfileBioModel))]
        public BodyMass? BodyMass { get; set; }

        [Custom(Name = "BirthDate_Name", ResourceType = typeof(Resources.Model.ProfileBioModel))]
        public DateTime BirthDate { get; set; }

        [Custom(Name = "Zodiac_Name", ResourceType = typeof(Resources.Model.ProfileBioModel))]
        public Zodiac Zodiac { get; set; }

        [Custom(Name = "Height_Name", ResourceType = typeof(Resources.Model.ProfileBioModel))]
        public Height? Height { get; set; }

        [Custom(Name = "Neurodiversity_Name", ResourceType = typeof(Resources.Model.ProfileBioModel))]
        public Neurodiversity? Neurodiversity { get; set; }

        [Custom(Name = "Disabilities_Name", ResourceType = typeof(Resources.Model.ProfileBioModel))]
        public IReadOnlyList<Disability> Disabilities { get; set; } = Array.Empty<Disability>();

        #endregion BIO

        #region LIFESTYLE

        [Custom(Name = "Drink_Name", ResourceType = typeof(Resources.Model.ProfileLifestyleModel))]
        public Drink? Drink { get; set; }

        [Custom(Name = "Smoke_Name", ResourceType = typeof(Resources.Model.ProfileLifestyleModel))]
        public Smoke? Smoke { get; set; }

        [Custom(Name = "Diet_Name", Description = "Diet_Description", ResourceType = typeof(Resources.Model.ProfileLifestyleModel))]
        public Diet? Diet { get; set; }

        [Custom(Name = "HaveChildren_Name", ResourceType = typeof(Resources.Model.ProfileLifestyleModel))]
        public HaveChildren? HaveChildren { get; set; }

        [Custom(Name = "WantChildren_Name", ResourceType = typeof(Resources.Model.ProfileLifestyleModel))]
        public WantChildren? WantChildren { get; set; }

        [Custom(Name = "EducationLevel_Name", ResourceType = typeof(Resources.Model.ProfileLifestyleModel))]
        public EducationLevel? EducationLevel { get; set; }

        [Custom(Name = "CareerCluster_Name", ResourceType = typeof(Resources.Model.ProfileLifestyleModel))]
        public CareerCluster? CareerCluster { get; set; }

        [Custom(Name = "Religion_Name", ResourceType = typeof(Resources.Model.ProfileLifestyleModel))]
        public Religion? Religion { get; set; }

        [Custom(Name = "Travel Frequency")]
        public TravelFrequency? TravelFrequency { get; set; }

        #endregion LIFESTYLE

        #region PERSONALITY

        //Every couple argues about money. It doesn’t matter if you’ve been married for 40 years or dating for 4 months, money touches every decision you make as a couple. And when the two of you don’t see eye-to-eye on how much to spend or how much to save, that’s when arguments turn into ugly toxic fights that leave both persons feeling hurt and angry. It’s why money has become the #1 cause of divorce in the U.S. Obviously, something needs to change. The reason this crisis has not been addressed is because it has never been identified, defined, or given a name.
        [Custom(Name = "MoneyPersonality_Name", Description = "MoneyPersonality_Description", FieldInfo = "Todo casal discute sobre dinheiro. Não importa se você está casado há 40 anos ou namorando há 4 meses, o dinheiro afeta todas as decisões que você toma como casal. E quando vocês dois não concordam sobre quanto gastar ou quanto economizar, é aí que as discussões se transformam em brigas feias e tóxicas que deixam as duas pessoas magoadas e com raiva. É por isso que o dinheiro se tornou a causa número 1 de divórcio nos EUA. Obviamente, algo precisa mudar. A razão pela qual esta crise não foi abordada é porque ela nunca foi identificada, definida ou nomeada.", ResourceType = typeof(Resources.Model.ProfileLifestyleModel))]
        public MoneyPersonality? MoneyPersonality { get; set; }

        //Talking about finances in a relationship can be tricky—even when you’ve been together a long time, talking about money can make people awkward and defensive. But if you live together and want to build a life together, it comes up—in part because, on a basic level, you’re going to need to figure out how to split the bills with your partner. The answer will come down to how you view your relationship.
        [Custom(Name = "SplitTheBill_Name", FieldInfo = "Falar sobre finanças em um relacionamento pode ser complicado – mesmo quando vocês estão juntos há muito tempo, falar sobre dinheiro pode tornar as pessoas estranhas e defensivas. Mas se vocês moram juntos e querem construir uma vida juntos, isso surge – em parte porque, em um nível básico, você precisará descobrir como dividir as contas com seu parceiro. A resposta se resume a como você vê seu relacionamento.", ResourceType = typeof(Resources.Model.ProfileLifestyleModel))]
        public SplitTheBill? SplitTheBill { get; set; }

        //According to relationship wizard Helen Fisher, PhD, there are four personality types -- Explorer, Builder, Negotiator and Director. She says that once you know who you are, you'll know why you're attracted to certain people. You'll also see who might make for a good match.
        [Custom(Name = "RelationshipPersonality_Name", Description = "RelationshipPersonality_Description", FieldInfo = "De acordo com a assistente de relacionamento Helen Fisher, PhD, existem quatro tipos de personalidade - Explorador, Construtor, Negociador e Diretor. Ela diz que quando você souber quem você é, você saberá por que se sente atraído por certas pessoas. Você também verá quem pode fazer uma boa combinação.", ResourceType = typeof(Resources.Model.ProfileLifestyleModel))]
        public RelationshipPersonality? RelationshipPersonality { get; set; }

        //A common misconception we all make at one point or another in the dating game is assuming that our partner’s relationship needs are perfectly aligned with our own. In reality, everyone is looking for something slightly different out of a relationship. A partnership that makes one person feel stifled might make another feel liberated. What one person sees as a fling another might look at as marriage potential. Our relationship preferences are highly intertwined with our personality preferences. Each personality type looks for something a little different out of a relationship. Here’s exactly which kind of partnership you’re most likely to thrive in based on your Myers-Briggs personality type.
        [Custom(Name = "MyersBriggsTypeIndicator_Name", Description = "MyersBriggsTypeIndicator_Description", FieldInfo = "Um equívoco comum que todos cometemos em um ponto ou outro no jogo do namoro é supor que as necessidades de relacionamento do nosso parceiro estão perfeitamente alinhadas com as nossas. Na realidade, todo mundo está procurando algo um pouco diferente de um relacionamento. Uma parceria que faz uma pessoa se sentir sufocada pode fazer outra se sentir liberada. O que uma pessoa vê como uma aventura, outra pode ver como potencial de casamento. Nossas preferências de relacionamento estão altamente entrelaçadas com nossas preferências de personalidade. Cada tipo de personalidade procura algo um pouco diferente em um relacionamento. Aqui está exatamente em qual tipo de parceria você provavelmente prosperará com base no seu tipo de personalidade Myers-Briggs.", ResourceType = typeof(Resources.Model.ProfileLifestyleModel))]
        public MyersBriggsTypeIndicator? MyersBriggsTypeIndicator { get; set; }

        //The five love languages describe five ways that people receive and express love in a relationship. Knowing your partner's love language and letting them know yours is a way to help you both feel loved and appreciated. Author and pastor Gary Chapman describes how to use these love languages to show your partner you care for them in a way that speaks to their heart.
        [Custom(Name = "LoveLanguage_Name", Description = "LoveLanguage_Description", FieldInfo = "As cinco linguagens do amor descrevem cinco maneiras pelas quais as pessoas recebem e expressam amor em um relacionamento. Conhecer a linguagem de amor do seu parceiro e deixá-lo conhecer a sua é uma maneira de ajudá-lo a se sentir amado e apreciado. O autor e pastor Gary Chapman descreve como usar essas linguagens do amor para mostrar ao seu parceiro que você se importa com ele de uma maneira que fala ao coração dele.", ResourceType = typeof(Resources.Model.ProfileLifestyleModel))]
        public LoveLanguage? LoveLanguage { get; set; }

        //[Custom(Name = "SexPersonality_Name", Description = "SexPersonality_Description", FieldInfo = "Sexual compatibility is paramount to healthy relationships. We tend to push it aside in favor of other positive personal qualities such as kindness, a good sense of humor, etc. To be clear, sex isn't the most important thing in a relationship, but research tells us couples that are more happy with their sex life are more happy with their relationship overall. When your sexual interests don't align with your partner's and a satisfying sex life is hard to access together, you're not going to have a very happy partnership.", ResourceType = typeof(Resources.Model.ProfileLifestyleModel))]
        [Custom(Name = "SexPersonality_Name", Description = "SexPersonality_Description", FieldInfo = "A compatibilidade sexual é primordial para relacionamentos saudáveis. Nós tendemos a deixar isso de lado em favor de outras qualidades pessoais positivas, como gentileza, bom senso de humor, etc. Para ser claro, sexo não é a coisa mais importante em um relacionamento, mas pesquisas nos dizem que casais são mais felizes com sua vida sexual são mais felizes com seu relacionamento em geral. Quando os seus interesses sexuais não se alinham com os do seu parceiro e uma vida sexual satisfatória é difícil de alcançar juntos, você não terá uma parceria muito feliz.", ResourceType = typeof(Resources.Model.ProfileLifestyleModel))]
        public SexPersonality? SexPersonality { get; set; }

        #endregion PERSONALITY

        #region INTEREST

        [Custom(Name = "Comidas")]
        public IReadOnlyList<Food> Food { get; set; } = Array.Empty<Food>();

        [Custom(Name = "Férias")]
        public IReadOnlyList<Vacation> Vacation { get; set; } = Array.Empty<Vacation>();

        [Custom(Name = "Esportes")]
        public IReadOnlyList<Sports> Sports { get; set; } = Array.Empty<Sports>();

        [Custom(Name = "Lazer")]
        public IReadOnlyList<LeisureActivities> LeisureActivities { get; set; } = Array.Empty<LeisureActivities>();

        [Custom(Name = "Música")]
        public IReadOnlyList<MusicGenre> MusicGenre { get; set; } = Array.Empty<MusicGenre>();

        [Custom(Name = "Filme")]
        public IReadOnlyList<MovieGenre> MovieGenre { get; set; } = Array.Empty<MovieGenre>();

        [Custom(Name = "TV")]
        public IReadOnlyList<TVGenre> TVGenre { get; set; } = Array.Empty<TVGenre>();

        [Custom(Name = "Leitura")]
        public IReadOnlyList<ReadingGenre> ReadingGenre { get; set; } = Array.Empty<ReadingGenre>();

        #endregion INTEREST

        public ProfilePreferenceModel Preference { get; set; }

        //public ProfileGamificationModel Gamification { get; set; }
        public ProfileBadgeModel Badge { get; set; }

        public ProfilePhotoModel Photo { get; set; }
        public ProfileReportModel[] Reports { get; set; } = Array.Empty<ProfileReportModel>();

        //public string[] ActiveInteractions { get; set; } = Array.Empty<string>();
        //public string[] PassiveInteractions { get; set; } = Array.Empty<string>();

        public List<Partner> Partners { get; set; } = new();

        private readonly string BlobPath = "https://storageverusdate.blob.core.windows.net";

        public void UpList()
        {
            DtTopList = DateTime.UtcNow;
        }

        public void Login()
        {
            DtLastLogin = DateTime.UtcNow;
        }

        public void UpdateData(ProfileModel profile)
        {
            //BASIC
            Modality = profile.Modality;
            NickName = profile.NickName;
            Description = profile.Description;
            Location = profile.Location;
            Languages = profile.Languages;
            CurrentSituation = profile.CurrentSituation;
            Intentions = profile.Intentions;
            BiologicalSex = profile.BiologicalSex;
            GenderIdentity = profile.GenderIdentity;
            SexualOrientation = profile.SexualOrientation;

            //BIO
            BirthDate = profile.BirthDate;
            Zodiac = profile.Zodiac;
            Height = profile.Height;
            RaceCategory = profile.RaceCategory;
            BodyMass = profile.BodyMass;

            //LIFESTYLE
            Drink = profile.Drink;
            Smoke = profile.Smoke;
            Diet = profile.Diet;
            HaveChildren = profile.HaveChildren;
            WantChildren = profile.WantChildren;
            EducationLevel = profile.EducationLevel;
            CareerCluster = profile.CareerCluster;
            Religion = profile.Religion;
            TravelFrequency = profile.TravelFrequency;

            //PERSONALITY
            MoneyPersonality = profile.MoneyPersonality;
            SplitTheBill = profile.SplitTheBill;
            RelationshipPersonality = profile.RelationshipPersonality;
            MyersBriggsTypeIndicator = profile.MyersBriggsTypeIndicator;
            LoveLanguage = profile.LoveLanguage;
            SexPersonality = profile.SexPersonality;

            //INTEREST
            Food = profile.Food;
            Vacation = profile.Vacation;
            Sports = profile.Sports;
            LeisureActivities = profile.LeisureActivities;
            MusicGenre = profile.MusicGenre;
            MovieGenre = profile.MovieGenre;
            TVGenre = profile.TVGenre;
            ReadingGenre = profile.ReadingGenre;

            //OTHERS
            Neurodiversity = profile.Neurodiversity;
            Disabilities = profile.Disabilities;

            Partners = profile.Partners;

            DtUpdate = DateTime.UtcNow;
        }

        public void UpdateLooking(ProfilePreferenceModel obj)
        {
            Preference = obj;

            DtUpdate = DateTime.UtcNow;
        }

        //public void UpdateGamification(ProfileGamificationModel obj)
        //{
        //    Gamification = obj;

        //    DtUpdate = DateTime.UtcNow;
        //}

        public void UpdateBadge(ProfileBadgeModel obj)
        {
            Badge = obj;

            DtUpdate = DateTime.UtcNow;
        }

        public void UpdatePhoto(ProfilePhotoModel obj)
        {
            Photo = obj;

            DtUpdate = DateTime.UtcNow;
        }

        public int DaysInsert()
        {
            return ProfileHelper.GetDaysPassed(DtInsert.Value);
        }

        public int DaysUpdate()
        {
            if (!DtUpdate.HasValue) return DaysInsert();

            return ProfileHelper.GetDaysPassed(DtUpdate.Value);
        }

        public string GetMainPhoto()
        {
            if (Photo == null || string.IsNullOrEmpty(Photo.Main))
                return GetNoUserPhoto;
            else
                return $"{BlobPath}/{GetPhotoContainer(PhotoType.PhotoFace)}/{Photo.Main}";
        }

        public string[] GetGalleryPhotos()
        {
            if (Photo == null || !Photo.Gallery.Any())
                return Array.Empty<string>();
            else
                return Photo.Gallery.Select(s => $"{BlobPath}/{GetPhotoContainer(PhotoType.PhotoGallery)}/{s}").ToArray();
        }

        public override void SetIds(string IdLoggedUser)
        {
            this.SetId(IdLoggedUser);
            this.SetPartitionKey(IdLoggedUser);
        }

        public enum LocationType
        {
            Full,
            Country,
            State,
            City
        }

        public string GetLocation(LocationType type)
        {
            if (string.IsNullOrEmpty(Location)) return null;

            var parts = Location.Split(" - ");

            switch (type)
            {
                case LocationType.Full:
                    return Location;

                case LocationType.Country:
                    return parts[0];

                case LocationType.State:
                    return parts[1];

                case LocationType.City:
                    if (parts.Length == 4)
                        return parts[2] + " - " + parts[3]; //county - city
                    else
                        return parts[2];

                default:
                    return null;
            }
        }
    }

    public class ProfileView : ProfileModel
    {
        public ActivityStatus ActivityStatus { get; set; }

        [Custom(Name = "Age_Name", ResourceType = typeof(Resources.Model.ProfileBioModel))]
        public int Age { get; set; }
    }

    public class Partner
    {
        [Required]
        [EmailAddress]
        [Custom(Name = "Convidar Parceiro", Prompt = "Email do parceiro", Description = "Precisa ser o mesmo e-mail que será usado no cadastro")]
        public string Email { get; set; }

        public string Id { get; set; }
    }
}