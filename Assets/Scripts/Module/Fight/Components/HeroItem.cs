/*
* ┌──────────────────────────────────┐
* │  描    述: 处理拖拽英雄的脚本                      
* │  类    名: HeroItem.cs       
* │  创    建: By qiqizizzz
* └──────────────────────────────────┘
*/

using System;
using System.Collections.Generic;
using Common;
using MVC;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Module.Fight.Components
{
    public class HeroItem : MonoBehaviour,IBeginDragHandler,IEndDragHandler,IDragHandler
    {
        private Dictionary<string, string> data;

        private void Start()
        {
            transform.Find("icon").GetComponent<Image>().SetIcon(data["Icon"]);
        }

        public void Init(Dictionary<string, string> data)
        {
            this.data = data;
        }

        //开始拖拽
        public void OnBeginDrag(PointerEventData eventData)
        {
            GameApp.ViewManager.Open(ViewType.DragHeroView, data["Icon"]);
        }

        //结束拖拽
        public void OnEndDrag(PointerEventData eventData)
        {
            GameApp.ViewManager.Close((int)ViewType.DragHeroView);
        }

        //拖拽中
        public void OnDrag(PointerEventData eventData)
        {
            
        }
    }
}