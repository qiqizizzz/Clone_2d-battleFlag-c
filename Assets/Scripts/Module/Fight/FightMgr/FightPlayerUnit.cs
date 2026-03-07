/*
* ┌──────────────────────────────────┐
* │  描    述: 玩家回合                      
* │  类    名: FightPlayerUnit.cs       
* │  创    建: By qiqizizzz
* └──────────────────────────────────┘
*/

using MVC;
using UnityEngine;

namespace Module.Fight.FightMgr
{
    public class FightPlayerUnit : FightUnitBase
    {
        public override void Init()
        {
            base.Init();
            GameApp.FightManager.ResetEnemies();//重置敌人行动
            GameApp.ViewManager.Open(ViewType.TipView, "玩家回合");
        }
    }
}