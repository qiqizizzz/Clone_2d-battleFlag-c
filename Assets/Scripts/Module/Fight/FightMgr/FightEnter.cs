/*
* ┌──────────────────────────────────┐
* │  描    述: 进入战斗逻辑                        
* │  类    名: FightEnter.cs       
* │  创    建: By qiqizizzz
* └──────────────────────────────────┘
*/

namespace Module.Fight.FightMgr
{
    public class FightEnter : FightUnitBase
    {
        public override void Init()
        {
            //地图初始化
            GameApp.MapManager.Init();
        }
    }
}