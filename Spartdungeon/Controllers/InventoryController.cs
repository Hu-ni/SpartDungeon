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
    // 인벤토리 리스트 관리
    // 뷰로 이동
    // 
    public class InventoryController
    {
        public List<GameItem> Inventory { get; private set; }

        private InventoryView inventoryView;

        public InventoryController()
        {
            Inventory = new List<GameItem>();
            inventoryView = new InventoryView();
        }

        /// <summary>
        /// 인벤토리 초기화
        /// </summary>
        public void Initialize()
        {
            Inventory.Clear();
        }

        /// <summary>
        /// 저장된 데이터를 통해 인벤토리 초기화
        /// </summary>
        /// <param name="items">저장된 데이터</param>
        public void Initialize(List<GameItem> items)
        {
            Inventory.Clear();
            Inventory.AddRange(items);

        }

        public int InventoryList(EquipmentSlots slots)
        {
            int input = inventoryView.Inventory(Inventory, slots);


            return input;
        }

        public EquipItem? EquipmentItem(EquipmentSlots slots)
        {
            int id = inventoryView.Equipment(Inventory, slots);
            EquipItem? equipItem = Inventory.FirstOrDefault(x => x.Id == id) as EquipItem;
            return equipItem;
        }

        public void AddItem(GameItem item)
        {
            Inventory.Add(item);
        }

        public void RemoveItem(GameItem item)
        {
            Inventory.Remove(item);
        }

        public List<GameItem> GetInventory()
        {
            return Inventory;
        }

        public GameItem? GetItem(int id)
        {
            return Inventory.FirstOrDefault(x => x.Id == id);
        }
    }
}
