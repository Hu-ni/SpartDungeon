using Spartdungeon.Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartdungeon.Domain.Character.Controller
{
    public interface IUserController
    {
        public void CreateUser();
        public void SetUserInfo(Player player);
        public void UpdateUserInfo(Player player);
        public void CheckLevelUp();

        public void EquipWeapon();
        public void UnEquipWeapon();
        public void EquipArmor();
        public void UnEquipArmor();
    }
}
