using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace HealthAtHome.Models
{
    public class Routine
    {
        [JsonPropertyName("routineNameId")]
        public int ID { get; set; }

        [JsonPropertyName("nameOfRoutine")]
        public string Name { get; set; }

        [JsonPropertyName("listOfExercises")]
        public List<Exercise> Exercises { get; set; }
    }
}
