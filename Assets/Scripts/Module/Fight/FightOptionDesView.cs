/*
* ┌──────────────────────────────────┐
* │  描    述: 战斗选项界面                      
* │  类    名: FightOptionDesView.cs       
* │  创    建: By qiqizizzz
* └──────────────────────────────────┘
*/

using MVC;
using MVC.View;
using UnityEngine.UI;

namespace Module.Fight
{
    public class FightOptionDesView : BaseView
    {
        protected override void OnStart()
        {
            base.OnStart();
            Find<Button>("bg/turnBtn").onClick.AddListener(onChangeEnemyTurnBtn);
            Find<Button>("bg/gameOverBtn").onClick.AddListener(onGameOverBtn);
            Find<Button>("bg/cancelBtn").onClick.AddListener(onCancelBtn);
        }

        //结束本局游戏
        private void onGameOverBtn()
        {
            GameApp.ViewManager.Close((int)ViewType.FightOptionDesView);
        }

        //切换到敌人回合
        private void onChangeEnemyTurnBtn()
        {
            GameApp.ViewManager.Close((int)ViewType.FightOptionDesView);
        }

        //取消
        private void onCancelBtn()
        {
            GameApp.ViewManager.Close((int)ViewType.FightOptionDesView);
        }
    }
}