using System;
using System.Net.Http;
using HealthAtHome.Models.Interfaces;

namespace HealthAtHome.Models.Services
{
    public class RatingService : IRating
    {
        private static readonly HttpClient client = new HttpClient();

        //private string baseURL = "https://healthathomeapi.azurewebsites.net/api";
        //private string baseURL = "https://localhost:5001/api";
    }
}
