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
   public enum ShopBuyResult
    {
        Success,
        AlreadyBought,
        NotEnoughMoney,
        Invalid
    }
    public class ShopController
    {

        private ItemList itemList;
        private List<ShopItem> shopItems;

        private List<int> soldItemIds;

        private ShopView _shopView;

        public ShopController(ItemList itemList, List<ShopItem> shopItems)
        {
            this.itemList = itemList;
            this.shopItems = shopItems;

            _shopView = new ShopView();
            soldItemIds = new List<int>();
        }
        
        public void Initialize(List<int> ids)
        {
            soldItemIds.Clear();
            soldItemIds.AddRange(ids);
        }

        public int ShowShopItems(int money)
        {
            List<ShopItemDTO> dto = CreateShopDTO();

            return _shopView.Shop(dto, money);
        }

        public (ShopBuyResult, int) BuyItemAtShop(int playerMoney)
        {
            string text = "";
            while (true)
            {
                List<ShopItemDTO> dto = CreateShopDTO();
                int id = _shopView.BuyItemShop(dto, playerMoney, text);

                if (id == 0)
                    return (ShopBuyResult.Invalid, 0);  // 0 선택 시 상점 메인 메뉴로 돌아감

                if (soldItemIds.Contains(id))
                {
                    text = "이미 구매한 아이템입니다.";
                    continue; // 다시 구매 화면으로!
                }

                ShopItem? item = shopItems.FirstOrDefault(x => x.Id == id);
                if (item == null)
                {
                    text = "존재하지 않는 아이템입니다.";
                    continue; // 다시 구매 화면으로!
                }

                if (playerMoney < item.Price)
                {
                    text = "돈이 부족합니다.";
                    continue; // 다시 구매 화면으로!
                }

                soldItemIds.Add(id);
                ViewHelper.ShowMessage("구매가 완료되었습니다!");
                return (ShopBuyResult.Success, id);
            }
        }

        public SellItemDTO SellItemAtShop(List<GameItem> inventory, int money)
        {
            int id = _shopView.SellItemShop(inventory, money);
            if (id == 0 || !soldItemIds.Contains(id))
                return new SellItemDTO
                {
                    ItemId = 0,
                    Price = 0,
                    Count = 0
                };

            int price = (int)(inventory.Find(x => x.Id == id).Price * 0.85);
            soldItemIds.Remove(id);
            SellItemDTO sellItemDTO = new SellItemDTO
            {
                ItemId = id,
                Price = price,
                Count = 1
            };
            return sellItemDTO;
        }

        public List<ShopItemDTO> CreateShopDTO()
        {
            List<ShopItemDTO> result = new List<ShopItemDTO>();
            foreach (ShopItem shopitem in shopItems)
            {
                GameItem item = itemList.GetItemByID(shopitem.Id);
                result.Add(new ShopItemDTO
                {
                    ItemId = shopitem.Id,
                    Name = item.Name,
                    Description = item.Description,
                    Status = item is EquipItem equip ? equip.EquipStatusString() : "",
                    Price = shopitem.Price,
                    isSold = soldItemIds.Contains(shopitem.Id)
                });
            }

            return result;
        }

        public BuyItemDTO? CreateBuyItemDTO(int id)
        {
            ShopItem? item = shopItems.FirstOrDefault(x => x.Id == id);
            if (item == null)
                return null;

            return new BuyItemDTO
            {
                ItemId = item.Id,
                Price = item.Price
            };
        }

        public List<int> GetSoldItemIds() => soldItemIds;
    }
}
