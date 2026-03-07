/*
* ┌──────────────────────────────────┐
* │  描    述: 敌人回合                      
* │  类    名: FightEnemyUnit.cs       
* │  创    建: By qiqizizzz
* └──────────────────────────────────┘
*/

using Module.Fight.Command;
using MVC;

namespace Module.Fight.FightMgr
{
    public class FightEnemyUnit : FightUnitBase
    {
        public override void Init()
        {
            base.Init();
            GameApp.FightManager.ResetHeroes();//重置英雄行动
            GameApp.ViewManager.Open(ViewType.TipView, "敌人回合");
            
            GameApp.CommandManager.AddCommand(new WaitCommand(1.25f));
            
            //敌人移动 使用技能等
            
            //等待一段时间 切换回玩家回合
            GameApp.CommandManager.AddCommand(new WaitCommand(0.2f, delegate()
            {
                GameApp.FightManager.ChangeState(GameState.PlayerRound);
            }));
        }
    }
}