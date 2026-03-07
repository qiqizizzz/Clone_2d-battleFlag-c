/*
 * ┌──────────────────────────────────┐
 * │  描    述: 敌人类
 * │  类    名: Enemy.cs
 * │  创    建: By qiqizizzz
 * └──────────────────────────────────┘
 */

using System.Collections;
using DG.Tweening;
using Module.Fight.Skill;
using MVC;
using UnityEngine;
using UnityEngine.UI;

namespace Module.Fight.FightMgr
{
    public class Enemy : ModelBase, ISkill
    {
        public SkillProperty skillPro { get; set; }

        private Slider hpSlider;
        
        protected override void Start()
        {
            base.Start();
            
            hpSlider = transform.Find("hp/bg").GetComponent<Slider>();
            
            data = GameApp.ConfigManager.GetConfigData("enemy").GetDataById(Id);
            
            Type = int.Parse(this.data["Type"]);
            Attack = int.Parse(this.data["Attack"]);
            Step = int.Parse(this.data["Step"]);
            MaxHp = int.Parse(this.data["Hp"]);
            CurHp = MaxHp;
            skillPro = new SkillProperty(int.Parse(data["Skill"]));
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
        
        public void ShowSkillArea()
        {
            
        }

        public void HideSkillArea()
        {
            
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
                
                //从敌人集合中移除
                GameApp.FightManager.RemoveEnemy(this);
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