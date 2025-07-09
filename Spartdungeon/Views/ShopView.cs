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
            int input = -1;

            do
            {
                Console.Clear();
                Console.WriteLine("상점");
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
                Console.WriteLine("\n1. 아이템 구매");
                Console.WriteLine("2. 아이템 판매");
                Console.WriteLine("0. 나가기");
                Console.WriteLine("원하시는 행동을 입력해주세요.");
                Console.Write(">> ");
                input = InputManager.Instance.ReadLineIntInRange(0,2);
            }
            while (input == -1 || input < 0 || input > 2);
            
            return input;
        }

        public int BuyItemShop(List<ShopItemDTO> dto, int money, string text)
        {
            int input = -1;

            int[] matchingIds = new int[dto.Count + 1];
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < dto.Count; i++)
            {
                ShopItemDTO item = dto[i];
                string priceOrStatus = item.isSold ? "구매완료" : $"{item.Price}";

                sb.AppendLine($"- {i + 1} | {item.Name} | {item.Status} | {item.Description} | {priceOrStatus}");
                matchingIds[i + 1] = item.ItemId;
            }

            do
            {
                Console.Clear();
                Console.WriteLine("상점 - 아이템 구매");
                Console.WriteLine();
                Console.WriteLine("[보유 골드]");
                Console.WriteLine($"{money}");
                Console.WriteLine();
                Console.WriteLine("아이템 목록");
                Console.WriteLine(sb.ToString());
                
                Console.WriteLine("\n0. 나가기");
                Console.WriteLine(text);
                Console.WriteLine("원하시는 행동을 입력해주세요.");
                Console.Write(">> ");
                input = InputManager.Instance.ReadLineIntInRange(0,dto.Count);
            }
            while (input == -1 || input < 0 || input > dto.Count);

            return matchingIds[input];
        }

        public int SellItemShop(List<GameItem> inventory, int money)
        {
            //TODO: 여러 개 있는 아이템 판매 구현
            int input = -1;

            int[] matchingIds = new int[inventory.Count + 1];
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < inventory.Count; i++)
            {
                GameItem item = inventory[i];
                string price = $"{(int)(item.Price * 0.85)}";
                string status = item is EquipItem equip ? $"| {equip.EquipStatusString()} " : "";

                sb.AppendLine($"- {i + 1} | {item.Name} {status}| {item.Description} | {price}");
                matchingIds[i+1] = item.Id;
            }

            do
            {
                Console.Clear();
                Console.WriteLine("상점 - 아이템 판매");
                Console.WriteLine();
                Console.WriteLine("[보유 골드]");
                Console.WriteLine($"{money}");
                Console.WriteLine();
                Console.WriteLine("아이템 목록");
                Console.WriteLine(sb.ToString());

                Console.WriteLine("0. 나가기");
                Console.WriteLine("원하시는 행동을 입력해주세요.");
                Console.Write(">> ");
                input = InputManager.Instance.ReadLineIntInRange(0, inventory.Count);
            }
            while (input == -1 || input < 0 || input > inventory.Count);

            return matchingIds[input];
        }
    }
}
