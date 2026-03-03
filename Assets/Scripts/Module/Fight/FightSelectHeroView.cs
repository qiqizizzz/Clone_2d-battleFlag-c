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
using Module.Fight.FightMgr;
using MVC.View;
using UnityEngine;
using UnityEngine.UI;

namespace Module.Fight
{
    public class FightSelectHeroView : BaseView
    {
        protected override void OnAwake()
        {
            base.OnAwake();
            Find<Button>("bottom/startBtn").onClick.AddListener(onFightBtn);
        }

        //选完英雄开始进入到玩家回合
        private void onFightBtn()
        {
            //如果一个英雄都没选,提示玩家选择(此处省略提示界面)
            if (GameApp.FightManager.heroes.Count == 0)
            {
                Debug.Log("没有选择英雄");
            }
            else
            {
                GameApp.ViewManager.Close(ViewId);//关闭选英雄界面
                
                //切换到玩家回合
                GameApp.FightManager.ChangeState(GameState.PlayerRound);
            }
        }

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