namespace Spartdungeon.Domain.Character.Common
{
    public class Status
    {
        // 기존 스탯
        public float Health { get; private set; }
        public float Attack { get; private set; }
        public float Defense { get; private set; }

        // 장비에 따른 스탯 증가
        public float BonusHealth { get; private set; }
        public float BonusAttack { get; private set; }
        public float BonusDefense { get; private set; }

        public Status(JobConfig config)
        {
            Health = config.BaseHealth;
            Attack = config.BaseAttack;
            Defense = config.BaseDefense;

            BonusHealth = 0;
            BonusAttack = 0;
            BonusDefense = 0;

        }

        public Status(Status status, JobConfig config)
        {
            Health = status.Health;
            Attack = status.Attack;
            Defense = status.Defense;

            BonusHealth = status.BonusHealth;
            BonusAttack = status.BonusAttack;
            BonusDefense = status.BonusDefense;
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

    }
}