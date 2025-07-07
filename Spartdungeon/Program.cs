using Spartdungeon.Domain.Character.View;

namespace Spartdungeon
{
    class Program
    {
        static void Main(string[] args)
        {
            // 시나리오
            // 게임 실행 -> 데이터 불러오기 -> 인트로 -> 유저 생성 -> 마을(로비)  -> 던전
            //                                              -> 상점
            //                                              -> 휴식
            //                                              -> 내 정보
            //                                              -> 인벤토리
            // 데이터 불러오기
            // 게임 실행 -> 불러오는 중 -> 마을(로비) 

            /* 현재 여기서는 1단 Save Data 있는지 확인
             * 만약 없을 경우 인트로로 이동.
             * 있을 경우 XML 데이터 불러오기
             * 
             * 흐름을 시작해줄 Controller가 필요함.
             * 입력에 따라 User, Dungeon, Shop로 이동
            */
            //while(true){ }
            CreateUserView createUserView = new CreateUserView();
            createUserView.CreatePlayer();
            return;
        }
    }
}
