/*
* ┌──────────────────────────────────┐
* │  描    述: 单例基类
* │  类    名: Singleton.cs       
* │  创    建: By qiqizizzz
* └──────────────────────────────────┘
*/

using System;

namespace Common
{
    public class Singleton<T>
    {
        //在运行时才去查找并创建实例
        private static readonly T instance = Activator.CreateInstance<T>();

        public static T Instance
        {
            get
            {
                return instance;
            }
        }

        //初始化
        public virtual void Init()
        {
            
        }

        //每帧执行
        public virtual void Update(float dt)
        {
            
        }
        
        //释放
        public virtual void OnDestroy()
        {
            
        }
    }
}