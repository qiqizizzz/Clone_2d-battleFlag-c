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
using Module.Fight.FightMgr;
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
            //检测拖拽后的位置是否有block脚本
            Tools.ScreenPointToRay2D(eventData.pressEventCamera, eventData.position, delegate(Collider2D col)
            {
                Block b = col.GetComponent<Block>();
                if (b != null)
                {
                    //有方块
                    Debug.Log(b);
                    Destroy(gameObject);//删除拖拽的英雄图标
                    //创建英雄物体
                    GameApp.FightManager.AddHero(b,data);
                }
                    
            });
        }

        //拖拽中
        public void OnDrag(PointerEventData eventData)
        {
            
        }
    }
}