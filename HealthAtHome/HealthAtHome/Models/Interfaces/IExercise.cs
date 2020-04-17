using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealthAtHome.Models.Interfaces
{
    public interface IExercise
    {
        /// <summary>
        /// Get all the exercises from the DB.
        /// </summary>
        /// <returns>A list of all Exercises.</returns>
        Task<List<Exercise>> GetAllExercises();

        /// <summary>
        /// Get an exercise from the DB.
        /// </summary>
        /// <param name="id">The exercise ID.</param>
        /// <returns>A single exercise from the DB.</returns>
        Task<Exercise> GetExerciseByID(int id);
    }
}
