using System;
using System.ComponentModel.DataAnnotations;
using VerusDate.Shared.Core;
using VerusDate.Shared.Enum;

namespace VerusDate.Shared.Entity
{
    public class Event : EntityType
    {
        [Key]
        public string Id { get; set; }

        public DateTimeOffset DtStart { get; set; }
        public DateTimeOffset DtEnd { get; set; }
        public EventType EventType { get; set; }
        public string CountryName { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public int MinimalAge { get; set; }
        public int MaxAge { get; set; }
        public Intent[] Intent { get; set; }
        public SexualOrientation[] SexualOrientation { get; set; }
        public bool GenderDivision { get; set; }
    }
}