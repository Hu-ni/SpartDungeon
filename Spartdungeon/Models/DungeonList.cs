using Spartdungeon.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartdungeon.Models
{
    public class DungeonList
    {
        public List<GameDungeon> gameDungeons;

        public DungeonList() 
        { 
            gameDungeons = new List<GameDungeon>();
        }

        public void LoadDungeonListFromXml()
        {
            gameDungeons = XmlSerializerHelper.Deserialize<DungeonList>(Strings.FILE_DUNGEON_PATH).gameDungeons;
        }

        public GameDungeon? GetDungeonById(int id)
        {
            return gameDungeons.FirstOrDefault(x=> x.Id == id);
        }
    }
}
