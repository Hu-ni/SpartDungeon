using Spartdungeon.Models;
using Spartdungeon.Services;
using Spartdungeon.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartdungeon.Controllers
{
    public class UserController
    {
        private Player player;
        private EquipmentSlots slots;

        private UserInfoView userInfoView;
        private CreateUserView createUserView;
        public UserController()
        {
            userInfoView = new UserInfoView();
            createUserView = new CreateUserView();

            slots = new EquipmentSlots();
        }

        public void CheckLevelUp()
        {
            player.TryLevelUp();
        }

        public void CreateUser()
        {
            player = createUserView.CreateUser();
        }

        public void EquipArmor(ArmorItem item)
        {
            if (slots.ArmorSlot != null)
                UnEquipArmor();
            player.EquipItem(item);
            slots.EquipArmor(item);
        }

        public void EquipWeapon(WeaponItem item)
        {
            if (slots.WeaponSlot != null)
                UnEquipWeapon();
            player.EquipItem(item);
            slots.EquipWeapon(item);
        }

        public void LoadPlayerData(SaveData data)
        {
            player = new Player(data);
        }

        public void ReduceHealth(float amount)
        {
            player.TakeDamage(amount);
        }

        public void UnEquipArmor()
        {
            if (slots.ArmorSlot == null) return;
            ArmorItem item = slots.ArmorSlot;
            player.UnequipItem(item);
            slots.UnEquipArmor();
        }

        public void UnEquipWeapon()
        {
            if (slots.WeaponSlot == null) return;
            WeaponItem item = slots.WeaponSlot;
            player.UnequipItem(item);
            slots.UnEquipWeapon();
        }

        public void UpdateUserInfo(Player player)
        {
            throw new NotImplementedException();
        }

        public int UserInfo()
        {
            return userInfoView.PrintUserInfo(player);
        }

        public EquipmentSlots GetEquipmentSlots() => slots;
        public Player GetPlayer() => player;
    }
}
