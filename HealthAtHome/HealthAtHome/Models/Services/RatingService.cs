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

        //private string baseURL = "https://healthathomeapi.azurewebsites.net/api";
        private string baseURL = "https://localhost:44310/api";

        public async Task<HttpResponseMessage> CreateRating(Rating rating)
        {

            string route = "ratings";

            client.DefaultRequestHeaders.Accept.Clear();

            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var stringContent = new StringContent(JsonConvert.SerializeObject(rating), Encoding.UTF8, "application/json");

            var streamTask = await client.PostAsync($"{baseURL}/{route}", stringContent);

            return streamTask;
        }
    }
}
