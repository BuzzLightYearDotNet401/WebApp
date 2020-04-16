using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using HealthAtHome.Models.Interfaces;
using Newtonsoft.Json;

namespace HealthAtHome.Models.Services
{
    public class UserService : IUser
    {
        private static readonly HttpClient client = new HttpClient();

        //private string baseURL = "https://healthathomeapi.azurewebsites.net/api";
        private string baseURL = "https://localhost:44310/api";

        public async Task<User> GetUser()
        {
            string route = "users";

            client.DefaultRequestHeaders.Accept.Clear();

            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var streamTask = await client.GetStreamAsync($"{baseURL}/{route}");

            var result = await System.Text.Json.JsonSerializer.DeserializeAsync<User>(streamTask);

            return result;
        }

        public async Task<List<User>> LogIn()
        {
            string route = "users";

            client.DefaultRequestHeaders.Accept.Clear();

            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            // var stringContent = new StringContent(JsonConvert.SerializeObject(user), Encoding.UTF8, "application/json");

            // var streamTask = await client.PostAsync($"{baseURL}/{route}", stringContent);

            var streamTask = await client.GetStreamAsync($"{baseURL}/{route}");

            var result = await System.Text.Json.JsonSerializer.DeserializeAsync<List<User>>(streamTask);

            return result;
        }


        /// <summary>
        /// Sends data for a new user to the API
        /// </summary>
        /// <param name="user">User name</param>
        /// <returns>Response message</returns>
        public async Task<HttpResponseMessage> RegisterUser(User user)
        {

            string route = "users";

            client.DefaultRequestHeaders.Accept.Clear();

            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var stringContent = new StringContent(JsonConvert.SerializeObject(user), Encoding.UTF8, "application/json");

            var streamTask = await client.PostAsync($"{baseURL}/{route}", stringContent);

            return streamTask;
        }

    }
}
