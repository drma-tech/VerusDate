using System;
using System.ComponentModel.DataAnnotations;
using VerusDate.Shared.Enum;

namespace VerusDate.Shared.Model
{
    public class ProfileBioModel
    {
        [Display(Name = "Nascimento", Description = "Confira a idade e signo")]
        public DateTime BirthDate { get; set; }

        [Display(Name = "Altura", Description = "Pode ser um valor aproximado")]
        public Height Height { get; set; }

        [Display(Name = "Raça", Description = "Classificação por US OMB")]
        public RaceCategory RaceCategory { get; set; }

        [Display(Name = "Corpo", Description = "Massa Corporal")]
        public BodyMass BodyMass { get; set; }
    }
}