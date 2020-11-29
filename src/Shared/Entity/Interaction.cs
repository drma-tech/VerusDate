using System.ComponentModel.DataAnnotations;
using VerusDate.Shared.Core;

namespace VerusDate.Shared.Entity
{
    public class Interaction : EntityType
    {
        [Key]
        public string Id { get; set; }

        [Key]
        public string IdUserInteraction { get; set; }

        public ValueType.Action Like { get; set; }
        public ValueType.Action Deslike { get; set; }
        public ValueType.Action Match { get; set; }
        public ValueType.Action Blink { get; set; }
        public ValueType.Action Block { get; set; }

        public string IdChat { get; set; }
    }
}