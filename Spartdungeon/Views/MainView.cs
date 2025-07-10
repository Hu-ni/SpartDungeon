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
            Console.Clear();

            ViewHelper.CenterWriteLine("====================================");
            ViewHelper.CenterWriteLine("        SPART DUNGEON");
            ViewHelper.CenterWriteLine("====================================");
            Console.WriteLine();

            ViewHelper.SlowWriteCenter("당신은 모든 것을 초월한 신(神)입니다.\n\n");
            ViewHelper.SlowWriteCenter("무한한 존재로서 온 세상을 내려다보며\n");
            ViewHelper.SlowWriteCenter("수많은 운명을 빚어내던 당신은 문득 심심함을 느낍니다.\n\n");

            ViewHelper.SlowWriteCenter("그래서 당신은 결심합니다.\n");
            ViewHelper.SlowWriteCenter("자신의 분신인 [아바타]를 인간 세상으로 보내\n");
            ViewHelper.SlowWriteCenter("험난한 모험과 전투를 간접적으로 즐기기로 말이죠.\n\n");

            ViewHelper.SlowWriteCenter("하지만 무한한 힘에도 불구하고, 규칙은 존재합니다.\n");
            ViewHelper.SlowWriteCenter("당신은 아바타의 운명을 세세히 통제할 수는 없고,\n");
            ViewHelper.SlowWriteCenter("단지 [선택지]를 통해 방향만 제시할 수 있을 뿐입니다.\n\n");

            ViewHelper.SlowWriteCenter("아바타는 당신의 선택에 따라 싸우고, 성장하며,\n");
            ViewHelper.SlowWriteCenter("때론 실패하고, 때론 승리할 것입니다.\n\n");

            ViewHelper.SlowWriteCenter("이제 당신의 선택이 시작됩니다.\n");
            ViewHelper.SlowWriteCenter("아바타를 강림시켜 여정을 시작하십시오...\n\n");

            ViewHelper.CenterWriteLine("------------------------------------");
            ViewHelper.CenterWriteLine("ENTER 키를 눌러 아바타를 소환하세요.");
            ViewHelper.CenterWriteLine("------------------------------------");

            Console.ReadLine();
        }

        public int Home()
        {
            Console.Clear();

            Console.WriteLine("+--------------------------------------+");
            Console.WriteLine("|           SPART DUNGEON WORLD        |");
            Console.WriteLine("|                                      |");
            Console.WriteLine("+--------------------------------------+");

            Console.WriteLine();
            Console.WriteLine("당신은 신전에서 아바타에게 명령을 내립니다.");
            Console.WriteLine("-------------------------------------------");
            Console.WriteLine();

            Console.WriteLine("1. 내 상태");
            Console.WriteLine("2. 인벤토리");
            Console.WriteLine("3. 상점");
            Console.WriteLine("4. 던전");
            Console.WriteLine("5. 휴식하기");
            Console.WriteLine();

            Console.WriteLine("-------------------------------------------");
            Console.WriteLine("원하는 명령의 번호를 입력하세요.");
            Console.Write(">> ");

            return InputManager.ReadLineIntInRange(1, 5);
        }
    }
}
