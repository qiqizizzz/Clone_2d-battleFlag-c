/*
* ┌──────────────────────────────────┐
* │  描    述: 选择关卡信息界面                      
* │  类    名: SelectLevelView.cs       
* │  创    建: By qiqizizzz
* └──────────────────────────────────┘
*/

using Common;
using Module.Loading;
using MVC;
using MVC.View;
using UnityEngine.UI;

namespace Module.Level
{
    public class SelectLevelView : BaseView
    {
        protected override void OnStart()
        {
            base.OnStart();
            Find<Button>("close").onClick.AddListener(onCloseBtn);
        }

        //返回开始界面
        private void onCloseBtn()
        {
            //关闭开始界面
            GameApp.ViewManager.Close(ViewId);
            
            LoadingModel loadingModel = new LoadingModel();
            loadingModel.SceneName = "game";
            loadingModel.callback = delegate()
            {
                //打开开始界面
                Controller.ApplyControllerFunc(ControllerType.GameUI, Defines.OpenStartView);
            };
            Controller.ApplyControllerFunc(ControllerType.Loading, Defines.LoadingScene, loadingModel);
        }

        //显示关卡详情面板
        public void ShowLevelDes()
        {
            Find("level").SetActive(true);
            LevelData current = Controller.GetModel<LevelModel>().current;
            Find<Text>("level/name/txt").text = current.Name;
            Find<Text>("level/des/txt").text = current.Des;
        }

        //隐藏关卡详情面板
        public void HideLevelDes()
        {
            Find("level").SetActive(false);
        }
    }
}