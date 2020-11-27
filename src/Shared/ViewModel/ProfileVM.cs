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
        public string MainPhoto { get; set; }
        public ActivityStatus ActivityStatus { get; set; }

        public string GetPhotoFace()
        {
            if (string.IsNullOrEmpty(MainPhoto))
                return "/img/nouser.jpg";
            else
                return MainPhoto;
        }
    }

    public class ProfileChatListVM : ProfileBasicVM
    {
        public int QtdUnread { get; set; }
    }

    [Table("Profile")]
    public class ProfileVM : ViewModelType
    {
        [ExplicitKey]
        public string Id { get; set; }

        public DateTimeOffset? DtInsert { get; set; }
        public DateTimeOffset? DtUpdate { get; set; }
        public DateTimeOffset? DtTopList { get; set; }
        public DateTimeOffset? DtLastLogin { get; set; }

        [Display(Name = "Nome / Apelido", Prompt = "Ex: Paulo ou Paulinho")]
        public string NickName { get; set; }

        [Display(Name = "Descrição", Prompt = "Para sua própria segurança, favor não incluir seu celular, email ou quaisquer informações de contato. \n\nOBS: Promover redes sociais de outras plataformas ou conteúdo que viole direitos de terceiros estará sujeito a banimento da plataforma.")]
        public string Description { get; set; }

        [Display(Name = "Nascimento")]
        public DateTime BirthDate { get; set; }

        [Display(Name = "Sexo Biológico")]
        public BiologicalSex BiologicalSex { get; set; }

        [Display(Name = "Status de Relacionamento")]
        public MaritalStatus MaritalStatus { get; set; }

        [Display(Name = "Intenção")]
        public Intent[] Intent { get; set; } = Array.Empty<Intent>();

        [Display(Name = "Identidade de Gênero")]
        [SensitiveData]
        public GenderIdentity GenderIdentity { get; set; }

        [Display(Name = "Orientação Sexual")]
        [SensitiveData]
        public SexualOrientation SexualOrientation { get; set; }

        [Display(Name = "Localização")]
        public double? Longitude { get; set; }

        [Display(Name = "Localização")]
        public double? Latitude { get; set; }

        [Write(false)]
        [Display(Name = "Distância")]
        public double? Distance { get; set; }

        [Display(Name = "Localidade")]
        public string Location { get; set; }

        [Display(Name = "Fuma")]
        public Smoke Smoke { get; set; }

        [Display(Name = "Bebe")]
        public Drink Drink { get; set; }

        [Display(Name = "Dieta")]
        public Diet Diet { get; set; }

        [Display(Name = "Altura")]
        public Height Height { get; set; }

        [Display(Name = "Corpo", Description = "Massa Corporal")]
        public BodyMass BodyMass { get; set; }

        [Display(Name = "Raça", Description = "Classificação da Raça")]
        [SensitiveData]
        public RaceCategory RaceCategory { get; set; }

        [Write(false)]
        public ActivityStatus ActivityStatus { get; set; }

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
        public string[] Hobbies { get; set; } = Array.Empty<string>();

        #endregion Data visible only to those with long-term intentions

        public string MainPhoto { get; set; }

        public string[] PhotoGallery { get; set; } = Array.Empty<string>();

        /// <summary>
        /// Indicates that extra data will be displayed (for long-term intentions)
        /// </summary>
        /// <returns></returns>
        public bool IsLongTerm()
        {
            return Intent.Any(x => x == Enum.Intent.Relationship) || Intent.Any(x => x == Enum.Intent.Married);
        }

        public string GetPhotoFace()
        {
            if (string.IsNullOrEmpty(MainPhoto))
                return "/img/nouser.jpg";
            else
                return MainPhoto;
        }

        public void LoadDefatultData()
        {
            BirthDate = DateTime.Now.AddYears(-18);
            GenderIdentity = GenderIdentity.Cisgender;
            SexualOrientation = SexualOrientation.Heteressexual;
            Diet = Diet.Omnivore;
        }

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