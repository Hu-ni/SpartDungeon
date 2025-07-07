using Spartdungeon.Domain.Item.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartdungeon.Game
{
    public class EquipmentSlots
    {
        public WeaponItem WeaponItem { get; set; }
        public ArmorItem ArmorItem { get; set; }

        public void EquipWeapon(WeaponItem weapon)
        {
            WeaponItem = weapon;
        }

        public void EquipArmor(ArmorItem armor)
        {
            ArmorItem = armor;
        }

        public void UnEquipWeapon()
        {
            WeaponItem = null;
        }

        public void UnEquipArmor()
        {
            ArmorItem = null;
        }

    }
}
