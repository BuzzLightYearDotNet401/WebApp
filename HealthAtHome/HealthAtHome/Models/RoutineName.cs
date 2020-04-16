using System;
using System.Text.Json.Serialization;

namespace HealthAtHome.Models
{
    public class RoutineName
    {
        [JsonPropertyName("routineNameId")]
        public int ID { get; set; }

        [JsonPropertyName("nameOfRoutine")]
        public string Name { get; set; }
    }
}
