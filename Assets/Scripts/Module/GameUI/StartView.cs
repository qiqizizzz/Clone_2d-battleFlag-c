/*
* ┌──────────────────────────────────┐
* │  描    述: 开始游戏界面                      
* │  类    名: StartView.cs       
* │  创    建: By qiqizizzz
* └──────────────────────────────────┘
*/

using Common;
using Module.Loading;
using MVC;
using MVC.View;
using UnityEngine;
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
            //关闭开始界面
            GameApp.ViewManager.Close(ViewId);
            
            LoadingModel loadingModel = new LoadingModel();
            loadingModel.SceneName = "map";
            loadingModel.callback = delegate()
            {
                //打开选择关卡界面
                Controller.ApplyControllerFunc(ControllerType.Level, Defines.OpenSelectLevelView);
            };
            Controller.ApplyControllerFunc(ControllerType.Loading, Defines.LoadingScene, loadingModel);
        }
        
        //打开设置面板
        private void onSetBtn()
        {
            ApplyFunc(Defines.OpenSetView);
        }
        
        //退出游戏
        private void onQuitGameBtn()
        {
            Controller.ApplyControllerFunc(ControllerType.GameUI, Defines.OpenMessageView, new MessageInfo()
            {
                okCallback = delegate()
                {
                    Application.Quit();//退出游戏
                },
                MsgTxt = "确认退出游戏吗?"
            });
        }
    }
}