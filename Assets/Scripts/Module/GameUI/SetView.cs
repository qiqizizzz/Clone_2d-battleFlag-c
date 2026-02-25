/*
* ┌──────────────────────────────────┐
* │  描    述: 设置音量面板                      
* │  类    名: SetView.cs       
* │  创    建: By qiqizizzz
* └──────────────────────────────────┘
*/

using MVC.View;
using UnityEngine;
using UnityEngine.UI;

namespace Module.GameUI
{
    public class SetView : BaseView
    {
        protected override void OnAwake()
        {
            base.OnAwake();
            Find<Button>("bg/closeBtn").onClick.AddListener(onCloseBtn);
        }

        //关闭
        private void onCloseBtn()
        {
            GameApp.ViewManager.Close(ViewId);
        }
    }
}