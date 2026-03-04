/*
* ┌──────────────────────────────────┐
* │  描    述: 英雄类                      
* │  类    名: Hero.cs       
* │  创    建: By qiqizizzz
* └──────────────────────────────────┘
*/

using System.Collections.Generic;
using Module.Fight.Command;
using MVC;

namespace Module.Fight.FightMgr
{
    public class Hero : ModelBase
    {
        public void Init(Dictionary<string,string> data, int row, int col)
        {
            this.data = data;
            this.RowIndex = row;
            this.ColIndex = col;
            Id = int.Parse(this.data["Id"]);
            Type = int.Parse(this.data["Type"]);
            Attack = int.Parse(this.data["Attack"]);
            Step = int.Parse(this.data["Step"]);
            MaxHp = int.Parse(this.data["Hp"]);
            CurHp = MaxHp;
        }

        //选中
        protected override void OnSelectCallback(object arg)
        {
            //玩家回合才能选择角色
            if (GameApp.FightManager.state == GameState.PlayerRound)
            {
                //若已经停止行动了则停止操作
                if(IsStop) return;
                
                //若正在执行命令则停止操作
                if(GameApp.CommandManager.IsRunningCommand) return;
                
                //添加显示路径命令
                GameApp.CommandManager.AddCommand(new ShowPathCommand(this));
                
                base.OnSelectCallback(arg);
                GameApp.ViewManager.Open(ViewType.HeroDesView, this);
            }
            
        }

        //未选中
        protected override void OnUnSelectCallback(object arg)
        {
            base.OnUnSelectCallback(arg);
            GameApp.ViewManager.Close((int)ViewType.HeroDesView);
        }
    }
}