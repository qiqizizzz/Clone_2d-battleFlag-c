/*
* ┌───────────────────────────────────────┐
* │  描    述: 用户控制管理器 键盘操作 鼠标操作等                      
* │  类    名: UserInputManager.cs       
* │  创    建: By qiqizizzz
* └───────────────────────────────────────┘
*/


using Common;
using UnityEngine;
using UnityEngine.EventSystems;

public class UserInputManager
{
    public void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (EventSystem.current.IsPointerOverGameObject())
            {
                //点击在UI上
            }
            else
            {
                Tools.ScreenPointToRay2D(Camera.main, Input.mousePosition, delegate(Collider2D col)
                {
                    if (col != null)
                    {
                        //检测到有碰撞体的物体
                        GameApp.MsgCenter.PostEvent(col.gameObject,Defines.OnSelectEvent);
                    }
                    else
                    {
                        //执行未选中
                        GameApp.MsgCenter.PostEvent(Defines.OnUnSelectEvent);
                    }
                });
            }
        }
    }
}
