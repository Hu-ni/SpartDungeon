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
            //var myDungeonList = new DungeonList();
            //myDungeonList.gameDungeons.Add(new GameDungeon 
            //{ 
            //    Id = 1, 
            //    Name = "쉬운 던전", 
            //    Description = "제일 쉬운 던전입니다.", 
            //    Difficult= 5, 
            //    Gold = 1000,
            //    ItemIds = new List<int>()
            //});
            //myDungeonList.gameDungeons.Add(new GameDungeon
            //{
            //    Id = 2,
            //    Name = "일반 던전",
            //    Description = "일반 던전입니다.",
            //    Difficult = 11,
            //    Gold = 1700,
            //    ItemIds = new List<int>()
            //});
            //myDungeonList.gameDungeons.Add(new GameDungeon
            //{
            //    Id = 3,
            //    Name = "어려운 던전",
            //    Description = "진짜 매우매우매우매우 어려운 던전입니다.",
            //    Difficult = 17,
            //    Gold = 2500,
            //    ItemIds = new List<int>()
            //});

            //var serializer = new XmlSerializer(typeof(DungeonList));
            //var ns = new XmlSerializerNamespaces();
            //ns.Add("", "");

            //using (var fs = new FileStream("Dungeon.xml", FileMode.Create))
            //{
            //    serializer.Serialize(fs, myDungeonList, ns);
            //}
            MainController main = new MainController();
            main.Run();
            return;
        }
    }
}
