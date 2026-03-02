/*
* ┌──────────────────────────────────┐
* │  描    述: 地图的单元格子                      
* │  类    名: Block.cs       
* │  创    建: By qiqizizzz
* └──────────────────────────────────┘
*/

using System;
using Common;
using UnityEngine;

namespace Module.Fight.FightMgr
{
    public enum BlockType
    {
        Null,//空
        Obstacle,//障碍物
    }
    
    public class Block : MonoBehaviour
    {
        public int RowIndex;//行下标
        public int ColIndex;//列下标
        public BlockType Type;//格子类型

        [Header("素材")]
        private SpriteRenderer selectSp;//选中的格子图片
        private SpriteRenderer gridSp;//网格图片
        private SpriteRenderer dirSp;//移动方向图片
        
        private void Awake()
        {
            selectSp = transform.Find("select").GetComponent<SpriteRenderer>();
            gridSp = transform.Find("grid").GetComponent<SpriteRenderer>();
            dirSp = transform.Find("dir").GetComponent<SpriteRenderer>();

            GameApp.MsgCenter.AddEvent(gameObject, Defines.OnSelectEvent, OnSelectCallback);
        }

        protected void OnDestroy()
        {
            GameApp.MsgCenter.RemoveEvent(gameObject, Defines.OnSelectEvent, OnSelectCallback);
        }

        private void OnSelectCallback(System.Object arg)
        {
            GameApp.MsgCenter.PostEvent(Defines.OnUnSelectEvent);
        }
        
        private void OnMouseEnter()
        {
            selectSp.enabled = true;
        }

        private void OnMouseExit()
        {
            selectSp.enabled = false;
        }
    }
}