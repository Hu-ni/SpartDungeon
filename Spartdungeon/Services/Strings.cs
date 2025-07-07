using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartdungeon.Services
{
    public static class Strings
    {
        #region XML 파일위치
        public const string FILE_ITEM_PATH = "Data\\Item.xml";
        public const string FILE_DUNGEON_PATH = "Data\\Dungeon.xml";
        public const string FILE_PLAYER_PATH = "Data\\SaveData\\SaveSlot.xml";
        #endregion

        #region CreateUserView
        // 이름
        public const string CREATE_USER_NAME_1 = "당신의 아바타의 이름을 정해주세요.";

        // 직업 선택
        public const string CREATE_USER_JOB_1 = "아바타의 직업은 무엇인가요.";
        public const string CREATE_USER_JOB_2 = "1. 전사";
        public const string CREATE_USER_JOB_3 = "2. 마법사";
        public const string CREATE_USER_JOB_4 = "3. 궁수";
        public const string CREATE_USER_JOB_5 = "4. 도적";
        public const string CREATE_USER_JOB_6 = "5. 사제";
        #endregion

        #region 인벤토리
        public const string EQUIPMENT_FORMAT = "%d | %s | %s | %s";

        #endregion
    }
}
