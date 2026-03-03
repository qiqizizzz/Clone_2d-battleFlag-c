/*
* ┌──────────────────────────────────┐
* │  描    述: 模型基础类                      
* │  类    名: ModelBase.cs       
* │  创    建: By qiqizizzz
* └──────────────────────────────────┘
*/

using System;
using System.Collections.Generic;
using Common;
using UnityEngine;

namespace Module.Fight.FightMgr
{
    public class ModelBase : MonoBehaviour
    {
        public int Id; //物体id
        public Dictionary<string, string> data; //数据表
        public int Step; //行动力
        public int Attack; //攻击力
        public int Type;//类型
        public int MaxHp; //最大血量
        public int CurHp; //当前血量

        public int RowIndex;
        public int ColIndex;
        public SpriteRenderer bodySp;//身体图片渲染组件
        public GameObject stopObj;//停止行动的标记物体
        public Animator anim;//动画组件

        private void Awake()
        {
            bodySp = transform.Find("body").GetComponent<SpriteRenderer>();
            stopObj = transform.Find("stop").gameObject;
            anim = transform.Find("body").GetComponent<Animator>();
        }

        protected virtual void Start()
        {
            AddEvents();
        }

        protected virtual void OnDestroy()
        {
            RemoveEvents();
        }

        //注册事件
        protected virtual void AddEvents()
        {
            GameApp.MsgCenter.AddEvent(gameObject, Defines.OnSelectEvent, OnSelectCallback);
            GameApp.MsgCenter.AddEvent(Defines.OnUnSelectEvent, OnUnSelectCallback);
        }

        //移除事件
        protected virtual void RemoveEvents()
        {
            GameApp.MsgCenter.RemoveEvent(gameObject, Defines.OnSelectEvent, OnSelectCallback);
            GameApp.MsgCenter.RemoveEvent(Defines.OnUnSelectEvent, OnUnSelectCallback);
        }

        //选中回调
        protected virtual void OnSelectCallback(System.Object arg)
        {
            //执行未选中
            GameApp.MsgCenter.PostEvent(Defines.OnUnSelectEvent);
            
            GameApp.MapManager.ShowStepGrid(this, Step);
        }
        
        //未选中回调
        protected virtual void OnUnSelectCallback(System.Object arg)
        {
            GameApp.MapManager.HideStepGrid(this, Step);
        }
    }
}