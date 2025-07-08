using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartdungeon.Services
{
    public class InputManager
    {
        private static InputManager _instance;
        public static InputManager Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new InputManager();
                return _instance;
            }
        }

        public string ReadLineString()
        {
            return Console.ReadLine();
        }

        public int ReadLineInt()
        {
            int input;
            if (int.TryParse(Console.ReadLine(), out input))
                return input;
            return -1;
        }

        public int[] ReadLineIntArray()
        {
            return Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
        }

        public void CenterWriteLine(string text)
        {
            int consoleWidth = Console.WindowWidth;
            int padding = (consoleWidth - text.Length) / 2;
            Console.WriteLine(new string(' ', padding) + text);
        }

        public void CenterWrite(string text)
        {
            int consoleWidth = Console.WindowWidth;
            int padding = (consoleWidth - text.Length) / 2;
            Console.Write(new string(' ', padding) + text);
        }
    }
}
