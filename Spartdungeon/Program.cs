using Spartdungeon.Controllers;
using Spartdungeon.Models;
using System.Xml.Serialization;

namespace Spartdungeon
{
    class Program
    {
        static void Main(string[] args)
        {
            // 시나리오
            // 게임 실행 -> 데이터 불러오기 -> 인트로 -> 유저 생성 -> 마을(로비)  -> 던전
            //                                              -> 상점
            //                                              -> 휴식
            //                                              -> 내 정보
            //                                              -> 인벤토리
            // 데이터 불러오기
            // 게임 실행 -> 불러오는 중 -> 마을(로비) 

            /* 현재 여기서는 1단 Save Data 있는지 확인
             * 만약 없을 경우 인트로로 이동.
             * 있을 경우 XML 데이터 불러오기
             * 
             * 흐름을 시작해줄 Controller가 필요함.
             * 입력에 따라 User, Dungeon, Shop로 이동
            */
            //while(true){ }
            //var myItemList = new ItemList();
            //myItemList.Items.Add(new WeaponItem { Id = 1, Name = "Sword of Valor", Description = "강력한 검입니다.", IsSellable = true, Status = new ItemStatus() { Attack = 15, Defense = 2 }, Price = 250, Type = WeaponType.Swoard });

            //var serializer = new XmlSerializer(typeof(ItemList));
            //var ns = new XmlSerializerNamespaces();
            //ns.Add("", "");

            //using (var fs = new FileStream("Items.xml", FileMode.Create))
            //{
            //    serializer.Serialize(fs, myItemList, ns);
            //}
            MainController main = new MainController();
            main.Run();
            return;
        }
    }
}
