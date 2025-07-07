using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Spartdungeon.Domain.Item.Model
{
    public enum ArmorType
    {
        Helmet,
        Chestplate,
        Boots
    }

    [XmlInclude(typeof(ArmorItem))]
    public class ArmorItem : EquipItem
    {
        public ArmorType Type { get; set; }
    }
}
