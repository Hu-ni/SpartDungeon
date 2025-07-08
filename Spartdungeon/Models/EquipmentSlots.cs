using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartdungeon.Models
{
    public class EquipmentSlots
    {
        public WeaponItem WeaponSlot { get; private set; }
        public ArmorItem ArmorSlot { get; private set; }

        public EquipmentSlots()
        {
            
        }

        public EquipmentSlots(WeaponItem weaponSlot, ArmorItem armorSlot)
        {
            WeaponSlot = weaponSlot;
            ArmorSlot = armorSlot;
        }


        public bool IsEquipped(GameItem item)
        {
            return item == WeaponSlot || item == ArmorSlot;
        }
        public void EquipWeapon(WeaponItem weapon)
        {
            WeaponSlot = weapon;
        }

        public void EquipArmor(ArmorItem armor)
        {
            ArmorSlot = armor;
        }

        public void UnEquipWeapon()
        {
            WeaponSlot = null;
        }

        public void UnEquipArmor()
        {
            ArmorSlot = null;
        }

    }
}
