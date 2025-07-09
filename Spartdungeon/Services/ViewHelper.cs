using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartdungeon.Services
{
    public static class ViewHelper
    {
        public static void PrintInvalidInput()
        {
            Console.WriteLine("잘못된 입력입니다.");
        }

        public static void ShowMessage(string message)
        {
            Console.WriteLine(message);
        }
    }
}
