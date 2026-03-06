/*
 * ┌──────────────────────────────────┐
 * │  描    述: 敌人类
 * │  类    名: Enemy.cs
 * │  创    建: By qiqizizzz
 * └──────────────────────────────────┘
 */

using MVC;
using MVC.Model;
using UnityEngine;

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

        //选中
        protected override void OnSelectCallback(object arg)
        {
            if(GameApp.CommandManager.IsRunningCommand) return;
            
            base.OnSelectCallback(arg);
            GameApp.ViewManager.Open(ViewType.EnemyDesView, this);
        }

        //未选中
        protected override void OnUnSelectCallback(object arg)
        {
            base.OnUnSelectCallback(arg);
            GameApp.ViewManager.Close((int)ViewType.EnemyDesView);
        }
    }
}