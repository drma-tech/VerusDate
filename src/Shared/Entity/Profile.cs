using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using VerusDate.Shared.Core;
using VerusDate.Shared.Enum;

namespace VerusDate.Shared.Entity
{
    public class Profile : EntityType
    {
        [Key]
        public string IdUser { get; set; }

        public DateTimeOffset DtTopList { get; set; } //main index for sorting
        public DateTimeOffset DtLastLogin { get; set; } //filter to ensure only active users

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

        public HaveChildren? HaveChildren { get; set; }
        public WantChildren? WantChildren { get; set; }
        public EducationLevel? EducationLevel { get; set; }
        public CareerCluster? CareerCluster { get; set; }
        public Religion? Religion { get; set; }
        public MoneyPersonality? MoneyPersonality { get; set; }
        public RelationshipPersonality? RelationshipPersonality { get; set; }
        public MyersBriggsTypeIndicator? MyersBriggsTypeIndicator { get; set; }
        public string[] Hobbies { get; set; }

        public string MainPhoto { get; set; }

        /// <summary>
        /// conteúdo privado. usado apenas para denúncias
        /// </summary>
        public string MainPhotoValidation { get; set; }

        public string[] PhotoGallery { get; set; }

        public ProfileLooking ProfileLooking { get; set; }
        public Gamification Gamification { get; set; }
        public Badge Badge { get; set; }
        public IEnumerable<Event> Events { get; set; }
        public IEnumerable<Ticket> Tickets { get; set; }
        public IEnumerable<TicketVote> TicketVotes { get; set; }
    }
}