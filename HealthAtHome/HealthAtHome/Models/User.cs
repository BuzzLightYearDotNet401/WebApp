using System;
using System.Text.Json.Serialization;

namespace HealthAtHome.Models
{
    public class User
    {
        [JsonPropertyName("id")]
        public int ID { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }
    }
}
