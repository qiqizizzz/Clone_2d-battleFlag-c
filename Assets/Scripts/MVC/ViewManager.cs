/*
* ┌──────────────────────────────────┐
* │  描    述: 视图管理器                      
* │  类    名: ViewManager.cs       
* │  创    建: By qiqizizzz
* └──────────────────────────────────┘
*/

using System;
using System.Collections.Generic;
using System.Linq;
using MVC.Controller;
using MVC.View;
using UnityEngine;
using UnityEngine.UI;

namespace MVC
{
    /// <summary>
    /// 视图信息类
    /// </summary>
    public class ViewInfo
    {
        public string PrefabName;
        public Transform parentTf;
        public BaseController controller;
    }
    
    public class ViewManager
    {
        public Transform canvasTf;//画布组件
        public Transform worldCanvasTf;//世界画布组件
        private Dictionary<int, IBaseView> _opens;//开启中的视图
        private Dictionary<int, IBaseView> _viewCache;//视图缓存
        private Dictionary<int, ViewInfo> _views;//注册的视图信息

        public ViewManager()
        {
            canvasTf = GameObject.Find("Canvas").transform;
            worldCanvasTf = GameObject.Find("WorldCanvas").transform;
            _opens = new Dictionary<int, IBaseView>();
            _viewCache = new Dictionary<int, IBaseView>();
            _views = new Dictionary<int, ViewInfo>();
        }
        
        //注册视图信息
        public void Register(int key, ViewInfo viewInfo)
        {
            if (_views.ContainsKey(key) == false)
            {
                _views.Add(key, viewInfo);
            }
        }

        public void Register(ViewType viewType, ViewInfo viewInfo)
        {
            Register((int)viewType,viewInfo);
        }

        //移除视图信息
        public void UnRegister(int key)
        {
            if (_views.ContainsKey(key))
            {
                _views.Remove(key);
            }
        }
        
        //移除面板
        public void RemoveView(int key)
        {
            _views.Remove(key);
            _viewCache.Remove(key);
            _opens.Remove(key);
        }
        
        //移除控制器中的面板视图
        public void RemoveViewByController(BaseController ctl)
        {
            foreach (var item in _views)
            {
                if(item.Value.controller == ctl)
                    RemoveView(item.Key);
            }
        }
        
        //是否开启中
        public bool IsOpen(int key)
        {
            return _opens.ContainsKey(key);
        }
        
        //获得某个视图
        public IBaseView GetView(int key)
        {
            if (_opens.ContainsKey(key))
            {
                return _opens[key];
            }

            if (_viewCache.ContainsKey(key))
            {
                return _viewCache[key];
            }

            return null;
        }

        public T GetView<T>(int key) where T : class, IBaseView
        {
            IBaseView view = GetView(key);
            if (view != null)
            {
                return view as T;
            }

            return null;
        }
        
        //销毁视图
        public void Destroy(int key)
        {
            IBaseView oldView = GetView(key);
            if (oldView != null)
            {
                UnRegister(key);
                oldView.DestroyView();
                _viewCache.Remove(key);
            }
        }
        
        //关闭面板视图
        public void Close(int key, params object[] args)
        {
            if(IsOpen(key) == false) return;
            
            IBaseView view = GetView(key);
            if (view != null)
            {
                _opens.Remove(key);
                view.Close(args);
                _views[key].controller.CloseView(view);
            }
        }

        
        //打开某个视图面板
        public void Open(int key, params object[] args)
        {
            IBaseView view = GetView(key);
            ViewInfo viewInfo = _views[key];
            if (view == null)
            {
                //若视图不存在,则进行资源加载
                string type = ((ViewType)key).ToString();
                GameObject uiObj = UnityEngine.Object.Instantiate(Resources.Load($"View/{viewInfo.PrefabName}"), 
                    viewInfo.parentTf) as GameObject;

                Canvas canvas = uiObj.GetComponent<Canvas>();
                if (canvas == null)
                {
                    canvas = uiObj.AddComponent<Canvas>();
                }

                if (uiObj.GetComponent<GraphicRaycaster>() == null)
                {
                    uiObj.AddComponent<GraphicRaycaster>();
                }
                canvas.overrideSorting = true;//可以设置层级
                
                /*if (viewType == null)
                {
                    Debug.LogError($"[ViewManager] 无法找到名为 '{type}' 的视图脚本，请检查 ViewType 枚举和脚本名称是否一致，以及脚本是否能被正确编译！");
                    return;
                }*/
                
                Type viewType = FindType(type); // 使用新方法查找类型
                view = uiObj.AddComponent(viewType) as IBaseView;//添加对应View脚本
                view.ViewId = key;//设置视图id
                view.Controller = viewInfo.controller;//设置控制器
                
                //添加到视图缓存
                _viewCache.Add(key, view);
                viewInfo.controller.OnLoadView(view);
            }
            
            //已经打开了
            if(this._opens.ContainsKey(key) == true) return;
            this._opens.Add(key, view);
            
            //已经初始化过
            if (view.IsInit())
            {
                view.SetVisible(true);//显示
                view.Open(args);//打开
                viewInfo.controller.OpenView(view);
            }
            else
            {
                view.InitUI();
                view.InitData();
                view.Open(args);
                viewInfo.controller.OpenView(view);
            }
        }
        public void Open(ViewType viewType, params object[] args)
        {
            Open((int)viewType, args);
        }
        
        //查找对应类型的脚本
        private Type FindType(string typeName)
        {
            return AppDomain.CurrentDomain.GetAssemblies() //获取当前应用程序域中所有已加载的程序集
                .SelectMany(assembly => assembly.GetTypes()) //将获取的所有类型扁平化为一个序列
                .FirstOrDefault(type => type.Name == typeName); //寻找匹配名称的第一个类型脚本
        }
    }

}
