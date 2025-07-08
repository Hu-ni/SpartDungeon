using Spartdungeon.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartdungeon.Views
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
                Console.WriteLine("2. 인벤토리");
                Console.WriteLine("3. 상점");
                Console.WriteLine("4. 던전");

                input = InputManager.Instance.ReadLineInt();

            } while (input == -1 || input < 1 || input > 5);

            return input;
        }
    }
}
