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

        // GET: /<controller>/
        public IActionResult Rating()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Favorites(LoggedInUser currentUser)
        {
            return View(currentUser);
        }

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
    }
}
