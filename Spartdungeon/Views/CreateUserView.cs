using Spartdungeon.Models;
using Spartdungeon.Resources;
using Spartdungeon.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartdungeon.Views
{
    public class CreateUserView
    {
        public Player CreateUser()
        {
            Console.Clear();

            string text = Strings.CREATE_USER_NAME_1;
            Console.WriteLine(text);
            Console.Write("이름: ");
            string name = InputManager.Instance.ReadLineString();

            Job job;
            int num;

            do
            {
                Console.Clear();
                Console.WriteLine(text);
                Console.WriteLine($"이름: {name}");

                Console.WriteLine("아바타의 직업은 무엇입니까?");
                Console.WriteLine("1. 전사");
                Console.WriteLine("2. 마법사");
                Console.WriteLine("3. 궁수");
                Console.WriteLine("4. 도적");
                Console.WriteLine("5. 사제");

                
                num = InputManager.Instance.ReadLineIntInRange(1, 5);
            }
            while (num == -1 || num < 1 || num > 5);

            job = (Job)num - 1;
            return new Player(name, job);
        }
    }
}
