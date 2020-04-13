using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HealthAtHome.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HealthAtHome.Controllers
{
    public class HomeController : Controller
    {
        // The IExercise interface.
        private readonly IExercise _exercise;

        public HomeController(IExercise exercise)
        {
            _exercise = exercise;
        }
        
        public async Task<IActionResult> Index()
        {
            var result = await _exercise.GetAllExercises();
            return View(result);
        }
    }
}