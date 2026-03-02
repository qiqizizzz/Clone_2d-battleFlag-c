/*
* ┌──────────────────────────────────┐
* │  描    述: 工具类                      
* │  类    名: Tools.cs       
* │  创    建: By qiqizizzz
* └──────────────────────────────────┘
*/

using UnityEngine;
using UnityEngine.UI;

namespace Common
{
    public static class Tools
    {
        public static void SetIcon(this Image img, string res)
        {
            //this表示调用这个方法的对象,即可以不传入img参数
            img.sprite = Resources.Load<Sprite>($"Icon/{res}");
        }
    }
}