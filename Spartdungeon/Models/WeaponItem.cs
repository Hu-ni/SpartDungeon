using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Spartdungeon.Models
{
    public enum WeaponType
    {
        Swoard,
        Spear,
        Bow
    }

    [XmlInclude(typeof(WeaponItem))]
    public class WeaponItem : EquipItem
    {
        public WeaponType Type { get; set; }

    }
}
