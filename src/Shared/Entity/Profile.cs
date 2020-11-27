using System;
using System.ComponentModel.DataAnnotations;
using VerusDate.Shared.Core;
using VerusDate.Shared.Enum;

namespace VerusDate.Shared.Entity
{
    public class Profile : EntityType
    {
        [Key]
        public string Id { get; set; }

        public DateTimeOffset DtInsert { get; set; }
        public DateTimeOffset? DtUpdate { get; set; } //update everytime the user edits the profile
        public DateTimeOffset DtTopList { get; set; } //main index for sorting
        public DateTimeOffset DtLastLogin { get; set; } //filter to ensure only active users

        #region BASIC - REQUIRED FIELDS

        public string NickName { get; set; }
        public string Description { get; set; }
        public DateTime BirthDate { get; set; }
        public BiologicalSex BiologicalSex { get; set; }
        public MaritalStatus MaritalStatus { get; set; }
        public Intent[] Intent { get; set; }
        public GenderIdentity GenderIdentity { get; set; }
        public SexualOrientation SexualOrientation { get; set; }
        public double Longitude { get; set; }
        public double Latitude { get; set; }
        public string Location { get; set; }
        public Height Height { get; set; }
        public BodyMass BodyMass { get; set; }
        public RaceCategory RaceCategory { get; set; }
        public Smoke Smoke { get; set; }
        public Drink Drink { get; set; }
        public Diet Diet { get; set; }

        #endregion BASIC - REQUIRED FIELDS

        #region EXTRA - LIFESTYLE

        public HaveChildren? HaveChildren { get; set; }
        public WantChildren? WantChildren { get; set; }
        public EducationLevel? EducationLevel { get; set; }
        public CareerCluster? CareerCluster { get; set; }
        public Religion? Religion { get; set; }
        public MoneyPersonality? MoneyPersonality { get; set; }
        public RelationshipPersonality? RelationshipPersonality { get; set; }
        public MyersBriggsTypeIndicator? MyersBriggsTypeIndicator { get; set; }
        public string[] Hobbies { get; set; }

        #endregion EXTRA - LIFESTYLE

        #region PHOTOS

        public string MainPhoto { get; set; }

        /// <summary>
        /// conteúdo privado. usado apenas para denúncias
        /// </summary>
        public string MainPhotoValidation { get; set; }

        public string[] PhotoGallery { get; set; }

        #endregion PHOTOS
    }
}