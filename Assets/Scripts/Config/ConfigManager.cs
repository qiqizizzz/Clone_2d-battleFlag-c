/*
* ┌──────────────────────────────────┐
* │  描    述: 管理游戏中所有的配置表                      
* │  类    名: ConfigManager.cs       
* │  创    建: By qiqizizzz
* └──────────────────────────────────┘
*/

using System.Collections.Generic;
using UnityEngine;

namespace Config
{
    public class ConfigManager
    {
        private Dictionary<string, ConfigData> loadList;//需要读取的配置表 - 未读取

        private Dictionary<string, ConfigData> configs;//已经加载完成的配置表 - 已读取

        public ConfigManager()
        {
            loadList = new Dictionary<string, ConfigData>();
            configs = new Dictionary<string, ConfigData>();
        }

        //注册需要加载的配置表
        public void Register(string file, ConfigData config)
        {
            loadList[file] = config;
        }
        
        //加载所有的配置表
        public void LoadAllConfigs()
        {
            foreach (var item in loadList)
            {
                TextAsset textAsset = item.Value.LoadFile();
                item.Value.Load(textAsset.text);
                configs.Add(item.Value.fileName, item.Value);
            }
            loadList.Clear();
        }

        public ConfigData GetConfigData(string file)
        {
            if(configs.ContainsKey(file))
                return configs[file];

            return null;
        }
        
    }
}