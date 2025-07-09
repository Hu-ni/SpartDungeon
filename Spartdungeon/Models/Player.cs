using Spartdungeon.DTOs;
using Spartdungeon.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartdungeon.Models
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
            Money = 1500;
        }

        public Player(SaveData data)
        {
            Name = data.player.Name;
            Level = new Level(data.player.Level, data.player.Exp);
            Job = data.player.job;
            Money = data.player.Money;
            Status = new Status(data.player.CurrHealth, data.player.Health, data.player.Attack, data.player.Defense);
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
            Status.ApplyEquipItem(item.Status.Health, item.Status.Attack, item.Status.Defense);
        }

        public void UnequipItem(EquipItem item)
        {
            Status.ApplyUnEquipItem(item.Status.Health, item.Status.Attack, item.Status.Defense);
        }

        public void TakeDamage(float damage)
        {
            Status.TakeDamage(damage);
        }

        public void GainMoney(int money)
        {
            Money += money;
        }

        public void UseMoney(int amount)
        {
            Money -= amount;
        }

        public string JobToString()
        {
            switch (Job)
            {
                case Job.Warrior:
                    return "전사";
                case Job.Mage:
                    return "마법사";
                case Job.Archer:
                    return "궁수";
                case Job.Thief:
                    return "도적";
                case Job.Priest:
                    return "사제";
                default:
                    return "무직";
            }
        }
    }
}
