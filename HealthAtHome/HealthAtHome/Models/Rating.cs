using System;
using System.Text.Json.Serialization;

namespace HealthAtHome.Models
{
    public class Rating
    {
        // Primary key

        [JsonPropertyName("id")]
        public int ID { get; set; }

        // Foreign key

        [JsonPropertyName("userID")]
        public int UserID { get; set; }

        [JsonPropertyName("routineID")]
        public int RoutineID { get; set; }

        //Payload

        [JsonPropertyName("starRating")]
        public int StarRating { get; set; }

        [JsonPropertyName("isCurrent")]
        public bool IsCurrent { get; set; }
    }
}
