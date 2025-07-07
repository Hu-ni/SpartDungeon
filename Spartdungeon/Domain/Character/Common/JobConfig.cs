using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartdungeon.Domain.Character.Common
{
    public class JobConfig
    {
        // Status
        public float BaseHealth { get; set; }
        public float BaseAttack { get; set; }
        public float BaseDefense { get; set; }

        public float HealthIncrement { get; set; }
        public float AttackIncrement { get; set; }
        public float DefenseIncrement { get; set; }

    }
}
