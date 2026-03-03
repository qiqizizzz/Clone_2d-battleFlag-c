/*
* ┌──────────────────────────────────┐
* │  描    述: tip界面                      
* │  类    名: TipView.cs       
* │  创    建: By qiqizizzz
* └──────────────────────────────────┘
*/

using DG.Tweening;
using MVC.View;
using UnityEngine.UI;

namespace Module.Fight
{
    public class TipView : BaseView
    {
        public override void Open(params object[] args)
        {
            base.Open(args);
            Find<Text>("content/txt").text = args[0].ToString();
            
            //动画
            Sequence seq = DOTween.Sequence(); //创建动画序列
            seq.Append(Find("content").transform.DOScaleY(1, 0.15f)).SetEase(Ease.OutBack); //追加动画 - 展开Tips界面
            seq.AppendInterval(0.75f); //追加动画 - 等待0.75秒
            seq.Append(Find("content").transform.DOScaleY(0, 0.15f)).SetEase(Ease.Linear);//追加动画 - 收起Tips界面
            seq.AppendCallback(delegate()
            {
                GameApp.ViewManager.Close(ViewId);
            });
        }
    }
}