/*
* ┌──────────────────────────────────┐
* │  描    述: 全局时间计时器管理器                      
* │  类    名: TimerManager.cs       
* │  创    建: By qiqizizzz
* └──────────────────────────────────┘
*/

namespace Timer
{
    public class TimerManager
    {
        private GameTimer timer;
        
        public TimerManager()
        {
            timer = new GameTimer();
        }

        public void Register(float time, System.Action callback)
        {
            timer.Register(time ,callback);
        }

        public void OnUpdate(float dt)
        {
            timer.OnUpdate(dt);
        }
    }
}