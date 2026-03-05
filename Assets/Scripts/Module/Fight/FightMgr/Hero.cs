/*
* ┌──────────────────────────────────┐
* │  描    述: 英雄类                      
* │  类    名: Hero.cs       
* │  创    建: By qiqizizzz
* └──────────────────────────────────┘
*/

using System.Collections.Generic;
using Common;
using Module.Fight.Command;
using MVC;
using UnityEngine;

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
                //若正在执行命令则停止操作
                if(GameApp.CommandManager.IsRunningCommand) return;
                
                //执行未选中
                GameApp.MsgCenter.PostEvent(Defines.OnUnSelectEvent);

                if (IsStop == false)
                {
                    GameApp.MapManager.ShowStepGrid(this, Step);//显示路径
                    GameApp.CommandManager.AddCommand(new ShowPathCommand(this));//添加显示路径命令
                    addOptionEvents();//添加选项事件
                }
                
                GameApp.ViewManager.Open(ViewType.HeroDesView, this);
            }
            
        }

        private void addOptionEvents()
        {
            GameApp.MsgCenter.AddTempEvent(Defines.OnAttackEvent, onAttackCallback);
            GameApp.MsgCenter.AddTempEvent(Defines.OnIdleEvent, onIdleCallback);
            GameApp.MsgCenter.AddTempEvent(Defines.OnCancelEvent, onCancelCallback);
        }

        //攻击
        private void onAttackCallback(System.Object arg)
        {
            Debug.Log("攻击事件");
        }
        
        //待机
        private void onIdleCallback(System.Object arg)
        {
            IsStop = true;
        }

        //取消
        private void onCancelCallback(System.Object arg)
        {
            GameApp.CommandManager.UnDo();
        }

        //未选中
        protected override void OnUnSelectCallback(object arg)
        {
            base.OnUnSelectCallback(arg);
            GameApp.ViewManager.Close((int)ViewType.HeroDesView);
        }
    }
}