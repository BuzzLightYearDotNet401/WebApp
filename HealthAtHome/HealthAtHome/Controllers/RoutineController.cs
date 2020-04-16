using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HealthAtHome.Models.Interfaces;
using HealthAtHome.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace HealthAtHome.Controllers
{
    [Route("[controller]")]
    public class RoutineController : Controller
    {
        private readonly IRoutine _routine;

        public RoutineController(IRoutine routine)
        {
            _routine = routine;
        }

        // Get all Routines View.
        // Route: /routine
        [HttpGet]
        public async Task<IActionResult> Routines(LoggedInUser user)
        {
            
            var result = await _routine.GetAllRoutines();
            user.RoutineNames = result;

            return View(user);
        }

        // Route: /routine/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetARoutine(int id)
        {
            var result = await _routine.GetRoutineById(id);

            return View(result);
        }
    }
}