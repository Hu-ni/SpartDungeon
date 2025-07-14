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
        private RestView restView;
        public MainController()
        {
            playerDataExists = false;
            itemList = new ItemList();
            dungeonList = new DungeonList();

            userController = new UserController();
            inventoryController = new InventoryController();

            shopController = new ShopController(itemList);

            dungeonController = new DungeonController(dungeonList);

            mainView = new MainView();
            restView = new RestView();
        }

        /// <summary>
        /// 초기화 후 데이터에 따라 인트로 스킵
        /// </summary>
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

            List<ShopItem> items = new List<ShopItem>();
            List<GameItem> gameItems = itemList.Items.FindAll(x => x.IsSellable);
            foreach (GameItem item in gameItems)
            {
                items.Add(new ShopItem { Id = item.Id, Price = item.Price });
            }

            if (File.Exists(Strings.FILE_PLAYER_PATH))
            {
                // 플레이어 데이터 불러오기
                playerDataExists = true;
                SaveData data = XmlSerializerHelper.Deserialize<SaveData>(Strings.FILE_PLAYER_PATH);
                inventoryController.Initialize(data.Inventory);
                shopController.Initialize(data.SoldItemIds, items);
                userController.LoadPlayerData(data);
            }
            else
            {
                shopController.Initialize(items);
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
                if(userController.isDied())
                {
                    mainView.Die();
                    break;
                }
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
                        GoToDungeon(userController.GetPlayer());
                        break;
                    case 5: //휴식하기
                        GoToRest(userController.GetPlayer());
                        break;
                }   
            }
        }

        private void GoToRest(Player player)
        {
            string message = "";
            while(true) {
                int input = restView.Rest(player.Money, message);
                if (input == 0)
                    break;
                if (input == 1)
                {
                    if (player.Money < Defines.REST_GOLD)
                    {
                        message = "돈이 부족합니다!";
                        continue;
                    }

                    player.UseMoney(Defines.REST_GOLD);
                    userController.RestHealth(Defines.REST_HEAL);
                    message = "휴식을 완료했습니다.";
                    PlaySave();
                }
            }
        }

        public void GoToInventory(EquipmentSlots slot)
        {
            while(true)
            {
                int input = inventoryController.InventoryList(slot);
                if (input == 2)
                    break;

                if(input == 1)
                {
                    EquipItem? item = inventoryController.EquipmentItem(slot);
                    if (item != null)
                    {
                        if (slot.IsEquipped(item))
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
                        PlaySave();
                    }

                }
            }
        }

        public void GoToShop(int Money)
        {
            int playerMoney = Money;
            while(true)
            {
                int input = shopController.ShowShopItems(playerMoney);
                if (input == 0)
                    break;

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
                        GameItem? item = itemList.GetItemByID(dto.ItemId);
                        if (item != null)
                        {
                            item.Price = dto.Price;
                            inventoryController.AddItem(item);
                            userController.UseMoney(dto.Price);
                        }
                        PlaySave();
                    }
                }
                if(input == 2)
                {
                    SellItemDTO dto = shopController.SellItemAtShop(inventoryController.Inventory, playerMoney);
                    if (dto.ItemId == 0)
                        continue;

                    GameItem? item = inventoryController.GetItem(dto.ItemId);
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
                PlaySave();
            }
        }

        public void GoToDungeon(Player player)
        {
            while(true)
            {
                int input = dungeonController.ShowDungeonList();
                if (input == 0)
                    break;

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
                            GameItem? item = itemList.GetItemByID(id);
                            if(item != null)
                                inventoryController.AddItem(item);
                        }
                    }
                    PlaySave();
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
