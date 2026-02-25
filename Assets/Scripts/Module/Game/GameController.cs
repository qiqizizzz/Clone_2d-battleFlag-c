/*
* ┌──────────────────────────────────────────────┐
* │  描    述: 游戏主控制器(处理开始游戏 保存 退出等操作)                      
* │  类    名: GameController.cs       
* │  创    建: By qiqizizzz
* └──────────────────────────────────────────────┘
*/

using Common;
using MVC;
using MVC.Controller;

namespace Module.Game
{
    public class GameController : BaseController
    {
        public GameController() : base()
        {
            //目前没有视图
            
            InitModuleEvent();
            InitModuleEvent();
        }

        public override void Init()
        {
            //调用GameUIController开发面板事件
            ApplyControllerFunc(ControllerType.GameUI, Defines.OpenStartView);
        }
    }
}