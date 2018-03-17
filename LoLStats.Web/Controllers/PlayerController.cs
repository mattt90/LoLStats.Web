using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using lol.Models.Player;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using RiotSharp;
using RiotSharp.Interfaces;
using RiotSharp.Misc;

namespace lol.Controllers
{
    public class PlayerController : Controller
    {
        public IRiotApi RiotApi { get; }
        private IMemoryCache Cache { get; }
        public PlayerController(
            IMemoryCache memoryCache, 
            IRiotApi riotApi)
        {
            RiotApi = riotApi ?? throw new ArgumentNullException(nameof(riotApi));
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> SelectPlayer(SelectPlayerViewModel selectPlayerViewModel)
        {
            ViewData["Message"] = "League of Legends";

            var summoner = await RiotApi.GetSummonerByNameAsync(
                selectPlayerViewModel.Region, 
                selectPlayerViewModel.Username);

            var matchList = await RiotApi.GetMatchListAsync(
                selectPlayerViewModel.Region,
                summoner.AccountId,
                beginIndex: 0,
                endIndex: 1);

            var match = await RiotApi.GetMatchAsync(
                selectPlayerViewModel.Region,
                matchList.Matches[0].GameId);

            return View(new PlayerProfileViewModel
            {
                Username = summoner.Name,
                Level = summoner.Level,
                ProfileIconId = summoner.ProfileIconId
            });
        }
    }
}
