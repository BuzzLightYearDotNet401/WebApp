using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HealthAtHome.Models;
using HealthAtHome.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HealthAtHome.Controllers
{
    public class HomeController : Controller
    {
        // The IExercise interface.
        private readonly IUser _user;

        public HomeController(IUser user)
        {
            _user = user;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(User user)
        {
            var result = await _user.LogIn(user);

          //TODO create logic for if user exists
           
            return null;
        }
        //TODO create a method to add logic for new user in home controller, will call registerUser()

    }
}