using Dapper.Contrib.Extensions;
using System;
using VerusDate.Shared.Core;
using VerusDate.Shared.Enum;

namespace VerusDate.Shared.ViewModel
{
    [Table("Event")]
    public class EventVM : ViewModelType
    {
        [ExplicitKey]
        public string Id { get; set; }

        public DateTimeOffset DtStart { get; set; } = DateTimeOffset.UtcNow.AddDays(7);
        public DateTimeOffset DtEnd { get; set; }
        public EventType EventType { get; set; }
        public string CountryName { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public int MinimalAge { get; set; } = 18;
        public int MaxAge { get; set; } = 120;
        public Intent[] Intent { get; set; }
        public SexualOrientation[] SexualOrientation { get; set; }
        public bool GenderDivision { get; set; }

        public void NewBlindDate(DateTimeOffset DtStart, string CountryName, string State, string City, int MinimalAge, int MaxAge, Intent[] Intent,
            SexualOrientation[] SexualOrientation, bool GenderDivision)
        {
            this.DtStart = DtStart;
            this.DtEnd = DtStart.AddDays(7);
            this.EventType = EventType.BlindDate;
            this.CountryName = CountryName;
            this.State = State;
            this.City = City;
            this.MinimalAge = MinimalAge;
            this.MaxAge = MaxAge;
            this.Intent = Intent;
            this.SexualOrientation = SexualOrientation;
            this.GenderDivision = GenderDivision;
        }

        public void NewSpeedDating(DateTimeOffset DtStart, string CountryName, string State, string City, int MinimalAge, int MaxAge, Intent[] Intent,
            SexualOrientation[] SexualOrientation, bool GenderDivision)
        {
            this.DtStart = DtStart;
            this.DtEnd = DtStart.AddHours(1);
            this.EventType = EventType.SpeedDating;
            this.CountryName = CountryName;
            this.State = State;
            this.City = City;
            this.MinimalAge = MinimalAge;
            this.MaxAge = MaxAge;
            this.Intent = Intent;
            this.SexualOrientation = SexualOrientation;
            this.GenderDivision = GenderDivision;
        }

        public void NewGroupDate(DateTimeOffset DtStart, DateTimeOffset DtEnd, string CountryName, string State, string City, int MinimalAge, int MaxAge, Intent[] Intent,
            SexualOrientation[] SexualOrientation, bool GenderDivision)
        {
            this.DtStart = DtStart;
            this.DtEnd = DtEnd;
            this.EventType = EventType.GroupDate;
            this.CountryName = CountryName;
            this.State = State;
            this.City = City;
            this.MinimalAge = MinimalAge;
            this.MaxAge = MaxAge;
            this.Intent = Intent;
            this.SexualOrientation = SexualOrientation;
            this.GenderDivision = GenderDivision;
        }
    }
}