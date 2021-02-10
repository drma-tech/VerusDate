using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using VerusDate.Shared.Enum;

namespace VerusDate.Shared.Model
{
    public class ProfileInterestModel
    {
        [Display(Name = "Comidas")]
        public IReadOnlyList<Food> Food { get; set; } = Array.Empty<Food>();

        [Display(Name = "Férias")]
        public IReadOnlyList<Holidays> Holidays { get; set; } = Array.Empty<Holidays>();

        [Display(Name = "Esportes")]
        public IReadOnlyList<Sports> Sports { get; set; } = Array.Empty<Sports>();

        [Display(Name = "Lazer")]
        public IReadOnlyList<LeisureActivities> LeisureActivities { get; set; } = Array.Empty<LeisureActivities>();

        [Display(Name = "Música")]
        public IReadOnlyList<Music> Music { get; set; } = Array.Empty<Music>();

        [Display(Name = "Filme")]
        public IReadOnlyList<Movie> Movie { get; set; } = Array.Empty<Movie>();

        [Display(Name = "Leitura")]
        public IReadOnlyList<Reading> Reading { get; set; } = Array.Empty<Reading>();
    }
}