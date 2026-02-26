/*
* ┌──────────────────────────────────────────────────────────────────────────┐
* │  描    述: 处理一些游戏通用ui的控制器(设置面板 提示面板 开始游戏面板等在这个控制器注册)                      
* │  类    名: GameUIController.cs       
* │  创    建: By qiqizizzz
* └──────────────────────────────────────────────────────────────────────────┘
*/

using Common;
using MVC;
using MVC.Controller;

namespace Module.GameUI
{
    public class GameUIController : BaseController
    {
        public GameUIController() : base()
        {
            #region 注册视图
            //开始游戏视图
            GameApp.ViewManager.Register(ViewType.StartView, new ViewInfo()
            {
                PrefabName = "StartView",
                controller = this,
                parentTf = GameApp.ViewManager.canvasTf
            });
            //设置面板
            GameApp.ViewManager.Register(ViewType.SetView, new ViewInfo()
            {
                PrefabName = "SetView",
                controller = this,
                Sorting_Order = 1,//设置面板显示在开始面板上一层
                parentTf = GameApp.ViewManager.canvasTf
            });
            //提示面板
            GameApp.ViewManager.Register(ViewType.MessageView, new ViewInfo()
            {
                PrefabName = "MessageView",
                controller = this,
                Sorting_Order = 999,
                parentTf = GameApp.ViewManager.canvasTf
            });
            
            #endregion
            
            //初始化事件
            InitModuleEvent();
            InitGlobalEvent();
        }

        public override void InitModuleEvent()
        {
            RegisterFunc(Defines.OpenStartView, openStartView);//注册打开开始面板
            RegisterFunc(Defines.OpenSetView, openSetView);
            RegisterFunc(Defines.OpenMessageView, openMessageView);
        }
        
        //测试模版注册事件 例子
        private void openStartView(System.Object[] args)
        {
            GameApp.ViewManager.Open(ViewType.StartView, args);
        }

        //打开设置面板
        private void openSetView(System.Object[] args)
        {
            GameApp.ViewManager.Open(ViewType.SetView, args);
        }
        
        //打开提示面板
        private void openMessageView(System.Object[] args)
        {
            GameApp.ViewManager.Open(ViewType.MessageView, args);
        }
    }
}