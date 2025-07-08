using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartdungeon.Models
{
    public class Level
    {
        public const int BaseLevel = 1;

        public int Lv { get; private set; }
        public int Exp { get; private set; }

        /// <summary>
        /// 초기 레벨 설정(1), 경험치 설정(0)
        /// </summary>
        public Level()
        {
            Lv = BaseLevel;
            Exp = 0;
        }

        /// <summary>
        /// 입력된 레벨과 경험치 설정.
        /// </summary>
        /// <param name="lv">입력된 레벨</param>
        /// <param name="exp">입력된 경험치</param>
        public Level(int lv, int exp)
        {
            Lv = lv;
            Exp = exp;
        }

        public void GainExp(int amount)
        {
            Exp += amount;
        }

        public void LoseExp(int amount)
        {
            Exp -= amount;
        }

        ///<summary>
        /// 레벨업 가능한지 확인하며, 가능할 경우 레벨 1 증가와 경험치 초기화
        ///</summary>
        public int IncrementLevel()
        {
            Lv += 1;
            Exp = 0;

            return Lv;
        }

        /// <summary>
        /// 최대 경험치. 레벨업을 하기 위한 최대 경험치 반환
        /// </summary>
        /// <param name="level">현재 레벨</param>
        /// <returns>레벨업에 필요한 최대 경험치</returns>
        public int GoalExp(int level)
        {
            return level;
        }

        /// <summary>
        /// 현재 경험치가 최대로 도달했는지 검사
        /// </summary>
        /// <returns>만약 최대 경험치일 경우 true, 아닐 경우 false.</returns>
        public bool IsLevelUpReady()
        {
            if (Exp == GoalExp(Lv))
            {

                return true;
            }
            return false;
        }
    }
}
