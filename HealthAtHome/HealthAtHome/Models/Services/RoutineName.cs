﻿using System;
using System.Net.Http;

namespace HealthAtHome.Models.Services
{
    public class RoutineName
    {
        private static readonly HttpClient client = new HttpClient();

        private string baseURL = "https://healthathomeapi.azurewebsites.net/api";
        //private string baseURL = "https://localhost:5001/api";
    }
}
