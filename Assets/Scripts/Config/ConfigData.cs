/*
* ┌─────────────────────────────────────────┐
* │  描    述: 读取csv格式数据表(逗号隔开的数据格式)                      
* │  类    名: ConfigData.cs       
* │  创    建: By qiqizizzz
* └─────────────────────────────────────────┘
*/

using System.Collections.Generic;
using UnityEngine;

namespace Config
{
    public class ConfigData
    {
        private Dictionary<int, Dictionary<string, string>> datas;//每个数据表存储的数据到字典中 key是字典的id 值是每一行数据
        public string fileName;//配置表文件名称

        public ConfigData(string fileName)
        {
            this.fileName = fileName;
            this.datas = new Dictionary<int, Dictionary<string, string>>();
        }

        public TextAsset LoadFile()
        {
            return Resources.Load<TextAsset>($"Data/{fileName}");
        }

        public void Load(string txt)
        {
            string[] dataArr = txt.Split("\n");
            string[] titleArr = dataArr[0].Trim().Split(',');//标题行

            //从第三行开始读取内容(下标是2)
            for (int i = 2; i < dataArr.Length; i++)
            {
                string[] tempArr = dataArr[i].Trim().Split(',');
                Dictionary<string, string> tempData = new Dictionary<string, string>();
                
                //循环每一列
                for (int j = 0; j < tempArr.Length; j++)
                {
                    tempData.Add(titleArr[j], tempArr[j]);
                }
                datas.Add(int.Parse(tempData["Id"]),tempData);
            }
        }

        public Dictionary<string, string> GetDataById(int id)
        {
            if (datas.ContainsKey(id))
                return datas[id];

            return null;
        }

        public Dictionary<int, Dictionary<string, string>> GetLines()
        {
            return datas;
        }
    }
}