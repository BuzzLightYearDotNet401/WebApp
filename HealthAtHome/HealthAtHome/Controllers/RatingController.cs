using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HealthAtHome.Models;
using HealthAtHome.Models.Interfaces;
using HealthAtHome.ViewModels;
using Microsoft.AspNetCore.Mvc;


namespace HealthAtHome.Controllers
{
    [Route("[controller]")]
    public class RatingController : Controller
    {
        private readonly IRating _rating;

        public RatingController(IRating rating)
        {
            _rating = rating;
        }

        // STRETCH
        [HttpGet]
        public IActionResult Favorites(LoggedInUser currentUser)
        {
            return View(currentUser);
        }

        /// <summary>
        /// Create a new rating for a routine and user.
        /// </summary>
        /// <param name="currentUser">The current user.</param>
        /// <returns>The specific Routine View.</returns>
        [HttpPost]
        public async Task<IActionResult> CreateRating(LoggedInUser currentUser)
        {
            Rating newRating = new Rating()
            {
                UserId = currentUser.ID,
                RoutineNameId = currentUser.RoutineID,
                StarRating =(int) currentUser.Rating
            };

            var result = await _rating.CreateRating(newRating);

            if (result.IsSuccessStatusCode == true)
            {
                return RedirectToAction("GetARoutine", "Routine", currentUser);
            }

            return RedirectToAction("GetARoutine", "Routine", currentUser);
        }

        /// <summary>
        /// Updates an existing rating for a routine.
        /// </summary>
        /// <param name="currentUser">The current user.</param>
        /// <returns>The specific routine View.</returns>
        [HttpPost, Route("bananas")]
        public async Task<IActionResult> UpdateRating(LoggedInUser currentUser)
        {
            Rating updatedRating = new Rating()
            {
                UserId = currentUser.ID,
                RoutineNameId = currentUser.RoutineID,
                StarRating = (int)currentUser.Rating
            };

            var result = await _rating.UpdateRating(updatedRating);

            if (result.IsSuccessStatusCode == true)
            {
                return RedirectToAction("GetARoutine", "Routine", currentUser);
            }

            return RedirectToAction("GetARoutine", "Routine", currentUser);
        }
    }
}
