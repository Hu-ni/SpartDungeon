using Spartdungeon.Models;
using Spartdungeon.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Spartdungeon.DTOs
{
    [XmlRoot("SaveData")]
    [XmlInclude(typeof(EquipItem))]
    [XmlInclude(typeof(WeaponItem))]
    [XmlInclude(typeof(ArmorItem))]
    public class SaveData
    {
        // 이름, 직업, 레벨, 인벤토리, 돈, 장착한 아이템
        public PlayerDTO player;

        [XmlArray("Inventory")]
        [XmlArrayItem("Item")]
        public List<GameItem> Inventory { get; set; }
        public int WeaponID { get; set; }
        public int ArmorID { get; set; }
        public List<int> SoldItemIds { get; set; }

        public SaveData()
        {

        }

        public SaveData(PlayerDTO dto, List<GameItem> inventory, EquipmentSlots equipmentSlots, List<int> soldItemIds)
        {
            player = dto;
            Inventory = inventory;
            if (equipmentSlots.WeaponSlot != null)
                WeaponID = equipmentSlots.WeaponSlot.Id;
            if (equipmentSlots.ArmorSlot != null)
                ArmorID = equipmentSlots.ArmorSlot.Id;
            SoldItemIds = soldItemIds;
        }
    }
}
