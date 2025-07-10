using Spartdungeon.Controllers;
using Spartdungeon.DTOs;
using Spartdungeon.Models;
using Spartdungeon.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartdungeon.Views
{
    public class ShopView
    {

        public ShopView() 
        { 
        }

        public int Shop(List<ShopItemDTO> dto, int money)
        {
            Console.Clear();
            ViewHelper.PrintTitle("상점");
            Console.WriteLine();
            Console.WriteLine("[보유 골드]");
            Console.WriteLine($"{money}");
            Console.WriteLine();
            Console.WriteLine("아이템 목록");
            for(int i = 0; i < dto.Count; i++)
            {
                ShopItemDTO item = dto[i];
                string priceOrStatus = item.isSold ? "구매완료" : $"{item.Price}";

                Console.WriteLine($"- {item.Name} | {item.Status} | {item.Description} | {priceOrStatus}");
            }
            ViewHelper.PrintDivider();

            Console.WriteLine("\n1. 아이템 구매");
            Console.WriteLine("2. 아이템 판매");
            Console.WriteLine("0. 나가기");

            Console.WriteLine();
            Console.WriteLine("원하시는 행동을 입력해주세요.");
            Console.Write(">>");
            int input = InputManager.ReadLineIntInRange(0,2);
            
            return input;
        }

        public int BuyItemShop(List<ShopItemDTO> dto, int money, string message)
        {



            Console.Clear();
            ViewHelper.PrintTitle("상점 - 아이템 구매");
            Console.WriteLine();
            Console.WriteLine("[보유 골드]");
            Console.WriteLine($"{money}");
            Console.WriteLine();
            Console.WriteLine("아이템 목록");
            for (int i = 0; i < dto.Count; i++)
            {
                ShopItemDTO item = dto[i];
                string priceOrStatus = item.isSold ? "구매완료" : $"{item.Price}";

                Console.WriteLine($"- {i + 1} | {item.Name} | {item.Status} | {item.Description} | {priceOrStatus}");
            }
            ViewHelper.PrintDivider();


            if (!string.IsNullOrWhiteSpace(message))
            {
                ViewHelper.PrintNotification(message);
                Console.WriteLine();
            }

            Console.WriteLine("\n0. 나가기");

            Console.WriteLine();
            Console.WriteLine("원하시는 행동을 입력해주세요.");
            Console.Write(">>");
            int input = InputManager.ReadLineIntInRange(0,dto.Count);


            return dto[input - 1].ItemId;
        }

        public int SellItemShop(List<GameItem> inventory, int money)
        {
            //TODO: 여러 개 있는 아이템 판매 구현

            Console.Clear();
            ViewHelper.PrintTitle("상점 - 아이템 판매");
            Console.WriteLine();
            Console.WriteLine("[보유 골드]");
            Console.WriteLine($"{money}");
            Console.WriteLine();
            Console.WriteLine("아이템 목록");
            for (int i = 0; i < inventory.Count; i++)
            {
                GameItem item = inventory[i];
                string price = $"{(int)(item.Price * 0.85)}";
                string status = item is EquipItem equip ? $"| {equip.EquipStatusString()} " : "";

                Console.WriteLine($"- {i + 1} | {item.Name} {status}| {item.Description} | {price}");
            }
            ViewHelper.PrintDivider();

            Console.WriteLine("0. 나가기");
            Console.WriteLine();
            Console.WriteLine("원하시는 행동을 입력해주세요.");
            Console.Write(">>");
            int input = InputManager.ReadLineIntInRange(0, inventory.Count);

            return inventory[input - 1].Id;
        }
    }
}
