using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartdungeon.User.Model
{
    struct Status
    {
        public int health;
        public int attack;
        public int defense;
    }

    enum Job
    { 
        None,
        Warrior,
        Assasin
    }

    public class User
    {
        private string name;
        private int level;
        private Job job;
        private Status status;

        User(string name, Job job)
        {
            this.name = name;
            this.job = job;
            int level = 1;
            status.health = 150;
            status.attack = 10;
            status.defense = 5;
        }


    }
}
