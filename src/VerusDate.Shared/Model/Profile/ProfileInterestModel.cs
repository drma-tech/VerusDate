using System;
using System.Collections.Generic;
using VerusDate.Shared.Core;
using VerusDate.Shared.Enum;

namespace VerusDate.Shared.Model
{
    public class ProfileInterestModel
    {
        [Custom(Name = "Comidas")]
        public IReadOnlyList<Food> Food { get; set; } = Array.Empty<Food>();

        [Custom(Name = "Férias")]
        public IReadOnlyList<Vacation> Vacation { get; set; } = Array.Empty<Vacation>();

        [Custom(Name = "Esportes")]
        public IReadOnlyList<Sports> Sports { get; set; } = Array.Empty<Sports>();

        [Custom(Name = "Lazer")]
        public IReadOnlyList<LeisureActivities> LeisureActivities { get; set; } = Array.Empty<LeisureActivities>();

        [Custom(Name = "Música")]
        public IReadOnlyList<MusicGenre> MusicGenre { get; set; } = Array.Empty<MusicGenre>();

        [Custom(Name = "Filme")]
        public IReadOnlyList<MovieGenre> MovieGenre { get; set; } = Array.Empty<MovieGenre>();

        [Custom(Name = "TV")]
        public IReadOnlyList<TVGenre> TVGenre { get; set; } = Array.Empty<TVGenre>();

        [Custom(Name = "Leitura")]
        public IReadOnlyList<ReadingGenre> ReadingGenre { get; set; } = Array.Empty<ReadingGenre>();
    }
}