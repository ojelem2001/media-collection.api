using System.ComponentModel.DataAnnotations;

namespace MediaCollection.Core.Models.Enum;

public enum AggregatorType
{
    [Display(Name = "IMDB")]
    Imdb = 1,

    [Display(Name = "Kinopoisk")]
    Kinopoisk = 2,

    [Display(Name = "Letterboxd")]
    Letterboxd = 3
}