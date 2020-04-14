using System;
using System.Text.Json.Serialization;

namespace HealthAtHome.Models
{
    public class RoutineName
    {
        [JsonPropertyName("id")]
        public int ID { get; set; }

        [JsonPropertyName("routineName")]
        public string Name { get; set; }
    }
}
