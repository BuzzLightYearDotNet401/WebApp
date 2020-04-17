using HealthAtHome.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;

namespace HealthAtHome.Models.Services
{
    public class ExerciseService : IExercise
    {
        private static readonly HttpClient client = new HttpClient();

        private string baseURL = "https://healthathomeapi.azurewebsites.net/api";
        //private string baseURL = "https://localhost:5001/api";

        /// <summary>
        /// Get all the exercises from the DB.
        /// </summary>
        /// <returns>A list of all Exercises.</returns>
        public async Task<List<Exercise>> GetAllExercises()
        {
            string route = "exercises";

            client.DefaultRequestHeaders.Accept.Clear();

            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var streamTask = await client.GetStreamAsync($"{baseURL}/{route}");

            var result = await JsonSerializer.DeserializeAsync<List<Exercise>>(streamTask);

            return result;
        }

        /// <summary>
        /// Get an exercise from the DB.
        /// </summary>
        /// <param name="id">The exercise ID.</param>
        /// <returns>A single exercise from the DB.</returns>
        public async Task<Exercise> GetExerciseByID(int id)
        {
            string route = $"exercises/{id}";

            client.DefaultRequestHeaders.Accept.Clear();

            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var streamTask = await client.GetStreamAsync($"{baseURL}/{route}");

            var result = await JsonSerializer.DeserializeAsync<Exercise>(streamTask);

            return result;
        }
    }
}
