/*
* ┌──────────────────────────────────┐
* │  描    述: 提示界面                      
* │  类    名: MessageView.cs       
* │  创    建: By qiqizizzz
* └──────────────────────────────────┘
*/

using MVC.View;
using UnityEngine.UI;

namespace Module.GameUI
{
    public class MessageInfo
    {
        public string MsgTxt;
        public System.Action okCallback;
        public System.Action noCallback;
    }
    
    public class MessageView : BaseView
    {
        private MessageInfo info;
        
        protected override void OnAwake()
        {
            base.OnAwake();
            Find<Button>("okBtn").onClick.AddListener(onOkBtn);
            Find<Button>("noBtn").onClick.AddListener(onNoBtn);
        }

        public override void Open(params object[] args)
        {
            info = args[0] as MessageInfo;
            Find<Text>("content/txt").text = info.MsgTxt;
        }

        private void onOkBtn()
        {
            info.okCallback?.Invoke();
        }

        private void onNoBtn()
        {
            info.noCallback?.Invoke();
            GameApp.ViewManager.Close(ViewId);
        }
    }
}