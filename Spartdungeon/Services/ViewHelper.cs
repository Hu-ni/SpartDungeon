using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartdungeon.Services
{
    public static class ViewHelper
    {
        public static void CenterWriteLine(string text)
        {
            int consoleWidth = Console.WindowWidth;
            int textWidth = 0;
            foreach (char c in text)
            {
                if (c >= 0xAC00 && c <= 0xD7A3)
                    textWidth += 2;
                else
                    textWidth += 1;
            }

            int padding = (consoleWidth - textWidth) / 2;
            padding = Math.Max(padding, 0); // 음수 방어

            Console.WriteLine(new string(' ', padding) + text);
        }

        public static void CenterWrite(string text)
        {
            int consoleWidth = Console.WindowWidth;
            int textWidth = 0;
            foreach (char c in text)
            {
                if (c >= 0xAC00 && c <= 0xD7A3)
                    textWidth += 2;
                else
                    textWidth += 1;
            }

            int padding = (consoleWidth - textWidth) / 2;
            Console.Write(new string(' ', padding) + text);
        }

        public static void PrintTitle(string title)
        {
            Console.WriteLine();
            Console.WriteLine("====================================");
            Console.WriteLine($" {title}");
            Console.WriteLine("====================================");
        }

        public static void PrintNotification(string message)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"[알림] {message}");
            Console.ResetColor();
        }

        public static void PrintDivider()
        {
            Console.WriteLine("------------------------------------");
        }

        public static void PrintInvalidInput()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("잘못된 입력입니다.");
            Console.ResetColor();
        }
        public static void SlowWrite(string text, int delay = 40)
        {
            foreach (char c in text)
            {
                Console.Write(c);
                Thread.Sleep(delay);
            }
        }

        public static void SlowWriteCenter(string text, int delay = 40)
        {
            int width = Console.WindowWidth;

            int textWidth = 0;
            foreach (char c in text)
            {
                if (c >= 0xAC00 && c <= 0xD7A3)
                    textWidth += 2;
                else
                    textWidth += 1;
            }

            int padding = (width - textWidth) / 2;
            padding = Math.Max(padding, 0);

            Console.Write(new string(' ', padding));

            foreach (char c in text)
            {
                Console.Write(c);
                Thread.Sleep(delay);
            }
            //Console.WriteLine();
        }
    }
}
