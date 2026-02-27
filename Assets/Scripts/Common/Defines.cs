/*
* ┌──────────────────────────────────┐
* │  描    述: 常量类                      
* │  类    名: Defines.cs       
* │  创    建: By qiqizizzz
* └──────────────────────────────────┘
*/

namespace Common
{
    public class Defines
    {
        //控制器相关的事件字符串
        public static readonly string OpenStartView = "OpenStartView";//打开开始面板
        public static readonly string OpenSetView = "OpenSetView";//打开设置面板
        public static readonly string OpenMessageView = "OpenMessageView";//打开提示面板
        public static readonly string LoadingScene = "LoadingScene";//加载场景
        public static readonly string OpenSelectLevelView = "OpenSelectLevelView";//打开选择关卡界面
        
        //全局事件相关
        public static readonly string ShowLevelDesEvent = "ShowLevelDesEvent";//显示关卡详情事件
        public static readonly string HideLevelDesEvent = "HideLevelDesEvent";//隐藏关卡详情事件
    }
}