using System.ComponentModel.DataAnnotations;
using VerusDate.Shared.Core;
using VerusDate.Shared.Enum;

namespace VerusDate.Shared.Entity
{
    public class ProfileLooking : EntityType
    {
        [Key]
        public string Id { get; set; }

        public Intent[] Intent { get; set; }
        public double Distance { get; set; }
        public int MinimalAge { get; set; }
        public int MaxAge { get; set; }
        public BiologicalSex? BiologicalSex { get; set; }
        public MaritalStatus? MaritalStatus { get; set; }
        public GenderIdentity? GenderIdentity { get; set; }
        public SexualOrientation? SexualOrientation { get; set; }
        public Smoke? Smoke { get; set; }
        public Drink? Drink { get; set; }
        public Diet? Diet { get; set; }
        public Height? MinimalHeight { get; set; }
        public Height? MaxHeight { get; set; }
        public BodyMass? BodyMass { get; set; }
        public RaceCategory? RaceCategory { get; set; }
        public HaveChildren? HaveChildren { get; set; }
        public WantChildren? WantChildren { get; set; }
        public Religion? Religion { get; set; }
        public EducationLevel? EducationLevel { get; set; }
        public CareerCluster? CareerCluster { get; set; }
    }
}