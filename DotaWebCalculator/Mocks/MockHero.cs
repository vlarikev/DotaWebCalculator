using System;
using System.Collections.Generic;
using DotaWebCalculator.Interfaces;
using DotaWebCalculator.Models;

namespace DotaWebCalculator.Mocks
{
    public class MockHero : IHeroes
    {
        public IEnumerable<Hero> AllHeroes
        {
            get
            {
                return new List<Hero>
                {
                    new Hero { heroId = 0, heroName = "Tinker", heroImage = "" },
                    new Hero { heroId = 1, heroName = "Brewmaster", heroImage = "" },
                    new Hero { heroId = 2, heroName = "Dark Willow", heroImage = "" }
                };
            }
        }

        public Hero GetObjectHero(int heroId)
        {
            throw new NotImplementedException();
        }
    }
}
