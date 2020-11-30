using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using VerusDate.Shared.Core;
using VerusDate.Shared.Enum;

namespace VerusDate.Shared.ViewModel.Command
{
    [Table("Event")]
    public class EventVM : ViewModelCommand
    {
        [ExplicitKey]
        public string IdEvent { get; set; }

        public string IdUser { get; set; }

        [Display(Name = "Data Início")]
        public DateTimeOffset DtStart { get; private set; }

        [Display(Name = "Data Fim")]
        public DateTimeOffset DtEnd { get; private set; }

        [Display(Name = "Tipo de Evento")]
        public EventType EventType { get; private set; }

        [Display(Name = "Localização")]
        public string Location { get; private set; }

        [Display(Name = "Idade (Min - Máx)")]
        public int MinimalAge { get; private set; }

        [Display(Name = "Idade (Min - Máx)")]
        public int MaxAge { get; private set; }

        [Display(Name = "Intenções")]
        public IReadOnlyList<Intent> Intent { get; private set; } = new List<Intent>();

        [Display(Name = "Orientação Sexual")]
        public SexualOrientation[] SexualOrientation { get; private set; }

        [Display(Name = "Equilibrar os gêneros?")]
        public bool GenderDivision { get; private set; }

        public override void LoadDefatultData()
        {
            DtStart = DateTimeOffset.UtcNow.AddDays(7);
            DtEnd = DateTimeOffset.UtcNow.AddDays(7).AddHours(3);
            MinimalAge = 18;
            MaxAge = 40;
        }

        public void NewBlindDate(DateTimeOffset DtStart, string Location, int MinimalAge, int MaxAge, Intent[] Intent,
            SexualOrientation[] SexualOrientation, bool GenderDivision)
        {
            this.DtStart = DtStart;
            this.DtEnd = DtStart.AddDays(7);
            this.EventType = EventType.BlindDate;
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
            this.DtEnd = DtStart.AddHours(1);
            this.EventType = EventType.SpeedDating;
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
            this.EventType = EventType.GroupDate;
            this.Location = Location;
            this.MinimalAge = MinimalAge;
            this.MaxAge = MaxAge;
            this.Intent = Intent;
            this.SexualOrientation = SexualOrientation;
            this.GenderDivision = GenderDivision;
        }
    }
}