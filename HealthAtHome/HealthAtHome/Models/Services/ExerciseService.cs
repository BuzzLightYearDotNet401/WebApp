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

        public async Task<List<Exercise>> GetAllExercises()
        {
            var baseURL = "https://localhost:44310/api";
            string route = "exercises";

            client.DefaultRequestHeaders.Accept.Clear();

            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var streamTask = await client.GetStreamAsync($"{baseURL}/{route}");

            var result = await JsonSerializer.DeserializeAsync<List<Exercise>>(streamTask);

            return result;
        }

        public async Task<Exercise> GetExerciseByID(int id)
        {
            var baseURL = "https://healthathomeapi.azurewebsites.net/api";
            string route = $"exercises/{id}";

            client.DefaultRequestHeaders.Accept.Clear();

            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var streamTask = await client.GetStreamAsync($"{baseURL}/{route}");

            var result = await JsonSerializer.DeserializeAsync<Exercise>(streamTask);

            return result;
        }
    }
}
