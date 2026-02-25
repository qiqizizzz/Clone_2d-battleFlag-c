/*
* ┌──────────────────────────────────┐
* │  描    述: 开始游戏界面                      
* │  类    名: StartView.cs       
* │  创    建: By qiqizizzz
* └──────────────────────────────────┘
*/

using Common;
using MVC.View;
using UnityEngine.UI;

namespace Module.GameUI
{
    public class StartView : BaseView
    {
        protected override void OnAwake()
        {
            base.OnAwake();
            
            Find<Button>("startBtn").onClick.AddListener(onStartGameBtn);
            Find<Button>("setBtn").onClick.AddListener(onSetBtn);
            Find<Button>("quitBtn").onClick.AddListener(onQuitGameBtn);
            
        }

        //开始游戏
        private void onStartGameBtn()
        {
            
        }
        
        //打开设置面板
        private void onSetBtn()
        {
            ApplyFunc(Defines.OpenSetView);
        }
        
        //退出游戏
        private void onQuitGameBtn()
        {
            
        }
    }
}