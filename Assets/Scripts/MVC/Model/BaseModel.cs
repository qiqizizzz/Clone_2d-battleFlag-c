/*
* ┌──────────────────────────────────┐
* │  描    述: 模型基类                      
* │  类    名: BaseModel.cs       
* │  创    建: By qiqizizzz
* └──────────────────────────────────┘
*/

using MVC.Controller;

namespace MVC.Model
{
    public class BaseModel
    {
        public BaseController controller;

        public BaseModel(BaseController ctl)
        {
            this.controller = ctl;
        }

        public virtual void Init()
        {
            
        }
    }
}