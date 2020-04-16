using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HealthAtHome.ViewModels;
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
            LoggedInUser currentUser = new LoggedInUser();
            /*currentUser.UserName = userName;
            currentUser.IsLoggedIn = loggedIn;*/

            return View(currentUser);
        }

        [HttpGet]
        public async Task<IActionResult> LogInUser(LoggedInUser user)
        {
           var result = await _user.LogIn();

          //TODO create logic for if user exists
          foreach (User userObject in result)
            {
                if (userObject.Name == user.UserName)
                {
                    user.IsLoggedIn = true;
                    return RedirectToAction("Routines", "Routine", user);
                }
                else
                {
                    user.ErrorFlag = true;
                }
                
            }
            return null;
           
            
        }
        //TODO create a method to add logic for new user in home controller, will call registerUser()

    }
}