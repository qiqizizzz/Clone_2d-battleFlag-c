/*
* ┌──────────────────────────────────┐
* │  描    述: 关卡管理器                      
* │  类    名: LevelController.cs       
* │  创    建: By qiqizizzz
* └──────────────────────────────────┘
*/

using Common;
using MVC;
using MVC.Controller;

namespace Module.Level
{
    public class LevelController : BaseController
    {
        public LevelController() : base()
        {
            GameApp.ViewManager.Register(ViewType.SelectLevelView, new ViewInfo()
            {
                PrefabName = "SelectLevelView",
                controller = this,
                parentTf = GameApp.ViewManager.canvasTf
            });
            
            InitModuleEvent();
        }

        public override void InitModuleEvent()
        {
            RegisterFunc(Defines.OpenSelectLevelView, onOpenSelectLevelView);
        }

        private void onOpenSelectLevelView(System.Object[] args)
        {
            GameApp.ViewManager.Open(ViewType.SelectLevelView, args);
        }
    }
}