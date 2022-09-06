using System;
using System.Collections.Generic;
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

        [Custom(Name = "Data Início")]
        public DateTime DtStart { get; set; } = DateTime.UtcNow.AddDays(7);

        [Custom(Name = "Data Fim")]
        public DateTime DtEnd { get; set; } = DateTime.UtcNow.AddDays(7).AddHours(3);

        [Custom(Name = "Tipo de Evento")]
        public EventType EventType { get; set; }

        [Custom(Name = "Localização")]
        public string Location { get; set; }

        [Custom(Name = "Idade (Min - Máx)")]
        public int MinimalAge { get; set; } = 18;

        [Custom(Name = "Idade (Min - Máx)")]
        public int MaxAge { get; set; } = 40;

        [Custom(Name = "Intenções")]
        public IReadOnlyList<Intentions> Intentions { get; set; } = new List<Intentions>();

        [Custom(Name = "Orientação Sexual")]
        public SexualOrientation[] SexualOrientation { get; set; }

        [Custom(Name = "Equilibrar os gêneros?")]
        public bool GenderDivision { get; set; }

        public void NewBlindDate(DateTime DtStart, string Location, int MinimalAge, int MaxAge, Intentions[] Intentions,
            SexualOrientation[] SexualOrientation, bool GenderDivision)
        {
            this.DtStart = DtStart;
            DtEnd = DtStart.AddDays(7);
            EventType = EventType.BlindDate;
            this.Location = Location;
            this.MinimalAge = MinimalAge;
            this.MaxAge = MaxAge;
            this.Intentions = Intentions;
            this.SexualOrientation = SexualOrientation;
            this.GenderDivision = GenderDivision;
        }

        public void NewSpeedDating(DateTime DtStart, string Location, int MinimalAge, int MaxAge, Intentions[] Intentions,
            SexualOrientation[] SexualOrientation, bool GenderDivision)
        {
            this.DtStart = DtStart;
            DtEnd = DtStart.AddHours(1);
            EventType = EventType.SpeedDating;
            this.Location = Location;
            this.MinimalAge = MinimalAge;
            this.MaxAge = MaxAge;
            this.Intentions = Intentions;
            this.SexualOrientation = SexualOrientation;
            this.GenderDivision = GenderDivision;
        }

        public void NewGroupDate(DateTime DtStart, DateTime DtEnd, string Location, int MinimalAge, int MaxAge, Intentions[] Intentions,
            SexualOrientation[] SexualOrientation, bool GenderDivision)
        {
            this.DtStart = DtStart;
            this.DtEnd = DtEnd;
            EventType = EventType.GroupDate;
            this.Location = Location;
            this.MinimalAge = MinimalAge;
            this.MaxAge = MaxAge;
            this.Intentions = Intentions;
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