using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotaWebCalculator.Models;

namespace DotaWebCalculator.Interfaces
{
    public interface IHeroes
    {
        IEnumerable<Hero> AllHeroes { get; }
        Hero GetObjectHero(int heroId);
    }
}
