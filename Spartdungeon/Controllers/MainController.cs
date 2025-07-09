using Spartdungeon.DTOs;
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
        private DungeonList dungeonList;

        private UserController userController;
        private InventoryController inventoryController;
        private ShopController shopController;
        private DungeonController dungeonController;

        private MainView mainView;
        public MainController()
        {
            playerDataExists = false;
            itemList = new ItemList();
            dungeonList = new DungeonList();

            userController = new UserController();
            inventoryController = new InventoryController();
            shopController = new ShopController(itemList, new List<ShopItem>
            {
                new ShopItem { Id = 1, Price = 250},
                new ShopItem { Id = 2, Price = 10000000 }
            });

            dungeonController = new DungeonController(dungeonList);

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
            itemList.LoadItemListFromXml();
            dungeonList.LoadDungeonListFromXml();
            //inventoryController.Initialize(itemList.Items);

            if (File.Exists(Strings.FILE_PLAYER_PATH))
            {
                // 플레이어 데이터 불러오기
                playerDataExists = true;
                SaveData data = XmlSerializerHelper.Deserialize<SaveData>(Strings.FILE_PLAYER_PATH);
                inventoryController.Initialize(data.Inventory);
                shopController.Initialize(data.SoldItemIds);
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
                        EquipmentSlots slots = userController.GetEquipmentSlots();
                        GoToInventory(slots);
                        break;
                    case 3: // 상점
                        int Money = userController.GetPlayer().Money;
                        GoToShop(Money);
                        break;
                    case 4: // 던전
                        Player player = userController.GetPlayer();
                        GoToDungeon(player);
                        break;
                    case 5: //휴식하기
                        break;
                }
                
                PlaySave();
            }
        }

        public void GoToInventory(EquipmentSlots slot)
        {
            bool exist = false;
            while(!exist)
            {
                int input = inventoryController.InventoryList(slot);
                if(input == 2)
                    exist = true;

                if(input == 1)
                {
                    EquipItem? item = inventoryController.EquipmentItem(slot);
                    
                    if(slot.IsEquipped(item))
                    {
                        if (item is WeaponItem weapon)
                            userController.UnEquipWeapon();
                        else if (item is ArmorItem armor)
                            userController.UnEquipArmor();
                    }
                    else
                    {
                        if (item is WeaponItem weapon)
                            userController.EquipWeapon(weapon);
                        else if (item is ArmorItem armor)
                            userController.EquipArmor(armor);
                    }


                }
            }
        }

        public void GoToShop(int Money)
        {
            int playerMoney = Money;
            bool exists = false;
            while(!exists)
            {
                int input = shopController.ShowShopItems(playerMoney);
                if (input == 0)
                    exists = true;

                if (input == 1)
                {
                    // 구매할 아이템 받기
                    var (result, id) = shopController.BuyItemAtShop(playerMoney);
                    if (id == 0)
                        continue;

                    if(result == ShopBuyResult.Success)
                    {
                        BuyItemDTO? dto = shopController.CreateBuyItemDTO(id);
                        if (dto == null)
                            continue;

                        // 아이템 구매 처리
                        GameItem item = itemList.GetItemByID(dto.ItemId);
                        item.Price = dto.Price;
                        if (item != null)
                        {
                            inventoryController.AddItem(item);
                            userController.UseMoney(dto.Price);
                        }
                    }
                }
                if(input == 2)
                {
                    SellItemDTO dto = shopController.SellItemAtShop(inventoryController.Inventory, playerMoney);
                    if (dto.ItemId == 0)
                        continue;

                    GameItem? item = inventoryController.Inventory.Find(x => x.Id == dto.ItemId);
                    if (item != null)
                    {
                        if(userController.IsEquipmented(item))
                        {
                            if(item is ArmorItem armor)
                                userController.UnEquipArmor();
                            else
                                userController.UnEquipWeapon();
                        }
                        inventoryController.RemoveItem(item);
                        userController.GainMoney(dto.Price);
                    }
                }
                playerMoney = userController.GetPlayer().Money;
            }
        }

        public void GoToDungeon(Player player)
        {
            bool exists = false;
            while(!exists)
            {
                int input = dungeonController.ShowDungeonList();
                if(input == 0)
                    exists = true;

                DungeonEnterDTO dto = new DungeonEnterDTO
                {
                    DungeonId = input,
                    PlayerAttack = player.Status.FinalAttack,
                    PlayerDefense = player.Status.FinalDefense,
                    PlayerHealth = player.Status.CurrHealth,
                    PlayerMoney = player.Money
                };

                DungeonRewardDTO result = dungeonController.EnterDungeon(dto);
                if (result != null)
                {
                    userController.ClearDungeon(result);
                    userController.CheckLevelUp();
                    if(result.ItemIds != null)
                    {
                        foreach(int id in result.ItemIds)
                        {
                            GameItem item = itemList.GetItemByID(id);
                            inventoryController.AddItem(item);
                        }
                    }
                }
            }
        }

        public void PlaySave()
        {
            PlayerDTO player = userController.GetPlayerDTO();
            List<GameItem> items = inventoryController.GetInventory();
            EquipmentSlots slots = userController.GetEquipmentSlots();
            List<int> soldItemIds = shopController.GetSoldItemIds();
            SaveData data = new SaveData(player, items, slots, soldItemIds);

            XmlSerializerHelper.Serialize(data, Strings.FILE_PLAYER_PATH);
        }
    }
}
