using Spartdungeon.Models;
using Spartdungeon.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Spartdungeon.Services
{
    [XmlRoot("SaveData")]
    [XmlInclude(typeof(EquipItem))]
    [XmlInclude(typeof(WeaponItem))]
    [XmlInclude(typeof(ArmorItem))]
    public class SaveData
    {
        // 이름, 직업, 레벨, 인벤토리, 돈, 장착한 아이템
        public string Name { get; private set; }
        public Job Job { get; private set; }
        public Level Level { get; private set; }
        public Status Status { get; private set; }

        [XmlArray("Inventory")]
        [XmlArrayItem("Item")]
        public List<GameItem> Inventory { get; private set; }
        public EquipmentSlots EquipmentSlots { get; private set; }
        public int Money { get; private set; }

        public SaveData(string name, Job job, Level level, Status status,List<GameItem> inventory, EquipmentSlots equipmentSlots, int money)
        {
            Name = name;
            Job = job;
            Level = level;
            Status = status;
            Inventory = inventory;
            EquipmentSlots = equipmentSlots;
            Money = money;
        }
    }
}
