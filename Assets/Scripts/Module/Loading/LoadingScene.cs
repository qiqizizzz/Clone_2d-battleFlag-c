/*
* ┌──────────────────────────────────┐
* │  描    述: 加载场景并转换场景                      
* │  类    名: LoadingScene.cs       
* │  创    建: By qiqizizzz
* └──────────────────────────────────┘
*/

using Common;
using MVC;
using MVC.Controller;

namespace Module.Loading
{
    public class LoadingScene
    {

        public void LoadScene(BaseController Controller, string sceneName, int ViewId, params object[] args)
        {
            GameApp.ViewManager.Close(ViewId);
            
            LoadingModel loadingModel = new LoadingModel();
            loadingModel.SceneName = sceneName;
            loadingModel.callback = delegate()
            {
                //打开选择关卡界面
                Controller.ApplyControllerFunc(ControllerType.Level, Defines.OpenSelectLevelView);
            };
            Controller.ApplyControllerFunc(ControllerType.Loading, Defines.LoadingScene, loadingModel);
        }
    }
}