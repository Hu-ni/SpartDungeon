using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spartdungeon.Models;
using Spartdungeon.Services;

namespace Spartdungeon.Views
{
    public class UserInfoView
    {
        public UserInfoView() { }

        public int PrintUserInfo(Player user)
        {
            int input;

            do
            {
                Console.Clear();
                Console.WriteLine();
                Console.WriteLine("상태 보기");
                Console.WriteLine("캐릭터의 정보가 표시됩니다.");
                Console.WriteLine();
                Console.WriteLine($"Lv{user.Level.Lv.ToString("00")}");
                Console.WriteLine($"클래스: {user.JobToString()}");

                float bonusAttack = user.Status.BonusAttack;
                string text = bonusAttack > 0 ? $"(+{bonusAttack.ToString("0.#")})" : bonusAttack < 0 ? $"({bonusAttack.ToString("0.#")}" : "";
                
                Console.WriteLine($"공격력: {user.Status.FinalAttack} {text}");
                
                float bonusDefense = user.Status.BonusDefense;
                text = bonusDefense > 0 ? $"(+{bonusDefense.ToString("0.#")})" : bonusDefense < 0 ? $"({bonusDefense.ToString("0.#")})" : "";

                Console.WriteLine($"방어력: {user.Status.FinalDefense} {text}");
                
                float bonuseHealth = user.Status.BonusHealth;
                text = bonuseHealth > 0 ? $"(+{bonuseHealth.ToString("0.#")})" : bonuseHealth < 0 ? $"({bonuseHealth.ToString("0.#")})" : "";

                Console.WriteLine($"체력: {user.Status.CurrHealth}/{user.Status.MaxHealth} {text}");
                Console.WriteLine($"돈: {user.Money}");
                Console.WriteLine();
                Console.WriteLine("0. 나가기");
                Console.WriteLine();
                Console.WriteLine("원하시는 행동을 입력해주세요.");
                Console.Write(">>");

                input = InputManager.Instance.ReadLineIntInRange(0,0);
            } while (input == -1 || input != 0);
            return input;
        }
    }
}
