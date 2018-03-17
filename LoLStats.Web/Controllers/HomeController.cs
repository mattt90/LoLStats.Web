using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RiotSharp;
using RiotSharp.Interfaces;
using RiotSharp.Misc;

namespace lol.Controllers
{
    public class HomeController : Controller
    {
        public IRiotApi RiotApi { get; set; }
        public HomeController(IRiotApi riotApi)
        {
            RiotApi = riotApi ?? throw new ArgumentNullException(nameof(riotApi));
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Champion()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }
        public async Task<IActionResult> Lol()
        {
            ViewData["Message"] = "League of Legends";

            var x = await RiotApi.GetSummonerByNameAsync(
                Region.na, 
                "mattt90");
            return View();
        }
        
        public IActionResult Statistics()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
