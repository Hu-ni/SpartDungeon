using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Spartdungeon.Models
{
    [XmlRoot("Dungeon")]
    public class GameDungeon
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Difficult {  get; set; }

        // 던전 클리어 보상
        public int Gold { get; set; }
        [XmlArray("ItemIds")]
        [XmlArrayItem("ID")]
        public List<int> ItemIds { get; set; }
    }
}
