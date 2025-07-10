using Spartdungeon.DTOs;
using Spartdungeon.Models;
using Spartdungeon.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartdungeon.Views
{
    public class DungeonView
    {
        public int ShowDungeonList(List<GameDungeon> dungeons)
        {

            Console.Clear();
            ViewHelper.PrintTitle("던전 입장");
            Console.WriteLine();

            for(int i = 0; i < dungeons.Count; i++)
            {
                GameDungeon dungeon = dungeons[i];
                Console.WriteLine($"{i+1}. {dungeon.Name} | 권장 방어력: {dungeon.Difficult}");
            }
                
            Console.WriteLine("\n0.나가기");
            Console.WriteLine("원하시는 행동을 입력해주세요.");
            Console.Write(">> ");
            return InputManager.ReadLineIntInRange(0, dungeons.Count);
        }

        public void ShowDungeonResult(GameDungeon dungeon, DungeonEnterDTO enter, DungeonRewardDTO result)
        {
            Console.Clear();
            string text = result.isClear ? "던전 클리어!" : "던전 실패!";
            ViewHelper.PrintTitle(text);

            text = result.isClear ? $"{dungeon.Name}을 클리어 하였습니다." : $"{dungeon.Name}을 클리어 하지 못했습니다.";
            Console.WriteLine(text);
            Console.WriteLine();
            Console.WriteLine("[탐험 결과]");
            Console.WriteLine($"{enter.PlayerHealth} -> {enter.PlayerHealth - result.ReduceHealth}");
            Console.WriteLine($"{enter.PlayerMoney} -> {enter.PlayerMoney + result.RewardMoney}");

            Console.WriteLine("\n0.나가기");
            Console.WriteLine("원하시는 행동을 입력해주세요.");
            Console.Write(">> ");
            int input = InputManager.ReadLineIntInRange(0,0);

        }
    }
}
