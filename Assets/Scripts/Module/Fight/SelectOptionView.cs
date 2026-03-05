/*
* ┌──────────────────────────────────┐
* │  描    述: 选择选项界面                      
* │  类    名: SelectOptionView.cs       
* │  创    建: By qiqizizzz
* └──────────────────────────────────┘
*/

using System.Collections.Generic;
using Module.Fight.Components;
using MVC.View;
using UnityEngine;

namespace Module.Fight
{
    public class SelectOptionView : BaseView
    {
        private Dictionary<int, OptionItem> opItems;//存储选项
        
        public override void InitData()
        {
            base.InitData();
            opItems = new Dictionary<int, OptionItem>();
            FightModel fightModel = Controller.GetModel() as FightModel;

            List<OptionData> ops = fightModel.options;

            Transform tf = Find("bg/grid").transform;
            GameObject prefabObj = Find("bg/grid/item");

            //根据配置表中的选项数据 创建对应的选项物体
            for (int i = 0; i < ops.Count; i++)
            {
                GameObject obj = Object.Instantiate(prefabObj, tf);
                obj.SetActive(false);
                OptionItem item = obj.AddComponent<OptionItem>();
                item.Init(ops[i]);
                opItems.Add(ops[i].Id, item);
            }
        }

        public override void Open(params object[] args)
        {
            //传入两个参数 一个是英雄的Event字符串 对应的选项id 需要切割
            //第二个参数 是角色的位置
            //Event 1001-1002-1005
            string[] evtArr = args[0].ToString().Split('-');
            Find("bg/grid").transform.position = (Vector2)args[1];
            foreach (var item in opItems)
            {
                item.Value.gameObject.SetActive(false);
            }

            for (int i = 0; i < evtArr.Length; i++)
            {
                opItems[int.Parse(evtArr[i])].gameObject.SetActive(true);
            }
        }
    }
}