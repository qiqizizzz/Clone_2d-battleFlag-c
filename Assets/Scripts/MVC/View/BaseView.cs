/*
* ┌──────────────────────────────────┐
* │  描    述:                       
* │  类    名: BaseView.cs       
* │  创    建: By qiqizizzz
* └──────────────────────────────────┘
*/

using System;
using System.Collections.Generic;
using MVC.Controller;
using UnityEngine;
using UnityEngine.UI;

namespace MVC.View
{
    public class BaseView : MonoBehaviour,IBaseView
    {
        public int ViewId { get; set; }
        public BaseController Controller { get; set; }

        protected Canvas _canvas;
        protected Dictionary<string, GameObject> m_cache_gos = new Dictionary<string, GameObject>();//缓存物品的字典

        private bool _isInit = false;//是否初始化
        
        private void Awake()
        {
            _canvas = gameObject.GetComponent<Canvas>();
            OnAwake();
        }

        private void Start()
        {
            OnStart();
        }

        protected virtual void OnAwake()
        {
            
        }

        protected virtual void OnStart()
        {
            
        }

        public bool IsInit() => _isInit;

        public bool IsShow() => _canvas.enabled;

        public void InitUI()
        {
            
        }

        public virtual void InitData()
        {
            _isInit = true;
        }

        public virtual void Open(params object[] args)
        {
            
        }

        public virtual void Close(params object[] args)
        {
            SetVisible(false);
        }

        public void DestroyView()
        {
            Controller = null;
            Destroy(gameObject);
        }

        public void ApplyFunc(string eventName, params object[] args)
        {
            this.Controller.ApplyFunc(eventName, args);
        }

        public void ApplyControllerFunc(int controllerKey, string eventName, params object[] args)
        {
            this.Controller.ApplyControllerFunc(controllerKey, eventName, args);
        }

        public void SetVisible(bool isVisible) => this._canvas.enabled = isVisible;

        public GameObject Find(string res)
        {
            if(m_cache_gos.ContainsKey(res)) return m_cache_gos[res];
            
            m_cache_gos.Add(res, transform.Find(res).gameObject);
            return m_cache_gos[res];
        }

        public T Find<T>(string res) where T : Component
        {
            GameObject obj = Find(res);
            return obj.GetComponent<T>();
        }
    }
}