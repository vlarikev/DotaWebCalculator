using System;
using System.Collections.Generic;
using DotaWebCalculator.Interfaces;
using DotaWebCalculator.Models;

namespace DotaWebCalculator.Mocks
{
    public class MockItem : IItems
    {
        public IEnumerable<Item> AllItems
        {
            get
            {
                return new List<Item>
                {
                    new Item { itemId = 0, itemName = "Hand of Midas", itemImage = "" },
                    new Item { itemId = 1, itemName = "Desolator", itemImage = "" },
                    new Item { itemId = 2, itemName = "Crystalys", itemImage = "" }
                };
            }
        }

        public Item GetObjectItem(int itemId)
        {
            throw new NotImplementedException();
        }
    }
}
