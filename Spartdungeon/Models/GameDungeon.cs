using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartdungeon.Models
{
    public class GameDungeon
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        // 던전 클리어 보상
        public int Gold { get; set; }
        public List<GameItem> Items { get; set; }
    }
}
