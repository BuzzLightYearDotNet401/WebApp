using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using HealthAtHome.Models.Interfaces;
using Newtonsoft.Json;

namespace HealthAtHome.Models.Services
{
    public class RatingService : IRating
    {
        private static readonly HttpClient client = new HttpClient();

        private string baseURL = "https://healthathomeapi.azurewebsites.net/api";
        //private string baseURL = "https://localhost:44310/api";

        /// <summary>
        /// Create a new rating for a routine.
        /// </summary>
        /// <param name="rating">The rating to insert into the DB.</param>
        /// <returns>The rating.</returns>
        public async Task<HttpResponseMessage> CreateRating(Rating rating)
        {

            string route = "ratings";

            client.DefaultRequestHeaders.Accept.Clear();

            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var stringContent = new StringContent(JsonConvert.SerializeObject(rating), Encoding.UTF8, "application/json");

            var streamTask = await client.PostAsync($"{baseURL}/{route}", stringContent);

            return streamTask;
        }

        /// <summary>
        /// Updates an existing rating in the DB.
        /// </summary>
        /// <param name="rating">the rating to update.</param>
        /// <returns>The rating.</returns>
        public async Task<HttpResponseMessage> UpdateRating(Rating rating)
        {
            string route = $"ratings/{rating.ID}";

            client.DefaultRequestHeaders.Accept.Clear();

            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var stringContent = new StringContent(JsonConvert.SerializeObject(rating), Encoding.UTF8, "application/json");

            var streamTask = await client.PutAsync($"{baseURL}/{route}", stringContent);

            return streamTask;
        }
    }
}
