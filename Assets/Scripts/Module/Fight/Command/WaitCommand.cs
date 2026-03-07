/*
* ┌──────────────────────────────────┐
* │  描    述: 等待指令                      
* │  类    名: WaitCommand.cs       
* │  创    建: By qiqizizzz
* └──────────────────────────────────┘
*/

using Module.Fight.FightMgr;

namespace Module.Fight.Command
{
    public class WaitCommand : BaseCommand
    {
        private float time;
        private System.Action callback;

        public WaitCommand(float time, System.Action callback = null)
        {
            this.time = time;
            this.callback = callback;
        }

        public override bool Update(float dt)
        {
            this.time -= dt;
            if (this.time <= 0)
            {
                callback?.Invoke();
                return true;
            }

            return false;
        }
    }
}