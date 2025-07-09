using Spartdungeon.DTOs;
using Spartdungeon.Models;
using Spartdungeon.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Reflection.Metadata.BlobBuilder;

namespace Spartdungeon.Views
{
    public class InventoryView
    {
        /// <summary>
        /// 인벤토리 목록
        /// </summary>
        /// <param name="inventory">인벤토리 데이터</param>
        /// <param name="slots">장착된 장비</param>
        /// <returns></returns>
        public int Inventory(List<GameItem> inventory, EquipmentSlots slots)
        {
            int input;
            do
            {
                Console.Clear();
                Console.WriteLine("아이템 목록");

                foreach (EquipItem item in inventory)
                {
                    if (slots.WeaponSlot?.Id == item.Id || slots.ArmorSlot?.Id == item.Id)
                        Console.WriteLine($"- [E]{item.Name} | {item.EquipStatusString()} | {item.Description}");
                    else
                        Console.WriteLine($"- {item.Name} | {item.EquipStatusString()} | {item.Description}");

                }
                Console.WriteLine("1. 장착 관리");
                Console.WriteLine("2. 나가기");

                input = InputManager.Instance.ReadLineIntInRange(1,2);
            } while (input == -1 || input > 2);
            return input;
        }

        /// <summary>
        /// 장착 관리
        /// </summary>
        /// <param name="inventory">인벤토리 데이터</param>
        /// <param name="slots">장착된 장비</param>
        /// <returns></returns>
        public int Equipment(List<GameItem> inventory, EquipmentSlots slots)
        {
            int input;

            int[] matchingIds = new int[inventory.Count + 1];
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < inventory.Count; i++)
            {
                if (inventory[i] is EquipItem item)
                {
                    if (slots.WeaponSlot?.Id == item.Id || slots.ArmorSlot?.Id == item.Id)
                        sb.AppendLine($"{i+1}. [E]{item.Name} | {item.EquipStatusString()} | {item.Description}");
                    else
                        sb.AppendLine($"{i+1}. {item.Name} | {item.EquipStatusString()} | {item.Description}");

                    matchingIds[i+1] = item.Id;
                }
            }

            do
            {
                Console.Clear();
                Console.WriteLine("장비 목록");
                Console.WriteLine(sb.ToString());
                Console.WriteLine();

                Console.WriteLine("0. 나가기");

                input = InputManager.Instance.ReadLineIntInRange(0, matchingIds.Length);

            } while (input == -1 || input < 0 || input > matchingIds.Length);

            return matchingIds[input];
        }
    }
}
