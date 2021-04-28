﻿using KodinimoUzduotis.Data;
using KodinimoUzduotis.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Net.Http.Json;

namespace KodinimoUzduotis.Controllers
{

    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly KodinimoUzduotisContext _context;

        public HomeController(ILogger<HomeController> logger, KodinimoUzduotisContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            Player player = new Player();

            player.CodeSolutions = _context.CodeSolutions.ToList();

            return View(player);
        }

        [HttpPost]
        public async Task<IActionResult> SolveCode(int Id)
        {
            string code = HttpContext.Request.Form["description"];
            var url = "https://api.jdoodle.com/v1/execute";
            var content = new 
            { 
                clientId = "e2778c98e3fb333237d368ada38a10bb", 
                clientSecret = "c246ffa6663b8b43c2e90d2a8cda5eb28b6e23c8169ab2bf16987c5c8977dd61", 
                script = code, 
                language = "php", 
                versionIndex = "3" 
            };

            var correctSolution = _context.CodeSolutions.SingleOrDefault(a => a.Id == Id);

            var correctContent = new
            {
                clientId = "e2778c98e3fb333237d368ada38a10bb",
                clientSecret = "c246ffa6663b8b43c2e90d2a8cda5eb28b6e23c8169ab2bf16987c5c8977dd61",
                script = correctSolution.Solution,
                language = "php",
                versionIndex = "3"
            };

            var httpClient = new HttpClient();
            var result = await httpClient.PostAsJsonAsync(url, content);
            var correctResult = await httpClient.PostAsJsonAsync(url, correctContent);

            string playerName = HttpContext.Request.Form["name"];
            var player =  _context.Players.Where(f => f.Name == playerName).SingleOrDefault();
            object json = await result.Content.ReadAsStringAsync();
            object correctJson = await correctResult.Content.ReadAsStringAsync();
            var answer = JsonConvert.DeserializeObject<Response>((string)json).output;
            var correctAnswer = JsonConvert.DeserializeObject<Response>((string)correctJson).output;

            if (player != null)
            {
                if (answer == correctAnswer)
                {
                    player.Success++;
                } 
            } else {
                Player newPlayer = new Player();
                newPlayer.Name = playerName;
                if (answer == correctAnswer) {
                    newPlayer.Success++;
                }
                _context.Players.Add(newPlayer);
            }
            _context.SaveChanges();

            return RedirectToAction("TopScore");
        }

        public IActionResult TopScore()
        {
            var topScores = _context.Players.OrderByDescending(x => x.Success).Take(3);

            return View(topScores);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
