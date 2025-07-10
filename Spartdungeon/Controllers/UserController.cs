using Spartdungeon.DTOs;
using Spartdungeon.Models;
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

            WeaponItem? weapon = data.Inventory.Find(x => x.Id == data.WeaponID) as WeaponItem;
            if(weapon != null)
                EquipWeapon(weapon);
            ArmorItem? armor = data.Inventory.Find(x => x.Id == data.ArmorID) as ArmorItem;
            if(armor != null)
                EquipArmor(armor);
        }

        public void ClearDungeon(DungeonRewardDTO dto)
        {
            player.TakeDamage(dto.ReduceHealth);
            player.GainExp(dto.Exp);
            player.GainMoney(dto.RewardMoney);
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

        public bool IsEquipmented(GameItem item) => slots.IsEquipped(item);
        public EquipmentSlots GetEquipmentSlots() => slots;
        public Player GetPlayer() => player;

        public PlayerDTO GetPlayerDTO()
        {
            PlayerDTO dto = new PlayerDTO
            {
                Name = player.Name,
                Level = player.Level.Lv,
                Exp = player.Level.Exp,
                job = player.Job,
                CurrHealth = player.Status.CurrHealth,
                Health = player.Status.Health,
                Attack = player.Status.Attack,
                Defense = player.Status.Defense,
                Money = player.Money
            };
            return dto;
        }

        public void UseMoney(int money)
        {
            player.UseMoney(money);
        }

        public void GainMoney(int money)
        {
            player.GainMoney(money);
        }

        public void RestHealth(float heal)
        {
            float result = heal;
            if(player.Status.CurrHealth + heal > player.Status.MaxHealth)
            {
                result -= (player.Status.CurrHealth + heal) - player.Status.MaxHealth ;
                result = Math.Max(0, result);
            }
            player.Heal(result);
        }
    }
}
