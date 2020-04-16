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

            return View(currentUser);
        }
        
        [HttpGet]
        public IActionResult LoginError(LoggedInUser currentUser)
        {
            return View(currentUser);
        }

        [HttpGet]
        public async Task<IActionResult> LogInUser(LoggedInUser user)
        {
           var result = await _user.LogIn();

          foreach (User userObject in result)
            {
                if (userObject.Name == user.UserName)
                {
                    user.IsLoggedIn = true;
                    user.ErrorType = FlashErrors.LoginError;
                    return RedirectToAction("Routines", "Routine", user);
                }                
            }
            user.ErrorFlag = true;
            return RedirectToAction("LoginError", user);
        }

        //TODO create a method to add logic for new user in home controller, will call registerUser()
        [HttpPost]
        public async Task<IActionResult> RegisterUser(LoggedInUser user)
        {
            var userExists = await _user.LogIn();

            foreach (User userObject in userExists)
            {
                if (userObject.Name == user.UserName)
                {
                    user.ErrorFlag = true;
                    user.ErrorType = FlashErrors.RegisterError;
                    return RedirectToAction("LoginError", user);
                }
            }

            User newUser = new User()
            {
                Name = user.UserName
            };

            var result = await _user.RegisterUser(newUser);

            if (result.IsSuccessStatusCode == true)
            {
                return RedirectToAction("Routines", "Routine", user);
            }

            user.ErrorFlag = true;
            user.ErrorType = FlashErrors.RegisterError;
            return RedirectToAction("LoginError", user);
        }
    }
}