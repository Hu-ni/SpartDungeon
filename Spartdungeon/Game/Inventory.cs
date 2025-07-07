using Spartdungeon.Domain.Item.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartdungeon.Game
{
    public class Inventory
    {
        public List<GameItem> Items { get; set; }

        public Inventory() 
        {
            Items = new List<GameItem>();
        }


        public void AddItem(GameItem item)
        {
            Items.Add(item);
        }

        public void RemoveItem(GameItem item)
        {
            Items.Remove(item);
        }

        public IEnumerable<GameItem> GetItems()
        {
            return Items;
        }

    }
}
