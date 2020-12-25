using System;
using System.ComponentModel.DataAnnotations;
using VerusDate.Shared.Enum;

namespace VerusDate.Shared.Model.Profile
{
    public class ProfileBio
    {
        [Display(Name = "Nascimento")]
        public DateTime BirthDate { get; set; } = DateTime.Now.AddYears(-18);

        [Display(Name = "Altura")]
        public Height Height { get; set; }

        [Display(Name = "Raça", Description = "Classificação da Raça")]
        public RaceCategory RaceCategory { get; set; }

        [Display(Name = "Corpo", Description = "Massa Corporal")]
        public BodyMass BodyMass { get; set; }
    }
}