/*
* ┌──────────────────────────────────┐
* │  描    述:                       
* │  类    名: GameTimerData.cs       
* │  创    建: By qiqizizzz
* └──────────────────────────────────┘
*/

namespace Timer
{
    public class GameTimerData
    {
        private float timer;//计时时长
        private System.Action callback;

        public GameTimerData(float timer, System.Action callback)
        {
            this.timer = timer;
            this.callback = callback;
        }

        //更新计时器
        public bool OnUpdate(float dt)
        {
            timer -= dt;
            if (timer <= 0)
            {
                this.callback.Invoke();
                return true;
            }
            return false;
        }
    }
}