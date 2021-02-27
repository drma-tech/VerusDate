using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using VerusDate.Shared.Core;
using VerusDate.Shared.Enum;

namespace VerusDate.Shared.Model
{
    public class EventModel : CosmosBase
    {
        public EventModel() : base(CosmosType.Event)
        {
        }

        public string IdUserOwner { get; set; }

        [Display(Name = "Data Início")]
        public DateTime DtStart { get; set; } = DateTime.UtcNow.AddDays(7);

        [Display(Name = "Data Fim")]
        public DateTime DtEnd { get; set; } = DateTime.UtcNow.AddDays(7).AddHours(3);

        [Display(Name = "Tipo de Evento")]
        public EventType EventType { get; set; }

        [Display(Name = "Localização")]
        public string Location { get; set; }

        [Display(Name = "Idade (Min - Máx)")]
        public int MinimalAge { get; set; } = 18;

        [Display(Name = "Idade (Min - Máx)")]
        public int MaxAge { get; set; } = 40;

        [Display(Name = "Intenções")]
        public IReadOnlyList<Intent> Intent { get; set; } = new List<Intent>();

        [Display(Name = "Orientação Sexual")]
        public SexualOrientation[] SexualOrientation { get; set; }

        [Display(Name = "Equilibrar os gêneros?")]
        public bool GenderDivision { get; set; }

        public void NewBlindDate(DateTime DtStart, string Location, int MinimalAge, int MaxAge, Intent[] Intent,
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

        public void NewSpeedDating(DateTime DtStart, string Location, int MinimalAge, int MaxAge, Intent[] Intent,
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

        public void NewGroupDate(DateTime DtStart, DateTime DtEnd, string Location, int MinimalAge, int MaxAge, Intent[] Intent,
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

        public override void SetIds(string IdLoggedUser)
        {
            var guid = Guid.NewGuid().ToString();
            this.SetId(guid);
            this.SetPartitionKey(guid);
            this.IdUserOwner = IdLoggedUser;
        }

        public string GetIcon()
        {
            return EventType switch
            {
                EventType.BlindDate => "fas fa-eye-slash",
                EventType.SpeedDating => "fas fa-user-clock",
                EventType.GroupDate => "fas fa-users",
                _ => throw new IndexOutOfRangeException(nameof(EventType)),
            };
        }
    }
}