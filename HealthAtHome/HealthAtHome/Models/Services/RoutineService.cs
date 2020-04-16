﻿using HealthAtHome.Models.Interfaces;
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

        //private string baseURL = "https://healthathomeapi.azurewebsites.net/api";
        private string baseURL = "https://localhost:44310/api";

        public async Task<List<Routine>> GetAllRoutines()
        {
            string route = "routinenames";

            client.DefaultRequestHeaders.Accept.Clear();

            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var streamTask = await client.GetStreamAsync($"{baseURL}/{route}");

            var result = await JsonSerializer.DeserializeAsync<List<Routine>>(streamTask);

            return result;
        }

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
