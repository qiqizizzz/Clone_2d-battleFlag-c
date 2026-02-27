/*
* ┌──────────────────────────────────┐
* │  描    述: 加载场景控制器                      
* │  类    名: LoadingController.cs       
* │  创    建: By qiqizizzz
* └──────────────────────────────────┘
*/

using Common;
using MVC;
using MVC.Controller;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Module.Loading
{
    public class LoadingController : BaseController
    {
        private AsyncOperation asyncOp;
        
        public LoadingController() : base()
        {
            GameApp.ViewManager.Register(ViewType.LoadingView, new ViewInfo()
            {
                PrefabName = "LoadingView",
                controller = this,
                parentTf = GameApp.ViewManager.canvasTf
            });
            
            InitModuleEvent();
        }

        public override void InitModuleEvent()
        {
            RegisterFunc(Defines.LoadingScene, loadSceneCallBack);
        }

        //加载场景回调
        private void loadSceneCallBack(System.Object[] args)
        {
            LoadingModel loadingModel = args[0] as LoadingModel;
            
            SetModel(loadingModel);
            
            //打开加载界面
            GameApp.ViewManager.Open(ViewType.LoadingView);
            
            //加载场景
            asyncOp = SceneManager.LoadSceneAsync(loadingModel.SceneName);

            asyncOp.completed += onLoadedEndCallBack;
        }

        //加载后回调
        private void onLoadedEndCallBack(AsyncOperation op)
        {
            asyncOp.completed -= onLoadedEndCallBack;//进入函数后取消订阅
            
            //延迟回调
            GameApp.TimerManager.Register(0.25f, delegate()
            {
                GetModel<LoadingModel>().callback?.Invoke();//执行回调
                GameApp.ViewManager.Close((int)ViewType.LoadingView);//关闭加载界面
            });
        }
    }
    
    
}