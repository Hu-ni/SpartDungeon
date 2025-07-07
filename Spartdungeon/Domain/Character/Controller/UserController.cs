using Spartdungeon.Domain.Character.View;
using Spartdungeon.Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartdungeon.Domain.Character.Controller
{
    public class UserController : IUserController
    {
        /* 책임져야할 것
        * 플레이어
        *  - 경험치 증가 이벤트
        *  - 전투 이벤트(피격, 데미지, 사망) #완성 이후 하자.
        *  - 데이터 생성 & 불러오기
        *  - 장비 장착
        * 인벤토리
        *  - 아이템 획득
        *  - 포션 
        *  - 장비 착용/해제
        *  
        * 상점
        *  - 아이템 구매
        *  - 아이템 판매
        * 
        * 던전
        *  - 클리어 보상
        */

        private Player player;
        private Inventory inventory;
        private EquipmentSlots equipmentSlots;

        private UserInfoView userInfoView;
        private CreateUserView createUserView;
        public UserController()
        {
            userInfoView = new UserInfoView();
            createUserView = new CreateUserView();
        }

        public void CheckLevelUp()
        {
            throw new NotImplementedException();
        }

        public void CreateUser()
        {
            player = createUserView.CreatePlayer();
        }

        public void SetUserInfo(Player player)
        {
            throw new NotImplementedException();
        }

        public void UpdateUserInfo(Player player)
        {
            throw new NotImplementedException();
        }

        public void EquipArmor()
        {
            throw new NotImplementedException();
        }

        public void EquipWeapon()
        {
            throw new NotImplementedException();
        }


        public void UnEquipArmor()
        {
            throw new NotImplementedException();
        }

        public void UnEquipWeapon()
        {
            throw new NotImplementedException();
        }


    }
}
