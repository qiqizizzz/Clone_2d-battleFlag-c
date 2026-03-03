/*
* ┌──────────────────────────────────────┐
* │  描    述: 命令基类(可派生 移动 使用技能等                      
* │  类    名: BaseCommand.cs       
* │  创    建: By qiqizizzz
* └──────────────────────────────────────┘
*/

using Module.Fight.FightMgr;

namespace Module.Fight.Command
{
    public class BaseCommand
    {
        public ModelBase model;//命令对象
        protected bool isFinish;//是否做完标记

        public BaseCommand(ModelBase model)
        {
            this.model = model;
            this.isFinish = false;
        }

        public virtual bool Update(float dt) => isFinish;
        
        //执行命令
        public virtual void Do()
        {
            
        }

        //撤销命令
        public virtual void Undo()
        {
            
        }
    }
}