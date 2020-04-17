using HealthAtHome.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealthAtHome.Models.Interfaces
{
    public interface IRoutine
    {
        /// <summary>
        /// Get a list of all routines from the DB.
        /// </summary>
        /// <returns>A list of all routines.</returns>
        Task<List<Routine>> GetAllRoutines();

        /// <summary>
        /// Get a single routine from the DB.
        /// </summary>
        /// <param name="id">The routine to get.</param>
        /// <returns>A routine.</returns>
        Task<Routine> GetRoutineById(int id);

        /// <summary>
        /// Get the rating for a routine from the DB.
        /// </summary>
        /// <param name="currentUser">The current user.</param>
        /// <returns>A rating.</returns>
        Task<StarRating> GetRatingForRoutine(LoggedInUser currentUser);
    }
}
