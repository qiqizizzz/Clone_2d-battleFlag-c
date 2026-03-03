/*
* ┌──────────────────────────────────┐
* │  描    述: 英雄信息面板                      
* │  类    名: HeroDesView.cs       
* │  创    建: By qiqizizzz
* └──────────────────────────────────┘
*/

using Common;
using Module.Fight.FightMgr;
using MVC.View;
using UnityEngine.UI;

namespace Module.Fight
{
    public class HeroDesView : BaseView
    {
        public override void Open(params object[] args)
        {
            base.Open(args);
            Hero hero = args[0] as Hero;
            Find<Image>("bg/icon").SetIcon(hero.data["Icon"]);
            Find<Image>("bg/hp/fill").fillAmount = (float)hero.CurHp / (float)hero.MaxHp;
            Find<Text>("bg/hp/txt").text = $"{hero.CurHp}/{hero.MaxHp}";
            Find<Text>("bg/atkTxt/txt").text = hero.Attack.ToString();
            Find<Text>("bg/StepTxt/txt").text = hero.Step.ToString();
        }
    }
}