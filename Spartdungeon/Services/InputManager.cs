using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartdungeon.Services
{
    public static class InputManager
    {
        public static string ReadLineString()
        {
            return Console.ReadLine();
        }

        public static int ReadLineInt()
        {
            int input;
            if (int.TryParse(Console.ReadLine(), out input))
                return input;
            return -1;
        }

        public static int[] ReadLineIntArray()
        {
            return Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
        }

        public static int ReadLineIntInRange(int min, int max)
        {
            int value;
            while (true)
            {
                value = ReadLineInt();
                if (value >= min && value <= max)
                    return value;

                ViewHelper.PrintInvalidInput();
            }
        }
    }
}
