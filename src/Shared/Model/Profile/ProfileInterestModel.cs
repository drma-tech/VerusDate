using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using VerusDate.Shared.Enum;

namespace VerusDate.Shared.Model
{
    public class ProfileInterestModel
    {
        [Display(Name = "Comidas", Description = "Este campo é opcional (escolha até 3 opções)")]
        public IReadOnlyList<Food> Food { get; set; } = Array.Empty<Food>();

        [Display(Name = "Férias", Description = "Este campo é opcional (escolha até 3 opções)")]
        public IReadOnlyList<Holidays> Holidays { get; set; } = Array.Empty<Holidays>();

        [Display(Name = "Esportes", Description = "Este campo é opcional (escolha até 3 opções)")]
        public IReadOnlyList<Sports> Sports { get; set; } = Array.Empty<Sports>();

        [Display(Name = "Lazer", Description = "Este campo é opcional (escolha até 3 opções)")]
        public IReadOnlyList<LeisureActivities> LeisureActivities { get; set; } = Array.Empty<LeisureActivities>();

        [Display(Name = "Música", Description = "Este campo é opcional (escolha até 3 opções)")]
        public IReadOnlyList<MusicGenre> MusicGenre { get; set; } = Array.Empty<MusicGenre>();

        [Display(Name = "Filme", Description = "Este campo é opcional (escolha até 3 opções)")]
        public IReadOnlyList<MovieGenre> MovieGenre { get; set; } = Array.Empty<MovieGenre>();

        [Display(Name = "TV", Description = "Este campo é opcional (escolha até 3 opções)")]
        public IReadOnlyList<TVGenre> TVGenre { get; set; } = Array.Empty<TVGenre>();

        [Display(Name = "Leitura", Description = "Este campo é opcional (escolha até 3 opções)")]
        public IReadOnlyList<ReadingGenre> ReadingGenre { get; set; } = Array.Empty<ReadingGenre>();
    }
}