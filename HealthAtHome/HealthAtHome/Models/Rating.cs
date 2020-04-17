using System;
using System.Text.Json.Serialization;

namespace HealthAtHome.Models
{
    public class Rating
    {
        [JsonPropertyName("ratingId")]
        public int ID { get; set; }

        [JsonPropertyName("userId")]
        public int UserId { get; set; }

        [JsonPropertyName("routineNameId")]
        public int RoutineNameId { get; set; }

        [JsonPropertyName("starRating")]
        public int StarRating { get; set; }
    }

    public enum StarRating
    {
        RatingNotFound = 0,
        OneStar = 1,
        TwoStar = 2,
        ThreeStar = 3,
        FourStar = 4,
        FiveStar = 5
    }
}
