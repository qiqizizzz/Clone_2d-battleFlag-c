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
        Enter,
        PlayerRound,
        EnemyRound
    }
    
    public class FightWorldManager
    {
        public GameState state = GameState.Idle;

        private FightUnitBase current;//当前所处的战斗单元

        public List<Hero> heroes;//战斗中的英雄集合

        public List<Enemy> enemies;//战斗中的敌人集合
        
        public int RoundCount;//当前回合数

        public FightUnitBase Current
        {
            get { return current; }
        }

        public FightWorldManager()
        {
            heroes = new List<Hero>();
            enemies = new List<Enemy>();
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
                case GameState.PlayerRound:
                    _current = new FightPlayerUnit();
                    break;
                case GameState.EnemyRound:
                    _current = new FightEnemyUnit();
                    break;
            }
            _current.Init();
        }

        //进入战斗 初始化一些信息(敌人信息 回合数等)
        public void EnterFight()
        {
            RoundCount = 1;
            heroes = new List<Hero>();
            enemies = new List<Enemy>();
            //将场景中的敌人进行存储
            GameObject[] objs = GameObject.FindGameObjectsWithTag("Enemy");
            Debug.Log("Enemy: " + objs.Length);
            for (int i = 0; i < objs.Length; i++)
            {
                Enemy enemy = objs[i].GetComponent<Enemy>();
                //当前位置被敌人占用了,设置方块的类型为障碍物
                GameApp.MapManager.ChangeBlockType(enemy.RowIndex, enemy.ColIndex, BlockType.Obstacle);
                enemies.Add(enemy);
            }
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
            heroes.Add(hero);
        }
        
        //移除敌人
        public void RemoveEnemy(Enemy enemy)
        {
            enemies.Remove(enemy);
        }

        //重置英雄行动
        public void ResetHeroes()
        {
            for (int i = 0; i < heroes.Count; i++)
            {
                heroes[i].IsStop = false;
            }
        }

        //重置敌人行动
        public void ResetEnemies()
        {
            for (int i = 0; i < enemies.Count; i++)
            {
                enemies[i].IsStop = false;
            }
        }

        /// <summary>
        /// 获得离目标最近的英雄
        /// </summary>
        /// <param name="model">目标</param>
        /// <returns></returns>
        public ModelBase GetMinDisHero(ModelBase model)
        {
            if (heroes.Count == 0) return null;

            Hero hero = heroes[0];
            float min_dis = hero.GetDis(model);
            for (int i = 1; i < heroes.Count; i++)
            {
                float dis = hero.GetDis(heroes[i]);
                if (dis < min_dis)
                {
                    min_dis = dis;
                    hero = heroes[i];
                }
            }

            return hero;
        }
    }
}