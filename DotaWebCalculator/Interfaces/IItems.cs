using DotaWebCalculator.Models;
using System.Collections.Generic;

namespace DotaWebCalculator.Interfaces
{
    public interface IItems
    {
        IEnumerable<Item> AllItems { get; }
        Item GetObjectItem(int itemId);
    }
}
