using Spartdungeon.Domain.Character.Common;
using Spartdungeon.Domain.Item.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartdungeon.Game
{
    public class Player
    {
        public string Name { get; private set; }
        public Level Level { get; private set; }
        public Job Job { get; private set; }
        public Status Status { get; private set; }
        public int Money { get; private set; }
        public Player(string name, Job job)
        {
            Name = name;
            Job = job;
            var config = JobConfigTable.Configs[job];
            Status = new Status(config);
            Level = new Level();
        }

        public void GainExp(int exp)
        {
            Level.GainExp(exp);
        }

        /// <summary>
        /// 최대 경험치에 도달할 경우, 레벨업 진행
        /// </summary>
        /// <returns>최대 경험치에 도달하여 레벨업한 경우 true, 아닐 경우 false</returns>
        public bool TryLevelUp()
        {
            if (Level.IsLevelUpReady())
            {
                Level.IncrementLevel();
                Status.IncrementStatus(Job);
                return true;
            }
            return false;
        }

        public void EquipItem(EquipItem item)
        {
            Status.ApplyEquipItem(item.Health, item.Attack, item.Defense);
        }

        public void UnequipItem(EquipItem item)
        {
            Status.ApplyUnEquipItem(item.Health, item.Attack, item.Defense);
        }

        public void GainMoney(int money)
        {
            Money += money;
        }

        public void UseMoney(int amount)
        {
            Money -= amount;
        }
    }
}
