/*
* ┌──────────────────────────────────┐
* │  描    述: 选项                      
* │  类    名: OptionItem.cs       
* │  创    建: By qiqizizzz
* └──────────────────────────────────┘
*/

using System;
using MVC;
using UnityEngine;
using UnityEngine.UI;

namespace Module.Fight.Components
{
    public class OptionItem : MonoBehaviour
    {
        private OptionData op_data;

        public void Init(OptionData data)
        {
            this.op_data = data;
        }
        
        private void Start()
        {
            GetComponent<Button>().onClick.AddListener(delegate()
            {
                GameApp.MsgCenter.PostTempEvent(op_data.EventName);//执行配置表中设置的Event事件
                GameApp.ViewManager.Close((int)ViewType.SelectOptionView);//关闭选项界面
            });
            transform.Find("txt").GetComponent<Text>().text = op_data.Name;
        }
    }
}