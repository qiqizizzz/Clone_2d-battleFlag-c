/*
* ┌──────────────────────────────────┐
* │  描    述:                       
* │  类    名: LoadingModel.cs       
* │  创    建: By qiqizizzz
* └──────────────────────────────────┘
*/

using MVC.Model;

namespace Module.Loading
{
    public class LoadingModel : BaseModel
    {
        public string SceneName;//加载场景名称
        public System.Action callback;//加载完成回调
        
        public LoadingModel()
        {
            
        }
    }
}