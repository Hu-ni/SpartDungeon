using Spartdungeon.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Spartdungeon.Models
{
    //모든 아이템 리스트
    [XmlRoot("Items", Namespace = "")]
    [XmlInclude(typeof(EquipItem))]
    [XmlInclude(typeof(WeaponItem))]
    [XmlInclude(typeof(ArmorItem))]
    public class ItemList
    {
        // 1. 아이템 XML 파싱하여 데이터 불러오기
        // 2. 요구하는 ID의 아이템 찾아서 보내주기
        // 3. 아이템이 있는지 확인하기
        [XmlElement("Item")]
        public List<GameItem> Items { get; private set; }

        public ItemList()
        {
            Items = new List<GameItem>();
        }

        public void Initialize()
        {
            Items = XmlSerializerHelper.Deserialize<ItemList>(Strings.FILE_ITEM_PATH).Items;
        }

        public GameItem GetItem(int id)
        {
            GameItem item = Items.Find(x => x.Id == id);
            return item;
        }
    }
}
