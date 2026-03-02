/*
* ┌──────────────────────────────────────────────────────────────┐
* │  描    述: 战斗管理器(用于管理战斗相关的实体 -> 敌人 英雄 地图 格子等)                      
* │  类    名: FightWorldManager.cs       
* │  创    建: By qiqizizzz
* └──────────────────────────────────────────────────────────────┘
*/

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

        public FightUnitBase Current
        {
            get { return current; }
        }

        public FightWorldManager()
        {
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
    }
}