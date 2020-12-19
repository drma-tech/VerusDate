using System;
using System.ComponentModel.DataAnnotations;
using VerusDate.Shared.Core;

namespace VerusDate.Shared.Entity
{
    public class Suggestions : EntityType
    {
        [Key]
        public string IdUser { get; set; }

        [Key]
        public string IdUserSuggestion { get; set; }

        public DateTimeOffset DtExpiration { get; set; }
    }
}