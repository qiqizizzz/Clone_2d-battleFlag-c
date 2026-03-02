/*
* ┌──────────────────────────────────┐
* │  描    述: 选择英雄面板                      
* │  类    名: FightSelectHeroView.cs       
* │  创    建: By qiqizizzz
* └──────────────────────────────────┘
*/

using System.Collections.Generic;
using Config;
using Module.Fight.Components;
using MVC.View;
using UnityEngine;

namespace Module.Fight
{
    public class FightSelectHeroView : BaseView
    {
        public override void Open(params object[] args)
        {
            base.Open(args);

            GameObject prefabObj = Find("bottom/grid/item");
            Transform gridTf = Find("bottom/grid").transform;
            
            //获取数据并实例化拥有的英雄
            for (int i = 0; i < GameApp.GameDataManager.heros.Count; i++)
            {
                Dictionary<string, string> data = GameApp.ConfigManager.GetConfigData("player").GetDataById(GameApp.GameDataManager.heros[i]);
                GameObject obj = Object.Instantiate(prefabObj, gridTf);
                obj.SetActive(true);
                
                HeroItem item = obj.AddComponent<HeroItem>();
                item.Init(data);//初始化数据
                //注意：初始化数据会在Start前调用，所以在Start中可以直接使用数据
            }
        }
    }
}