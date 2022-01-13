using System.Collections.Generic;
using DotaWebCalculator.Models;

namespace DotaWebCalculator.Interfaces
{
    public interface IHeroes
    {
        IEnumerable<Hero> AllHeroes { get; }
        Hero GetObjectHero(int heroId);
    }
}
