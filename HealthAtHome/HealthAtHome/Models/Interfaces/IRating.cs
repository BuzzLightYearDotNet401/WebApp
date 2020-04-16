using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace HealthAtHome.Models.Interfaces
{
    public interface IRating
    {
        Task<HttpResponseMessage> CreateRating(Rating rating);
    }
}
