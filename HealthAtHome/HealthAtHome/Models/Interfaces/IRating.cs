using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace HealthAtHome.Models.Interfaces
{
    public interface IRating
    {
        /// <summary>
        /// Create a new rating for a routine.
        /// </summary>
        /// <param name="rating">The rating to insert into the DB.</param>
        /// <returns>The rating.</returns>
        Task<HttpResponseMessage> CreateRating(Rating rating);

        /// <summary>
        /// Updates an existing rating in the DB.
        /// </summary>
        /// <param name="rating">the rating to update.</param>
        /// <returns>The rating.</returns>
        Task<HttpResponseMessage> UpdateRating(Rating rating);
    }
}
