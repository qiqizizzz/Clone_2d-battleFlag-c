/*
* ┌──────────────────────────────────┐
* │  描    述: 敌人类                      
* │  类    名: Enemy.cs       
* │  创    建: By qiqizizzz
* └──────────────────────────────────┘
*/

using MVC.Model;

namespace Module.Fight.FightMgr
{
    public class Enemy : ModelBase
    {
        protected override void Start()
        {
            base.Start();

            data = GameApp.ConfigManager.GetConfigData("enemy").GetDataById(Id);
            
            Type = int.Parse(this.data["Type"]);
            Attack = int.Parse(this.data["Attack"]);
            Step = int.Parse(this.data["Step"]);
            MaxHp = int.Parse(this.data["Hp"]);
            CurHp = MaxHp;
        }
    }
}