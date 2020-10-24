using System.ComponentModel.DataAnnotations;
using VerusDate.Shared.Core;

namespace VerusDate.Shared.Entity
{
    public class Gamification : EntityType
    {
        [Key]
        [Required]
        public string Id { get; set; }

        public int XP { get; set; }

        public int Level { get; set; }

        public int Diamond { get; set; }

        public int Food { get; set; }
    }
}