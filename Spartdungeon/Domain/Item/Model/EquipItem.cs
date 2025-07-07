using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Spartdungeon.Domain.Item.Model
{
    [XmlInclude(typeof(EquipItem))]
    public class EquipItem : GameItem
    {
        public float Health { get; set; }
        public float Attack { get; set; }
        public float Defense { get; set; }
        public EquipItem() { }

    }
}
