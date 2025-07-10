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

            ViewHelper.PrintTitle("아바타 생성");

            Console.WriteLine("아바타의 이름을 정해주세요.");
            Console.Write("이름: ");
            string name = InputManager.ReadLineString();

            Console.Clear();
            ViewHelper.PrintTitle("아바타 생성");
            Console.WriteLine("아바타의 이름을 정해주세요.");
            Console.WriteLine($"이름: {name}");
            ViewHelper.PrintDivider();
            Console.WriteLine();

            Console.WriteLine("아바타의 직업은 무엇입니까?");
            Console.WriteLine("1. 전사");
            Console.WriteLine("2. 마법사");
            Console.WriteLine("3. 궁수");
            Console.WriteLine("4. 도적");
            Console.WriteLine("5. 사제");
            ViewHelper.PrintDivider();
            Console.WriteLine();
            int input = InputManager.ReadLineIntInRange(1, 5);
            Job job = (Job)input - 1;
            return new Player(name, job);
        }
    }
}
