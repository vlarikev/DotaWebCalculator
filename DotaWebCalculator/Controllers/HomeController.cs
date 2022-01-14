using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;
using DotaWebCalculator.Interfaces;
using DotaWebCalculator.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace DotaWebCalculator.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHeroes allHeroes;
        private readonly IItems allitems;

        public HomeController(IHeroes iAllHeroes, IItems iAllItems)
        {
            allHeroes = iAllHeroes;
            allitems = iAllItems;
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

        private const int maxSlot = 6;
        public IActionResult Calculator()
        {
            return View(HeroesItemsModel());
        }

        [HttpPost]
        public IActionResult Calculator(string buttonValue)
        {
            string[] strParts = buttonValue.Split("_");

            if (strParts[0] == "ally")
                InventoryUpdate("allyItem_", strParts[1]);

            if (strParts[0] == "enemy")
                InventoryUpdate("enemyItem_", strParts[1]);

            return View(HeroesItemsModel());
        }
        private void InventoryUpdate(string value, string part)
        {
            for (int i = 0; i < maxSlot; i++)
            {
                if (HttpContext.Session.GetString(value + i) == "" || HttpContext.Session.GetString(value + i) == null)
                {
                    HttpContext.Session.SetString(value + i,
                        GetAllItems().Where(i => i.itemId == int.Parse(part)).FirstOrDefault().itemName);
                    break;
                }
            }
        }

        public IActionResult SellItem(string buttonValue)
        {
            HttpContext.Session.SetString(buttonValue, "");

            return RedirectToAction("Calculator", HeroesItemsModel());
        }

        private IEnumerable<Hero> GetAllHeroes()
        {
            var heroes = allHeroes.AllHeroes;
            return heroes;
        }
        private IEnumerable<Item> GetAllItems()
        {
            var items = allitems.AllItems;
            return items;
        }
        private dynamic HeroesItemsModel()
        {
            dynamic model = new ExpandoObject();
            model.Heroes = GetAllHeroes();
            model.Items = GetAllItems();

            return model;
        }
    }
}
