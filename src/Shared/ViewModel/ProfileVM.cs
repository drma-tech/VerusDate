using Dapper.Contrib.Extensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using VerusDate.Shared.Core;
using VerusDate.Shared.Enum;

namespace VerusDate.Shared.ViewModel
{
    public class ProfileBasicVM : ViewModelType
    {
        [ExplicitKey]
        public string Id { get; set; }

        public string NickName { get; set; }
        public DateTime BirthDate { get; set; }
        public double? Distance { get; set; }
        public string PhotoFace { get; set; }
        public ActivityStatus ActivityStatus { get; set; }
    }

    public class ProfileChatListVM : ProfileBasicVM
    {
        public int QtdUnread { get; set; }
    }

    public abstract class ProfileBaseVM : ViewModelType
    {
        [ExplicitKey]
        public string Id { get; set; }

        [Display(Name = "Nome / Apelido", Prompt = "Ex: Paulo ou Paulinho")]
        public string NickName { get; set; }

        [Display(Name = "Descrição", Prompt = "Para sua própria segurança, favor não incluir seu celular, email ou quaisquer informações de contato. \n\nOBS: Promover redes sociais de outras plataformas ou conteúdo que viole direitos de terceiros estará sujeito a banimento da plataforma.")]
        public string Description { get; set; }

        [Display(Name = "Nascimento")]
        public DateTime BirthDate { get; set; } = DateTime.Now.AddYears(-18);

        [Display(Name = "Sexo Biológico")]
        public BiologicalSex BiologicalSex { get; set; }

        [Display(Name = "Status de Relacionamento")]
        public MaritalStatus MaritalStatus { get; set; }

        [Display(Name = "Intenção")]
        public Intent[] Intent { get; set; }

        [Display(Name = "Identidade de Gênero")]
        [SensitiveData]
        public GenderIdentity GenderIdentity { get; set; } = GenderIdentity.Cisgender;

        [Display(Name = "Orientação Sexual")]
        [SensitiveData]
        public SexualOrientation SexualOrientation { get; set; } = SexualOrientation.Heteressexual;

        [Write(false)]
        [Display(Name = "Distância")]
        public double? Distance { get; set; }

        [Display(Name = "País")]
        public string CountryName { get; set; }

        [Display(Name = "Estado")]
        public string State { get; set; }

        [Display(Name = "Cidade")]
        public string City { get; set; }

        [Display(Name = "Fuma")]
        public Smoke Smoke { get; set; }

        [Display(Name = "Bebe")]
        public Drink Drink { get; set; }

        [Display(Name = "Dieta")]
        public Diet Diet { get; set; } = Diet.Omnivore;

        [Display(Name = "Altura")]
        public Height Height { get; set; }

        [Display(Name = "Corpo", Description = "Massa Corporal")]
        public BodyMass BodyMass { get; set; }

        [Display(Name = "Raça", Description = "Classificação da Raça")]
        [SensitiveData]
        public RaceCategory RaceCategory { get; set; }

        #region Data visible only to those with long-term intentions

        [Display(Name = "Tem Filho(s)")]
        public HaveChildren? HaveChildren { get; set; }

        [Display(Name = "Quer Filho(s)")]
        public WantChildren? WantChildren { get; set; }

        [Display(Name = "Religião")]
        [SensitiveData]
        public Religion? Religion { get; set; }

        [Display(Name = "Educação")]
        public EducationLevel? EducationLevel { get; set; }

        [Display(Name = "Carreira")]
        public CareerCluster? CareerCluster { get; set; }

        [Display(Name = "Personalidade Financeira")]
        [SensitiveData]
        public MoneyPersonality? MoneyPersonality { get; set; }

        [Display(Name = "Personalidade no Relacionamento")]
        [SensitiveData]
        public RelationshipPersonality? RelationshipPersonality { get; set; }

        [Display(Name = "Personalidade MBTI")]
        public MyersBriggsTypeIndicator? MyersBriggsTypeIndicator { get; set; }

        [Display(Name = "Hobbies")]
        public string[] Hobbies { get; set; }

        #endregion Data visible only to those with long-term intentions

        #region PHOTOS

        public string PhotoFileName1 { get; set; }
        public string PhotoFileName2 { get; set; }
        public string PhotoFileName3 { get; set; }
        public string PhotoFileName4 { get; set; }
        public string PhotoFileName5 { get; set; }

        #endregion PHOTOS

        /// <summary>
        /// Indicates that extra data will be displayed (for long-term intentions)
        /// </summary>
        /// <returns></returns>
        public bool IsLongTerm()
        {
            return Intent.Any(x => x == Enum.Intent.Relationship) || Intent.Any(x => x == Enum.Intent.Married);
        }
    }

    /// <summary>
    /// view other profile users
    /// </summary>
    [Table("Profile")]
    public class ProfileViewVM : ProfileBaseVM
    {
        public ActivityStatus ActivityStatus { get; set; } = ActivityStatus.Disabled;
    }

    /// <summary>
    /// Visible only for the logged user
    /// </summary>
    [Table("Profile")]
    public class ProfileUserVM : ProfileBaseVM
    {
        public DateTimeOffset? DtUpdate { get; set; } //update everytime the user edits the profile
        public DateTimeOffset DtLastLogin { get; set; } //filter to ensure only active users

        [Display(Name = "Localização")]
        public double? Longitude { get; set; }

        [Display(Name = "Localização")]
        public double? Latitude { get; set; }

        public void ClearSimpleView()
        {
            if (!IsLongTerm())
            {
                EducationLevel = null;
                HaveChildren = null;
                WantChildren = null;
                CareerCluster = null;
                Religion = null;
                MoneyPersonality = null;
                RelationshipPersonality = null;
                MyersBriggsTypeIndicator = null;
            }
        }
    }
}