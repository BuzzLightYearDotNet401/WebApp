using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HealthAtHome.Models;

namespace HealthAtHome.ViewModels
{
    public class LoggedInUser
    {
        // the current user's id
        public int ID { get; set; }

        // The current user's username.
        public string UserName { get; set; } = "Anonymous";

        // Is the current user logged in.
        public bool IsLoggedIn { get; set; }

        // Do we need to display any errors?
        public bool ErrorFlag { get; set; }

        // What type of error to display.
        public FlashErrors ErrorType { get; set; }

        // The list of the errors possible.
        public string[] Errors = new string[] {
            "Invalid Username!",
            "User already exists!"
        };

        // All routines for the list.
        public List<Routine> RoutineNames { get; set; }

        // Individual routine.
        public Routine RoutineThing { get; set; }

        public int RoutineID { get; set; }

        public StarRating Rating { get; set; }
    }

    public enum FlashErrors
    {
        LoginError,
        RegisterError
    }
}
