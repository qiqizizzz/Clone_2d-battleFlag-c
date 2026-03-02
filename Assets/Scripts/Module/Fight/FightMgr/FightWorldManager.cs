/*
* ┌──────────────────────────────────────────────────────────────┐
* │  描    述: 战斗管理器(用于管理战斗相关的实体 -> 敌人 英雄 地图 格子等)                      
* │  类    名: FightWorldManager.cs       
* │  创    建: By qiqizizzz
* └──────────────────────────────────────────────────────────────┘
*/

using System.Collections.Generic;
using UnityEngine;

namespace Module.Fight.FightMgr
{
    //战斗中的状态枚举
    public enum GameState
    {
        Idle,
        Enter
    }
    
    public class FightWorldManager
    {
        public GameState state = GameState.Idle;

        private FightUnitBase current;//当前所处的战斗单元

        public List<Hero> heros;//战斗中的英雄集合

        public FightUnitBase Current
        {
            get { return current; }
        }

        public FightWorldManager()
        {
            heros = new List<Hero>();
            ChangeState(GameState.Idle);
        }
        
        public void Update(float dt)
        {
            if (current != null && current.Update(dt))
            {
                //TODO
            }
            else
            {
                current = null;
            }
        }

        //切换战斗状态
        public void ChangeState(GameState state)
        {
            FightUnitBase _current = current;
            this.state = state;

            switch (this.state)
            {
                case GameState.Idle:
                    _current = new FightIdle();
                    break;
                case GameState.Enter:
                    _current = new FightEnter();
                    break;
                
            }
            _current.Init();
        }
        
        //添加英雄
        public void AddHero(Block b, Dictionary<string, string> data)
        {
            GameObject obj =Object.Instantiate(Resources.Load($"Model/{data["Model"]}")) as GameObject;
            obj.transform.position = new Vector3(b.transform.position.x, b.transform.position.y, -1);
            Hero hero = obj.AddComponent<Hero>();
            hero.Init(data, b.RowIndex, b.ColIndex);
            //这个位置被占领了,设置方块的类型为障碍物 -> 因为英雄占领了这个位置
            b.Type = BlockType.Obstacle;
            heros.Add(hero);
        }
    }
}