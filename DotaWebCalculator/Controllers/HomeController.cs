using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using DotaWebCalculator.Interfaces;
using DotaWebCalculator.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DotaWebCalculator.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHeroes allHeroes;

        public HomeController(IHeroes iAllHeroes)
        {
            allHeroes = iAllHeroes;
        }

        public IActionResult Index()
        {
            if (HttpContext.Session.GetInt32("isAllyChosen") == null)
                HttpContext.Session.SetInt32("isAllyChosen", 0);
            if (HttpContext.Session.GetInt32("isEnemyChosen") == null)
                HttpContext.Session.SetInt32("isEnemyChosen", 0);

            return View(GetAllHeroes());
        }

        [HttpPost]
        public IActionResult Index(string buttonValue)
        {
            string[] strParts = buttonValue.Split("_");

            if (strParts[0] == "ally")
            {
                HttpContext.Session.SetInt32("isAllyChosen", 1);
                HttpContext.Session.SetString("chosenAlly", GetAllHeroes().Where(i => i.heroId == int.Parse(strParts[1])).FirstOrDefault().heroName);
            }
            if (strParts[0] == "enemy")
            {
                HttpContext.Session.SetInt32("isEnemyChosen", 1);
                HttpContext.Session.SetString("chosenEnemy", GetAllHeroes().Where(i => i.heroId == int.Parse(strParts[1])).FirstOrDefault().heroName);
            }
            
            return View(GetAllHeroes());
        }

        public IActionResult Calculator()
        {
            return View();
        }

        private IEnumerable<Hero> GetAllHeroes()
        {
            var heroes = allHeroes.AllHeroes;
            return heroes;
        }
    }
}
