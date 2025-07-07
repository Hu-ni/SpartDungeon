using Spartdungeon.User.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartdungeon.User
{
    public static class UserStatic
    {
        public const int LEVEL = 1;
        public const int HEALTH = 150;
        public const int ATTACK = 10;
        public const int DEFENSE = 5;

        public Status GetDefaultStatus()
        {
            return new Status (){ HEALTH, ATTACK, DEFENSE };
        }
    }
}
