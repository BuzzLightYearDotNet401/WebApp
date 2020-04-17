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
        /// <summary>
        /// The IUser interface.
        /// </summary>
        private readonly IUser _user;

        /// <summary>
        /// Constructor method to bring in the IUser interface.
        /// </summary>
        /// <param name="user">The IUser interface.</param>
        public HomeController(IUser user)
        {
            _user = user;
        }

        /// <summary>
        /// Returns the Index View.
        /// </summary>
        /// <returns>The Index View.</returns>
        [HttpGet]
        public IActionResult Index()
        {
            LoggedInUser currentUser = new LoggedInUser();

            return View(currentUser);
        }
        
        /// <summary>
        /// Returns an error on login or registration.
        /// </summary>
        /// <param name="currentUser">The user View Model.</param>
        /// <returns>The error View.</returns>
        [HttpGet]
        public IActionResult LoginError(LoggedInUser currentUser)
        {
            return View(currentUser);
        }

        /// <summary>
        /// Logs in an existing user.
        /// </summary>
        /// <param name="user">The user View Model.</param>
        /// <returns>Redirects to Routines View.</returns>
        [HttpGet]
        public async Task<IActionResult> LogInUser(LoggedInUser user)
        {
            // Get all users in DB.
           var result = await _user.LogIn();

            // Check each one for a matching usernmae.
          foreach (User userObject in result)
            {
                if (userObject.Name == user.UserName)
                {
                    // Log in user.
                    user.IsLoggedIn = true;
                    user.ID = userObject.ID;
                    return RedirectToAction("Routines", "Routine", user);
                }                
            }
          // Returns to error View if something went wrong.
            user.ErrorFlag = true;
            user.ErrorType = FlashErrors.LoginError;
            return RedirectToAction("LoginError", user);
        }

        /// <summary>
        /// Registers a new user.
        /// </summary>
        /// <param name="user">The user to register.</param>
        /// <returns>Redirects to the Routines View.</returns>
        [HttpPost]
        public async Task<IActionResult> RegisterUser(LoggedInUser user)
        {
            // Get all users in the DB.
            var userExists = await _user.LogIn();

            // Compare if user already exists.
            foreach (User userObject in userExists)
            {
                if (userObject.Name == user.UserName)
                {
                    // If user already exists, return error View.
                    user.ErrorFlag = true;
                    user.ErrorType = FlashErrors.RegisterError;
                    return RedirectToAction("LoginError", user);
                }
            }

            // Create a new User model.
            User newUser = new User()
            {
                Name = user.UserName
            };

            // Call the RegisterUser service method.
            var result = await _user.RegisterUser(newUser);

            if (result.IsSuccessStatusCode == true)
            {
                var allUsers = await _user.LogIn();

                foreach (User userObject in allUsers)
                {
                    if (userObject.Name == user.UserName)
                    {
                        user.IsLoggedIn = true;
                        user.ID = userObject.ID;
                        return RedirectToAction("Routines", "Routine", user);
                    }
                }
            }

            user.ErrorFlag = true;
            user.ErrorType = FlashErrors.RegisterError;
            return RedirectToAction("LoginError", user);
        }

        /// <summary>
        /// Delete a user from the DB.
        /// </summary>
        /// <param name="currentUser">The user to delete.</param>
        /// <returns>Redirects to the Index View.</returns>
        [HttpPost]
        public async Task<IActionResult> DeleteUser(LoggedInUser currentUser)
        {
            var result = await _user.DeleteUser(currentUser.ID);

            if (result.IsSuccessStatusCode == true)
            {
                return RedirectToAction("Index", "Home");
            }

            return RedirectToAction("Routines", "Routine", currentUser);
        }
    }
}