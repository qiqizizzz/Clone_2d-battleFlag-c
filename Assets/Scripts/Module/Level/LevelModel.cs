/*
* ┌──────────────────────────────────┐
* │  描    述: 关卡数据                      
* │  类    名: LevelModel.cs       
* │  创    建: By qiqizizzz
* └──────────────────────────────────┘
*/

using System.Collections.Generic;
using Config;
using MVC.Model;

namespace Module.Level
{
    public class LevelData
    {
        public int Id;
        public string Name;
        public string SceneName;
        public string Des;
        public bool IsFinish;//是否通关

        public LevelData(Dictionary<string, string> data)
        {
            Id = int.Parse(data["Id"]);
            Name = data["Name"];
            SceneName = data["SceneName"];
            Des = data["Des"];
            IsFinish = false;
        }
    }
    
    public class LevelModel : BaseModel
    {
        private ConfigData levelConfig;
        private Dictionary<int, LevelData> levels;//关卡字典
        public LevelData current;//当前关卡

        public LevelModel()
        {
            levels = new Dictionary<int, LevelData>();
        }

        public override void Init()
        {
            levelConfig = GameApp.ConfigManager.GetConfigData("level");
            foreach (var item in levelConfig.GetLines())
            {
                LevelData l_data = new LevelData(item.Value);
                levels.Add(l_data.Id, l_data);
            }
        }

        public LevelData GetLevel(int id) => levels[id];
    }
}