using System.ComponentModel.DataAnnotations;
using VerusDate.Shared.Core;

namespace VerusDate.Shared.Entity
{
    public class Gamification : EntityType
    {
        [Key]
        public string IdUser { get; set; }

        public int Rank { get; set; }
        public int XP { get; set; }
        public int Food { get; set; }
        public int Diamond { get; set; }

        public Profile Profile { get; set; }
    }
}