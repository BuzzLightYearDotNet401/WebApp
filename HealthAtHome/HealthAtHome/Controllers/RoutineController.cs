using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HealthAtHome.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HealthAtHome.Controllers
{
    [Route("[controller]")]
    public class RoutineController : Controller
    {
        private readonly IExercise _exercise;

        public RoutineController(IExercise exercise)
        {
            _exercise = exercise;
        }

        // Get all Routines View.
        // Route: /routine
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var result = await _exercise.GetAllExercises();

            return View(result);
        }

        // Route: /routine/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetARoutine(int id)
        {
            var result = await _exercise.GetExerciseByID(id);

            return View(result);
        }
    }
}