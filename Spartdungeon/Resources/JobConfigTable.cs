using Spartdungeon.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartdungeon.Resources
{
    public enum Job
    {
        Warrior,
        Mage,
        Archer,
        Thief,
        Priest
    }

    public static class JobConfigTable
    {
        public static readonly Dictionary<Job, JobConfig> Configs;

        static JobConfigTable()
        {
            Configs = new Dictionary<Job, JobConfig>
            {
                { Job.Warrior,  new JobConfig { BaseHealth = 150, BaseAttack = 5, BaseDefense = 15,
                                                HealthIncrement = 10, AttackIncrement = 0.5f, DefenseIncrement = 1 } },
                { Job.Mage,     new JobConfig { BaseHealth = 100, BaseAttack = 15, BaseDefense = 5,
                                                HealthIncrement = 5, AttackIncrement = 2f, DefenseIncrement = 0.5f} },
                { Job.Archer,   new JobConfig { BaseHealth = 100, BaseAttack = 10, BaseDefense = 10,
                                                HealthIncrement = 10, AttackIncrement = 1.5f, DefenseIncrement = 0.5f} },
                { Job.Thief,    new JobConfig { BaseHealth = 150, BaseAttack = 15, BaseDefense = 5,
                                                HealthIncrement = 10, AttackIncrement = 1.5f, DefenseIncrement = 0.5f} },
                { Job.Priest,   new JobConfig { BaseHealth = 150, BaseAttack = 10, BaseDefense = 10,
                                                HealthIncrement = 5, AttackIncrement = 1f, DefenseIncrement = 1f} },

            };
        }
    }
}
