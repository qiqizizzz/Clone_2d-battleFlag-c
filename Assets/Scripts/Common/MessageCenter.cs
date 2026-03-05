/*
* ┌──────────────────────────────────┐
* │  描    述: 消息处理中心脚本                      
* │  类    名: MessageCenter.cs       
* │  创    建: By qiqizizzz
* └──────────────────────────────────┘
*/

using System;
using System.Collections.Generic;

namespace Common
{
    public class MessageCenter
    {
        private Dictionary<string, System.Action<object>> msgDic;//存储普通的消息字典
        private Dictionary<string, System.Action<object>> tempMsgDic;//存储临时的消息字典,实行后清除
        private Dictionary<System.Object, Dictionary<string, System.Action<object>>> objMsgDic;//存储特定对象的消息字典

        public MessageCenter()
        {
            msgDic = new Dictionary<string, Action<object>>();
            tempMsgDic = new Dictionary<string, Action<object>>();
            objMsgDic = new Dictionary<object, Dictionary<string, Action<object>>>();
        }

        //添加事件
        public void AddEvent(string eventName, System.Action<object> callback)
        {
            if (msgDic.ContainsKey(eventName))
            {
                msgDic[eventName] += callback;
            }
            else
            {
                msgDic.Add(eventName, callback);
            }
        }
        
        //移除事件
        public void RemoveEvent(string eventName, System.Action<object> callback)
        {
            if (msgDic.ContainsKey(eventName))
            {
                msgDic[eventName] -= callback;
                if (msgDic[eventName] == null)
                {
                    msgDic.Remove(eventName);
                }
            }
        }

        //执行事件
        public void PostEvent(string eventName, object arg = null)
        {
            if (msgDic.ContainsKey(eventName))
            {
                msgDic[eventName].Invoke(arg);
            }
        }

        //添加对象事件
        public void AddEvent(System.Object listenerObj, string eventName, System.Action<object> callback)
        {
            if (objMsgDic.ContainsKey(listenerObj)) //如果已经存在这个对象的事件字典
            {
                if (objMsgDic[listenerObj].ContainsKey(eventName))
                {
                    objMsgDic[listenerObj][eventName] += callback;
                }
                else
                {
                    objMsgDic[listenerObj].Add(eventName, callback);
                }
            }
            else
            {
                Dictionary<string, System.Action<object>> _tempDic = new Dictionary<string, Action<object>>();
                _tempDic.Add(eventName, callback);
                objMsgDic.Add(listenerObj, _tempDic);
            }
        }

        //移除对象事件
        public void RemoveEvent(System.Object listenerObj, string eventName, System.Action<object> callback)
        {
            if (objMsgDic.ContainsKey(listenerObj))
            {
                if (objMsgDic[listenerObj].ContainsKey(eventName))
                {
                    objMsgDic[listenerObj][eventName] -= callback;//移除/注销 对象事件的回调方法
                    if (objMsgDic[listenerObj][eventName] == null)
                    {
                        objMsgDic[listenerObj].Remove(eventName);//移除对象中事件
                        if (objMsgDic[listenerObj].Count == 0)
                        {
                            objMsgDic.Remove(listenerObj);//移除对象
                        }
                    }
                }
            }
        }

        //移除对象的所有事件
        public void RemoveObjAllEvent(System.Object listenerObj)
        {
            if (objMsgDic.ContainsKey(listenerObj))
            {
                objMsgDic.Remove(listenerObj);
            }
        }
        
        //执行对象的事件
        public void PostEvent(System.Object listenerObj, string eventName, object arg = null)
        {
            if (objMsgDic.ContainsKey(listenerObj))
            {
                if (objMsgDic[listenerObj].ContainsKey(eventName))
                {
                    objMsgDic[listenerObj][eventName].Invoke(arg);
                }
            }
        }

        //添加临时事件
        public void AddTempEvent(string eventName, System.Action<object> callback)
        {
            if (tempMsgDic.ContainsKey(eventName))
            {
                tempMsgDic[eventName] = callback;//添加的临时事件 是要覆盖的而不是累加
            }
            else
            {
                tempMsgDic.Add(eventName, callback);
            }
        }
        
        //执行临时事件
        public void PostTempEvent(string eventName, System.Object arg = null)
        {
            if (tempMsgDic.ContainsKey(eventName))
            {
                tempMsgDic[eventName].Invoke(arg);
                tempMsgDic[eventName] = null;
                tempMsgDic.Remove(eventName);
            }
        }
    }
}