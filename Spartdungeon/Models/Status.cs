using Spartdungeon.Resources;
using System.Xml.Serialization;

namespace Spartdungeon.Models
{
    public class Status
    {
        // 기존 스탯
        public float Health { get; private set; }
        public float Attack { get; private set; }
        public float Defense { get; private set; }

        public float CurrHealth { get; private set; }

        // 장비에 따른 스탯 증가
        public float BonusHealth { get; private set; }
        public float BonusAttack { get; private set; }
        public float BonusDefense { get; private set; }


        // 최종 스텟
        public float FinalAttack { get { return Attack + BonusAttack; } }
        public float FinalDefense { get { return Defense + BonusDefense; } }

        [XmlIgnore]
        public float MaxHealth
        {
            get
            {
                return BonusHealth + Health;
            }
        }

        public Status()
        {

        }

        public Status(JobConfig config)
        {
            Health = config.BaseHealth;
            Attack = config.BaseAttack;
            Defense = config.BaseDefense;

            BonusHealth = 0;
            BonusAttack = 0;
            BonusDefense = 0;

            CurrHealth = Health;
        }

        public Status(float currHealth, float health, float attack, float defense)
        {
            CurrHealth = currHealth;
            Health = health;
            Attack = attack;
            Defense = defense;
        }

        public void IncrementStatus(Job job)
        {
            var config = JobConfigTable.Configs[job];
            Health += config.HealthIncrement;
            Attack += config.AttackIncrement;
            Defense += config.DefenseIncrement;
        }

        public void ApplyEquipItem(float health, float attack, float defense)
        {
            BonusHealth += health;
            BonusAttack += attack;
            BonusDefense += defense;
        }

        public void ApplyUnEquipItem(float health, float attack, float defense)
        {
            BonusHealth -= health;
            BonusAttack -= attack;
            BonusDefense -= defense;
        }

        public void TakeDamage(float amount)
        {
            CurrHealth -= amount;
        }
    }
}