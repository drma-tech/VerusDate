using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using VerusDate.Shared.Core;
using VerusDate.Shared.Enum;

namespace VerusDate.Shared.Model.Event
{
    public class Event : CosmosBase
    {
        public Event() : base("Event")
        {
        }

        public DateTimeOffset? DtInsert { get; set; } = DateTimeOffset.UtcNow;
        public DateTimeOffset? DtUpdate { get; set; }
        public string IdUserOwner { get; private set; }

        [Display(Name = "Data Início")]
        public DateTimeOffset DtStart { get; private set; } = DateTimeOffset.UtcNow.AddDays(7);

        [Display(Name = "Data Fim")]
        public DateTimeOffset DtEnd { get; private set; } = DateTimeOffset.UtcNow.AddDays(7).AddHours(3);

        [Display(Name = "Tipo de Evento")]
        public EventType EventType { get; private set; }

        [Display(Name = "Localização")]
        public string Location { get; private set; }

        [Display(Name = "Idade (Min - Máx)")]
        public int MinimalAge { get; private set; } = 18;

        [Display(Name = "Idade (Min - Máx)")]
        public int MaxAge { get; private set; } = 40;

        [Display(Name = "Intenções")]
        public IReadOnlyList<Intent> Intent { get; private set; } = new List<Intent>();

        [Display(Name = "Orientação Sexual")]
        public SexualOrientation[] SexualOrientation { get; private set; }

        [Display(Name = "Equilibrar os gêneros?")]
        public bool GenderDivision { get; private set; }

        public void NewBlindDate(DateTimeOffset DtStart, string Location, int MinimalAge, int MaxAge, Intent[] Intent,
            SexualOrientation[] SexualOrientation, bool GenderDivision)
        {
            this.DtStart = DtStart;
            DtEnd = DtStart.AddDays(7);
            EventType = EventType.BlindDate;
            this.Location = Location;
            this.MinimalAge = MinimalAge;
            this.MaxAge = MaxAge;
            this.Intent = Intent;
            this.SexualOrientation = SexualOrientation;
            this.GenderDivision = GenderDivision;
        }

        public void NewSpeedDating(DateTimeOffset DtStart, string Location, int MinimalAge, int MaxAge, Intent[] Intent,
            SexualOrientation[] SexualOrientation, bool GenderDivision)
        {
            this.DtStart = DtStart;
            DtEnd = DtStart.AddHours(1);
            EventType = EventType.SpeedDating;
            this.Location = Location;
            this.MinimalAge = MinimalAge;
            this.MaxAge = MaxAge;
            this.Intent = Intent;
            this.SexualOrientation = SexualOrientation;
            this.GenderDivision = GenderDivision;
        }

        public void NewGroupDate(DateTimeOffset DtStart, DateTimeOffset DtEnd, string Location, int MinimalAge, int MaxAge, Intent[] Intent,
            SexualOrientation[] SexualOrientation, bool GenderDivision)
        {
            this.DtStart = DtStart;
            this.DtEnd = DtEnd;
            EventType = EventType.GroupDate;
            this.Location = Location;
            this.MinimalAge = MinimalAge;
            this.MaxAge = MaxAge;
            this.Intent = Intent;
            this.SexualOrientation = SexualOrientation;
            this.GenderDivision = GenderDivision;
        }

        public override void SetIdLoggedUser(string IdUser)
        {
            this.IdUserOwner = IdUser;
        }
    }
}