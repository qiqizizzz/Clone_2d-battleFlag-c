/*
* ┌──────────────────────────────────┐
* │  描    述: 胜利界面                      
* │  类    名: WinView.cs       
* │  创    建: By qiqizizzz
* └──────────────────────────────────┘
*/

using Common;
using Module.Loading;
using MVC;
using MVC.View;
using UnityEngine.UI;

namespace Module.Fight
{
    public class WinView : BaseView
    {
        protected override void OnStart()
        {
            base.OnStart();
            Find<Button>("bg/okBtn").onClick.AddListener(delegate()
            {
                //卸载战斗中的资源
                GameApp.FightManager.ReLoadRes();
                GameApp.ViewManager.CloseAll();
                
                //切换场景
                LoadingModel load = new LoadingModel();
                load.SceneName = "map";
                load.callback = delegate()
                {
                    GameApp.SoundManager.PlayBGM("mapbgm");
                    GameApp.ViewManager.Open(ViewType.SelectLevelView);
                };
                Controller.ApplyControllerFunc(ControllerType.Loading, Defines.LoadingScene, load);
            });
        }
    }
}