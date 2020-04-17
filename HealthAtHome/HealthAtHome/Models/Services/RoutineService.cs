using HealthAtHome.Models.Interfaces;
using HealthAtHome.ViewModels;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;

namespace HealthAtHome.Models.Services
{
    public class RoutineService : IRoutine
    {
        private static readonly HttpClient client = new HttpClient();

        private string baseURL = "https://healthathomeapi.azurewebsites.net/api";
        //private string baseURL = "https://localhost:44310/api";


        /// <summary>
        /// Get a list of all routines from the DB.
        /// </summary>
        /// <returns>A list of all routines.</returns>
        public async Task<List<Routine>> GetAllRoutines()
        {
            string route = "routinenames";

            client.DefaultRequestHeaders.Accept.Clear();

            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var streamTask = await client.GetStreamAsync($"{baseURL}/{route}");

            var result = await JsonSerializer.DeserializeAsync<List<Routine>>(streamTask);

            return result;
        }

        /// <summary>
        /// Get the rating for a routine from the DB.
        /// </summary>
        /// <param name="currentUser">The current user.</param>
        /// <returns>A rating.</returns>
        public async Task<StarRating> GetRatingForRoutine(LoggedInUser currentUser)
        {
            string route = "ratings";

            client.DefaultRequestHeaders.Accept.Clear();

            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var streamTask = await client.GetStreamAsync($"{baseURL}/{route}");

            var result = await JsonSerializer.DeserializeAsync<List<Rating>>(streamTask);

            foreach (var rating in result)
            {
                if (rating.RoutineNameId == currentUser.RoutineID && rating.UserId == currentUser.ID)
                {
                    var starRating = (StarRating)rating.StarRating;
                    return starRating;
                }
            }

            return 0;
        }

        /// <summary>
        /// Get a single routine from the DB.
        /// </summary>
        /// <param name="id">The routine to get.</param>
        /// <returns>A routine.</returns>
        public async Task<Routine> GetRoutineById(int id)
        {
            string route = $"routinenames/{id}";

            client.DefaultRequestHeaders.Accept.Clear();

            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var streamTask = await client.GetStreamAsync($"{baseURL}/{route}");

            var result = await JsonSerializer.DeserializeAsync<Routine>(streamTask);

            return result;
        }
    }
}

