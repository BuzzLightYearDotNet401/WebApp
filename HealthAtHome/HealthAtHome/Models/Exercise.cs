using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace HealthAtHome.Models
{
    public class Exercise
    {
        [JsonPropertyName("exerciseId")]
        public int ID { get; set; }

        [JsonPropertyName("exerciseName")]
        public string Name { get; set; }

        [JsonPropertyName("sets")]
        public int Sets { get; set; }

        [JsonPropertyName("reps")]
        public int Reps { get; set; }

        [JsonPropertyName("image")]
        public string Image { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }
    }
}
