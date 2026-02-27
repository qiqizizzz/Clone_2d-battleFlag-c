/*
* ┌──────────────────────────────────┐
* │  描    述:                       
* │  类    名: GameTimer.cs       
* │  创    建: By qiqizizzz
* └──────────────────────────────────┘
*/

using System.Collections.Generic;

namespace Timer
{
    public class GameTimer
    {
        private List<GameTimerData> timers;

        public GameTimer()
        {
            timers = new List<GameTimerData>();
        }
        
        public void Register(float timer, System.Action callback)
        {
            timers.Add(new GameTimerData(timer, callback));
        }

        public void OnUpdate(float dt)
        {
            for (int i = timers.Count - 1; i >= 0; i--)
            {
                if (timers[i].OnUpdate(dt))
                {
                    timers.RemoveAt(i);
                }
            }
        }

        /// <summary>
        /// 打断计时器
        /// </summary>
        public void Break() => timers.Clear();

        public int Count() => timers.Count;
    }
}