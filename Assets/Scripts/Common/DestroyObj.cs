/*
* ┌──────────────────────────────────┐
* │  描    述: 自动删除物体                      
* │  类    名: DestroyObj.cs       
* │  创    建: By qiqizizzz
* └──────────────────────────────────┘
*/

using System;
using UnityEngine;

namespace Common
{
    public class DestroyObj : MonoBehaviour
    {
        public float timer;

        private void Start()
        {
            Destroy(gameObject, timer);
        }
    }
}