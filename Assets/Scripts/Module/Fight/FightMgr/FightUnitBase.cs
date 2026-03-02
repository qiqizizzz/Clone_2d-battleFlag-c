/*
* ┌──────────────────────────────────┐
* │  描    述: 战斗单元                      
* │  类    名: FightUnitBase.cs       
* │  创    建: By qiqizizzz
* └──────────────────────────────────┘
*/

namespace Module.Fight.FightMgr
{
    public class FightUnitBase
    {
        public virtual void Init()
        {
            
        }

        public virtual bool Update(float dt)
        {
            return false;
        }
    }
}