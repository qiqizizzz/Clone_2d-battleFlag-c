/*
* ┌──────────────────────────────────┐
* │  描    述: 战斗结束                      
* │  类    名: FightGameOverUnit.cs       
* │  创    建: By qiqizizzz
* └──────────────────────────────────┘
*/

using Module.Fight.Command;
using MVC;

namespace Module.Fight.FightMgr
{
    public class FightGameOverUnit : FightUnitBase
    {
        public override void Init()
        {
            base.Init();
            
            GameApp.CommandManager.Clear();//清除指令

            if (GameApp.FightManager.heroes.Count == 0)
            {
                GameApp.CommandManager.AddCommand(new WaitCommand(1.25f, delegate()
                {
                    GameApp.ViewManager.Open(ViewType.LossView);
                }));
            }else if (GameApp.FightManager.enemies.Count == 0)
            {
                GameApp.CommandManager.AddCommand(new WaitCommand(1.25f, delegate()
                {
                    GameApp.ViewManager.Open(ViewType.WinView);
                }));
            }
            else
            {
                
            }
        }

        public override bool Update(float dt)
        {
            return true;
        }
    }
}