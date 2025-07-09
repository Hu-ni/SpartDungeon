using Spartdungeon.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartdungeon.DTOs
{
    public class ShopItemDTO
    {
        public int ItemId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public int Price { get; set; }
        public bool isSold { get; set; }
    }
}
