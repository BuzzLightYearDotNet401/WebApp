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
        [ActionName("Routines")]
        [HttpGet]
        public async Task<IActionResult> Routines(LoggedInUser user)
        {
            
            var result = await _routine.GetAllRoutines();
            user.RoutineNames = result;

            return View(user);
        }

        // Route: /routine/5
        [ActionName("GetARoutine")]
        [HttpGet, Route("potato")]
        public async Task<IActionResult> GetARoutine(LoggedInUser user)
        {
            int id = user.RoutineID;

            var result = await _routine.GetRoutineById(id);

            user.RoutineThing = result;

            return View(user);
        }
    }
}