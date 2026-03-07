/*
* ┌──────────────────────────────────┐
* │  描    述: 英雄类                      
* │  类    名: Hero.cs       
* │  创    建: By qiqizizzz
* └──────────────────────────────────┘
*/

using System.Collections;
using System.Collections.Generic;
using Common;
using DG.Tweening;
using Module.Fight.Command;
using Module.Fight.Skill;
using MVC;
using UnityEngine;
using UnityEngine.UI;

namespace Module.Fight.FightMgr
{
    public class Hero : ModelBase, ISkill
    {
        public SkillProperty skillPro { get; set; }
        
        private Slider hpSlider;

        protected override void Start()
        {
            base.Start();
            
            hpSlider = transform.Find("hp/bg").GetComponent<Slider>();
        }

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
            skillPro = new SkillProperty(int.Parse(this.data["Skill"]));
        }

        //显示技能区域
        public void ShowSkillArea()
        {
            GameApp.MapManager.ShowAttackStep(this, skillPro.AttackRange, Color.red);
        }

        //隐藏技能攻击区域
        public void HideSkillArea()
        {
            GameApp.MapManager.HideAttackStep(this, skillPro.AttackCount);
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
            GameApp.CommandManager.AddCommand(new ShowSkillAreaCommand(this));
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

        //受伤
        public override void GetHit(ISkill skill)
        {
            //播放受伤特效
            GameApp.SoundManager.PlayEffect("hit", transform.position);
            //扣血
            CurHp -= skill.skillPro.Attack;
            //显示伤害数字
            GameApp.ViewManager.ShowHitNum($"-{skill.skillPro.Attack}", Color.red, transform.position);
            //击中特效
            PlayEffect(skill.skillPro.AttackEffect);
            
            //判断是否死亡
            if (CurHp <= 0)
            {
                CurHp = 0;
                PlayAni("die");
                Destroy(gameObject, 1.2f);
                
                //从英雄集合中移除
                GameApp.FightManager.RemoveHero(this);
            }
            
            StopAllCoroutines();
            StartCoroutine(ChangeColor());
            StartCoroutine(UpdateHpSlider());
        }
        
        private IEnumerator ChangeColor()
        {
            bodySp.material.SetFloat("_FlashAmount", 1);
            yield return new WaitForSeconds(0.25f);
            bodySp.material.SetFloat("_FlashAmount", 0);
        }

        private IEnumerator UpdateHpSlider()
        {
            hpSlider.gameObject.SetActive(true);
            hpSlider.DOValue((float)CurHp / (float)MaxHp, 0.25f);
            yield return new WaitForSeconds(0.75f);
            hpSlider.gameObject.SetActive(false);
        }
    }
}