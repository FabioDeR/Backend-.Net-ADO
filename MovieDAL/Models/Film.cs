using System;
using System.Collections.Generic;
using System.Text;

namespace MovieDAL.Models
{
    public class Film : IEntity<int>
    {
        public int Id { get; set; }
        public string Titre { get; set; }
        public string Description { get; set; }
        public int ReleaseYear { get; set; }
        public int LanguageId { get; set; }
        public int RentalDuration { get; set; }
        public decimal RentalPrice { get; set; }
        public int Length { get; set; }
        public decimal ReplacementCost { get; set; }
        public int RatingId { get; set; }

        public Film()
        {
        }

        public Film(string titre, string description, int releaseYear, int languageId, int rentalDuration, decimal rentalPrice, int length, decimal replacementCost, int ratingId)
        {
            Titre = titre;
            Description = description;
            ReleaseYear = releaseYear;
            this.LanguageId = languageId;
            RentalDuration = rentalDuration;
            RentalPrice = rentalPrice;
            Length = length;
            ReplacementCost = replacementCost;
            RatingId = ratingId;
        }

        public Film(int id, string titre, string description, int releaseYear, int languageId, int rentalDuration, decimal rentalPrice, int length, decimal replacementCost, int ratingId)
            : this(titre, description, releaseYear, languageId, rentalDuration, rentalPrice, length, replacementCost, ratingId)
        {
            Id = id;

        }

    }
}
