/*
* ┌────────────────────────────────────────────┐
* │  描    述: 统一定义游戏中的管理器，在此类进行初始化
* │  类    名: GameApp.cs       
* │  创    建: By qiqizizzz
* └────────────────────────────────────────────┘
*/

using Common;
using MVC;
using Sound;

public class GameApp : Singleton<GameApp>
{
    public static SoundManager SoundManager;//音频管理器
    public static ControllerManager ControllerManager;//控制器管理器
    
    public override void Init()
    {
        SoundManager = new SoundManager();
        ControllerManager = new ControllerManager();
    }
}