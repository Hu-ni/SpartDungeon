using Spartdungeon.Domain.Character.Controller;
using Spartdungeon.Domain.Item.Model;
using Spartdungeon.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartdungeon
{
    public class MainController
    {
        // 흐름 제어
        // 글로벌 변수 선언(아이템, 던전)

        private ItemList itemList;
        
        private UserController userController;
        private MainView mainView;
        public MainController() { }

        /// <summary>
        /// 초기 설정. (데이터 로드)
        /// </summary>
        public void Initialize()
        {
            // 아이템 던전 정보 불러오기
            itemList.Initialize();

            if (File.Exists(Strings.FILE_PLAYER_PATH))
            {
                // 플레이어 데이터 불러오기

            }
        }

        public void Play()
        {
            // 음...
            // 인트로 재생
            // 유저 생성
            userController.CreateUser();
            // 마을로 이동!
            while(true)
            {
                mainView.Home();
            }
        }
    }
}
