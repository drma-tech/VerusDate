using System.ComponentModel.DataAnnotations;
using VerusDate.Shared.Core;

namespace VerusDate.Shared.Entity
{
    public class Badge : EntityType
    {
        [Key]
        [Required]
        public string Id { get; set; }

        public bool Validated { get; set; }
        public bool Popular { get; set; }
    }
}