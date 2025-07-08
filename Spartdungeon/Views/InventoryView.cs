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
                    if (slots.WeaponSlot == item || slots.ArmorSlot == item)
                        Console.WriteLine($"- [E]{item.Name} | {item.EquipStatusString()} | {item.Description}");
                    else
                        Console.WriteLine($"- {item.Name} | {item.EquipStatusString()} | {item.Description}");

                }
                Console.WriteLine("1. 장착 관리");
                Console.WriteLine("2. 나가기");

                input = InputManager.Instance.ReadLineInt();
            } while (input == -1 || input > 2);
            return input;
        }

        /// <summary>
        /// 장착 관리
        /// </summary>
        /// <param name="inventory">인벤토리 데이터</param>
        /// <param name="slots">장착된 장비</param>
        /// <returns></returns>
        public EquipItem Equipment(List<GameItem> inventory, EquipmentSlots slots)
        {
            //TODO: 장비 아이템이 아닌 아이템 예외 처리.
            int input;
            EquipItem equip = null;

            do
            {
                Console.Clear();
                Console.WriteLine("장비 목록");

                List<int> mappingIndex= new List<int>();

                int idx = 1;
                for (int i = 0; i < inventory.Count; i++)
                {
                    if (inventory[i] is EquipItem item)
                    {
                        if (slots.WeaponSlot == item || slots.ArmorSlot == item)
                            Console.WriteLine($"{idx}. [E]{item.Name} | {item.EquipStatusString()} | {item.Description}");
                        else
                            Console.WriteLine($"{idx}. {item.Name} | {item.EquipStatusString()} | {item.Description}");

                        // 매핑 추가
                        mappingIndex.Add(i);
                        idx++;
                    }
                }

                Console.WriteLine("0. 나가기");

                input = InputManager.Instance.ReadLineInt();

                if (input == 0)
                    return null;

                if (input >= 1 && input <= mappingIndex.Count)
                {
                    int inventoryIndex = mappingIndex[input - 1];
                    equip = inventory[inventoryIndex] as EquipItem;
                }
                else
                {
                    Console.WriteLine("잘못된 입력입니다.");
                }

            } while (equip == null);

            return equip;
        }
    }
}
