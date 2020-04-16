using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HealthAtHome.Models;

namespace HealthAtHome.ViewModels
{
    public class LoggedInUser
    {
        // The current user's username.
        public string UserName { get; set; }

        // Is the current user logged in.
        public bool IsLoggedIn { get; set; }

        // Do we need to display any errors?
        public bool ErrorFlag { get; set; }

        // The list of the errors possible.
        public string[] Errors = new string[] {
            "Invalid Username!",
        };

        public List<RoutineName> RoutineNames { get; set; }
    }
}
