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
                    new Hero { heroId = 0, heroName = "Tinker", heroHealth = 560, heroMana = 435, heroStatRed = 18, heroStatGreen = 13, heroStatBlue = 30, heroArmor = 4.17f,
                        heroEvasion = 0, heroSpellAmp = 0, heroMagicRes = 25, heroStatusRes = 0, heroAttackDmgLower = 54, heroAttackDmgHigher = 60, heroAttackSpeed = 100,
                        heroImage = "" },
                    new Hero { heroId = 1, heroName = "Brewmaster", heroHealth = 660, heroMana = 255, heroStatRed = 23, heroStatGreen = 19, heroStatBlue = 15, heroArmor = 2.17f,
                        heroEvasion = 0, heroSpellAmp = 0, heroMagicRes = 25, heroStatusRes = 0, heroAttackDmgLower = 52, heroAttackDmgHigher = 59, heroAttackSpeed = 100,
                        heroImage = "" },
                    new Hero { heroId = 2, heroName = "Dark Willow", heroHealth = 600, heroMana = 327, heroStatRed = 20, heroStatGreen = 18, heroStatBlue = 21, heroArmor = 2f,
                        heroEvasion = 0, heroSpellAmp = 0, heroMagicRes = 25, heroStatusRes = 0, heroAttackDmgLower = 48, heroAttackDmgHigher = 56, heroAttackSpeed = 115,
                        heroImage = "" },
                };
            }
        }

        public Hero GetObjectHero(int heroId)
        {
            throw new NotImplementedException();
        }
    }
}
