using Spartdungeon.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartdungeon.Views
{
    public class RestView
    {
        public int Rest(int playerMoney, string message)
        {
            int input = -1;

            Console.Clear();
            ViewHelper.PrintTitle("휴식하기");
            Console.WriteLine($"{Defines.REST_GOLD}원을 소비하여 체력 회복할 수 있습니다.(보유 돈: {playerMoney})");
            Console.WriteLine();

            if (!string.IsNullOrWhiteSpace(message))
            {
                ViewHelper.PrintNotification(message);
                Console.WriteLine();
            }

            Console.WriteLine("1. 휴식하기");
            Console.WriteLine("0. 나가기");
            Console.WriteLine();
            Console.WriteLine("원하시는 행동을 입력해주세요.");
            Console.Write(">>");
            input = InputManager.ReadLineIntInRange(0, 1);
            return input;
        }
    }
}
