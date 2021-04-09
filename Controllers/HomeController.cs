using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ModelTalk.Models;

namespace ModelTalk.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return RedirectToAction("Form");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        // [HttpGet("display")]
        // public IActionResult DisplayOctopus()
        // {
        //     Octopus fred = new Octopus()
        //     {
        //         Name = "Fred",
        //         Age = 22,
        //         Hat = "top hat"
        //     };

        //     return View("DisplayOctopus", fred);
        // }

        [HttpGet("form")]
        public IActionResult Form()
        {
            return View();
        }

        [HttpPost("submit")]
        public IActionResult Submit(Octopus newOcto)
        {
            if(ModelState.IsValid)
            {
                return View("DisplayOctopus", newOcto);
            }
            else
            {
                return View("Form");
            }
        }
    }
}
