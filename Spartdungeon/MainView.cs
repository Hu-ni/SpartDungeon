using Spartdungeon.Game.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartdungeon
{
    public class MainView
    {
        public void Intro()
        {

        }

        public int Home()
        {
            int input;
            do
            {
                Console.Clear();
                Console.WriteLine("1. 내 상태");
                Console.WriteLine("2. 상점");
                Console.WriteLine("3. 던전");
                Console.WriteLine("4. 인벤토리");

                input = InputManager.Instance.ReadLineInt();

            } while (input != -1);

            return input;
        }
    }
}
