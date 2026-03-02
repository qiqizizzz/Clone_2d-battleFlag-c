/*
* ┌──────────────────────────────────────────┐
* │  描    述: 游戏数据管理器(存储玩家的基本游戏信息）                      
* │  类    名: GameDataManager.cs       
* │  创    建: By qiqizizzz
* └──────────────────────────────────────────┘
*/


using System.Collections.Generic;

public class GameDataManager
{
    public List<int> heros;//英雄集合
    
    public int Money;//金币
    
    public GameDataManager()
    {
        heros = new List<int>();
        
        //默认拥有三个英雄的id
        heros.Add(10001);
        heros.Add(10002);
        heros.Add(10003);
        
        
    }
}
