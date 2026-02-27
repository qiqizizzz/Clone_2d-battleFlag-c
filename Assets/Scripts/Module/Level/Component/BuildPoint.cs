/*
* ┌──────────────────────────────────┐
* │  描    述: 关卡检查点                      
* │  类    名: BuildPoint.cs       
* │  创    建: By qiqizizzz
* └──────────────────────────────────┘
*/

using System;
using Common;
using UnityEngine;

namespace Module.Level.Component
{
    public class BuildPoint : MonoBehaviour
    {
        public int LevelId;//关卡ID

        public void OnTriggerEnter2D(Collider2D other)
        {
            GameApp.MsgCenter.PostEvent(Defines.ShowLevelDesEvent, LevelId);
        }
        
        private void OnTriggerExit2D(Collider2D other)
        {
            GameApp.MsgCenter.PostEvent(Defines.HideLevelDesEvent);
        }
    }
}