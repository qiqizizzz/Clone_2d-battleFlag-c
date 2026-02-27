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
            SetModel(new LevelModel());//设置数据模型
            
            GameApp.ViewManager.Register(ViewType.SelectLevelView, new ViewInfo()
            {
                PrefabName = "SelectLevelView",
                controller = this,
                parentTf = GameApp.ViewManager.canvasTf
            });
            
            InitModuleEvent();
            InitGlobalEvent();
        }

        public override void Init()
        {
            model.Init();//初始化数据
        }

        public override void InitModuleEvent()
        {
            RegisterFunc(Defines.OpenSelectLevelView, onOpenSelectLevelView);
        }

        //注册全局事件
        public override void InitGlobalEvent()
        {
            GameApp.MsgCenter.AddEvent(Defines.ShowLevelDesEvent, onShowLevelDesCallback);
            GameApp.MsgCenter.AddEvent(Defines.HideLevelDesEvent, onHideLevelDesCallback);
        }

        //移除全局事件
        public override void RemoveGlobalEvent()
        {
            GameApp.MsgCenter.RemoveEvent(Defines.ShowLevelDesEvent, onShowLevelDesCallback);
            GameApp.MsgCenter.RemoveEvent(Defines.HideLevelDesEvent, onHideLevelDesCallback);
        }

        private void onShowLevelDesCallback(System.Object arg)
        {
            LevelModel levelModel = GetModel<LevelModel>();
            levelModel.current = levelModel.GetLevel(int.Parse(arg.ToString()));
            
            GameApp.ViewManager.GetView<SelectLevelView>((int)ViewType.SelectLevelView).ShowLevelDes();
        }
        
        private void onHideLevelDesCallback(System.Object arg)
        {
            GameApp.ViewManager.GetView<SelectLevelView>((int)ViewType.SelectLevelView).HideLevelDes();
        }

        private void onOpenSelectLevelView(System.Object[] args)
        {
            GameApp.ViewManager.Open(ViewType.SelectLevelView, args);
        }
    }
}