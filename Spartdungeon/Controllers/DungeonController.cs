using Spartdungeon.DTOs;
using Spartdungeon.Models;
using Spartdungeon.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartdungeon.Controllers
{
    public class DungeonController
    {
        private DungeonList dungeonList;
        private DungeonView dungeonView;
        public DungeonController(DungeonList dungeonList) 
        {
            this.dungeonList = dungeonList;
            dungeonView = new DungeonView();

        }

        public int ShowDungeonList()
        {
            int input = dungeonView.ShowDungeonList(dungeonList.gameDungeons);

            return input;
        }

        public DungeonRewardDTO EnterDungeon(DungeonEnterDTO dto)
        {
            GameDungeon dungeon = dungeonList.GetDungeonById(dto.DungeonId);
            if (dungeon == null)
                return new DungeonRewardDTO
                {
                    isClear = false,
                    ItemIds = null,
                    ReduceHealth = 0,
                    RewardMoney = 0,
                    Exp = 0
                };

            DungeonRewardDTO result;
            if (CalculateClear(dto.PlayerDefense, dungeon.Difficult))
            {
                result = new DungeonRewardDTO
                {
                    isClear = true,
                    ItemIds = null,
                    ReduceHealth = CalculateHealth(Math.Abs(dto.PlayerDefense - dungeon.Difficult)),
                    RewardMoney = CalculateRewardGold(dto.PlayerAttack, dungeon.Gold),
                    Exp = 1
                };

                dungeonView.ClearDungeon(dungeon, dto, result);
            }
            else
            {
                result = new DungeonRewardDTO
                {
                    isClear = false,
                    ItemIds = null,
                    ReduceHealth = CalculateHealth(Math.Abs(dto.PlayerDefense - dungeon.Difficult)) / 2,
                    RewardMoney = 0,
                    Exp = 0
                };

                dungeonView.FailDungeon(dungeon, dto, result);
            }
            return result;

        }

        private float CalculateHealth(float abs)
        {
            Random rnd = new Random();
            return rnd.Next(25, 30) - abs;
        }
        
        private bool CalculateClear(float playerDefense, float dungeonDefense)
        {
            if (playerDefense > dungeonDefense) return true;

            Random rand = new Random();
            return rand.Next(0, 100) < 40;
        }

        private int CalculateRewardGold(float playerAttack, int baseReward)
        {
            double multiplier = 1.0 + (playerAttack * 0.01); 
            return (int)(baseReward * multiplier);
        }

    }
}
