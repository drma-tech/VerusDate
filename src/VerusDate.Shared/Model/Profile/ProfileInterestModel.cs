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
        public IReadOnlyList<Vacation> Vacation { get; set; } = Array.Empty<Vacation>();

        [Display(Name = "Esportes")]
        public IReadOnlyList<Sports> Sports { get; set; } = Array.Empty<Sports>();

        [Display(Name = "Lazer")]
        public IReadOnlyList<LeisureActivities> LeisureActivities { get; set; } = Array.Empty<LeisureActivities>();

        [Display(Name = "Música")]
        public IReadOnlyList<MusicGenre> MusicGenre { get; set; } = Array.Empty<MusicGenre>();

        [Display(Name = "Filme")]
        public IReadOnlyList<MovieGenre> MovieGenre { get; set; } = Array.Empty<MovieGenre>();

        [Display(Name = "TV")]
        public IReadOnlyList<TVGenre> TVGenre { get; set; } = Array.Empty<TVGenre>();

        [Display(Name = "Leitura")]
        public IReadOnlyList<ReadingGenre> ReadingGenre { get; set; } = Array.Empty<ReadingGenre>();
    }
}