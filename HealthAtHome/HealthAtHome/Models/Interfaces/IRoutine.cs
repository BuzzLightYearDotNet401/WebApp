using HealthAtHome.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealthAtHome.Models.Interfaces
{
    public interface IRoutine
    {
        Task<List<Routine>> GetAllRoutines();

        Task<Routine> GetRoutineById(int id);

        Task<StarRating> GetRatingForRoutine(LoggedInUser currentUser);
    }
}
