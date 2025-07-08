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
    public class MainController
    {
        // 흐름 제어
        // 글로벌 변수 선언(아이템, 던전)
        private bool playerDataExists;
        private ItemList itemList;

        private UserController userController;
        private InventoryController inventoryController;


        private MainView mainView;
        public MainController()
        {
            playerDataExists = false;
            itemList = new ItemList();

            userController = new UserController();
            inventoryController = new InventoryController();

            mainView = new MainView();
        }

        public void Run()
        {
            Initialize();

            if (playerDataExists)
            {
                Play();
            }
            else
            {
                Start();
            }
        }

        /// <summary>
        /// 초기 설정. (데이터 로드)
        /// </summary>
        public void Initialize()
        {
            // 아이템 던전 정보 불러오기
            itemList.Initialize();
            inventoryController.Initialize(itemList.Items);

            if (File.Exists(Strings.FILE_PLAYER_PATH))
            {
                // 플레이어 데이터 불러오기
                playerDataExists = true;
                SaveData data = XmlSerializerHelper.Deserialize<SaveData>(Strings.FILE_PLAYER_PATH);
                userController.LoadPlayerData(data);
            }
        }

        public void Start()
        {
            // 인트로 재생
            // 유저 생성
            mainView.Intro();
            userController.CreateUser();
            Play();
        }

        public void Play()
        {
            // 마을로 이동!
            while (true)
            {
                int input = mainView.Home();
                switch (input)
                {
                    case 1: // 상태 보기
                        userController.UserInfo();
                        break;
                    case 2: // 인벤토리
                        int result = inventoryController.InventoryList(userController.GetEquipmentSlots());
                        if (result == 1)
                            EquipmentItem();
                        break;
                    case 3: // 상점

                        break;
                    case 4: // 던전

                        break;
                }
            }
        }

        public void EquipmentItem()
        {
            EquipItem item = inventoryController.EquipmentItem(userController.GetEquipmentSlots());
            if (item is WeaponItem weapon)
            {
                userController.EquipWeapon(weapon);

            }
            if (item is ArmorItem armor)
            {
                userController.EquipArmor(armor);
            }
        }
    }
}
