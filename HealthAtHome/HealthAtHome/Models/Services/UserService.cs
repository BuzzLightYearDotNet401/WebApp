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

        private string baseURL = "https://healthathomeapi.azurewebsites.net/api";
        //private string baseURL = "https://localhost:44310/api";


        /// <summary>
        /// Deletes a user from a DB.
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<HttpResponseMessage> DeleteUser(int userId)
        {
            string route = $"users/{userId}";

            client.DefaultRequestHeaders.Accept.Clear();

            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var streamTask = await client.DeleteAsync($"{baseURL}/{route}");

            return streamTask;
        }

        /// <summary>
        /// Get a user from the DB.
        /// </summary>
        /// <returns>A user.</returns>
        public async Task<User> GetUser()
        {
            string route = "users";

            client.DefaultRequestHeaders.Accept.Clear();

            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var streamTask = await client.GetStreamAsync($"{baseURL}/{route}");

            var result = await System.Text.Json.JsonSerializer.DeserializeAsync<User>(streamTask);

            return result;
        }

        /// <summary>
        /// Logs in an existing user.
        /// </summary>
        /// <returns>success or fail.</returns>
        public async Task<List<User>> LogIn()
        {
            string route = "users";

            client.DefaultRequestHeaders.Accept.Clear();

            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var streamTask = await client.GetStreamAsync($"{baseURL}/{route}");

            var result = await System.Text.Json.JsonSerializer.DeserializeAsync<List<User>>(streamTask);

            return result;
        }


        /// <summary>
        /// Registers a new user.
        /// </summary>
        /// <param name="user">The user to register.</param>
        /// <returns>Success or fail.</returns>
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
