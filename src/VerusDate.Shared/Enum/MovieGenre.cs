using VerusDate.Shared.Core;

namespace VerusDate.Shared.Enum
{
    //https://www.studiobinder.com/blog/movie-genres-list/
    public enum MovieGenre
    {
        [Custom(Name = "Action_Name", Description = "Action_Description", ResourceType = typeof(Resources.Enum.MovieGenre))]
        Action = 1,

        [Custom(Name = "Animation_Name", Description = "Animation_Description", ResourceType = typeof(Resources.Enum.MovieGenre))]
        Animation = 2,

        //[Custom(Name = "Biografias", Description = "Em sua essência, os filmes biográficos dramatizam pessoas reais e eventos reais com vários graus de verossimilhança.")]
        //Biopics = 3,

        [Custom(Name = "Comedy_Name", Description = "Comedy_Description", ResourceType = typeof(Resources.Enum.MovieGenre))]
        Comedy = 4,

        [Custom(Name = "Crime_Name", Description = "Crime_Description", ResourceType = typeof(Resources.Enum.MovieGenre))]
        Crime = 5,

        [Custom(Name = "Drama_Name", Description = "Drama_Description", ResourceType = typeof(Resources.Enum.MovieGenre))]
        Drama = 6,

        [Custom(Name = "Experimental_Name", Description = "Experimental_Description", ResourceType = typeof(Resources.Enum.MovieGenre))]
        Experimental = 7,

        [Custom(Name = "Fantasy_Name", Description = "Fantasy_Description", ResourceType = typeof(Resources.Enum.MovieGenre))]
        Fantasy = 8,

        [Custom(Name = "Historical_Name", Description = "Historical_Description", ResourceType = typeof(Resources.Enum.MovieGenre))]
        Historical = 9,

        [Custom(Name = "Horror_Name", Description = "Horror_Description", ResourceType = typeof(Resources.Enum.MovieGenre))]
        Horror = 10,

        [Custom(Name = "Musical_Name", Description = "Musical_Description", ResourceType = typeof(Resources.Enum.MovieGenre))]
        Musical = 11,

        [Custom(Name = "Romance_Name", Description = "Romance_Description", ResourceType = typeof(Resources.Enum.MovieGenre))]
        Romance = 12,

        [Custom(Name = "ScienceFiction_Name", Description = "ScienceFiction_Description", ResourceType = typeof(Resources.Enum.MovieGenre))]
        ScienceFiction = 13,

        [Custom(Name = "Thriller_Name", Description = "Thriller_Description", ResourceType = typeof(Resources.Enum.MovieGenre))]
        Thriller = 14,

        [Custom(Name = "War_Name", Description = "War_Description", ResourceType = typeof(Resources.Enum.MovieGenre))]
        War = 15,

        [Custom(Name = "Western_Name", Description = "Western_Description", ResourceType = typeof(Resources.Enum.MovieGenre))]
        Western = 16
    }
}