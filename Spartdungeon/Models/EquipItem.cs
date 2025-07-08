using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Spartdungeon.Models
{
    [XmlInclude(typeof(WeaponItem))]
    [XmlInclude(typeof(ArmorItem))]
    public class EquipItem : GameItem
    {
        public ItemStatus Status { get; set; }
        public EquipItem() { }

        public string EquipStatusString()
        {
            // 체력 +10 공격력 +5 방어력 +1
            // 공격력 -2 방어력 +10
            StringBuilder sb = new StringBuilder();

            if (Status.Health != 0)
            {
                sb.Append($"체력 {FormatStat(Status.Health)} ");

            }

            if (Status.Attack != 0)
            {
                sb.Append(' ');
                sb.Append($"공격력 {FormatStat(Status.Attack)} ");
            }

            if (Status.Defense != 0)
            {

                sb.Append($"방어력 {FormatStat(Status.Defense)} ");
            }

            if (sb.Length >= 1)
                sb.Length -= 1;

            return sb.ToString();
        }

        private string FormatStat(float value)
        {
            return value > 0 ? $"+{value.ToString("0.#")}" : value.ToString("0.#");
        }
    }
}
