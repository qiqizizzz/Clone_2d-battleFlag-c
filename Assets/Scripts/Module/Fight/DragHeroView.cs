/*
* ┌──────────────────────────────────┐
* │  描    述: 拖拽出来的图标界面                      
* │  类    名: DragHeroView.cs       
* │  创    建: By qiqizizzz
* └──────────────────────────────────┘
*/

using System;
using Common;
using MVC.View;
using UnityEngine;
using UnityEngine.UI;

namespace Module.Fight
{
    public class DragHeroView : BaseView
    {
        private void Update()
        {
            //拖拽中跟随鼠标移动,显示的时候才进行移动
            if(!_canvas.enabled)
                return;
            
            //鼠标坐标转换成世界坐标
            Vector2 worldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = worldPos;
        }

        public override void Open(params object[] args)
        {
            transform.GetComponent<Image>().SetIcon(args[0].ToString());
        }
    }
}