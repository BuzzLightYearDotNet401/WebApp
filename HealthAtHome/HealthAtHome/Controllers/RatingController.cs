using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HealthAtHome.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;


namespace HealthAtHome.Controllers
{
    [Route("[controller]")]
    public class RatingController : Controller
    {
        private readonly IRating _rating;

        public RatingController(IRating rating)
        {
            _rating = rating;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }
    }
}
