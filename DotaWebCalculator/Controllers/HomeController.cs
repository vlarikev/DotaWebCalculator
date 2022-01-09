using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using DotaWebCalculator.Interfaces;
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
            var heroes = allHeroes.AllHeroes;
            return View(heroes);
        }

        public IActionResult ChooseAlly()
        {
            HttpContext.Session.SetString("testSession", "test session string");
            return View();
        }
    }
}
