using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartdungeon.DTOs
{
    public class DungeonRewardDTO
    {
        public bool isClear { get; set; }
        public float ReduceHealth { get; set; }
        public List<int> ItemIds {get; set;}
        public int RewardMoney {get; set;}
        public int Exp { get; set;}

        public DungeonRewardDTO()
        {
            ItemIds = new List<int>();
        }
    }
}
