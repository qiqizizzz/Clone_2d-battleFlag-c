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
            for (int i = 0; i < GameApp.FightManager.enemies.Count; i++)
            {
                Enemy enemy = GameApp.FightManager.enemies[i];
                GameApp.CommandManager.AddCommand(new WaitCommand(0.25f));//等待
                GameApp.CommandManager.AddCommand(new AiMoveCommand(enemy));//移动
                GameApp.CommandManager.AddCommand(new WaitCommand(0.25f));//等待
                GameApp.CommandManager.AddCommand(new SkillCommand(enemy));//使用技能
                GameApp.CommandManager.AddCommand(new WaitCommand(0.25f));//等待
            }
            
            //等待一段时间 切换回玩家回合
            GameApp.CommandManager.AddCommand(new WaitCommand(0.2f, delegate()
            {
                GameApp.FightManager.ChangeState(GameState.PlayerRound);
            }));
        }
    }
}